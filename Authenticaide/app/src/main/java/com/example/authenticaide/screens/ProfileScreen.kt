package com.example.authenticaide.screens

import androidx.compose.foundation.BorderStroke
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.aspectRatio
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.DisposableEffect
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.getValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavHostController
import androidx.navigation.compose.currentBackStackEntryAsState
import coil.compose.rememberAsyncImagePainter
import coil.request.ImageRequest
import com.example.authenticaide.R
import com.example.authenticaide.components.BackAndEditTopBar
import com.example.authenticaide.components.ButtonComponent
import com.example.authenticaide.components.NormalTextComponent
import com.example.authenticaide.components.ProfileTextComponent
import com.example.authenticaide.ui.theme.colorBlack
import com.example.authenticaide.ui.theme.colorPrimary
import com.example.authenticaide.viewmodel.UserAccountViewModel
import com.google.firebase.auth.FirebaseAuth

@Composable
fun ProfileScreen(navController: NavHostController) {
    val viewModel: UserAccountViewModel = viewModel()

    // Retrieve user details from the view model
    val userDetails by viewModel.userDetails
    val userProfileChanged by viewModel.userProfileChanged
    val currentBackStackEntry by navController.currentBackStackEntryAsState()

    // Function to handle log-out
    val onLogOutClicked: () -> Unit = {
        viewModel.logOut()
        navController.navigate(route = "LoginScreen")
    }

    // Function to handle account deletion
    val onDeleteAccountClicked: () -> Unit = {
        val currentUser = FirebaseAuth.getInstance().currentUser
        currentUser?.let {
            val userId = it.uid
            viewModel.deleteUserAccountByUid(navController, userId)
        }
    }

    LaunchedEffect(userProfileChanged) {
        if (userProfileChanged) {
            // Refresh the user details
            viewModel.fetchUserDetails()
            // Reset userProfileChanged to false after refreshing
            viewModel.userProfileChanged.value = false
        }
    }

    DisposableEffect(currentBackStackEntry) {
        onDispose {
            // Refresh user details when this screen is back in scope
            viewModel.fetchUserDetails()
        }
    }

    Scaffold(
        topBar = { BackAndEditTopBar(value = "My profile", navController = navController) }
    ) { padding ->
        Column(
            modifier = Modifier
                .padding(padding)
                .fillMaxSize()
                .verticalScroll(rememberScrollState())
                .padding(28.dp),
            horizontalAlignment = Alignment.CenterHorizontally
        ) {
            userDetails?.let { currentUser ->
                val username = currentUser.username
                val first = currentUser.firstName
                val last = currentUser.lastName
                val email = currentUser.email
                val photo = currentUser.photo

                val painter = // Placeholder image while loading
                    rememberAsyncImagePainter(ImageRequest.Builder // Image to show in case of an error
                        (LocalContext.current).data(
                        data = photo // Pass the photo URL here
                    ).apply(block = fun ImageRequest.Builder.() {
                        placeholder(R.drawable.ic_profile) // Placeholder image while loading
                        error(R.drawable.ic_profile) // Image to show in case of an error
                    }).build()
                    )
                Image(
                    painter = painter,
                    contentDescription = "Profile picture",
                    modifier = Modifier
                        .size(150.dp)
                        .aspectRatio(1f)
                        .border(BorderStroke(1.dp, colorPrimary))
                        .align(Alignment.CenterHorizontally)
                )
                Spacer(modifier = Modifier.height(10.dp))
                Column(
                    modifier = Modifier
                        .fillMaxHeight()
                        .weight(1f),
                ) {
                    NormalTextComponent(value = username)
                    // Display two achievements with percentage bars
                    AchievementComponent(value = "Achievement 1", progress = 0.8f)
                    AchievementComponent(value = "Achievement 2", progress = 0.6f)

                    Spacer(modifier = Modifier.height(30.dp))
                    ProfileTextComponent(value = "First Name: $first")
                    ProfileTextComponent(value = "Last Name: $last")
                    ProfileTextComponent(value = "Email: $email")
                    Spacer(modifier = Modifier.height(10.dp))
                    ButtonComponent(value = "Log Out", onButtonClicked = onLogOutClicked)
                    Spacer(modifier = Modifier.height(10.dp))
                    ButtonComponent(value = "Delete Account", onButtonClicked = onDeleteAccountClicked)
                }
            } ?: run {
                NormalTextComponent(value = "User not logged in")
            }
        }
    }
}


@Composable
fun AchievementComponent(value: String, progress: Float) {
    // Check if the progress is valid
    if (progress < 0f || progress > 1f) {
        throw IllegalArgumentException("Progress must be between 0 and 1")
    }
    // Define some constants for the UI
    val barHeight = 8.dp
    val barColor = Color(0xFF4CAF50)
    val barBackgroundColor = Color(0xFFBDBDBD)
    val textColor = colorBlack
    val textSize = 16.sp
    val textPadding = 4.dp
    // Create a row to display the achievement name and the progress bar
    Row(
        modifier = Modifier
            .fillMaxWidth()
            .padding(textPadding),
        verticalAlignment = Alignment.CenterVertically
    ) {
        // Display the achievement name on the left
        Text(
            text = value,
            color = textColor,
            fontSize = textSize,
            modifier = Modifier.weight(1f)
        )
        // Display the progress bar on the right
        Box(
            modifier = Modifier
                .height(barHeight)
                .width(100.dp)
                .background(barBackgroundColor)
        ) {
            // Fill the progress bar with the bar color according to the progress
            Box(
                modifier = Modifier
                    .height(barHeight)
                    .width((progress * 100).dp)
                    .background(barColor)
            )
        }
    }
}

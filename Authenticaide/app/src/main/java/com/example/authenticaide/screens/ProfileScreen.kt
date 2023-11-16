package com.example.authenticaide.screens

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Surface
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavHostController
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.R
import com.example.authenticaide.components.NormalTextComponent
import com.example.authenticaide.viewmodel.HomeViewModel
import com.google.firebase.auth.FirebaseAuth

@Composable
fun ProfileScreen(navController: NavHostController) {
    val homeNavController = rememberNavController()
    val viewModel: HomeViewModel = viewModel()

    val auth = FirebaseAuth.getInstance()
    val currentUser = auth.currentUser

    Surface(
        modifier = Modifier
            .fillMaxSize()
            .background(Color.White)
            .padding(28.dp)
    ) {
        Column(modifier = Modifier.fillMaxSize()) {
            NormalTextComponent(value = stringResource(id = R.string.profile))

            // Display user details if the user is logged in
            if (currentUser != null) {
                val displayName = currentUser.displayName ?: "No display name available"
                val names = displayName.split(" ")
                val username = if (names.isNotEmpty()) names[0] else "No username"
                NormalTextComponent(value = "Username: $username")

                // Extract first and last names from the display name if available

                val firstName = if (names.size >= 2) names[1] else "No first name"
                val middleName  = if (names.size >= 3) names[2] else "No middle name"
                val lastName  = if (names.size >= 4) names[3] else "No last name"

                val halfName = if (middleName != "No middle name" && lastName != "No last name") {
                    "$middleName $lastName"
                } else if (middleName != "No middle name") {
                    middleName
                } else if (lastName != "No last name") {
                    lastName
                } else {
                    "No middle name and last name"
                }
                // Display first and last names
                NormalTextComponent(value = "First Name: $firstName")
                NormalTextComponent(value = "Last Name: $halfName")
            } else {
                NormalTextComponent(value = "User not logged in")
            }

            // Other components for the profile screen...
        }
    }
}
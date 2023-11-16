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
fun EditProfileScreen(navController: NavHostController){
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

            // Display the username if the user is logged in
            if (currentUser != null) {
                val username = currentUser.displayName ?: "No username available"
                NormalTextComponent(value = "Username: $username")
            } else {
                NormalTextComponent(value = "User not logged in")
            }

            // Other components for the profile screen...
        }
    }
}
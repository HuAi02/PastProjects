

package com.example.authenticaide

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.runtime.Composable
import androidx.compose.ui.tooling.preview.Preview
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.navigation.ProvideBackPressedDispatcherOwner
import com.example.authenticaide.screens.HomeScreen
import com.example.authenticaide.screens.LoginScreen
import com.example.authenticaide.screens.SignUpScreen
import com.example.authenticaide.screens.TermsAndConditionsScreen
import com.google.firebase.FirebaseApp


class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        val backDispatcherOwner = this
        FirebaseApp.initializeApp(this)
        setContent {
            ProvideBackPressedDispatcherOwner(backDispatcherOwner) {
                Authenticaide()
            }
        }
    }
}

@Composable
fun Authenticaide() {
    val navController = rememberNavController()

    NavHost(
        navController = navController,
        startDestination = "LoginScreen"
    ) {
        composable("SignUpScreen") {
            SignUpScreen(navController)
        }
        composable("TermsAndConditionsScreen") {
            TermsAndConditionsScreen(navController)
        }
        composable("LoginScreen") {
            LoginScreen(navController)
        }
        composable("HomeScreen") {
            // Passing the primary NavController to the HomeScreen
            HomeScreen(navController = navController)
        }
    }
}

@Preview(showBackground = true)
@Composable
fun ScaffoldPreview() {
//    CenterAlignedTopAppBar()
}



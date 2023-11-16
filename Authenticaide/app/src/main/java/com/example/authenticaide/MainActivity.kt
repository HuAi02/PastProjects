

package com.example.authenticaide

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.LocalOnBackPressedDispatcherOwner
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Scaffold
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.components.CenterAlignedTopAppBar
import com.example.authenticaide.components.NavigationBar
import com.example.authenticaide.navigation.ProvideBackPressedDispatcherOwner
import com.example.authenticaide.screens.ComposeScreen
import com.example.authenticaide.screens.EditProfileScreen
import com.example.authenticaide.screens.HomeScreen
import com.example.authenticaide.screens.LoginScreen
import com.example.authenticaide.screens.MessageScreen
import com.example.authenticaide.screens.NotificationScreen
import com.example.authenticaide.screens.ProfileScreen
import com.example.authenticaide.screens.SearchScreen
import com.example.authenticaide.screens.SignUpScreen
import com.example.authenticaide.screens.TermsAndConditionsScreen
import com.google.firebase.FirebaseApp


class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        FirebaseApp.initializeApp(this)
        setContent {
            ProvideNavHost {
                MainScreen()
            }
        }
    }
}

@Composable
fun ProvideNavHost(content: @Composable () -> Unit) {
    val navController = rememberNavController()
    LocalOnBackPressedDispatcherOwner.current?.let {
        ProvideBackPressedDispatcherOwner(it) {
        Authenticaide(navController)
    }
    }
}

@Composable
fun Authenticaide(navController: NavHostController) {
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
            MainScreen()
        }
    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MainScreen() {
    val navController = rememberNavController()

    Scaffold(
        topBar = { CenterAlignedTopAppBar(value = "Authenticaide", navController = navController) },
        content = { padding ->
            Column (
                modifier = Modifier
                    .padding(padding)
                    .fillMaxSize()
            ){
                NavHost(navController = navController, startDestination = "HomeScreen") {
                    composable("HomeScreen") {
                        HomeScreen(navController)
                    }
                    composable("SearchScreen") {
                        SearchScreen(navController)
                    }
                    composable("ComposeScreen") {
                        ComposeScreen(navController)
                    }
                    composable("NotificationScreen") {
                        NotificationScreen(navController)
                    }
                    composable("MessageScreen") {
                        MessageScreen(navController)
                    }
                    composable("ProfileScreen") {
                        ProfileScreen(navController)
                    }
                    composable("EditProfileScreen") {
                        EditProfileScreen(navController)
                    }
                }
            }
        },
        bottomBar = {
            NavigationBar(navController = navController)
        }
    )
}

@Preview(showBackground = true)
@Composable
fun ScaffoldPreview() {
//    CenterAlignedTopAppBar()
}



package com.example.authenticaide

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Surface
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import androidx.lifecycle.ViewModelProvider
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.components.NavigationBar
import com.example.authenticaide.screens.ComposeScreen
import com.example.authenticaide.screens.EditProfileScreen
import com.example.authenticaide.screens.HomeScreen
import com.example.authenticaide.screens.LoginScreen
import com.example.authenticaide.screens.MessageScreen
import com.example.authenticaide.screens.NotificationScreen
import com.example.authenticaide.screens.ProfileScreen
import com.example.authenticaide.screens.SignUpScreen
import com.example.authenticaide.screens.TermsAndConditionsScreen
import com.example.authenticaide.screens.ThreadScreen
import com.example.authenticaide.viewmodel.NavigationViewModel
import com.example.authenticaide.viewmodel.ThreadsViewModel
import com.google.firebase.FirebaseApp
import com.google.firebase.auth.FirebaseAuth


class MainActivity : ComponentActivity() {
    private lateinit var auth: FirebaseAuth
    private lateinit var navigationViewModel: NavigationViewModel

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        FirebaseApp.initializeApp(this)
        auth = FirebaseAuth.getInstance()
        navigationViewModel = ViewModelProvider(this)[NavigationViewModel::class.java]


        setContent {
            ProvideNavHost(navigationViewModel = navigationViewModel)
        }
        auth.addAuthStateListener { firebaseAuth ->
            val user = firebaseAuth.currentUser
            navigationViewModel.updateLoggedInState(user != null)
        }
    }
}

@Composable
fun ProvideNavHost(navigationViewModel: NavigationViewModel) {
    val navController = rememberNavController()
    val loggedInState by navigationViewModel.loggedInState.observeAsState(initial = false)
    val destination = if (loggedInState) navigationViewModel.getDestinationRoute("HomeScreen") else navigationViewModel.getDestinationRoute("LoginScreen")
    val threadsViewModel: ThreadsViewModel = viewModel()

    Scaffold(
        content = { padding ->
            Surface(
                modifier = Modifier
                    .padding(padding)
                    .fillMaxSize()
            ) {
                NavHost(navController = navController, startDestination = destination ?: "LoginScreen") {
                    navigationViewModel.navigationRoutes.forEach { (routeKey, _) ->
                        composable(routeKey) {
                            when (routeKey) {
                                "SignUpScreen" -> SignUpScreen(navController)
                                "LoginScreen" -> LoginScreen(navController)
                                "TermsAndConditionsScreen" -> TermsAndConditionsScreen(navController)
                                "HomeScreen" -> HomeScreen(navController, threadsViewModel)
                                "ComposeScreen" -> ComposeScreen(navController)
                                "NotificationScreen" -> NotificationScreen(navController)
                                "MessageScreen" -> MessageScreen(navController)
                                "ProfileScreen" -> ProfileScreen(navController)
                                "EditProfileScreen" -> EditProfileScreen(navController)
                                else -> {
                                    LoginScreen(navController)
                                }
                            }
                        }
                        composable("ThreadsScreen/{threadId}") { backStackEntry ->
                            val threadId = backStackEntry.arguments?.getString("threadId") ?: ""

                            // Pass the fetched thread and replies to ThreadsScreen composable
                            ThreadScreen(navController = navController, threadId = threadId)
                        }
                    }
                }
            }
        },
        bottomBar = {
            if (loggedInState) {
                NavigationBar(navController = navController)
            }
        }
    )
}


@Preview(showBackground = true)
@Composable
fun ScaffoldPreview() {
//    CenterAlignedTopAppBar()
}



package com.example.authenticaide.screens

import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.runtime.Composable
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavHostController
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.components.RedditLikeUI
import com.example.authenticaide.viewmodel.HomeViewModel

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun HomeScreen(navController: NavHostController){
    val homeNavController = rememberNavController()
    val viewModel: HomeViewModel = viewModel()

    RedditLikeUI(navController = navController)
}


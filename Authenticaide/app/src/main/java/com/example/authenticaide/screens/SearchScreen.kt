package com.example.authenticaide.screens

import androidx.compose.runtime.Composable
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavHostController
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.components.RedditLikeUI
import com.example.authenticaide.viewmodel.HomeViewModel

@Composable
fun SearchScreen(navController: NavHostController){
    val homeNavController = rememberNavController()
    val viewModel: HomeViewModel = viewModel()

    RedditLikeUI(navController = navController)
}


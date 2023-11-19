package com.example.authenticaide.screens

import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material3.Scaffold
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.navigation.NavHostController
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.components.ProfileTopBar
import com.example.authenticaide.components.SearchBar
import com.example.authenticaide.components.ThreadItem
import com.example.authenticaide.viewmodel.ThreadsViewModel
import com.google.accompanist.swiperefresh.SwipeRefresh
import com.google.accompanist.swiperefresh.rememberSwipeRefreshState
import kotlinx.coroutines.delay
import kotlinx.coroutines.launch

@Composable
fun HomeScreen(navController: NavHostController, viewModel: ThreadsViewModel) {
    rememberNavController()
    var isRefreshing by remember { mutableStateOf(false) }
    val keyword = remember { mutableStateOf("") }
    val coroutineScope = rememberCoroutineScope()
    val filteredThreads = viewModel.searchThreads(keyword.value)
    val threadChanged by viewModel.threadChanged
    var replyAdded by viewModel.replyAdded

    LaunchedEffect(isRefreshing) {
        if (isRefreshing) {
            delay(3000)
            isRefreshing = false
        }
    }

    LaunchedEffect(threadChanged || replyAdded) {
        isRefreshing = true
        coroutineScope.launch {
            viewModel.refreshThreads()
            isRefreshing = false
        }
    }

    SwipeRefresh(
        state = rememberSwipeRefreshState(isRefreshing),
        onRefresh = {
            // Refresh logic when the user pulls to refresh
            isRefreshing = true
            coroutineScope.launch {
                viewModel.refreshThreads()
                isRefreshing = false
            }
        }
    ) {
        Scaffold(
            topBar = { ProfileTopBar(value = "Authenticaide", navController = navController) },
            content = { padding ->
                Column(
                    modifier = Modifier
                        .padding(padding)
                ) {
                    // Display the SearchBar
                    SearchBar { searchedKeyword ->
                        keyword.value = searchedKeyword
                    }
                    LazyColumn {
                        items(filteredThreads) { thread ->
                            ThreadItem(thread = thread, threadsViewModel = viewModel, navController = navController)
                        }
                    }
                }
            }
        )
    }
}

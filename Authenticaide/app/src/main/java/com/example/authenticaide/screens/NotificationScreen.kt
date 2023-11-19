package com.example.authenticaide.screens

import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material3.Scaffold
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.remember
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.navigation.NavHostController
import com.example.authenticaide.components.NotificationItem
import com.example.authenticaide.components.ProfileTopBar
import com.example.authenticaide.models.ThreadsModel
import com.example.authenticaide.viewmodel.ThreadsViewModel

@Composable
fun NotificationScreen(navController: NavHostController, viewModel: ThreadsViewModel = ThreadsViewModel()) {
    // Mutable list to hold notification items
    val notificationItems = remember { mutableStateListOf<ThreadsModel>() }

    LaunchedEffect(viewModel.threadChanged) {
        // Refresh notifications whenever threadChanged state changes
        viewModel.refreshThreads()
    }

    LaunchedEffect(viewModel.relatedRepliesIds) {
        // Get threads based on relatedRepliesIds changes
        notificationItems.clear()
        viewModel.relatedRepliesIds.forEach { relatedReplyId ->
            val thread = viewModel.getThreadById(relatedReplyId)
            thread?.let { notificationItems.add(it) }
        }
    }

    Scaffold(
        topBar = { ProfileTopBar(value = "Notification", navController = navController) },
        content = { padding ->
            Column(
                modifier = Modifier
                    .padding(padding)
                    .fillMaxSize()
                    .verticalScroll(rememberScrollState())
                    .padding(28.dp),
                horizontalAlignment = Alignment.CenterHorizontally
            ) {
                notificationItems.forEach { thread ->
                    NotificationItem(thread = thread)
                    Spacer(modifier = Modifier.height(16.dp))
                }
            }
        }
    )
}
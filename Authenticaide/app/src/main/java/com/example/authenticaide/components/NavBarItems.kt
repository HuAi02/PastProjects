package com.example.authenticaide.components

import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Add
import androidx.compose.material.icons.filled.Email
import androidx.compose.material.icons.filled.Home
import androidx.compose.material.icons.filled.Notifications

object NavBarItems {
    val BarItems = listOf(
        BarItem(
            title = "Home",
            image = Icons.Filled.Home,
            route = "HomeScreen"
        ),
        BarItem(
            title = "Compose",
            image = Icons.Filled.Add,
            route = "ComposeScreen"
        ),
        BarItem(
            title = "Notification",
            image = Icons.Filled.Notifications,
            route = "NotificationScreen"
        ),
        BarItem(
            title = "Message",
            image = Icons.Filled.Email,
            route = "MessageScreen"
        )
    )
}
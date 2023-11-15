package com.example.authenticaide.components

import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Add
import androidx.compose.material.icons.filled.Email
import androidx.compose.material.icons.filled.Home
import androidx.compose.material.icons.filled.Notifications
import androidx.compose.material.icons.filled.Search

object NavBarItems {
    val BarItems = listOf(
        BarItem(
            title = "Home",
            image = Icons.Filled.Home,
            route = "home"
        ),
        BarItem(
            title = "Search",
            image = Icons.Filled.Search,
            route = "search"
        ),
        BarItem(
            title = "Compose",
            image = Icons.Filled.Add,
            route = "compose"
        ),
        BarItem(
            title = "Notification",
            image = Icons.Filled.Notifications,
            route = "notification"
        ),
        BarItem(
            title = "Message",
            image = Icons.Filled.Email,
            route = "message"
        )
    )
}
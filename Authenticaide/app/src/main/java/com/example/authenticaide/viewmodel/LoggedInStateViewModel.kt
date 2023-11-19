package com.example.authenticaide.viewmodel

import androidx.compose.runtime.State
import androidx.compose.runtime.mutableStateOf
import androidx.lifecycle.ViewModel

class LoggedInStateViewModel : ViewModel() {
    private val _loggedInState = mutableStateOf(false)
    val loggedInState: State<Boolean> = _loggedInState

    // Function to update the logged-in state
    fun updateLoggedInState(loggedIn: Boolean) {
        _loggedInState.value = loggedIn
    }
}
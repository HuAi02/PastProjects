package com.example.authenticaide.viewmodel

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel

class NavigationViewModel : ViewModel() {
    private val _loggedInState = MutableLiveData<Boolean>()
    val loggedInState: LiveData<Boolean> = _loggedInState

    private val _navigationRoutes = mutableMapOf<String, String>()
    val navigationRoutes: Map<String, String>
        get() = _navigationRoutes

    init {
        _navigationRoutes["HomeScreen"] = "HomeScreen"
        _navigationRoutes["LoginScreen"] = "LoginScreen"
        _navigationRoutes["SignUpScreen"] = "SignUpScreen"
        _navigationRoutes["TermsAndConditionsScreen"] = "TermsAndConditionsScreen"
        _navigationRoutes["ComposeScreen"] = "ComposeScreen"
        _navigationRoutes["NotificationScreen"] = "NotificationScreen"
        _navigationRoutes["MessageScreen"] = "MessageScreen"
        _navigationRoutes["ProfileScreen"] = "ProfileScreen"
        _navigationRoutes["EditProfileScreen"] = "EditProfileScreen"
        _navigationRoutes["ThreadsScreen"] = "ThreadsScreen"
    }

    fun updateLoggedInState(loggedIn: Boolean) {
        _loggedInState.value = loggedIn
    }

    fun getDestinationRoute(destinationKey: String): String? {
        return _navigationRoutes[destinationKey]
    }
}
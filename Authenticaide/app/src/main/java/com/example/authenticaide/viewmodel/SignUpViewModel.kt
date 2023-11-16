package com.example.authenticaide.viewmodel

import androidx.compose.runtime.mutableStateOf
import androidx.lifecycle.ViewModel

class SignUpViewModel : ViewModel() {
    val firstName = mutableStateOf("")
    val lastName = mutableStateOf("")
    val username = mutableStateOf("")
    val email = mutableStateOf("")
    val password = mutableStateOf("")
    val termsAndConditionsChecked = mutableStateOf(false)
}
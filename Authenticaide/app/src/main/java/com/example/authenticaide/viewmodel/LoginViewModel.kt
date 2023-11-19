package com.example.authenticaide.viewmodel

import androidx.compose.runtime.mutableStateOf
import androidx.lifecycle.ViewModel

class LoginViewModel : ViewModel() {
    val email = mutableStateOf("aholykek@gmail.com")
    val password = mutableStateOf("LLaren.88")
}
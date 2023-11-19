package com.example.authenticaide.screens

import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material3.Surface
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavController
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.R
import com.example.authenticaide.components.ButtonComponent
import com.example.authenticaide.components.ClickableLoginComponent
import com.example.authenticaide.components.HeadingTextComponent
import com.example.authenticaide.components.MyTextFieldComponent
import com.example.authenticaide.components.NormalTextComponent
import com.example.authenticaide.components.PasswordTextField
import com.example.authenticaide.components.UnderLinedTextComponent
import com.example.authenticaide.viewmodel.UserAccountViewModel

@Composable
fun LoginScreen(navController: NavController){
    val viewModel: UserAccountViewModel = viewModel()
    val context = LocalContext.current

    val email by viewModel.loginEmail
    val password by viewModel.loginPassword

//     Function to handle login button click
    val onLoginClicked: () -> Unit = {
        viewModel.loginUser(email, password, navController)
    }

    Surface(
        modifier = Modifier
            .fillMaxSize()
            .background(Color.White)
            .padding(28.dp)
    ) {
        Column(
            modifier = Modifier
                .fillMaxSize()
                .verticalScroll(rememberScrollState())
        ) {
            NormalTextComponent(value = stringResource(id = R.string.hello))
            HeadingTextComponent(value = stringResource(id = R.string.welcome))
            Spacer(modifier = Modifier.height(20.dp))
            Image(
                painter = painterResource(id = R.drawable.ic_launcher), // Replace with your launcher icon resource ID
                contentDescription = "App Launcher Icon",
                modifier = Modifier
                    .size(100.dp)
                    .align(Alignment.CenterHorizontally)
            )
            MyTextFieldComponent(labelValue = stringResource(id = R.string.email), value = email) { newValue ->
                viewModel.loginEmail.value = newValue
            }
            PasswordTextField(labelValue = stringResource(id = R.string.password)) { newPassword ->
                viewModel.loginPassword.value = newPassword
            }
            Spacer(modifier = Modifier.height(20.dp))
            UnderLinedTextComponent(value = stringResource(id = R.string.forgot_password))
            Spacer(modifier = Modifier.height(100.dp))
            ButtonComponent(value = stringResource(id = R.string.login)) {
                onLoginClicked.invoke()
            }
            Spacer(modifier = Modifier.height(10.dp))
            ClickableLoginComponent(tryingToLogin = true) { buttonText ->
                if (buttonText == "Login") {
                    navController.navigate("LoginScreen") {
                        popUpTo("SignUpScreen") {
                            inclusive = true
                        }
                    }
                } else {
                    navController.navigate("SignUpScreen") {
                        popUpTo("LoginScreen") {
                            inclusive = true
                        }
                    }
                }
            }
        }
    }
}

@Preview
@Composable
fun LoginScreenPreview(){
    val navController = rememberNavController()
    LoginScreen(navController)
}
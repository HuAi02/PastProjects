package com.example.authenticaide.screens

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Surface
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.saveable.rememberSaveable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
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
import com.example.authenticaide.viewmodel.LoginViewModel

@Composable
fun LoginScreen(navController: NavController){
    val viewModel: LoginViewModel = viewModel()

    val email by rememberSaveable { viewModel.email }
    val password by rememberSaveable { viewModel.password }

    // Function to handle login button click
//    val onLoginClicked: () -> Unit = {
//        FirebaseAuth.getInstance().signInWithEmailAndPassword(email, password)
//            .addOnCompleteListener { task ->
//                if (task.isSuccessful) {
//                    // Authentication successful, navigate to the next screen
//                    navController.navigate("HomeScreen")
//                } else {
//                    // Authentication failed, show error message or handle accordingly
//                    // For example:
//                    // Toast.makeText(this, "Authentication failed", Toast.LENGTH_SHORT).show()
//                }
//            }
//    }
    val onLoginClicked: () -> Unit = {navController.navigate("HomeScreen")}
    Surface(
        modifier = Modifier
            .fillMaxSize()
            .background(Color.White)
            .padding(28.dp)
    ) {
        Column() {
            NormalTextComponent(value = stringResource(id = R.string.hello))
            HeadingTextComponent(value = stringResource(id = R.string.welcome))
            Spacer(modifier = Modifier.height(80.dp))
            MyTextFieldComponent(labelValue = stringResource(id = R.string.email), value = email) { newValue ->
                viewModel.email.value = newValue
            }
            PasswordTextField(labelValue = stringResource(id = R.string.password))
            Spacer(modifier = Modifier.height(20.dp))
            UnderLinedTextComponent(value = stringResource(id = R.string.forgot_password))
            Spacer(modifier = Modifier.height(80.dp))
            ButtonComponent(value = stringResource(id = R.string.login)) {
                onLoginClicked.invoke()
            }
            Spacer(modifier = Modifier.height(20.dp))
            ClickableLoginComponent(tryingToLogin = true) { buttonText ->
                if (buttonText == "Login") {
                    navController.navigate("LoginScreen")
                } else {
                    navController.navigate("SignUpScreen")
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
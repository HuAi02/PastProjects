package com.example.authenticaide.screens

import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
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
import androidx.navigation.NavHostController
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.R
import com.example.authenticaide.components.ButtonComponent
import com.example.authenticaide.components.CheckboxComponent
import com.example.authenticaide.components.ClickableLoginComponent
import com.example.authenticaide.components.HeadingTextComponent
import com.example.authenticaide.components.MyTextFieldComponent
import com.example.authenticaide.components.NormalTextComponent
import com.example.authenticaide.components.PasswordTextField
import com.example.authenticaide.viewmodel.UserAccountViewModel


@Composable
fun SignUpScreen(navController: NavHostController) {
    val viewModel: UserAccountViewModel = viewModel()
    val context = LocalContext.current

    val firstName by viewModel.signUpFirstName
    val lastName by viewModel.signUpLastName
    val username by viewModel.signUpUsername
    val email by viewModel.signUpEmail
    val password by viewModel.signUpPassword
    val termsAndConditionsChecked by viewModel.signUpTermsAndConditionsChecked

    val onRegisterClicked: () -> Unit = {
        viewModel.registerUser(email, password, username, firstName, lastName, navController)
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
            HeadingTextComponent(value = stringResource(id = R.string.create_account))
            Spacer(modifier = Modifier.height(20.dp))
            Image(
                painter = painterResource(id = R.drawable.ic_launcher), // Replace with your launcher icon resource ID
                contentDescription = "App Launcher Icon",
                modifier = Modifier
                    .size(100.dp)
                    .align(Alignment.CenterHorizontally)
            )
            Row(
                modifier = Modifier.fillMaxWidth(),
                horizontalArrangement = Arrangement.SpaceBetween
            ) {
                Box(
                    modifier = Modifier.weight(1f),
                    contentAlignment = Alignment.CenterStart
                ) {
                    MyTextFieldComponent(
                        labelValue = stringResource(id = R.string.first_name), value = firstName) { newValue ->
                        viewModel.signUpFirstName.value = newValue
                    }
                }

                Spacer(modifier = Modifier.width(8.dp)) // Adjust the spacing as needed

                Box(
                    modifier = Modifier.weight(1f),
                    contentAlignment = Alignment.CenterStart
                ) {
                    MyTextFieldComponent(labelValue = stringResource(id = R.string.last_name), value = lastName ) { newValue ->
                        viewModel.signUpLastName.value = newValue
                    }
                }
            }
            MyTextFieldComponent(labelValue = stringResource(id = R.string.username), value = username) { newValue ->
                viewModel.signUpUsername.value = newValue
            }
            MyTextFieldComponent(labelValue = stringResource(id = R.string.email), value = email) { newValue ->
                viewModel.signUpEmail.value = newValue
            }
            PasswordTextField(labelValue = stringResource(id = R.string.password)) { newPassword ->
                viewModel.signUpPassword.value = newPassword
            }
            CheckboxComponent(
                isChecked = termsAndConditionsChecked,
                onCheckedChange = { newValue ->
                    viewModel.signUpTermsAndConditionsChecked.value = newValue
                },
                navController = navController
            )
            Spacer(modifier = Modifier.height(40.dp))
            ButtonComponent(value = stringResource(id = R.string.register)) {
                onRegisterClicked.invoke()
            }
            Spacer(modifier = Modifier.height(10.dp))
            ClickableLoginComponent(tryingToLogin = false) { buttonText ->
                if (buttonText == "Register") {
                    navController.navigate("SignUpScreen") {
                        popUpTo("LoginScreen") {
                            inclusive = true
                        }
                    }
                } else {
                    navController.navigate("LoginScreen") {
                        popUpTo("SignUpScreen") {
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
fun DefaultSignUpScreenPreview() {
    val navController = rememberNavController()
    SignUpScreen(navController)
}
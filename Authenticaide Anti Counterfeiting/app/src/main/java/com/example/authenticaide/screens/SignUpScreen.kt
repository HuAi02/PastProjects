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
import com.example.authenticaide.viewmodel.SignUpViewModel


@Composable
fun SignUpScreen(navController: NavHostController) {
    val viewModel: SignUpViewModel = viewModel()

    val username by rememberSaveable { viewModel.lastName }
    val email by rememberSaveable { viewModel.email }
    val password by rememberSaveable { viewModel.password }
    val termsAndConditionsChecked by rememberSaveable { viewModel.termsAndConditionsChecked }

//    val onRegisterClicked: () -> Unit = {
//        FirebaseAuth.getInstance().createUserWithEmailAndPassword(email, password)
//            .addOnCompleteListener { task ->
//                if (task.isSuccessful) {
//                    // Registration successful, navigate to the next screen or perform actions accordingly
//                    navController.navigate("HomeScreen")
//                } else {
//                    // Registration failed, show error message or handle accordingly
//                    // For example:
//                    // Toast.makeText(this, "Registration failed", Toast.LENGTH_SHORT).show()
//                }
//            }
//    }
    val onRegisterClicked: () -> Unit = {navController.navigate("HomeScreen")}
    Surface(
        modifier = Modifier
            .fillMaxSize()
            .background(Color.White)
            .padding(28.dp)
    ) {
        Column(modifier = Modifier.fillMaxSize()) {
            NormalTextComponent(value = stringResource(id = R.string.hello))
            HeadingTextComponent(value = stringResource(id = R.string.create_account))
            Spacer(modifier = Modifier.height(80.dp))
            MyTextFieldComponent(labelValue = stringResource(id = R.string.username), value = username) { newValue ->
                viewModel.firstName.value = newValue
            }
            MyTextFieldComponent(labelValue = stringResource(id = R.string.email), value = email) { newValue ->
                viewModel.email.value = newValue
            }
            PasswordTextField(labelValue = stringResource(id = R.string.password))
            CheckboxComponent(
                value = stringResource(id = R.string.terms_and_conditions),
                isChecked = termsAndConditionsChecked,
                onCheckedChange = { newValue ->
                    viewModel.termsAndConditionsChecked.value = newValue
                },
                navController = navController
            )
            Spacer(modifier = Modifier.height(80.dp))
            ButtonComponent(value = stringResource(id = R.string.register)) {
                onRegisterClicked.invoke()
            }
            Spacer(modifier = Modifier.height(20.dp))
            ClickableLoginComponent(tryingToLogin = false) { buttonText ->
                if (buttonText == "Register") {
                    navController.navigate("SignUpScreen")
                } else {
                    navController.navigate("LoginScreen")
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
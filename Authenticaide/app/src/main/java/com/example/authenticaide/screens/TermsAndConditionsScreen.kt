package com.example.authenticaide.screens

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import androidx.navigation.compose.rememberNavController
import com.example.authenticaide.R
import com.example.authenticaide.components.HeadingTextComponent

@Composable
fun TermsAndConditionsScreen(navController: NavController) {
    Surface(
        modifier = Modifier
            .fillMaxSize()
            .background(color = Color.White)
            .padding(16.dp)
    ) {
        Box(
            modifier = Modifier.verticalScroll(rememberScrollState())
        ) {
            Column(
                modifier = Modifier
                    .fillMaxSize()
                    .padding(16.dp),
                verticalArrangement = Arrangement.Top,
                horizontalAlignment = Alignment.CenterHorizontally
            ) {
                HeadingTextComponent(value = stringResource(id = R.string.terms_and_conditions_header))
                Text(
                    text = stringResource(id = R.string.termsOfUse),
                    modifier = Modifier.padding(vertical = 8.dp)
                )
                // Add more Text composable components for additional terms and conditions
            }
        }
    }
}



@Preview
@Composable
fun TermsAndConditionsScreenPreview(){
    val navController = rememberNavController()
    TermsAndConditionsScreen(navController)
}

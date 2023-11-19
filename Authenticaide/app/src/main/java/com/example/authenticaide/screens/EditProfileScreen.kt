package com.example.authenticaide.screens

import android.net.Uri
import androidx.activity.compose.rememberLauncherForActivityResult
import androidx.activity.result.contract.ActivityResultContracts
import androidx.compose.foundation.BorderStroke
import androidx.compose.foundation.Image
import androidx.compose.foundation.border
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.aspectRatio
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material3.Scaffold
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavHostController
import coil.compose.rememberAsyncImagePainter
import coil.request.ImageRequest
import com.example.authenticaide.R
import com.example.authenticaide.components.BackAndConfirmTopBar
import com.example.authenticaide.components.ButtonComponent
import com.example.authenticaide.components.MyTextFieldComponent
import com.example.authenticaide.ui.theme.colorPrimary
import com.example.authenticaide.viewmodel.UserAccountViewModel
import com.google.firebase.Firebase
import com.google.firebase.storage.storage
import java.util.UUID

@Composable
fun EditProfileScreen(navController: NavHostController) {
    val viewModel: UserAccountViewModel = viewModel()

    // State variables for profile details
    val firstName by viewModel.editProfileFirstName
    val lastName by viewModel.editProfileLastName
    val username by viewModel.editProfileUsername
    val password by viewModel.editProfilePassword

    // Access Firebase storage instance
    val storage = Firebase.storage
    val storageRef = storage.reference

    // Create a variable to hold the chosen image Uri
    var chosenImageUri by remember { mutableStateOf<Uri?>(null) }

    // Create an ActivityResultLauncher to handle image selection
    val getContent = rememberLauncherForActivityResult(contract = ActivityResultContracts.GetContent()) { uri: Uri? ->
        // Upload the image to Firebase Storage
        uri?.let { imageUri ->
            val imagesRef = storageRef.child("images/${UUID.randomUUID()}")
            val uploadTask = imagesRef.putFile(imageUri)

            uploadTask.addOnCompleteListener { task ->
                if (task.isSuccessful) {
                    // Get the download URL from Firebase Storage and set it as chosenImageUri
                    imagesRef.downloadUrl.addOnSuccessListener { downloadUri ->
                        chosenImageUri = downloadUri
                    }.addOnFailureListener {
                        // Handle failure to get download URL
                    }
                } else {
                    // Handle unsuccessful image upload
                }
            }
        }
    }

    Scaffold(
        topBar = { BackAndConfirmTopBar(value = "Edit profile", navController = navController) },
        content = { padding ->
            Column(
                modifier = Modifier
                    .padding(padding)
                    .fillMaxSize()
                    .verticalScroll(rememberScrollState())
                    .padding(28.dp),
                horizontalAlignment = Alignment.CenterHorizontally
            ) {
                // Display the profile photo
                Image(
                    painter = rememberAsyncImagePainter(
                        ImageRequest.Builder(LocalContext.current)
                            .data(data = chosenImageUri)
                            .apply {
                                placeholder(R.drawable.upload)
                                error(R.drawable.upload)
                            }
                            .build()
                    ),
                    contentDescription = "Profile photo",
                    modifier = Modifier
                        .size(150.dp)
                        .aspectRatio(1f)
                        .border(BorderStroke(1.dp, colorPrimary))
                        .clickable {
                            // Trigger image selection when clicked
                            getContent.launch("image/*") // Specify MIME type or use "*/*" for any type
                        }
                )
                Spacer(modifier = Modifier.height(30.dp))
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
                            viewModel.editProfileFirstName.value = newValue
                        }
                    }

                    Spacer(modifier = Modifier.width(8.dp)) // Adjust the spacing as needed

                    Box(
                        modifier = Modifier.weight(1f),
                        contentAlignment = Alignment.CenterStart
                    ) {
                        MyTextFieldComponent(labelValue = stringResource(id = R.string.last_name), value = lastName ) { newValue ->
                            viewModel.editProfileLastName.value = newValue
                        }
                    }
                }
                MyTextFieldComponent(
                    labelValue = stringResource(id = R.string.username),
                    value = username
                ) { newValue ->
                    viewModel.editProfileUsername.value = newValue
                }
                MyTextFieldComponent(
                    labelValue = stringResource(id = R.string.password),
                    value = password,

                ) { newValue ->
                    viewModel.editProfilePassword.value = newValue
                }
                Spacer(modifier = Modifier.height(30.dp))
                ButtonComponent(value = "Save") {
                    val updatedPhotoUrl = chosenImageUri

                    // Call the ViewModel function to update profile details
                    viewModel.updateProfile(
                        updatedPhotoUrl,
                        username,
                        firstName,
                        lastName,
                        password
                    )

                    // Navigate back
                    navController.popBackStack()
                }
            }
        }
    )
}

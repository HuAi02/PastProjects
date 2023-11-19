package com.example.authenticaide.screens

import android.net.Uri
import androidx.activity.compose.rememberLauncherForActivityResult
import androidx.activity.result.contract.ActivityResultContracts
import androidx.compose.foundation.BorderStroke
import androidx.compose.foundation.Image
import androidx.compose.foundation.border
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.aspectRatio
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material3.Scaffold
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.unit.dp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavHostController
import androidx.navigation.compose.rememberNavController
import coil.compose.rememberAsyncImagePainter
import coil.request.ImageRequest
import com.example.authenticaide.R
import com.example.authenticaide.components.ButtonComponent
import com.example.authenticaide.components.MyTextFieldComponent
import com.example.authenticaide.components.ProfileTopBar
import com.example.authenticaide.models.ThreadsModel
import com.example.authenticaide.ui.theme.colorPrimary
import com.example.authenticaide.viewmodel.ThreadsViewModel
import com.example.authenticaide.viewmodel.writeToFirestore
import com.google.firebase.Firebase
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.firestore.FirebaseFirestore
import com.google.firebase.storage.storage
import kotlinx.coroutines.launch
import kotlinx.coroutines.tasks.await
import java.util.UUID

@Composable
fun ComposeScreen(navController: NavHostController, viewModel: ThreadsViewModel = viewModel()){
    rememberNavController()
    val coroutineScope = rememberCoroutineScope()

    val currentUser = FirebaseAuth.getInstance().currentUser
    val currentUserId = currentUser?.uid ?: ""
    val firestore = FirebaseFirestore.getInstance()
    val usersCollection = firestore.collection("Users")
    var username = ""

    // Create a variable to hold the chosen image Uri
    var chosenImageUri by remember { mutableStateOf<Uri?>(null) }

    // Create an ActivityResultLauncher to handle image selection
    val getContent = rememberLauncherForActivityResult(
        contract = ActivityResultContracts.GetContent(),
        onResult = { uri: Uri? ->
            // Handle the selected image URI
            chosenImageUri = uri
        }
    )

    var title by remember { mutableStateOf("") }
    var productName by remember { mutableStateOf("") }
    var productLink by remember { mutableStateOf("") }
    var content by remember { mutableStateOf("") }

    Scaffold(
        topBar = { ProfileTopBar(value = "New thread", navController = navController) },
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
                    painter = rememberAsyncImagePainter(ImageRequest.Builder(LocalContext.current)
                        .data(
                            data = chosenImageUri ?: currentUser?.photoUrl ?: "" // Use chosen image URI if available
                        ).apply(block = fun ImageRequest.Builder.() {
                            placeholder(R.drawable.upload)
                            error(R.drawable.upload)
                        }).build()
                    ),
                    contentDescription = "Profile photo",
                    modifier = Modifier
                        .size(150.dp)
                        .aspectRatio(1f)
                        .border(BorderStroke(1.dp, colorPrimary))
                        .clickable {
                            // Trigger image selection when clicked
                            getContent.launch("image/jpeg") // Specify MIME type or use "*/*" for any type
                        }
                )
                Spacer(modifier = Modifier.height(30.dp))
                MyTextFieldComponent(
                    labelValue = stringResource(id = R.string.title),
                    value = title
                ) { newValue ->
                    title = newValue
                }
                MyTextFieldComponent(
                    labelValue = stringResource(id = R.string.product_name),
                    value = productName
                ) { newValue ->
                    productName = newValue
                }
                MyTextFieldComponent(
                    labelValue = stringResource(id = R.string.product_link),
                    value = productLink
                ) { newValue ->
                    productLink = newValue
                }
                MyTextFieldComponent(
                    labelValue = stringResource(id = R.string.content),
                    value = content
                ) { newValue ->
                    content = newValue
                }
                Spacer(modifier = Modifier.height(30.dp))
                ButtonComponent(value = "Confirm") {
                    // Get the Firebase Storage reference
                    val storageRef = Firebase.storage.reference

                    coroutineScope.launch {
                        val userDoc = usersCollection.document(currentUserId).get().await()
                        username = userDoc.getString("username") ?: ""


                        if (username.isNotEmpty()) {
                            // Generate a unique filename for the image in Firebase Storage
                            val filename = UUID.randomUUID().toString()

                            // Get the reference to the image's location in Firebase Storage
                            val imageRef = storageRef.child("images/$filename")

                            // Check if an image was chosen
                            chosenImageUri?.let { uri ->
                                // Upload the image to Firebase Storage
                                val uploadTask = imageRef.putFile(uri)

                                // Monitor the upload task for success or failure
                                uploadTask.continueWithTask { task ->
                                    if (!task.isSuccessful) {
                                        task.exception?.let { exception ->
                                            // Handle unsuccessful upload
                                            throw exception
                                        }
                                    }
                                    // Continue with the task to get the download URL
                                    imageRef.downloadUrl
                                }.addOnCompleteListener { task ->
                                    if (task.isSuccessful) {
                                        // Image upload succeeded, get the download URL
                                        val downloadUri = task.result

                                        // Create the ThreadsModel with the updated values including the download URL
                                        val thread = ThreadsModel(
                                            title = title,
                                            productName = productName,
                                            productLink = productLink,
                                            content = content,
                                            id = currentUserId,
                                            username = username,
                                            photo = downloadUri.toString() // Set the photo URL
                                        )

                                        // Write the updated thread to Firestore
                                        coroutineScope.launch {
                                            writeToFirestore(thread)
                                            navController.popBackStack()
                                        }
                                    } else {
                                        // Handle unsuccessful task
                                        // Log the error or display a message to the user
                                    }
                                }
                            } ?: run {
                                // If no image was chosen, proceed without uploading a new photo
                                val thread = ThreadsModel(
                                    title = title,
                                    productName = productName,
                                    productLink = productLink,
                                    content = content,
                                    id = currentUserId,
                                    username = username,
                                    photo = "" // Set the current user's photo URL
                                )

                                // Write the thread to Firestore
                                coroutineScope.launch {
                                    writeToFirestore(thread)
                                    navController.popBackStack()
                                }
                            }
                        }
                    }
                }

            }
        }
    )
}
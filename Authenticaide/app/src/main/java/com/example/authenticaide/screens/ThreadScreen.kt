package com.example.authenticaide.screens

import androidx.compose.foundation.Image
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.verticalScroll
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Favorite
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.Divider
import androidx.compose.material3.Icon
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavHostController
import coil.compose.rememberAsyncImagePainter
import com.example.authenticaide.components.BackTopBar
import com.example.authenticaide.components.ClickableProductLink
import com.example.authenticaide.components.openLinkInBrowser
import com.example.authenticaide.models.RepliesModel
import com.example.authenticaide.models.ThreadsModel
import com.example.authenticaide.ui.theme.colorSecondary
import com.example.authenticaide.viewmodel.ThreadsViewModel
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.firestore.FirebaseFirestore
import kotlinx.coroutines.launch
import kotlinx.coroutines.tasks.await

@Composable
fun ThreadScreen(
    navController: NavHostController,
    threadId: String,
    threadsViewModel: ThreadsViewModel = viewModel() // Retrieve ThreadsViewModel using viewModel()
) {
    val scope = rememberCoroutineScope()
    val context = LocalContext.current
    val thread = remember { mutableStateOf<ThreadsModel?>(null) }
    val filteredReplies = remember { mutableStateListOf<RepliesModel>() }
    val threadChanged by threadsViewModel.threadChanged
    val replyAdded by threadsViewModel.replyAdded

    LaunchedEffect(threadId) {
        val fetchedThread = threadsViewModel.getThreadById(threadId)
        val fetchedReplies = fetchedThread?.let { threadsViewModel.getRepliesForThread(it.relatedRepliesIds) }

        if (fetchedThread != null && fetchedReplies != null) {
            thread.value = fetchedThread
            filteredReplies.clear()
            filteredReplies.addAll(fetchedReplies)
        }
    }

    LaunchedEffect(threadChanged || replyAdded) {
        if (threadChanged) {
            val fetchedThread = threadsViewModel.getThreadById(threadId)
            val fetchedReplies = fetchedThread?.let { threadsViewModel.getRepliesForThread(it.relatedRepliesIds) }

            if (fetchedThread != null && fetchedReplies != null) {
                thread.value = fetchedThread
                filteredReplies.clear()
                filteredReplies.addAll(fetchedReplies)
            }
            threadsViewModel.threadChanged.value = false
        } else if (replyAdded){
            val fetchedThread = threadsViewModel.getThreadById(threadId)
            val fetchedReplies = fetchedThread?.let { threadsViewModel.getRepliesForThread(it.relatedRepliesIds) }

            if (fetchedThread != null && fetchedReplies != null) {
                thread.value = fetchedThread
                filteredReplies.clear()
                filteredReplies.addAll(fetchedReplies)
            }
            threadsViewModel.replyAdded.value = false
        }
    }


    Scaffold(
        topBar = {
            thread.value?.let { BackTopBar(value = it.title, navController = navController) }
        }
    ) { padding ->
        Column(
            modifier = Modifier
                .padding(padding)
                .fillMaxSize()
                .verticalScroll(rememberScrollState())
                .padding(18.dp),
            horizontalAlignment = Alignment.CenterHorizontally
        ) {
            thread.value?.let { currentThread ->

                Text(text = "${currentThread.username}:",
                    modifier = Modifier.align(Alignment.Start),
                    fontWeight = FontWeight.Bold,
                    fontSize = 28.sp,
                )
                Image(
                    painter = rememberAsyncImagePainter(model = currentThread.photo),
                    contentDescription = "Thread photo",
                    modifier = Modifier
                        .size(150.dp)
                        .clip(shape = RoundedCornerShape(8.dp))
                )
                Text(text = currentThread.content,
                    modifier = Modifier.align(Alignment.Start),
                    fontSize = 18.sp
                )
                if (currentThread.productLink.isNotEmpty() && currentThread.productName.isNotEmpty()) {
                    Text(
                        text = "Product Name: ${currentThread.productName}",
                        modifier = Modifier.align(Alignment.Start)
                    )
                    ClickableProductLink(
                        productLink = currentThread.productLink,
                        modifier = Modifier.align(Alignment.Start),
                        onProductLinkSelected = { selectedLink ->
                            openLinkInBrowser(context, selectedLink) // Handle the product link selection
                        }
                    )
                }
                Spacer(modifier = Modifier.height(20.dp))
                Row(
                    verticalAlignment = Alignment.CenterVertically,
                    modifier = Modifier
                        .align(Alignment.Start)
                        .clickable {
                            scope.launch {
                                thread.value?.id?.let { threadId ->
                                    threadsViewModel.incrementLikeCount(threadId)
                                }
                            }
                    }
                ) {
                    Icon(
                        imageVector = Icons.Default.Favorite,
                        contentDescription = "Icon",
                        modifier = Modifier.padding(end = 8.dp)
                    )
                    Text(
                        text = "Likes: ${currentThread.likeCounts}",
                        fontWeight = FontWeight.Bold,
                        fontSize = 18.sp,
                    )
                }
            }



            var replyText by remember { mutableStateOf("") }
            OutlinedTextField(
                value = replyText,
                onValueChange = { replyText = it },
                label = { Text("New Reply") },
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(vertical = 16.dp)
            )

            Button(
                onClick = {
                    val currentUser = FirebaseAuth.getInstance().currentUser
                    val currentUserId = currentUser?.uid ?: ""

                    scope.launch {
                        val firestore = FirebaseFirestore.getInstance()
                        val usersCollection = firestore.collection("Users")
                        val userDoc = usersCollection.document(currentUserId).get().await()
                        val username = userDoc.getString("username") ?: ""
                        threadsViewModel.postReplyToThread(threadId, replyText, username, currentUserId)
                        replyText = "" // Clear the reply text field after posting the reply
                    }
                },
                modifier = Modifier.align(Alignment.End),
                colors = ButtonDefaults.buttonColors(colorSecondary)
            ) {
                Text("Post Reply")
            }
            filteredReplies.forEach { reply ->
                Spacer(modifier = Modifier.height(20.dp))

                Text(
                    text = "${reply.username}:",
                    fontWeight = FontWeight.Bold,
                    fontSize = 16.sp,
                    modifier = Modifier.align(Alignment.Start)
                )
                Spacer(modifier = Modifier.height(8.dp))
                Text(
                    text = reply.content,
                    modifier = Modifier.align(Alignment.Start)
                )

                Spacer(modifier = Modifier.height(20.dp))
                Divider(
                    color = colorSecondary,
                    thickness = 1.dp,
                    modifier = Modifier.fillMaxWidth()
                )
            }
        }
    }
}
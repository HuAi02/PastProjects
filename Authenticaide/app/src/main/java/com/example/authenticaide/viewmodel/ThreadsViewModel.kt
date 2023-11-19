package com.example.authenticaide.viewmodel

import android.util.Log
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.mutableStateOf
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.authenticaide.models.RepliesModel
import com.example.authenticaide.models.ThreadsModel
import com.google.firebase.firestore.FirebaseFirestore
import com.google.firebase.firestore.FirebaseFirestoreException
import kotlinx.coroutines.launch
import kotlinx.coroutines.tasks.await

class ThreadsViewModel : ViewModel() {
    private val threadsList = mutableStateListOf<ThreadsModel>()

    private val usernames = mutableStateListOf<String>()
    private val photos = mutableStateListOf<String>()
    private val titles = mutableStateListOf<String>()
    private val ids = mutableStateListOf<String>()
    private val contents = mutableStateListOf<String>()
    private val productNames = mutableStateListOf<String>()
    private val productLinks = mutableStateListOf<String>()
    private val likeCounts = mutableStateListOf<Int>()
    val relatedRepliesIds = mutableStateListOf<String>()

    val threadChanged = mutableStateOf(false)
    val replyAdded = mutableStateOf(false)

    init {
        getData()
    }

    private fun getData() {
        viewModelScope.launch {
            threadsList.addAll(getFromFireStore())
            // For each thread in threadsList, update individual properties
            threadsList.forEach { thread ->
                usernames.add(thread.username)
                photos.add(thread.photo)
                titles.add(thread.title)
                ids.add(thread.id)
                contents.add(thread.content)
                productNames.add(thread.productName)
                productLinks.add(thread.productLink)
                likeCounts.add(thread.likeCounts)
                relatedRepliesIds.add(thread.relatedRepliesIds.toString())
            }
        }
    }

    suspend fun refreshThreads() {
        try {
            val refreshedThreads = getFromFireStore()
            threadsList.clear()
            threadsList.addAll(refreshedThreads)
        } catch (e: Exception) {
            Log.e("ThreadsViewModel", "Error refreshing threads: $e")
        }
    }

    fun searchThreads(keyword: String): List<ThreadsModel> {
        return if (keyword.isEmpty()) {
            // Return the original threadsList if the keyword is empty
            threadsList.toList()
        } else {
            // Filter threadsList based on the keyword
            threadsList.filter { thread ->
                thread.title.contains(keyword, ignoreCase = true) ||
                        thread.content.contains(keyword, ignoreCase = true)
            }
        }
    }

    suspend fun getThreadById(threadId: String): ThreadsModel? {
        return try {
            val threadDocument = FirebaseFirestore.getInstance().collection("Threads").document(threadId).get().await()

            if (threadDocument.exists()) {
                threadDocument.toObject(ThreadsModel::class.java)?.apply {
                    // Set the ID explicitly since it might not be included in the object
                    this.id = threadDocument.id
                }
            } else {
                null
            }
        } catch (e: Exception) {
            null
        }
    }

    private suspend fun getReplyFromFirestore(replyId: String): RepliesModel? {
        val db = FirebaseFirestore.getInstance()

        try {
            // Log the replyId for debugging purposes
            Log.d("Firestore", "Fetching reply with ID: $replyId")

            val replyDocument = db.collection("Replies").document(replyId).get().await()

            if (replyDocument.exists()) {
                return replyDocument.toObject(RepliesModel::class.java)
            } else {
                Log.d("Firestore", "No document found for replyId: $replyId")
            }
        } catch (e: Exception) {
            Log.e("Firestore", "Error getting reply document: $e")
        }

        return null
    }


    // Retrieve replies based on related IDs in the thread
    suspend fun getRepliesForThread(relatedRepliesIds: List<String>): List<RepliesModel> {
        val allReplies = mutableListOf<RepliesModel>()

        // Loop through each related reply ID
        relatedRepliesIds.forEach { replyId ->
            val reply = getReplyFromFirestore(replyId) // Fetch reply from Firestore by ID
            reply?.let { allReplies.add(it) } // Add the fetched reply to the list
        }

        return allReplies
    }

    suspend fun getThreadIdByAttributes(thread: ThreadsModel): String? {
        val db = FirebaseFirestore.getInstance()
        val threadsCollection = db.collection("Threads")
        var documentId: String? = null

        try {
            val querySnapshot = threadsCollection
                .whereEqualTo("title", thread.title)
                .whereEqualTo("content", thread.content)
                .get()
                .await() // Use await() here to suspend and wait for the query result

            for (document in querySnapshot.documents) {
                val matchingThread = document.toObject(ThreadsModel::class.java)
                if (matchingThread == thread) {
                    documentId = document.id
                    break
                }
            }
        } catch (e: Exception) {
            Log.e("ThreadsViewModel", "Error getting document ID: $e")
        }

        return documentId
    }

    suspend fun incrementLikeCount(threadId: String) {
        val db = FirebaseFirestore.getInstance()
        val threadRef = db.collection("Threads").document(threadId)

        try {
            db.runTransaction { transaction ->
                val currentThread = transaction.get(threadRef).toObject(ThreadsModel::class.java)

                currentThread?.let {
                    val updatedLikeCount = it.likeCounts + 1
                    transaction.update(threadRef, "likeCounts", updatedLikeCount)
                }
            }.await()
        } catch (e: Exception) {
            Log.e("ThreadsViewModel", "Error incrementing like count: $e")
        }
        threadChanged.value = true
    }

    suspend fun postReplyToThread(threadId: String, replyText: String, username: String, userId: String) {
        val db = FirebaseFirestore.getInstance()

        try {
            val replyMap = mapOf(
                "content" to replyText,
                "username" to username,
                "id" to userId
            )

            // Add the reply document to the Replies collection
            val replyDocumentRef = db.collection("Replies").add(replyMap).await()

            // Get the Firestore document ID of the newly added reply
            val replyDocumentId = replyDocumentRef.id

            // Update the relatedRepliesId array in the corresponding thread in the Threads collection
            val threadRef = db.collection("Threads").document(threadId)
            db.runTransaction { transaction ->
                val threadSnapshot = transaction.get(threadRef)
                val relatedRepliesIds = threadSnapshot.get("relatedRepliesIds") as? List<String> ?: emptyList()

                // Append the newly added reply's document ID to the relatedRepliesIds array
                val updatedRelatedRepliesIds = relatedRepliesIds.toMutableList().apply {
                    add(replyDocumentId)
                }

                // Update the thread's relatedRepliesIds field
                transaction.update(threadRef, "relatedRepliesIds", updatedRelatedRepliesIds)
            }.await()
        } catch (e: Exception) {
            Log.e("ThreadsViewModel", "Error posting reply: $e")
        }
        replyAdded.value = true
    }
}

suspend fun getFromFireStore(): List<ThreadsModel> {
    val db = FirebaseFirestore.getInstance()
    val threadsList = mutableListOf<ThreadsModel>()

    try {
        val querySnapshot = db.collection("Threads").get().await()
        threadsList.addAll(querySnapshot.documents.mapNotNull { document ->
            val thread = document.toObject(ThreadsModel::class.java)
            thread?.copy(
                likeCounts = document.getLong("likeCounts")?.toInt() ?: 0,
                relatedRepliesIds = document.get("relatedRepliesIds") as? List<String> ?: emptyList()
            )
        })
    } catch (e: FirebaseFirestoreException) {
        Log.d("error", "getFromFireStore: $e")
    }

    return threadsList
}

suspend fun writeToFirestore(thread: ThreadsModel) {
    val db = FirebaseFirestore.getInstance()
    val threadMap = mapOf(
        "id" to thread.id,
        "photo" to thread.photo,
        "productLink" to thread.productLink,
        "productName" to thread.productName,
        "title" to thread.title,
        "username" to thread.username,
        "likeCounts" to thread.likeCounts,
        "relatedRepliesIds" to thread.relatedRepliesIds,
        "content" to thread.content
    )

    try {
        db.collection("Threads").add(threadMap).await()
    } catch (e: FirebaseFirestoreException) {
        Log.d("error", "writeToFirestore: $e")
    }
}


suspend fun updateInFirestore(threadId: String, updatedThread: ThreadsModel) {
    val db = FirebaseFirestore.getInstance()
    try {
        db.collection("Threads").document(threadId).set(updatedThread).await()
    } catch (e: FirebaseFirestoreException) {
        Log.d("error", "updateInFirestore: $e")
    }
}
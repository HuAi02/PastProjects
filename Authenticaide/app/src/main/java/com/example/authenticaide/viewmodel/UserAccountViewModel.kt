package com.example.authenticaide.viewmodel

import android.net.Uri
import android.util.Log
import androidx.compose.runtime.MutableState
import androidx.compose.runtime.mutableStateOf
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import androidx.navigation.NavController
import com.example.authenticaide.models.UserModel
import com.google.firebase.auth.FirebaseAuth
import com.google.firebase.auth.FirebaseUser
import com.google.firebase.auth.UserProfileChangeRequest
import com.google.firebase.firestore.DocumentSnapshot
import com.google.firebase.firestore.FirebaseFirestore
import kotlinx.coroutines.launch
import kotlinx.coroutines.tasks.await

class UserAccountViewModel : ViewModel() {
    private val auth = FirebaseAuth.getInstance()
    private val db = FirebaseFirestore.getInstance()
    private val usersCollection = db.collection("Users")

    // Sign-up related mutable states
    val signUpFirstName = mutableStateOf("")
    val signUpLastName = mutableStateOf("")
    val signUpUsername = mutableStateOf("")
    val signUpEmail = mutableStateOf("")
    val signUpPassword = mutableStateOf("")
    val signUpTermsAndConditionsChecked = mutableStateOf(false)

    // Login related mutable states
    val loginEmail = mutableStateOf("")
    val loginPassword = mutableStateOf("")

    // Edit profile and user details mutable states
    val editProfileFirstName = mutableStateOf("")
    val editProfileLastName = mutableStateOf("")
    val editProfileUsername = mutableStateOf("")
    val editProfilePassword = mutableStateOf("")
    val editProfilePhotoUrl = mutableStateOf("")

    // User profile details mutable state
    val userDetails: MutableState<UserModel?> = mutableStateOf(null)
    val userProfileChanged = mutableStateOf(false)


    // Fetch user details when the ViewModel is created
    init {
        fetchUserDetails()
    }

    fun fetchUserDetails() {
        val currentUser = auth.currentUser
        currentUser?.let { user ->
            val userId = user.uid
            viewModelScope.launch {
                try {
                    val documentSnapshot = getUserDocument(userId)
                    val user1 = getUserFromSnapshot(documentSnapshot)
                    userDetails.value = user1
                } catch (e: Exception) {
                    // Handle any potential exceptions here
                    Log.e("UserAccountViewModel", "Error fetching user details: $e")
                }
            }
        }
    }

    private suspend fun getUserDocument(userId: String): DocumentSnapshot {
        return usersCollection.document(userId).get().await()
    }

    private fun getUserFromSnapshot(documentSnapshot: DocumentSnapshot): UserModel? {
        return if (documentSnapshot.exists()) {
            documentSnapshot.toObject(UserModel::class.java)
        } else {
            null
        }
    }

    private fun updateUserProfileInAuth(username: String) {
        val currentUser = auth.currentUser
        currentUser?.let { user ->
            val profileUpdates = UserProfileChangeRequest.Builder()
                .setDisplayName(username)
                .build()
            user.updateProfile(profileUpdates)
        }
    }

    private fun updateUserProfileInFirestore(user: FirebaseUser?, userProfileUpdates: Map<String, Any>) {
        user?.uid?.let { uid ->
            usersCollection.document(uid).set(userProfileUpdates)
                .addOnSuccessListener {
                    // Profile updated successfully in Firestore
                }
                .addOnFailureListener { e ->
                    Log.e("UserAccountViewModel", "Error updating user profile in Firestore: $e")
                }
        }
    }

    private fun updatePassword(newPassword: String) {
        val currentUser = auth.currentUser
        currentUser?.let { user ->
            user.updatePassword(newPassword)
                .addOnCompleteListener { task ->
                    if (task.isSuccessful) {
                        Log.d("UserAccountViewModel", "Password updated successfully")
                    } else {
                        Log.e("UserAccountViewModel", "Password update failed")
                    }
                }
        }
    }

    fun updateProfile(updatedPhotoUrl: Uri?, username: String, firstName: String, lastName: String, password: String) {
        val currentUser = auth.currentUser
        currentUser?.let { user ->
            val userProfileUpdates = mutableMapOf<String, Any>()

            if (username.isNotEmpty()) {
                updateUserProfileInAuth(username)
                userProfileUpdates["username"] = username
            }

            if (password.isNotEmpty()) {
                updatePassword(password)
            }

            if (firstName.isNotEmpty()) {
                userProfileUpdates["firstName"] = firstName
            }

            if (lastName.isNotEmpty()) {
                userProfileUpdates["lastName"] = lastName
            }

            updatedPhotoUrl?.let { url ->
                userProfileUpdates["photo"] = url.toString()
            }

            // Fetch existing user details from Firestore
            val existingUserDetails = userDetails.value

            existingUserDetails?.let { existingUser ->
                // Retain original values in Firestore if new values are not provided
                userProfileUpdates["username"] = username.takeIf { it.isNotEmpty() } ?: existingUser.username
                userProfileUpdates["firstName"] = firstName.takeIf { it.isNotEmpty() } ?: existingUser.firstName
                userProfileUpdates["lastName"] = lastName.takeIf { it.isNotEmpty() } ?: existingUser.lastName
                userProfileUpdates["email"] = existingUser.email
                userProfileUpdates["photo"] = updatedPhotoUrl?.toString() ?: existingUser.photo
            }

            updateUserProfileInFirestore(user, userProfileUpdates)
            userProfileChanged.value = true
        }
    }

    fun registerUser(
        email: String,
        password: String,
        username: String,
        firstName: String,
        lastName: String,
        navController: NavController
    ) {
        auth.createUserWithEmailAndPassword(email, password)
            .addOnCompleteListener { task ->
                if (task.isSuccessful) {
                    val photo = ""
                    val user = auth.currentUser
                    val userProfileUpdates = mutableMapOf<String, Any>(
                        "username" to username,
                        "email" to email,
                        "photo" to photo
                        // Add more user details as needed
                    )

                    if (firstName.isNotEmpty()) {
                        userProfileUpdates["firstName"] = firstName
                    }

                    if (lastName.isNotEmpty()) {
                        userProfileUpdates["lastName"] = lastName
                    }

                    updateUserProfileInAuth(username)
                    updateUserProfileInFirestore(user, userProfileUpdates)

                    navController.navigate("HomeScreen") {
                        popUpTo("SignUpScreen") {
                            inclusive = true
                        }
                    }
                } else {
                    Log.e("UserAccountViewModel", "User creation failed")
                    navController.navigate("SignUpScreen") {
                        popUpTo("LoginScreen") {
                            inclusive = true
                        }
                    }
                }
            }
    }

    // Function to handle user login
    fun loginUser(email: String, password: String, navController: NavController) {
        val auth = FirebaseAuth.getInstance()
        auth.signInWithEmailAndPassword(email, password)
            .addOnCompleteListener { task ->
                if (task.isSuccessful) {
                    // Authentication successful, navigate to the next screen
                    navController.navigate("HomeScreen") {
                        popUpTo("LoginScreen") {
                            inclusive = true
                        }
                    }
                } else {
                    Log.e("UserAccountViewModel", "Authentication failed")
                    navController.navigate("LoginScreen") {
                        popUpTo("SignUpScreen") {
                            inclusive = true
                        }
                    }
                }
            }
    }

    // Function to handle user logout
    fun logOut() {
        auth.signOut()
    }

    // Function to delete the user account by UID
    fun deleteUserAccountByUid(navController: NavController, userId: String) {
        usersCollection.document(userId)
            .delete()
            .addOnCompleteListener { task ->
                if (task.isSuccessful) {
                    val currentUser = auth.currentUser
                    currentUser?.delete()
                        ?.addOnCompleteListener { deleteTask ->
                            if (deleteTask.isSuccessful) {
                                Log.d("UserAccountViewModel", "User account deleted successfully")
                                navController.navigate("LoginScreen") {
                                    popUpTo("ProfileScreen") {
                                        inclusive = true
                                    }
                                }
                            } else {
                                Log.e("UserAccountViewModel", "Failed to delete user account: ${deleteTask.exception}")
                                // Handle failure to delete user account from Firebase Auth
                            }
                        }
                } else {
                    Log.e("UserAccountViewModel", "Failed to delete user document: ${task.exception}")
                    // Handle failure to delete user document from Firestore
                }
            }
    }
}

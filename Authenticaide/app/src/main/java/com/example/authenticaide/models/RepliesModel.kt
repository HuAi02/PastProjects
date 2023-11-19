package com.example.authenticaide.models

data class RepliesModel(
    val creationDateTime: String = "", // or you can use Date type if preferred
    val content: String = "",
    val username: String = "",
    val id: String = ""
)
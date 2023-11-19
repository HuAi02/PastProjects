package com.example.authenticaide.models

data class ThreadsModel(
    var id: String = "",
    val username: String = "",
    val photo: String = "",
    val title: String = "",
    val content: String = "",
    val productName: String = "",
    val productLink: String = "",
    val likeCounts: Int = 0,
    val relatedRepliesIds: List<String> = emptyList(),
)


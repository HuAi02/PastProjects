package com.example.authenticaide.navigation

import androidx.activity.OnBackPressedCallback
import androidx.activity.OnBackPressedDispatcherOwner
import androidx.compose.runtime.Composable
import androidx.compose.runtime.CompositionLocalProvider
import androidx.compose.runtime.DisposableEffect
import androidx.compose.runtime.rememberUpdatedState
import androidx.compose.runtime.staticCompositionLocalOf
import androidx.compose.ui.platform.LocalLifecycleOwner

private val localBackPressedDispatcherOwner =
    staticCompositionLocalOf<OnBackPressedDispatcherOwner?> { null }

@Composable
fun ProvideBackPressedDispatcherOwner(
    backPressedDispatcherOwner: OnBackPressedDispatcherOwner,
    content: @Composable () -> Unit
) {
    CompositionLocalProvider(localBackPressedDispatcherOwner provides backPressedDispatcherOwner) {
        content()
    }
}

@Composable
fun SystemBackButtonHandler(
    onBackPressed: () -> Unit
) {
    val dispatcherOwner = localBackPressedDispatcherOwner.current ?: return

    val backCallback = rememberUpdatedState(onBackPressed)

    val backDispatcher = dispatcherOwner.onBackPressedDispatcher
    val lifecycleOwner = LocalLifecycleOwner.current

    DisposableEffect(key1 = backDispatcher, effect = {
        val callback = object : OnBackPressedCallback(true) {
            override fun handleOnBackPressed() {
                backCallback.value()
            }
        }
        backDispatcher.addCallback(lifecycleOwner, callback)
        onDispose {
            callback.remove()
        }
    })
}

package com.example.authenticaide.components

import android.content.Context
import android.content.Intent
import android.net.Uri
import androidx.compose.foundation.BorderStroke
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.PaddingValues
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.heightIn
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.ClickableText
import androidx.compose.foundation.text.KeyboardActions
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.ArrowBack
import androidx.compose.material.icons.filled.Edit
import androidx.compose.material.icons.filled.Person2
import androidx.compose.material.icons.filled.Search
import androidx.compose.material.icons.filled.Visibility
import androidx.compose.material.icons.filled.VisibilityOff
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.CenterAlignedTopAppBar
import androidx.compose.material3.Checkbox
import androidx.compose.material3.Divider
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.NavigationBarItem
import androidx.compose.material3.NavigationBarItemDefaults
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.OutlinedTextFieldDefaults
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.material3.TextField
import androidx.compose.material3.TextFieldDefaults
import androidx.compose.material3.TopAppBarDefaults
import androidx.compose.material3.rememberTopAppBarState
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
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.platform.LocalFocusManager
import androidx.compose.ui.res.colorResource
import androidx.compose.ui.res.stringResource
import androidx.compose.ui.text.SpanStyle
import androidx.compose.ui.text.TextStyle
import androidx.compose.ui.text.buildAnnotatedString
import androidx.compose.ui.text.font.FontStyle
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.ImeAction
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.text.input.VisualTransformation
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.text.style.TextDecoration
import androidx.compose.ui.text.style.TextOverflow
import androidx.compose.ui.text.withStyle
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavController
import androidx.navigation.NavGraph.Companion.findStartDestination
import androidx.navigation.NavHostController
import androidx.navigation.compose.currentBackStackEntryAsState
import androidx.navigation.compose.rememberNavController
import coil.compose.AsyncImage
import coil.compose.rememberAsyncImagePainter
import com.example.authenticaide.R
import com.example.authenticaide.models.RepliesModel
import com.example.authenticaide.models.ThreadsModel
import com.example.authenticaide.ui.theme.colorBlack
import com.example.authenticaide.ui.theme.colorPrimary
import com.example.authenticaide.ui.theme.colorPrimaryLight
import com.example.authenticaide.ui.theme.colorSecondary
import com.example.authenticaide.ui.theme.colorSecondaryLight
import com.example.authenticaide.ui.theme.colorWhite
import com.example.authenticaide.viewmodel.ThreadsViewModel
import kotlinx.coroutines.launch

@Composable
fun NormalTextComponent(value:String){
    Text(
        text = value,
        modifier = Modifier
            .fillMaxWidth()
            .heightIn(min = 40.dp),
        style = TextStyle(
            fontSize = 24.sp,
            fontWeight = FontWeight.Normal,
            fontStyle = FontStyle.Normal
        )
    , color = colorResource(id = R.color.colorBlack),
        textAlign = TextAlign.Center
    )
}

@Composable
fun ProfileTextComponent(value:String){
    Text(
        text = value,
        modifier = Modifier
            .fillMaxWidth()
            .heightIn(min = 40.dp),
        style = TextStyle(
            fontSize = 18.sp,
            fontWeight = FontWeight.Normal,
            fontStyle = FontStyle.Normal
        )
        , color = colorResource(id = R.color.colorBlack),
        textAlign = TextAlign.Left
    )
}

@Composable
fun HeadingTextComponent(value:String){
    Text(
        text = value,
        modifier = Modifier
            .fillMaxWidth()
            .heightIn(),
        style = TextStyle(
            fontSize = 30.sp,
            fontWeight = FontWeight.Bold,
            fontStyle = FontStyle.Normal
        )
        , color = colorResource(id = R.color.colorBlack),
        textAlign = TextAlign.Center
    )
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MyTextFieldComponent(labelValue: String, value: String, onValueChange: (String) -> Unit) {
    OutlinedTextField(
        modifier = Modifier
            .fillMaxWidth()
            .background(colorWhite),
        label = { Text(text = labelValue) },
        colors = OutlinedTextFieldDefaults.colors(
            cursorColor = colorBlack,
            focusedBorderColor = colorPrimary,
            focusedLabelColor = colorPrimary,
        ),
        keyboardOptions = KeyboardOptions(imeAction = ImeAction.Next),
        singleLine = true,
        maxLines = 1,
        value = value,
        onValueChange = onValueChange,
//        leadingIcon = {
//            androidx.compose.material3.Icon(painter = painterResource(id = R.drawable.profile), contentDescription = "")
//        }
        )
}




@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun PasswordTextField(labelValue:String, onPasswordChange: (String) -> Unit){
    val localFocusManager = LocalFocusManager.current
    val password = remember {
        mutableStateOf("")
    }
    var passwordVisible by remember { mutableStateOf(false) }

    OutlinedTextField(
        modifier = Modifier
            .fillMaxWidth()
            .background(colorWhite),
        label = {Text(text = labelValue)},
        colors = OutlinedTextFieldDefaults.colors(
            cursorColor = colorBlack,
            focusedBorderColor = colorPrimary,
            focusedLabelColor = colorPrimary,
        ),
        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Password, imeAction = ImeAction.Done),
        singleLine = true,
        keyboardActions = KeyboardActions{
            localFocusManager.clearFocus()
        },
        maxLines = 1,
        value = password.value,
        onValueChange = {
            password.value = it
            onPasswordChange(it)
        },
//        leadingIcon = {
//            androidx.compose.material3.Icon(painter = painterResource(id = R.drawable.profile), contentDescription = "")
//        }
        trailingIcon = {
            val iconImage = if(passwordVisible){
                Icons.Filled.Visibility
            } else{
                Icons.Filled.VisibilityOff
            }
            val description = if(passwordVisible){
                stringResource(id = R.string.hide_password)
            } else{
                stringResource(id = R.string.show_password)
            }

            IconButton(onClick = { passwordVisible = !passwordVisible }){
                Icon(imageVector = iconImage, contentDescription = description)
            }
        },
        visualTransformation = if (passwordVisible) VisualTransformation.None else PasswordVisualTransformation()
    )
}

@Composable
fun CheckboxComponent(
    isChecked: Boolean,
    onCheckedChange: (Boolean) -> Unit,
    navController: NavController
) {
    Row(
        modifier = Modifier
            .fillMaxWidth()
            .heightIn(56.dp),
        verticalAlignment = Alignment.CenterVertically
    ) {
        remember {
            mutableStateOf(false)
        }
        Checkbox(
            checked = isChecked,
            onCheckedChange = { newCheckedState ->
                onCheckedChange(newCheckedState)
            }
        )
        ClickableTextComponent {
            if (it == "Terms of Use" || it == "Privacy Policy") {
                navController.navigate("TermsAndConditionsScreen")
            }
        }
    }
}

@Composable
fun ClickableTextComponent(onTextSelected: (String) -> Unit) {
    val part1 = "By continuing you accept our "
    val privacyPolicy = "Privacy Policy"
    val part2 = " and "
    val termsOfUse = "Terms of Use"

    val annotatedString = buildAnnotatedString {
        append(part1)
        withStyle(SpanStyle(color = colorPrimaryLight)) {
            pushStringAnnotation(tag = privacyPolicy, annotation = privacyPolicy)
            append(privacyPolicy)
        }
        append(part2)
        withStyle(SpanStyle(color = colorPrimaryLight)) {
            pushStringAnnotation(tag = termsOfUse, annotation = termsOfUse)
            append(termsOfUse)
        }
    }
    ClickableText(text = annotatedString, onClick = { offset ->
        annotatedString.getStringAnnotations(offset, offset)
            .firstOrNull()?.also { span ->
                if (span.item == termsOfUse || span.item == privacyPolicy) {
                    onTextSelected(span.item)
                }
            }
    })
}

@Composable
fun ButtonComponent(value:String, onButtonClicked: () -> Unit){
    Button(
        onClick = { onButtonClicked.invoke() },
        modifier = Modifier
            .fillMaxWidth()
            .heightIn(48.dp),
        contentPadding = PaddingValues(),
        colors = ButtonDefaults.buttonColors(colorSecondary),
        shape = RoundedCornerShape(50.dp),
    ) {
        Box(
            modifier = Modifier
                .fillMaxWidth()
                .heightIn(48.dp),
            contentAlignment = Alignment.Center
        ){
            Text(text = value,
                fontSize = 18.sp,
                fontWeight = FontWeight.Bold)
        }
    }
}

@Composable
fun ClickableLoginComponent(tryingToLogin: Boolean = true, onTextSelected: (String) -> Unit) {
    val part1 = if(tryingToLogin) "Don't have an account yet? " else "Already have an account? "
    val loginText = if(tryingToLogin) "Register" else "Login"

    val annotatedString = buildAnnotatedString {
        append(part1)
        withStyle(SpanStyle(color = colorPrimaryLight)) {
            pushStringAnnotation(tag = loginText, annotation = loginText)
            append(loginText)
        }
    }

    rememberNavController()

    ClickableText(modifier = Modifier
        .fillMaxWidth()
        .heightIn(min = 40.dp),
        style = TextStyle(
            fontSize = 18.sp,
            fontWeight = FontWeight.Normal,
            fontStyle = FontStyle.Normal,
            textAlign = TextAlign.Center
        ),
        text = annotatedString, onClick = { offset ->
        annotatedString.getStringAnnotations(offset, offset)
            .firstOrNull()?.also { span ->
                if (span.item == loginText) {
                    onTextSelected(span.item)
                }
            }
    })
}

@Composable
fun ClickableProductLink(
    productLink: String,
    modifier: Modifier = Modifier,
    onProductLinkSelected: (String) -> Unit // Callback to handle the product link selection
) {
    val context = LocalContext.current

    // Create the annotated string
    val annotatedString = remember {
        buildAnnotatedString {
            val part1 = "Product Link: "
            withStyle(SpanStyle(color = colorPrimaryLight)) {
                // Push annotation for the product link
                pushStringAnnotation(tag = "ProductLink", annotation = productLink)
                append(part1)
                append(productLink)
            }
        }
    }

    // Show the annotated string using ClickableText
    ClickableText(
        modifier = modifier.fillMaxWidth(),
        text = annotatedString,
        onClick = { offset ->
            // Get the clicked annotation and handle product link selection
            annotatedString.getStringAnnotations(start = offset, end = offset)
                .firstOrNull()?.let { annotation ->
                    if (annotation.tag == "ProductLink") {
                        onProductLinkSelected(annotation.item)
                    }
                }
        }
    )
}

fun openLinkInBrowser(context: Context, url: String) {
    val intent = Intent(Intent.ACTION_VIEW, Uri.parse(url))
    context.startActivity(Intent.createChooser(intent, "Browse with"));
}

@Composable
fun UnderLinedTextComponent(value: String){
    Text(
        text = value,
        modifier = Modifier
            .fillMaxWidth()
            .heightIn(min = 40.dp),
        style = TextStyle(
            fontSize = 16.sp,
            fontWeight = FontWeight.Normal,
            fontStyle = FontStyle.Normal
        ), color = colorResource(id = R.color.colorPrimaryLight),
        textAlign = TextAlign.Center,
        textDecoration = TextDecoration.Underline
    )
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun SearchBar(onSearch: (String) -> Unit) {
    // Create a state for the search keyword
    val keyword = remember { mutableStateOf("") }

    // Create a surface with outline for the search bar
    Surface(
        shape = RoundedCornerShape(8.dp), // Rounded corners for the entire search bar
        shadowElevation = 4.dp, // Elevation for shadow effect
        border = BorderStroke(1.dp, colorSecondaryLight), // Outline color and width
        modifier = Modifier
            .fillMaxWidth()
            .height(80.dp)
            .padding(horizontal = 18.dp, vertical = 8.dp) // Adjust vertical padding
    ) {
        // Row to display the search bar content
        Row(
            modifier = Modifier.fillMaxSize(),
            horizontalArrangement = Arrangement.SpaceBetween,
            verticalAlignment = Alignment.CenterVertically
        ) {
            // Display the text field on the left
            TextField(
                value = keyword.value,
                onValueChange = {
                    keyword.value = it
                    onSearch(it)
                },
                keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text, imeAction = ImeAction.Search),
                modifier = Modifier
                    .weight(1f)
                    .fillMaxHeight(),
                singleLine = true,
                placeholder = {
                    Text(
                        text = "Search keyword",
                        color = Color.Gray,
                    )
                },
                colors = TextFieldDefaults.colors(
                    focusedContainerColor = colorWhite,
                    unfocusedContainerColor = colorWhite,
                    disabledContainerColor = Color.Gray,
                    cursorColor = colorBlack,
                )
            )
            // Display the magnifying glass icon on the right
            Icon(
                imageVector = Icons.Default.Search,
                contentDescription = "Search icon",
                modifier = Modifier
                    .size(28.dp),
                tint = colorSecondaryLight
            )
            Spacer(modifier = Modifier.width(8.dp))
        }
    }
}


@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun ProfileTopBar(value: String, navController: NavHostController) {
    val scrollBehavior = TopAppBarDefaults.pinnedScrollBehavior(rememberTopAppBarState())


    CenterAlignedTopAppBar(
        colors = TopAppBarDefaults.centerAlignedTopAppBarColors(
            containerColor = colorSecondary,
            titleContentColor = colorWhite,
        ),
        title = {
            Row(
                verticalAlignment = Alignment.CenterVertically,
                modifier = Modifier
                    .fillMaxWidth()
                    .height(56.dp)
            ) {
                IconButton(onClick = {
                }) {

                }

                Text(
                    text = value,
                    maxLines = 1,
                    overflow = TextOverflow.Ellipsis,
                    textAlign = TextAlign.Center,
                    color = colorWhite,
                    modifier = Modifier.weight(1f)
                )

                IconButton(onClick = {
                    navController.navigate("ProfileScreen")
                }) {
                    Icon(
                        imageVector = Icons.Filled.Person2,
                        contentDescription = "My Profile",
                        tint = Color.White
                    )
                }
            }

        },
        scrollBehavior = scrollBehavior,
        modifier = Modifier.height(56.dp)
    )
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun BackTopBar(value: String, navController: NavHostController) {
    val scrollBehavior = TopAppBarDefaults.pinnedScrollBehavior(rememberTopAppBarState())


    CenterAlignedTopAppBar(
        colors = TopAppBarDefaults.centerAlignedTopAppBarColors(
            containerColor = colorSecondary,
            titleContentColor = colorWhite,
        ),
        title = {
            Row(
                verticalAlignment = Alignment.CenterVertically,
                modifier = Modifier
                    .fillMaxWidth()
                    .height(56.dp)
            ) {
                IconButton(onClick = {
                    navController.popBackStack()
                }) {
                    Icon(
                        imageVector = Icons.Filled.ArrowBack,
                        contentDescription = "Back",
                        tint = Color.White
                    )
                }

                Text(
                    text = value,
                    maxLines = 1,
                    overflow = TextOverflow.Ellipsis,
                    textAlign = TextAlign.Center,
                    color = colorWhite,
                    modifier = Modifier.weight(1f)
                )

                IconButton(onClick = {}) {}
            }

        },
        scrollBehavior = scrollBehavior,
        modifier = Modifier.height(56.dp)
    )
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun BackAndEditTopBar(value: String, navController: NavHostController) {
    val scrollBehavior = TopAppBarDefaults.pinnedScrollBehavior(rememberTopAppBarState())

    CenterAlignedTopAppBar(
        colors = TopAppBarDefaults.centerAlignedTopAppBarColors(
            containerColor = colorSecondary,
            titleContentColor = colorWhite,
        ),
        title = {
            Row(
                verticalAlignment = Alignment.CenterVertically,
                modifier = Modifier
                    .fillMaxWidth()
                    .height(56.dp)
            ) {
                IconButton(onClick = {
                    navController.popBackStack()
                }) {
                    Icon(
                        imageVector = Icons.Filled.ArrowBack,
                        contentDescription = "Back",
                        tint = Color.White
                    )
                }

                Text(
                    text = value,
                    maxLines = 1,
                    overflow = TextOverflow.Ellipsis,
                    textAlign = TextAlign.Center,
                    color = colorWhite,
                    modifier = Modifier.weight(1f)
                )

                IconButton(onClick = {
                    navController.navigate("EditProfileScreen")
                }) {
                    Icon(
                        imageVector = Icons.Filled.Edit,
                        contentDescription = "Edit Profile",
                        tint = Color.White
                    )
                }
            }
        },
        scrollBehavior = scrollBehavior,
        modifier = Modifier.height(56.dp)
    )
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun BackAndConfirmTopBar(value: String, navController: NavHostController) {
    val scrollBehavior = TopAppBarDefaults.pinnedScrollBehavior(rememberTopAppBarState())

    CenterAlignedTopAppBar(
        colors = TopAppBarDefaults.centerAlignedTopAppBarColors(
            containerColor = colorSecondary,
            titleContentColor = colorWhite,
        ),
        title = {
            Row(
                verticalAlignment = Alignment.CenterVertically,
                modifier = Modifier
                    .fillMaxWidth()
                    .height(56.dp)
            ) {
                IconButton(onClick = {
                    navController.popBackStack()
                }) {
                    Icon(
                        imageVector = Icons.Filled.ArrowBack,
                        contentDescription = "Back",
                        tint = Color.White
                    )
                }

                Text(
                    text = value,
                    maxLines = 1,
                    overflow = TextOverflow.Ellipsis,
                    textAlign = TextAlign.Center,
                    color = colorWhite,
                    modifier = Modifier.weight(1f)
                )

                IconButton(onClick = {
                }) {

                }
            }
        },
        scrollBehavior = scrollBehavior,
        modifier = Modifier.height(56.dp)
    )
}

@Composable
fun NavigationBar(navController: NavHostController){
    val navBarItemColors = NavigationBarItemDefaults.colors(
        indicatorColor = colorSecondary
    )
    androidx.compose.material3.NavigationBar(
        modifier = Modifier.height(80.dp),
        containerColor = colorWhite,
        contentColor = colorSecondary,
    ) {
        val backStackEntry by navController.currentBackStackEntryAsState()
        val currentRoute = backStackEntry?.destination?.route

        NavBarItems.BarItems.forEach { navItem ->

            NavigationBarItem(
                selected = currentRoute == navItem.route,
                colors = navBarItemColors,
                onClick = {
                    navController.navigate(navItem.route) {
                        popUpTo(navController.graph.findStartDestination().id) {
                            saveState = true
                        }
                        launchSingleTop = true
                        restoreState = true
                    }
                },

                icon = {
                    Icon(
                        imageVector = navItem.image,
                        contentDescription = navItem.title,
                        tint = if (currentRoute == navItem.route) colorWhite else colorSecondary
                    )
                },
                label = {
                    Text(
                        text = navItem.title,
                        color = colorSecondary
                    )
                }
            )
        }
    }
}

@Composable
fun ThreadItem(
    thread: ThreadsModel,
    threadsViewModel: ThreadsViewModel,
    navController: NavHostController
) {
    val context = LocalContext.current
    val scope = rememberCoroutineScope()

    // Click listener to navigate to ThreadsScreen
    val onClick = {
        scope.launch {
            val threadId = threadsViewModel.getThreadIdByAttributes(thread)
            threadId?.let {
                navController.navigate("ThreadsScreen/$it")
            }
        }
    }


    // Composable to display each thread item
    Row(
        modifier = Modifier
            .fillMaxWidth()
            .padding(16.dp)
            .clickable { onClick.invoke() }
    ) {
        // Display image on the left side
        Image(
            painter = rememberAsyncImagePainter(model = thread.photo),
            contentDescription = "Thread photo",
            modifier = Modifier
                .size(150.dp)
                .clip(shape = RoundedCornerShape(8.dp))
        )
        Column(
            modifier = Modifier
                .padding(start = 16.dp)
                .align(Alignment.Top)
                .fillMaxHeight()
        ) {
            Text(text = thread.username)
            Text(text = "Title: ${thread.title}")
            Text(text = "Content: ${thread.content}")
            Spacer(modifier = Modifier.height(10.dp))
            Text(text = "Likes: ${thread.likeCounts}")
        }
    }
    Divider(
        color = colorSecondary,
        thickness = 1.dp,
        modifier = Modifier
            .fillMaxWidth()
    )
}

@Composable
fun ReplyItem(
    threadsViewModel: ThreadsViewModel = viewModel(),
    threadId: String
) {
    // Fetch related reply IDs from Firestore using threadId
    val relatedRepliesIds = remember { mutableStateListOf<String>() }
    LaunchedEffect(threadId) {

        threadsViewModel.getThreadById(threadId)
            ?.let { relatedRepliesIds.addAll(it.relatedRepliesIds) }
    }

    // Fetch replies based on related reply IDs
    val replies = remember { mutableStateListOf<RepliesModel>() }
    LaunchedEffect(relatedRepliesIds) {
        val fetchedReplies = threadsViewModel.getRepliesForThread(relatedRepliesIds)
        replies.addAll(fetchedReplies)
    }

    // Display each reply's username and content
    Column {
        for (reply in replies) {
            Text(text = "Username: ${reply.username}")
            Text(text = "Content: ${reply.content}")
            Divider(
                color = colorSecondary,
                thickness = 1.dp,
                modifier = Modifier.fillMaxWidth()
            )
        }
    }
}

@Composable
fun NotificationItem(thread: ThreadsModel) {
    Row(
        verticalAlignment = Alignment.CenterVertically
    ) {
        // Display thread picture if available
        thread.photo.let { photoUrl ->
            AsyncImage(
                model = photoUrl,
                contentDescription = null,
                modifier = Modifier.size(48.dp).clip(shape = RoundedCornerShape(4.dp)),
            )
        }
        Spacer(modifier = Modifier.width(8.dp))
        Text(
            text = "${thread.username} just replied to your thread '${thread.title}'"
        )
    }
}
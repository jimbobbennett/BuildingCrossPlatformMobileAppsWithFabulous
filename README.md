# Building Cross-Platform Mobile Apps With Fabulous

This repo contains all the resources and links you will need to get started building cross-platform mobile apps with Fabulous. This content was created for a talk given at [NDC London](https://ndc-london.com) in January 2019.

## Links

* [Fabulous on GitHub](https://github.com/fsprojects/Fabulous)
* [Fabulous documentation](https://fsprojects.github.io/Fabulous/)
* [Awesome Fabulous](https://github.com/jimbobbennett/Awesome-Fabulous) - a collection of resources on Fabulous
* [FSharp.org](https://fsharp.org) - The home of F#

## Slides

The slides for this talk are available [here](./Slides.pdf)

## Video

The video from NDC London is here:

https://youtu.be/DTzfe98pFvs

## Sample apps

This repo contains 2 sample apps.

**Simple Hello World**

This is the canonical 'Hello Fabulous' app showing the basics of the MVU pattern. It has a model with a `Count` field and an `Increment` message. The `update` function processes the message, returns a new model with the `Count` incremented, and this is drawn on the view. The `view` function returns a view with the `Count` in a `Label`, as well as a `Button` that dispatches the `Increment` message.

A good way to get started is to add a decrement button, and wire it up using a message. Try this whilst using the [Live Update](https://fsprojects.github.io/Fabulous/tools.html) feature to get a good feel of how rapid Fabulous devlopment is.

**Advanced Hello World**

This app is a online photo storage app that takes photos and uploads them to the cloud.

To try this app out you will need an [Azure](https://azure.microsoft.com/?WT.mc_id=fabulous-github-jabenn) account. You can sign up for a free account [here](https://azure.microsoft.com/Free/?WT.mc_id=fabulous-github-jabenn).

Once you have an account, create a [blob storage resource](https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?WT.mc_id=fabulous-github-jabenn), and add the connection string to the `Keys.fs` file.

When you run the app you will be able to take a photo and it will upload to your blob storage.

This app checks to see if you have network connectivity using [Xamarin Essentials](https://docs.microsoft.com/xamarin/essentials/?WT.mc_id=fabulous-github-jabenn). If you have network connectivity, it uses the [Xamarin Media plugin](https://github.com/jamesmontemagno/MediaPlugin) to take a photo.

This app only works on Android at the moment. It uses the [Android Azure storage SDK](https://github.com/Azure/azure-storage-android), bound in a [Xamarin Java Binding Library](https://docs.microsoft.com/xamarin/android/platform/binding-java-library/binding-an-aar/?WT.mc_id=fabulous-github-jabenn). An exercise to the reader is to implement the [iOS version](https://github.com/Azure/azure-storage-ios) using [Objective Sharpie](https://docs.microsoft.com/xamarin/cross-platform/macios/binding/objective-sharpie/?WT.mc_id=fabulous-github-jabenn).

The storage is implemented in platform specific code using a bound native library, and the function to store the blob is passed in to the app constructor to show how you can compose your app using platform-specific functions.

## Get involved!

Fabulous is open source and relies on the community to build it. If you want to get involved, check out the issues in [GitHub](https://github.com/fsprojects/Fabulous/issues), especially the ones with the [**Good first issue** label](https://github.com/fsprojects/Fabulous/issues?q=is%3Aissue+is%3Aopen+label%3A%22good+first+issue%22).

If you've written any apps, blog posts, sample code or anything to do with Fabulous, please raise a PR to add it to the [Awesome Fabulous](https://github.com/jimbobbennett/Awesome-Fabulous) repo.

We could also use an icon if you are a designer!

You can also join the conversation on Twitter:

* [Jim Bennett](https://twitter.com/jimbobbennett) - me!
* [Don Syme](https://twitter.com/dsyme) - the initial creator of Fabulous
* [Timothé Larivière](https://twitter.com/Tim_Lariviere) - one of the core contributors and maintainers
* [#Fabulous](https://twitter.com/hashtag/Fabulous?src=hash) - the Fabulous Hashtag - though others keep using it for non-FSharp things!

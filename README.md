# CodeChallenge

## UpComing Movies App

This project was writed like a code challenge to a hire process and has basic functions to get the Upcoming movies in the  [The Movies DB API](https://themoviedb.org/).

* The main functions are
	* List of UpComing Movies (show movie photo, title and release date)
	* Search movies by title (full name or part name)
	* UpComing Movie detail (show the poster, title, overview and popularity)

:warning: Is some cases, the photo movie wasn´t at the API, so we put a default photo with the logo of our project to maintain the behavior default of the list.

#### Used Technologies

* Microsoft Visual Studio 2015 (Version 14.0.25431.01 Update 3)
* Microsoft .NET Framework (Version 4.7.02556)
* Mono Debugging for Visual Studio (4.8.4-pre)
* NuGet Package Manager (3.4.4)
* Visual Studio Tools for Universal Windows Apps (14.0.25527.01)
* Xamarin (4.8.0.756)
* Xamarin Designer (4.8.188)
* Xamarin Inspector Support (1.0.0.0)
* Xamarin.Android (8.1.0.13)
* Xamarin.Android SDK (8.1.0.23)
* Xamarin.iOS (11.6.1.2)
* Xamarin.iOS and Xamarin.Mac SDK (11.6.1.2)

:warning: There are in the GIT the three platforms (Android, IOS and UWP) but consider use only (Android) because the version of IOS was incomplete and the version of UWP has been a unfriendly layout.

#### Third Party Libraries

* Newtonsoft.Json (11.0.2)

**Used to serialize and deserialize the informations of consumed API**

* Unity (5.8.1)

**Used to resolve the dependencies of projects**

* Xamarin.FFImageLoading (2.3.6)
* Xamarin.FFImageLoading.Forms (2.3.6)
* Xamarin.FFImageLoading.Transformations (2.3.6)

**Used in listview to show the image with rounded corners and to cache the images avoiding waste time to load when scroll the list.**

* Xamarin.Forms (2.4.0.280)

**Used to construct the application using Xamarin platform**




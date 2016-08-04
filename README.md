# Microsoft Graph Property Manager Sample for Xamarin Native

##Table of contents

* [Prerequisites](#prerequisites)
* [Register and configure the app](#register)
* [Build and debug](#build)
* [Run the sample](#run)
* [How the sample affects your account data](#how-the-sample-affects-your-tenant-data)
* [Add a snippet](#add-a-snippet)
* [Questions and comments](#questions)
* [Contributing](#contributing")
* [Additional resources](#additional-resources)

<a name="introduction"></a>
This sample project demonstrates how to use the Microsoft Graph as the only back-end component for a complete property management solution. The samples covers features such as property details, conversations, files and tasks in a Xamarin Native app. Because the sample targets the beta branch of the Microsoft Graph, network calls are being made with the built in HTTP stack towards the Microsoft Graph instead of using the [Microsoft Graph .NET Client SDK](https://github.com/microsoftgraph/msgraph-sdk-dotnet),

The purpose of this sample is to demonstrate the ability to create platform user interfaces and experiences, while sharing code across platforms and supercharging the solution with the Microsoft Graph. It heavily leverages Office 365 Groups in order to organize data into properties.

The samples uses the [Active Directory Authentication Library](https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/) for authentication and the [MvvmCross ](https://mvvmcross.com/) library to bring the [MVVM](https://msdn.microsoft.com/en-us/library/hh848246.aspx) pattern across platforms with Xamarin.




## Project ##
Project | Author(s)
---------|----------
XamarinNativePropertyManager | Simon Jäger (**Microsoft**)

## Version history ##
Version  | Date | Comments
---------| -----| --------
1.0  | August 4th 2016 | Initial release

<a name="prerequisites"></a>
## Prerequisites ##

This sample requires the following:  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin for Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 ([development mode enabled](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * Either an [Office 365 for business account](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)

If you want to run the iOS project in this sample, you'll need the following:

  * The latest iOS SDK
  * The latest version of Xcode
  * Mac OS X Yosemite(10.10) & above 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * A [Xamarin Mac agent connected to Visual Studio](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

You can use the [Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) if you want to run the Android project.

<a name="register"></a>
##Register and configure the app

1. Sign into the [App Registration Portal](https://apps.dev.microsoft.com/) using either your personal or work or school account.
2. Select **Add an app**.
3. Enter a name for the app, and select **Create application**.
	
	The registration page displays, listing the properties of your app.
 
4. Under **Platforms**, select **Add platform**.
5. Select **Mobile application**.
6. Copy the Client Id (App Id) value to the clipboard. You'll need to enter this value into the sample app.

	The app id is a unique identifier for your app.

7. Select **Save**.

<a name="build"></a>
## Build and debug ##

**Note:** If you see any errors while installing packages during step 2, make sure the local path where you placed the solution is not too long/deep. Moving the solution closer to the root of your drive resolves this issue.

1. Open the App.cs file inside the **XamarinFormsMeetingManager (Portable)** project of the solution.

    ![Screenshot of the Solution Explorer pane in Visual Studio, with App.cs file selected in the XamarinFormsMeetingManager project](/readme-images/Appdotcs.png "Open App.cs file in XamarinFormsMeetingManager project")

2. After you've loaded the solution in Visual Studio, configure the sample to use the client id that you registered by making this the value of the **ClientId** variable in the App.cs file.


    ![Screenshot of the ClientId variable in the App.cs file, currently set to an empty string.](/readme-images/appId.png "Client ID value in App.cs file")


3. Select the project that you want to run. If you select the Universal Windows Platform option, you can run the sample on the local machine. If you want to run the iOS project, you'll need to connect to a [Mac that has the Xamarin tools](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/) installed on it. (You can also open this solution in Xamarin Studio on a Mac and run the sample directly from there.) You can use the [Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) if you want to run the Android project. 

    ![Screenshot of the Visual Studio toolbar, with iOS selected as the start-up project.](/readme-images/SelectProject.png "Select project in Visual Studio")

4. Press F5 to build and debug. Run the solution and sign in with either your personal or work or school account.
    > **Note** You might have to open the Build Configuration Manager to make sure that the Build and Deploy steps are selected for the UWP project.

<a name="run"></a>
## Run the sample

After launching the app, click the **Connect** button to log in to your Microsoft account. After you authenticate, the app displays a date picker that defaults to the current date and a list of all meetings on the current user's calendar for that date. Use the date picker to view, edit, and create meetings on other dates.

| UWP | Android | iOS |
| --- | ------- | ----|
| <img src="/readme-images/UWPVersion.png" alt="Connect sample on UWP" width="100%" /> | <img src="/readme-images/DroidVersion.png" alt="Connect sample on Android" width="100%" /> | <img src="/readme-images/iOSVersion.png" alt="Connect sample on iOS" width="100%" /> |

After you select a date, you can either view meeting details or create a new meeting for the selected date.

Select a meeting from the list to view its details. From the meeting details page you can forward the meeting to others, send a "reply all" message to all meeting participants, send a "running late" message, or edit the meeting details. The edit meeting page contains an option for adding a recurrence pattern to the meeting.

Use the **Cancel** button to navigate from the edit and create meeting pages if you don't want to save your changes.

<a name="#how-the-sample-affects-your-tenant-data"></a>
##How the sample affects your account data

This sample runs commands that create, read, update, or delete data. It creates and leaves data artifacts (meetings and messages) in your account as part of its operation.

<a name="contributing"></a>
## Contributing ##

If you'd like to contribute to this sample, see [CONTRIBUTING.MD](/CONTRIBUTING.md).

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.


<a name="additional-resources"></a>
## Additional resources ##

- [Other Microsoft Graph Connect samples](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Microsoft Graph overview](http://graph.microsoft.io)
- [Office developer code samples](http://dev.office.com/code-samples)
- [Office dev center](http://dev.office.com/)


## Copyright
Copyright (c) 2016 Microsoft. All rights reserved.




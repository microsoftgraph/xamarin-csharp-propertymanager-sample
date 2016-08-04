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
This sample project demonstrates how to use the Microsoft Graph as the only back-end component for a complete property management solution. The samples covers features such as property details, conversations, files and tasks in a Xamarin Native app.

The purpose of this sample is to demonstrate the ability to create platform user interfaces and experiences (by implementing native views), while sharing common code across platforms and supercharging the solution with the Microsoft Graph. It heavily leverages Office 365 groups in order to organize data into properties.

> **Note** The sample targets the beta branch of the Microsoft Graph, which the [Microsoft Graph .NET Client SDK](https://github.com/microsoftgraph/msgraph-sdk-dotnet) does not implement. Instead, network calls are being made with the built in HTTP stack towards the Microsoft Graph to consume its resources.

The samples uses the [Active Directory Authentication Library](https://www.nuget.org/packages/Microsoft.IdentityModel.Clients.ActiveDirectory/) for authentication and the [MvvmCross ](https://mvvmcross.com/) library to bring the [MVVM pattern](https://msdn.microsoft.com/en-us/library/hh848246.aspx) across platforms with Xamarin.

![Screenshots of the sample running on Android, iOS and UWP project.](/Images/PM_OSes.png "Sample running on Android, iOS and UWP.")  

### Project ###
Project | Author(s)
---------|----------
XamarinNativePropertyManager | [Simon Jäger](http://simonjaeger.com/) (**Microsoft**)

### Version history ###
Version  | Date | Comments
---------| -----| --------
1.0  | August 4th 2016 | Initial release

<a name="prerequisites"></a>
## Prerequisites ##

This sample requires the following:  

  * [Visual Studio 2015](https://www.visualstudio.com/downloads) 
  * [Xamarin for Visual Studio](https://www.xamarin.com/visual-studio)
  * Windows 10 ([development mode enabled](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
  * An [Office 365 account](https://msdn.microsoft.com/office/office365/howto/setup-development-environment#bk_Office365Account)

If you are building for Office 365 and you're missing an Office 365 tenant - get yourself a developer account at: <http://dev.office.com/devprogram>

If you want to run the iOS project in this sample, you'll need the following:

  * The latest iOS SDK
  * The latest version of Xcode
  * Mac OS X Yosemite(10.10) & above 
  * [Xamarin.iOS](https://developer.xamarin.com/guides/ios/getting_started/installation/mac/)
  * A [Xamarin Mac agent connected to Visual Studio](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/)

You can use the [Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) if you want to run the Android project.

<a name="register"></a>
##Register and configure the app

The first thing you need to do is to register your app in Azure AD.

1. Sign in with an administrative user of your Office 365 tenant at the [Azure Management Portal](https://manage.windowsazure.com/).
2. Select **Active Directory**.  
![Screenshots of the Azure AD tab icon.](/Images/AAD.png "Azure AD tab icon.")  
3. Select your Azure AD tenant in the **Directory** tab.  
![Screenshots of an Azure AD tenant.](/Images/SelectTenant.png "Azure AD tenant.")  
4. Click on **Applications** in the tab menu.
5. Click on the **Add** button at the bottom.  
![Screenshots of the Add Application button](/Images/AddApp.png "Add Application button.")  
6. Choose **Add an application my organization is developing** in the dialog that shows up.
7. Name your application and select **Native Client Application**.
8. Enter a **Redirect Uri**. You can use anything for this, for example "https://propertymanagerapp".
9. When the application has been created, click on the **Configure** tab in the application page.
10. Scroll down to the bottom to the **Permissions to other applications** section and click on the **Add application** button.
11. Show **Microsoft Apps** and add the **Microsoft Graph**.
12. Save your changes by clicking the check button at the bottom.  
![Screenshots of the Microsoft Graph app.](/Images/AddMSGraph.png "Microsoft Graph app.")  
13. Click on **Delegated permissions** and pick the following permissions:
    1.  Sign users in
    2.  Read and write all groups
    3.  Read items in all site collections
    4.  Have full access to all files user can access
    5.  Create, read, update and delete user tasks and projects (preview)
    6.  Read directory data
3.  Save your configuration by clicking the **Save** button at the bottom.  
![Screenshots of the Save Application button.](/Images/SaveApp.png "Save Application button.")  

<a name="build"></a>
## Build and debug ##

**Note:** If you see any errors while installing packages during step 2, make sure the local path where you placed the solution is not too long/deep. Moving the solution closer to the root of your drive resolves this issue.

1. Open the Constants.cs file inside the **XamarinNativePropertyManager (Portable)** project of the solution.  
![Screenshots of the Constants.cs file.](/Images/Constants.png "Constants.cs.") 

2. After you've loaded the solution in Visual Studio, configure the sample to use your Azure AD tenant by replacing the **[TENANT_ID_OR_NAME]** value in the **Authority** property in the **Constants.cs** file.  
![Screenshots of the Authority property in the Constants.cs file.](/Images/TenantId.png "Authority property.") 

3. Configure the sample to use your Azure AD application Client Id by replacing the **[CLIENT_ID]** value in the **ClientId** property in the **Constants.cs** file.  
![Screenshots of the ClientId property in the Constants.cs file.](/Images/ClientId.png "ClientId property.") 

3. Configure the sample to use your Azure AD application Redirect Uri by replacing the **[REDIRECT_URI]** value in the **RedirectUri** property in the **Constants.cs** file.  
![Screenshots of the RedirectUri property in the Constants.cs file.](/Images/RedirectUri.png "RedirectUri property.") 

3. Select the project that you want to run. If you select the Universal Windows Platform option, you can run the sample on the local machine. If you want to run the iOS project, you'll need to connect to a [Mac that has the Xamarin tools](https://developer.xamarin.com/guides/ios/getting_started/installation/windows/connecting-to-mac/) installed on it. (You can also open this solution in Xamarin Studio on a Mac and run the sample directly from there.) You can use the [Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) if you want to run the Android project.  
![Screenshot of the Visual Studio toolbar, with UWP selected as the start-up project.](/Images/Projects.png "Select start-up project.") 

4. Press F5 to build and debug. Run the solution and sign in with either your personal or work or school account.
    > **Note** You might have to open the Build Configuration Manager to make sure that the Build and Deploy steps are selected for the UWP project.

<a name="run"></a>
## Run the sample

After launching the app, click the **Sign in** button to sign in to your organizational account. After you authenticate, the app displays all the properties in your organization. Create a new one by filling in the details and the app will provision a new Office 365 group for this property. At this point you will be able to post messages to the group conversations, add files and create tasks.

![Screenshots of the sample running on Android, iOS and UWP project.](/Images/PM_OSes.png "Sample running on Android, iOS and UWP.")

You will also be able to update the details of the property and create new ones. Explore the Office 365 groups in your browser to find all of the data used within the app. The property details are stored in an Excel workbook named **Data.xlsx**, located in the **Property Managers** group. 

| Screenshots        |
| ------------- |
| **Android**       |
| <img src="/Images/PM_Android.png" alt="Sample running on Android." width="100%" /> |
| **iOS**      |
| <img src="/Images/PM_iOS.png" alt="Sample running on Android." width="100%" /> |
| **UWP** |
| <img src="/Images/PM_UWP1.png" alt="Sample running on Android." width="100%" /> |


<a name="#how-the-sample-affects-your-tenant-data"></a>
##How the sample affects your account data

When this sample is started for the first time (in the Office 365 tenant) an Office 365 group named **Property Managers** is created. In this group, a **Data.xlsx** file is stored which hosts all of the details for the different properties.

For each property that is created within the app, a new Office 365 group is provisioned. In each group the files, conversations and tasks resources are used by the app. Tasks are the only thing that can be deleted (completed) from within the app. The app does not provide an ability to delete conversation posts or files. 

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
- [Simon Jäger's blog on #Office365Dev](http://simonjaeger.com/)


## Copyright
Copyright (c) 2016 Microsoft. All rights reserved.
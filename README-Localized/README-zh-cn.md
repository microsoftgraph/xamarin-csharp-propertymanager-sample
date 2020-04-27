---
page_type: sample
products:
- ms-graph
languages:
- csharp
description: "演示如何使用 Microsoft Graph 作为完整属性管理解决方案的唯一后端组件。"
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  platforms:
  - Xamarin
  createdDate: 8/3/2016 8:57:27 AM
---
# 适用于 Xamarin Native 的 Microsoft Graph 属性管理器

## 目录

* [先决条件](#prerequisites)
* [注册和配置应用](#register-and-configure-the-app)
* [构建和调试](#build-and-debug)
* [运行示例](#run-the-sample)
* [示例如何影响你的帐户数据](#how-the-sample-affects-your-account-data)
* [参与](#contributing)
* [其他资源](#additional-resources)

此示例项目演示如何使用 Microsoft Graph 作为完整属性管理解决方案的唯一后端组件。这些示例介绍了 Xamarin 本机应用中的属性详细信息、对话、文件和任务等功能。

此示例的目的是演示创建平台用户界面和体验（通过实现本机视图）的功能，同时使用 Microsoft Graph 跨平台共享公共代码并丰富解决方案。主要利用 Office 365 组将数据组织到属性中。

> **备注** 示例面向 Microsoft Graph 的试用版分支，其无法实现 [Microsoft Graph .NET 客户端 SDK](https://github.com/microsoftgraph/msgraph-sdk-dotnet)。相反，使用面向 Microsoft Graph 的内置 HTTP 堆栈来进行网络调用，以使用资源。

示例使用 [Microsoft 身份验证库 (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client) 进行身份验证，并使用 [MvvmCross](https://mvvmcross.com/) 库将[MVVM 模式](https://msdn.microsoft.com/en-us/library/hh848246.aspx) 跨平台（装有 Xamarin）。

![运行在 Android、iOS 和 UWP 项目上的示例截屏。](/Images/PM_OSes.png "运行在 Android、iOS 和 UWP 上的项目。")

### 项目

项目 | 作者
---------|----------
XamarinNativePropertyManager | [Simon Jäger](http://simonjaeger.com/) (**Microsoft**)

### 版本历史记录

|版本 |日期 |批注 |
|---------|------|----------|
|1.0 | 2016 年 8 月 4 日|初始版本 |
|1.1 | 2018 年 4月4日 | 已更新为使用 MSAL 库进行身份验证 |


## 先决条件

此示例要求如下：  

- 装有 [Xamarin](https://www.xamarin.com/visual-studio) 工作负载的 [Visual Studio 2017](https://www.visualstudio.com/downloads)
- Windows 10（[已启用开发模式](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx)）
-  一个 Office 365 账户 - 如果为 Office 365 生成示例，但没有 Office 365 账户，访问 https://developer.microsoft.com/en-us/office/dev-program 获取开发人员账户。

如果想要在此示例中运行 iOS 项目，则要求如下：

- 最新的 iOS SDK
- 最新版本的 Xcode
- Mac OS X Yosemite (10.10) 和更高版本
- [Xamarin.iOS](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/mac)

如果想要运行 Android 项目，可以使用“[适用于 Android 的 Visual Studio 模拟器](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx)。

## 注册应用程序 
 
1. 导航到 [Azure 门户 > 应用程序注册](https://go.microsoft.com/fwlink/?linkid=2083908)以注册应用。使用**工作或学校帐户**登录。 
 
2. 选择“**新注册**”。在“**注册应用程序**”页上，按如下方式设置值。 
 
* 设置“**名称**”为 **Xamarin Native PropertyManager**。 
* 将“**支持的帐户类型**”设置为“**任何组织目录中的帐户**”。 
* 保留“**重定向 URI**”为空。 
* 选择“**注册**”。 
 
3. 在 **Xamarin Native PropertyManager** 页面上，复制并保存“**应用程序（客户端）ID**”和“**目录（租户）ID**”的值。在第 7 步上将需要它们。 
 
4. 选择“**管理**”下的“**证书和密码**”。选择“**新客户端密码**”按钮。在“**说明**”中输入数值，随后选择任意“**过期**”选项并选择“**添加**”。 
 
5. 离开页面前，先复制客户端密码值。将在下一步中用到它。 
 
6. 在 Visual Studio 中打开示例解决方案，然后打开 **Constants.cs** 文件。将“**租户**”字符串更改为之前复制的 “**目录（租户） ID**” 值。同样，将 **ClientIdForAppAuthn** 字符串更改为 **应用程序（客户端） ID** 值，并将 **ClientSecret** 字符串更改为客户端密码值。 
 
7. 返回 Azure Active Directory 管理中心。选择“**API 权限**”并随后选择“**添加权限**”。在出现的窗格上，选择 **Microsoft Graph** 并随后选择“**应用程序权限**”。 
 
8. 使用“**选择权限**”搜索框来搜索下列权限：User.Read, Group.ReadWrite.All, Sites.Read.All, Files.ReadWrite.All, Tasks.ReadWrite, Directory.Read.All.在每个权限显示时，选择其复选框（请注意，选择每个权限后，它不会在列表中保持可见）。选择窗格下方选择“**添加权限**”。 
 
9. 选择“**为\[租户名称]授予管理员许可**”按钮。选择“**是**”确认显示的内容。

## 构建和调试

**注意：**如果在步骤 2 安装程序包时出现任何错误，请确保您放置该解决方案的本地路径并未太长/太深。若要解决此问题，可以将解决方案移到更接近驱动器根目录的位置。

1. 在解决方案的 **XamarinNativePropertyManager (Portable)** 项目内打开 Constants.cs 文件。

    ![Constants.cs 文件截屏。](/Images/Constants.png "Constants.cs。") 

1. 载入解决方案至 Visual Studio 中时，通过替换 **Constants.cs** 文件中“**机构**”内的 **\[TENANT\_ID\_OR\_NAME]** 值，配置示例以使用 Azure AD 租户。

    ![Constants.cs 文件机构属性截屏。](/Images/TenantId.png "机构属性。") 

1. 通过替换 **Constants.cs** 文件中 **ClientId** 属性内的 **\[CLIENT\_ID]** 值，配置示例以使用 Azure AD 应用客户端 ID。

    ![Constants.cs 文件中 ClientId 属性截屏。](/Images/ClientId.png "ClientId 属性。") 

1. 打开文件 **XamarinNativePropertyManager.Droid/Properties/AndroidManifest.xml**。使用客户端 ID 替换 `[CLIENT_ID`]值。

    > **注意：**如果正在使用 Visual Studio for Mac，确保在打开 **AndroidManifest.xml** 后单击“**资源**”选项卡。

1. 打开文件 **XamarinNativePropertyManager.iOS/Info.plist**。选择“**高级**”选项卡，然后找到“**URL 类型**”部分。使用客户端 ID 替换 `[CLIENT_ID]`。

    ![Info.plist 文件 “URL 类型”部分截屏](Images/url_in_info_plist.png)

1. 选择想要运行的项目。如果选择“通用 Windows 平台”项目，必须在 Windows 计算机上运行示例。如果想要运行 iOS 项目，需要连接至[安装有 Xamarin 工具的 Mac](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/windows/connecting-to-mac/)，或者需要在 Visual Studio for Mac 中运行项目。只要安装有 Android 模拟器，可在 Windows 或 Mac 系统上生成和运行 Android 项目。

    ![Visual Studio 工具栏的屏幕截图（UWP 被选为启动项目）。](/Images/Projects.png "选择启动项目。") 

1. 按 F5 进行构建和调试。运行此解决方案并使用个人或工作或学校帐户登录。

    > **注意**可能需要打开生成配置管理器，以确保为 UWP 项目选择“生成”和“部署”步骤。

## 运行示例

启动应用程序后，单击“**登录**”按钮以登录至组织账户。验证身份后，应用程序显示组织内的所有属性。通过填写详细信息新建属性，应用程序将为此属性预配一个新 Office 365 组。此时，可以发布消息至组对话、添加文件并创建任务。

还能够更新属性的详细信息并新建属性。在浏览器中浏览 Office 365 组，，以查找应用程序中使用的所有数据。属性详细信息存储在“**属性管理器**”组内的“**Data.xlsx**” Excel 工作簿中。 

### 平台截屏

#### Android

![在 Android 上运行的示例。](Images/PM_Android.png)

#### iOS

![在 Android 上运行的示例。](Images/PM_iOS.png)

#### UWP

![在 Android 上运行的示例。](Images/PM_UWP1.png)

## 示例如何影响你的帐户数据

首次启动此示例（Office 365 租户）时，创建名为“**属性管理器**”的 Office 365 组。在此组中，存储有托管不同属性的所有详细信息的 **Data.xlsx** 文件。

对于应用程序内创建的各属性，预配一个新 Office 365 组。在各组中，文件、对话和任务资源由应用程序使用。任务的唯一作用是可从应用程序内删除（完成）。应用程序无法删除对话文章或文件。 

## 参与

如果想要参与本示例，请参阅 [CONTRIBUTING.MD](/CONTRIBUTING.md)。

此项目已采用 [Microsoft 开放源代码行为准则](https://opensource.microsoft.com/codeofconduct/)。有关详细信息，请参阅[行为准则常见问题解答](https://opensource.microsoft.com/codeofconduct/faq/)。如有其他任何问题或意见，也可联系 [opencode@microsoft.com](mailto:opencode@microsoft.com)。

## 其他资源

- [其他 Microsoft Graph Connect 示例](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Microsoft Graph 概述](https://developer.microsoft.com/en-us/graph/docs/concepts/overview)
- [Office 开发人员代码示例](https://developer.microsoft.com/en-us/office/gallery/?filterBy=Samples)
- [Office 开发人员中心](https://developer.microsoft.com/en-us/office)
- [Simon Jäger #Office365Dev 博客](http://simonjaeger.com/)

## 版权信息
版权所有 (c) 2016 Microsoft。保留所有权利。

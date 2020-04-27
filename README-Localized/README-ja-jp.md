---
page_type: sample
products:
- ms-graph
languages:
- csharp
description: "Microsoft Graph を、完全なプロパティ管理ソリューションの唯一のバックエンド コンポーネントとして使用する方法を示します。"
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  platforms:
  - Xamarin
  createdDate: 8/3/2016 8:57:27 AM
---
# Xamarin Native 用の Microsoft Graph Property Manager のサンプル

## 目次

* [前提条件](#prerequisites)
* [アプリを登録して構成する](#register-and-configure-the-app)
* [ビルドとデバッグ](#build-and-debug)
* [サンプルを実行する](#run-the-sample)
* [サンプルによるアカウント データへの影響](#how-the-sample-affects-your-account-data)
* [貢献](#contributing)
* [その他のリソース](#additional-resources)

このサンプル プロジェクトは、Microsoft Graph を完全なプロパティ管理ソリューションの唯一のバックエンド コンポーネントとして使用する方法を示します。サンプルは、Xamarin Native アプリのプロパティの詳細、会話、ファイル、タスクなどの機能が含まれています。

このサンプルの目的は、プラットフォーム ユーザー インターフェイスとエクスペリエンスを (ネイティブ ビューを実装することで) 作成できることを示しています。また、プラットフォーム間で共通のコードを共有し、Microsoft Graph を使用してソリューションを過給します。データをプロパティに整理するために、Office 365 グループを大いに活用します。

> **注** サンプルは、Microsoft Graph のベータ分岐を対象としています。[Microsoft Graph .NET クライアント SDK](https://github.com/microsoftgraph/msgraph-sdk-dotnet) は実装されていません。代わりに、Microsoft Graph に向けた組み込み HTTP スタックを使用して、ネットワーク通話を行い、リソースを使用します。

サンプルでは、認証と [MvvmCross](https://mvvmcross.com/) ライブラリ用に [Microsoft Authentication Library (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client) を使用して、[MVVM パターン](https://msdn.microsoft.com/en-us/library/hh848246.aspx)を Xamarin を使用してプラットフォーム間で移動します。

![Android、iOS、UWP プロジェクトで実行されているサンプルのスクリーンショット。](/Images/PM_OSes.png "Android、iOS、UWP で実行されているサンプル。")

### プロジェクト

プロジェクト | 作成者
---------|----------
XamarinNativePropertyManager | [Simon Jäger](http://simonjaeger.com/) (**Microsoft**)

### バージョン履歴

| バージョン | 日付 | コメント |
|---------|------|----------|
| 1.0 | 2016 年 8 月 4 日 | 最初のリリース |
| 1.1 | 2018 年 4 月 4 日 | 認証に MSAL ライブラリを使用するように更新 |


## 前提条件

このサンプルを実行するには次のものが必要です。  

- [Xamarin](https://www.xamarin.com/visual-studio) のワークロードがインストールされた [Visual Studio 2017](https://www.visualstudio.com/downloads)
- Windows 10 ([開発モードが有効](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
-  Office 365 アカウント - Office 365 用に構築していて、Office 365 テナントが存在しない場合は、https://developer.microsoft.com/en-us/office/dev-program で開発者アカウントを取得します。

このサンプルで iOS プロジェクトを実行する場合は、以下のものが必要です:

- 最新の iOS SDK
- 最新バージョンの Xcode
- Mac OS X Yosemite (10.10) 以上
- [Xamarin.iOS](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/mac)

Android プロジェクトを実行する場合は、[Visual Studio Emulator for Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) を使用できます。

## アプリケーションの登録 
 
1. [Azure ポータル - アプリの登録](https://go.microsoft.com/fwlink/?linkid=2083908)ページに移動してアプリを登録します。**職場または学校のアカウント**を使用してログインします。 
 
2. \[**新規登録**] を選択します。\[**アプリケーションの登録**] ページで、次のように値を設定します。 
 
* \[**名前**] を **Xamarin Native PropertyManager** に設定します。 
* \[**サポートされているアカウントの種類**] を \[**任意の組織のディレクトリ内のアカウント**] に設定します。 
* \[**リダイレクト URI**] は空のままにします。 
* \[**登録**] を選択します。 
 
3. **Xamarin Native PropertyManager** ページで、**アプリケーション (クライアント) ID** と**ディレクトリ (テナント) ID** の値をコピーして保存します。これらの値は、手順 7 で必要になります。 
 
4. \[**管理**] で \[**証明書とシークレット**] を選択します。\[**新しいクライアント シークレット**] ボタンを選択します。\[**説明**] に値を入力し、\[**有効期限**] で任意のオプションを選び、\[**追加**] を選択します。 
 
5. このページを離れる前に、クライアント シークレットの値をコピーします。この値は次の手順で必要になります。 
 
6. サンプル ソリューションを Visual Studio で開き、ファイル **Constants.cs** を開きます。\[**テナント**] 文字列を先ほどコピーした **Directory (テナント) ID** 値に変更します。同様に、\[**ClientIdForAppAuthn**] 文字列を**アプリケーション (クライアント) ID** 値に変更し、\[**ClientSecret**] 文字列をクライアント シークレット値に変更します。 
 
7. Azure Active Directory 管理センターに戻ります。\[**API のアクセス許可**]、\[**アクセス許可の追加**] の順に選択します。表示されるパネルで、\[**Microsoft Graph**] を選択し、\[**アプリケーションのアクセス許可**] を選択します。 
 
8. \[**アクセス許可の選択**] 検索ボックスを使用して次のアクセス許可を検索します。User.Read、Group.ReadWrite.All、Sites.Read.All、Files.ReadWrite.All、Tasks.ReadWrite、Directory.Read.All.表示された各権限のチェック ボックスをオンにします (各権限を選択しても、権限は一覧に表示されたままにはなりません)。パネル下部にある \[**アクセス許可の追加**] ボタンを選択します。 
 
9. \[**\[テナント名] に管理者の同意を与えます**] ボタンを選択します。確認メッセージが表示されたら、\[**はい**] を選択します。

## ビルドとデバッグ

**メモ:**手順 2 でパッケージのインストール中にエラーが発生した場合は、ソリューションを保存したローカル パスが長すぎたり深すぎたりしていないかご確認ください。この問題は、ソリューションをドライブのルート近くに移動すると解決します。

1. ソリューションの **XamarinNativePropertyManager (ポータブル)** プロジェクト内で Constants.cs ファイルを開きます。

    ![Constants.cs ファイルのスクリーンショット。](/Images/Constants.png "Constants.cs。") 

1. Visual Studio でソリューションを読み込んだ後、**Constants.cs** ファイルの **Authority** プロパティの**\[TENANT\_ID\_OR\_NAME]** 値を置き換えて、Azure AD テナントを使用するようにサンプルを構成します。

    ![Constants.cs ファイルの Authority プロパティのスクリーンショット。](/Images/TenantId.png "Authority プロパティ。") 

1. **Constants.cs** ファイルの **ClientId** プロパティの **\[CLIENT\_ID]** 値を置き換えて、Azure AD アプリケーションのクライアント ID を使用するようにサンプルを構成します。

    ![Constants.cs ファイルの ClientId プロパティのスクリーンショット。](/Images/ClientId.png "ClientId プロパティ。") 

1. **XamarinNativePropertyManager.Droid/Properties/AndroidManifest.xml** ファイルを開きます。`[CLIENT_ID`] の値をクライアント ID で置き換えます。

    > **注:**Visual Studio for Mac を使用している場合は、**AndroidManifest.xml** を開いた後、必ず \[**ソース**] タブをクリックします。

1. **XamarinNativePropertyManager.iOS/Info.plist** ファイルを開きます。\[**詳細**] タブを選択し、\[**URL の種類**] セクションに移動します。`[CLIENT_ID]` を使用しているクライアント ID で置き換えます。

    ![Info.plist ファイルの \[URL の種類] セクションのスクリーンショット](Images/url_in_info_plist.png)

1. 実行するプロジェクトを選択します。ユニバーサル Windows プラットフォーム プロジェクトを選択した場合は、Windows マシンでサンプルを実行する必要があります。iOS プロジェクトを実行する場合は、[Xamarin ツールがインストールされている Mac](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/windows/connecting-to-mac/) に接続するか、または Visual Studio for Mac でプロジェクトを構築して実行する必要があります。Android プロジェクトは、Android エミュレーターがインストールされている限り、Windows または Mac のいずれかに構築して実行できます。

    ![スタートアップ プロジェクトとして UWP が選択されている Visual Studio ツールバーのスクリーンショット。](/Images/Projects.png "スタートアップ プロジェクトを選択します。") 

1. F5 キーを押して、ビルドとデバッグを実行します。　ソリューションを実行し、個人用アカウント、あるいは職場または学校のアカウントのいずれかでサインインします。

    > **注** ビルド構成マネージャーを開いて、ビルドと展開の手順が UWP プロジェクトに対して選択されていることを確認することが必要な場合があります。

## サンプルを実行する

アプリを起動した後、\[**サインイン**] ボタンをクリックして、組織のアカウントにサインインします。認証が完了すると、アプリで組織のすべてのプロパティが表示されます。詳細を入力して新しいものを作成すると、アプリによってこのプロパティの新しい Office 365 グループがプロビジョニングされます。この時点で、グループの会話にメッセージを投稿し、ファイルを追加し、タスクを作成できるようになります。

プロパティの詳細を更新し、新しいプロパティを作成することもできます。ブラウザーで Office 365 グループを探索し、アプリ内で使用されているすべてのデータを検索します。プロパティの詳細は、**プロパティ マネージャー** グループにある **Data.xlsx** という名前の Excel ブックに格納されます。 

### プラットフォームのスクリーンショット

#### Android

![Android で実行中のサンプルです。](Images/PM_Android.png)

#### iOS

![Android で実行中のサンプルです。](Images/PM_iOS.png)

#### UWP

![Android で実行中のサンプルです。](Images/PM_UWP1.png)

## サンプルによるアカウント データへの影響

このサンプルを初めて使用する場合 (Office 365 テナント内) には、**プロパティ マネージャー** という名前の Office 365 グループが作成されます。このグループには、さまざまなプロパティの詳細がすべてホストされる **Data.xlsx** ファイルが保存されます。。

アプリ内に作成される各プロパティに対して、新しい Office 365 グループがプロビジョニングされます。グループごとに、ファイル、会話、タスク リソースがアプリで使用されます。タスクは、アプリの内部から削除 (完了) できる唯一のものです。アプリでは、会話の投稿やファイルを削除することはできません。 

## 投稿

このサンプルに投稿する場合は、[CONTRIBUTING.MD](/CONTRIBUTING.md) を参照してください。

このプロジェクトでは、[Microsoft Open Source Code of Conduct (Microsoft オープン ソース倫理規定)](https://opensource.microsoft.com/codeofconduct/) が採用されています。詳細については、「[Code of Conduct の FAQ](https://opensource.microsoft.com/codeofconduct/faq/)」を参照してください。また、その他の質問やコメントがあれば、[opencode@microsoft.com](mailto:opencode@microsoft.com) までお問い合わせください。

## その他のリソース

- [その他の Microsoft Graph Connect のサンプル](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Microsoft Graph の概要](https://developer.microsoft.com/en-us/graph/docs/concepts/overview)
- [Office 開発者向けコード サンプル](https://developer.microsoft.com/en-us/office/gallery/?filterBy=Samples)
- [Office デベロッパー センター](https://developer.microsoft.com/en-us/office)
- [\#Office365Dev の Simon Jäger のブログ](http://simonjaeger.com/)

## 著作権
Copyright (c) 2016 Microsoft.All rights reserved.

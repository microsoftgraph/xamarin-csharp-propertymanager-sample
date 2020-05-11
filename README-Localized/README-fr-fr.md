---
page_type: sample
products:
- ms-graph
languages:
- csharp
description: "Montre comment utiliser Microsoft Graph comme composant de base unique pour une solution complète de gestion des propriétés."
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  platforms:
  - Xamarin
  createdDate: 8/3/2016 8:57:27 AM
---
# Exemple de gestionnaire de propriétés Microsoft Graph pour Xamarin Native

## Table des matières

* [Conditions préalables](#prerequisites)
* [Enregistrement et configuration de l’application](#register-and-configure-the-app)
* [Création et débogage](#build-and-debug)
* [Exécuter l’exemple](#run-the-sample)
* [Impact de l’exemple sur les données de votre compte](#how-the-sample-affects-your-account-data)
* [Contribution](#contributing)
* [Ressources supplémentaires](#additional-resources)

Cet exemple montre comment utiliser Microsoft Graph comme composant principal unique pour une solution complète de gestion des propriétés. Les exemples couvrent des fonctionnalités telles que les détails des propriétés, les conversations, les fichiers et les tâches dans une application Xamarin Native.

Cet exemple a pour but de montrer la capacité à créer des interfaces utilisateur et des expériences de plateforme ( par la mise en œuvre de vues natives), tout en partageant un code commun pour toutes les plateformes et en surchargeant la solution avec Microsoft Graph. Il s'appuie fortement sur les groupes d'Office 365 afin d'organiser les données en propriétés.

> **Remarque :** l'exemple vise la branche bêta de Microsoft Graph que le [Kit de développement logiciel (SDK) du client Microsoft Graph .NET](https://github.com/microsoftgraph/msgraph-sdk-dotnet) ne met pas en œuvre. Au contraire, des appels réseau sont effectués vers Microsoft Graph à l'aide de la pile HTTP intégrée pour consommer ses ressources.

Les exemples utilisent la [Bibliothèque d'authentification de Microsoft (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client) pour l'authentification et la bibliothèque [MvvmCross](https://mvvmcross.com/) pour faire passer le [modèle MVVM](https://msdn.microsoft.com/en-us/library/hh848246.aspx) d'une plate-forme à l'autre à l’aide de Xamarin.

![Captures d’écran de l’exemple exécuté sur un projet Android, iOS et UWP. ](/Images/PM_OSes.png "Exemple exécuté sur Android, iOS et UWP.")

### Projet

Projet | Auteur(s)
---------|----------
XamarinNativePropertyManager | [Simon Jäger](http://simonjaeger.com/) (**Microsoft**)

### Historique des versions

| Version | Date | Commentaires |
|---------|------|----------|
| 1.0 | 4 août 2016 | Publication initiale |
| 1.1 | 4 août 2018 | Mise à jour pour utiliser la bibliothèque MSAL pour authentification |


## Conditions préalables

Cet exemple nécessite les éléments suivants :  

- [Visual Studio 2017](https://www.visualstudio.com/downloads) avec la charge de travail [Xamarin](https://www.xamarin.com/visual-studio) installée
- Windows 10 ([avec mode de développement](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
-  Un compte Office 365 – Si vous créez pour Office 365 et que vous ne disposez pas de client Office 365, procurez-vous un compte développeur à l'adresse suivante : https://developer.microsoft.com/en-us/office/dev-program.

Si vous souhaitez exécuter le projet iOS dans cet exemple, vous avez besoin des éléments suivants :

- Le dernier kit de développement logiciel iOS
- La dernière version de Xcode
- Mac OS X Yosemite (10.10) et versions ultérieures
- [Xamarin.iOS](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/mac)

Vous pouvez utiliser l’[Émulateur Visual Studio pour Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) si vous souhaitez exécuter le projet Android.

## Inscription de l’application 
 
1. Accédez au [Portail Microsoft Azure : enregistrement des applications](https://go.microsoft.com/fwlink/?linkid=2083908) pour enregistrer votre application. Connectez-vous en utilisant un **compte professionnel ou scolaire**. 
 
2. Sélectionnez **Nouvelle inscription**. Sur la page **Inscrire une application**, définissez les valeurs comme suit. 
 
* Attribuez un **Nom** à **Xamarin Native PropertyManager**. 
* Définissez les **Types de comptes pris en charge** sur **Comptes figurant dans un annuaire organisationnel**. 
* Laissez **Redirect URI** vide. 
* Choisissez **Inscrire**. 
 
3. Sur la page **Xamarin Native PropertyManager**, copiez et enregistrez les valeurs pour l’**ID de l’application (client)** et l’**ID de répertoire (client)**. Vous en aurez besoin lors de l'étape 7. 
 
4. Sélectionnez **Certificats et secrets** sous **Gérer**. Sélectionnez le bouton **Nouvelle clé secrète client**. Entrez une valeur dans la **Description**, sélectionnez une option pour **Expire le**, puis choisissez **Ajouter**. 
 
5. Copiez la valeur de la clé secrète client avant de quitter cette page. Vous en aurez besoin à l’étape suivante. 
 
6. Ouvrez la solution d'exemple dans Visual Studio, puis ouvrez le fichier **Constants.cs**. Remplacez la chaîne **Client **par la valeur d'**ID de Directory (locataire)** que vous avez précédemment copiée. De la même façon, remplacez la chaîne de **ClientIdForAppAuthn** par la valeur de l'**ID de l’application (client)** et remplacez la chaîne **ClientSecret** par la valeur de la clé secrète cliente. 
 
7. Retournez au Portail de gestion Azure Active Directory. Sélectionnez **Autorisations API**, puis **Ajouter une autorisation**. Dans le volet qui apparaît, sélectionnez **Microsoft Graph**, puis choisissez **Autorisations d'application**. 
 
8. Utilisez la zone de recherche **Sélectionnez les autorisations** pour trouver les autorisations qui suivent : User.Read, Group.ReadWrite.All, Sites.Read.All, Files.ReadWrite.All, Tasks.ReadWrite, Directory.Read.All. Sélectionnez la case à cocher pour chacune des autorisations comme elle apparaît (notez que les autorisations ne restent pas visibles dans la liste lorsque vous sélectionnez chacune d’elles). Sélectionner le bouton **Ajouter des autorisations** en bas de la boîte de dialogue. 
 
9. Sélectionnez le bouton **Accorder l’autorisation administrateur pour \[nom du client]**. Sélectionnez **Oui** pour confirmer ce qui s’affiche.

## Création et débogage

**Remarque :** si vous constatez des erreurs pendant l’installation des packages à l’étape 2, vérifiez que le chemin d’accès local où vous avez sauvegardé la solution n’est pas trop long/profond. Pour résoudre ce problème, il vous suffit de déplacer la solution dans un dossier plus près du répertoire racine de votre lecteur.

1. Ouvrez le fichier Constants.cs dans le projet **XamarinNativePropertyManager (Portable)** de la solution.

    ![Captures d’écran du fichier Constants.cs.](/Images/Constants.png "Constants.cs.") 

1. Après avoir chargé la solution dans Visual Studio, configurez l'exemple pour utiliser le client Azure AD en remplaçant la valeur **\[TENANT\_ID\_OR\_NAME]** de la propriété **Autorité** dans le fichier **Constants.cs**.

    ![Captures d’écran de la propriété Autorité dans le fichier Constants.cs.](/Images/TenantId.png "Propriété Autorité.") 

1. Configurez l'exemple pour utiliser l'ID client de votre application Azure AD en remplaçant la valeur **\[CLIENT\_ID]** de la propriété **ClientId** dans le fichier **Constants.cs**.

    ![Captures d’écran de la propriété ClientId dans le fichier Constants.cs.](/Images/ClientId.png "Propriété ClientId.") 

1. Ouvrez le fichier **XamarinNativePropertyManager.Droid/Properties/AndroidManifest.xml**. Remplacez la valeur `[CLIENT_ID`] par votre ID client.

    > **Remarque :** Si vous utilisez Visual Studio pour Mac, assurez-vous de cliquer sur l'onglet **Source** après avoir ouvert **AndroidManifest.xml**.

1. Ouvrez le fichier **XamarinNativePropertyManager.iOS/Info.plist**. Sélectionnez l'onglet **Avancé** et trouvez la section **Types d'URL**. Remplacez `[CLIENT_ID]` par votre ID client.

    ![Une capture d'écran de la section Types d'URL du fichier Info.plist](Images/url_in_info_plist.png)

1. Sélectionnez le projet à exécuter. Si vous sélectionnez le projet Universal Windows Platform – plateforme Windows universelle, vous devez exécuter l'exemple sur un ordinateur Windows. Si vous voulez exécuter le projet iOS, vous devez soit vous connecter à un [Mac sur lequel les outils Xamarin](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/windows/connecting-to-mac/) sont installés, soit créer et exécuter le projet dans Visual Studio pour Mac. Le projet Android peut être créé et exécuté sur Windows ou Mac, dès lors que l'émulateur Android est installé.

    ![Capture d'écran de la barre d'outils Visual Studio, avec UWP sélectionné comme projet de démarrage. ](/Images/Projects.png "Sélectionnez le projet de démarrage.")   

1. Appuyez sur F5 pour créer et déboguer l’application. Exécutez la solution et connectez-vous avec votre compte personnel, professionnel ou scolaire.

    > **Remarque**: vous devrez ouvrir le gestionnaire de configuration de Build pour vous assurer que les étapes de création et de déploiement sont sélectionnées pour le projet UWP.

## Exécuter l’exemple

Une fois l'application lancée, cliquez sur le bouton **Connexion** pour vous connecter au compte professionnel. Une fois l'authentification effectuée, l'application affiche toutes les propriétés de votre organisation. Créez-en une nouvelle en indiquant les détails et l'application met en service un nouveau groupe Office 365 pour cette propriété. À ce stade, vous pouvez publier des messages dans les conversations de groupe, ajouter des fichiers et créer des tâches.

Vous pouvez également mettre à jour les détails de la propriété et en créer de nouvelles. Explorez les groupes Office 365 dans votre navigateur pour rechercher toutes les données utilisées dans l’application. Les détails de la propriété sont stockés dans un classeur Excel nommé **Data.xlsx**, situé dans le groupe des **Gestionnaires de propriété**. 

### Captures d’écran de plateforme

#### Android

![Exemple exécuté sur Android.](Images/PM_Android.png)

#### iOS

![Exemple exécuté sur Android.](Images/PM_iOS.png)

#### UWP

![Exemple exécuté sur Android.](Images/PM_UWP1.png)

## Impact de l’exemple sur les données de votre compte

Lorsque cet exemple est lancé pour la première fois (dans le client Office 365), un groupe Office 365 nommé **Gestionnaires de propriétés** est créé. Dans ce groupe, un fichier **Data.xlsx** est stocké et héberge tous les détails des différentes propriétés.

Pour chaque propriété créée dans l'application, un nouveau groupe Office 365 est constitué. Dans chaque groupe, les fichiers, les ressources des conversations et des tâches sont utilisés par l'application. Les tâches constituent l'unique opération qui peut être supprimée (réalisée) à partir de l'application. L'application n'offre pas la possibilité de supprimer des billets de conversation ou des fichiers. 

## Contribution

Si vous souhaitez contribuer à cet exemple, voir [CONTRIBUTING.MD](/CONTRIBUTING.md).

Ce projet a adopté le [code de conduite Open Source de Microsoft](https://opensource.microsoft.com/codeofconduct/). Pour en savoir plus, reportez-vous à la [FAQ relative au code de conduite](https://opensource.microsoft.com/codeofconduct/faq/) ou contactez [opencode@microsoft.com](mailto:opencode@microsoft.com) pour toute question ou tout commentaire.

## Ressources supplémentaires

- [Autres exemples de connexion avec Microsoft Graph](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Présentation de Microsoft Graph](https://developer.microsoft.com/en-us/graph/docs/concepts/overview)
- [Exemples de code du développeur Office](https://developer.microsoft.com/en-us/office/gallery/?filterBy=Samples)
- [Centre de développement Office](https://developer.microsoft.com/en-us/office)
- [Blog de Simon Jäger sur #Office365Dev](http://simonjaeger.com/)

## Copyright
Copyright (c) 2016 Microsoft. Tous droits réservés.

---
page_type: sample
products:
- ms-graph
languages:
- csharp
description: "Demonstra como usar o Microsoft Graph como o único componente de back-end para uma solução completa de gerenciamento de propriedades."
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  platforms:
  - Xamarin
  createdDate: 8/3/2016 8:57:27 AM
---
# Exemplo do Microsoft Graph Property Manager para Xamarin Native

## Sumário

* [Pré-requisitos](#prerequisites)
* [Registrar e configurar o aplicativo](#register-and-configure-the-app)
* [Criar e depurar](#build-and-debug)
* [Executar o exemplo](#run-the-sample)
* [Como o exemplo afeta os dados da conta](#how-the-sample-affects-your-account-data)
* [Colaboração](#contributing)
* [Recursos adicionais](#additional-resources)

Este projeto de exemplo demonstra como usar o Microsoft Graph como o único componente de back-end para uma solução completa de gerenciamento de propriedades. Os exemplos abrangem recursos como detalhes de propriedade, conversas, arquivos e tarefas em um aplicativo Xamarin Native.

O objetivo deste exemplo é demonstrar a capacidade de criar interfaces e experiências com o usuário da plataforma (implementando visualizações nativas), compartilhando código comum entre plataformas e incrementando a solução com o Microsoft Graph. Ele utiliza fortemente os grupos do Office 365 para organizar dados em propriedades.

> **Observação** O exemplo tem como alvo a ramificação beta do Microsoft Graph, que o [SDK do Microsoft Graph .NET Client](https://github.com/microsoftgraph/msgraph-sdk-dotnet) não implementa. Em vez disso, as chamadas de rede estão sendo feitas com a pilha HTTP incorporada em direção ao Microsoft Graph para consumir seus recursos.

Os exemplos usam a [Microsoft Authentication Library (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client) para autenticação e a biblioteca [MvvmCross](https://mvvmcross.com/) para trazer o [padrão MVVM](https://msdn.microsoft.com/en-us/library/hh848246.aspx) para plataformas com o Xamarin.

![Capturas de tela do exemplo em execução no projeto Android, iOS e UWP.](/Images/PM_OSes.png "Exemplo em execução no Android, iOS e UWP.")

### Project

Projeto | Autor (es)
--------- | ----------
XamarinNativePropertyManager | [Simon Jäger](http://simonjaeger.com/)(**Microsoft**)

### Histórico de versão

| Versão | Data | Comentários |
| --------- | ------ | ---------- |
| 1.0 4 de agosto de 2016 | Versão inicial |
| 1.1 | 4 de abril de 2018 | Atualizada para usar a biblioteca MSAL para autenticação |


## Pré-requisitos

Esse exemplo requer o seguinte:  

- [Visual Studio 2017](https://www.visualstudio.com/downloads) com a carga de trabalho do [Xamarin](https://www.xamarin.com/visual-studio) instalada
- Windows 10 ([habilitado para o modo de desenvolvimento](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
-  Uma conta do Office 365 - Se você estiver criando para o Office 365 e não tiver um locatário do Office 365, obtenha uma conta de desenvolvedor em: https://developer.microsoft.com/en-us/office/dev-program.

Se quiser executar o projeto do iOS neste exemplo, você precisará do seguinte:

- O SDK mais recente do iOS
- A versão mais recente do Xcode
- Mac OS X Yosemite (10.10) e versões superiores
- [Xamarin.iOS](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/mac)

Você pode usar o [Emulador do Visual Studio para Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) se desejar executar o projeto Android.

## Registrar o aplicativo 
 
1. Navegue até o [portal do Azure-registros de aplicativo](https://go.microsoft.com/fwlink/?linkid=2083908) para registrar seu aplicativo. Faça o login usando uma **Conta Corporativa ou de Estudante**. 
 
2. Selecione **Novo registro**. Na página **Registrar um aplicativo**, defina os valores da seguinte forma. 
 
* Defina **Nome** como **Xamarin Native PropertyManager**. 
* Defina os **Tipos de conta com suporte** para **Contas em qualquer diretório organizacional**. 
* Deixe o **URI de Redirecionamento** vazio. 
* Escolha **Registrar**. 
 
3. Na página **Xamarin Native PropertyManager**, copie e salve os valores para o **ID do aplicativo (cliente)** e o **ID do diretório (locatário)**. Você precisará deles na etapa 7. 
 
4. Selecione **Certificados e segredos** em **Gerenciar**. Selecione o botão **Novo segredo do cliente**. Insira um valor em **Descrição**, selecione qualquer uma das opções para **Expira** e escolha **Adicionar**. 
 
5. Copie o valor do segredo do cliente antes de sair desta página. Você precisará dele na próxima etapa. 
 
6. Abra a solução de exemplo no Visual Studio e, em seguida, abra o arquivo **Constants.cs**. Altere a cadeia de caracteres do**Locatário** para o valor do **ID de Directory (locatário)** que você copiou anteriormente. Da mesma forma, altere a cadeia de caracteres **ClientIdForAppAuthn** para o valor da **ID do aplicativo (cliente)** e altere a cadeia de caracteres **ClientSecret** para o valor de segredo do cliente. 
 
7. Retorne para o centro de gerenciamento do Azure Active Directory.  Selecione **Permissões da API** e, em seguida, selecione **Adicionar uma permissão**. No painel exibido, escolha **Microsoft Graph** e escolha **Permissões do aplicativo**. 
 
8. Use a caixa de pesquisa **Selecionar permissões** para pesquisar as seguintes permissões: User.Read, Group.ReadWrite.All, Sites.Read.All, Files.ReadWrite.All, Tasks.ReadWrite, Directory.Read.All. Marque a caixa de seleção para cada permissão como aparece (observe que as permissões não permanecem visíveis na lista ao selecionar cada uma delas). Selecione o botão **Adicionar permissões** na parte inferior do painel. 
 
9. Escolha o botão **Conceder consentimento de administrador para \[nome do locatário]**. Marque **Sim** para a confirmação exibida.

## Criar e depurar

**Observação:** caso receba mensagens de erro durante a instalação de pacotes na etapa 2, verifique se o caminho para o local onde você colocou a solução não é muito longo ou extenso. Para resolver esse problema, coloque a solução junto à raiz da unidade.

1. Abra o arquivo Constants.cs dentro do projeto **XamarinNativePropertyManager (Portable)** da solução.

    ![Capturas de tela do arquivo Constants.cs. ](/Images/Constants.png "Constants.cs.") 

1. Depois de carregar a solução no Visual Studio, configure o exemplo para usar seu locatário do Azure AD, substituindo o valor **\[TENANT\_ID\_OR\_NAME]** na propriedade **Authority** no arquivo **Constants.cs**.

    ![Capturas de tela da propriedade Authority no arquivo Constants.cs. ](/Images/TenantId.png "Propriedade Authority.") 

1. Configure o exemplo para usar sua ID de cliente do aplicativo Azure AD, substituindo o valor **\[CLIENT\_ID]** na propriedade **ClientId** no arquivo **Constants.cs**.

    ![Capturas de tela da propriedade ClientId no arquivo Constants.cs.](/Images/ClientId.png "Propriedade ClientId.") 

1. Abra o arquivo **XamarinNativePropertyManager.Droid/Properties/AndroidManifest.xml**. Substitua o valor `[CLIENT_ID`] pela sua ID de cliente.

    > **Observação:** Se você estiver usando o Visual Studio para Mac, certifique-se de clicar na guia **Origem** depois de abrir o **AndroidManifest.xml**.

1. Abra o arquivo **XamarinNativePropertyManager.iOS/Info.plist**. Selecione a guia **Avançado** e localize a seção **Tipos de URL**. Substitua `[CLIENT_ID]` pela sua ID de cliente.

    ![Uma captura de tela da seção Tipos de URL do arquivo Info.plist](Images/url_in_info_plist.png)

1. Escolha o projeto que você deseja executar. Se você selecionar o projeto Plataforma Universal do Windows, deverá executar o exemplo em um computador Windows. Se você deseja executar o projeto iOS, é necessário conectar-se a um [Mac com as ferramentas Xamarin](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/windows/connecting-to-mac/) instaladas, ou criar e executar o projeto no Visual Studio para Mac. O projeto Android pode ser criado e executado no Windows ou Mac, desde que o emulador do Android esteja instalado.

    ![Captura de tela da barra de ferramentas do Visual Studio, com UWP selecionado como o projeto de inicialização.](/Images/Projects.png "Selecione o projeto de inicialização.") 

1. Pressione F5 para criar e depurar. Execute a solução e entre com sua conta pessoal ou sua conta comercial ou escolar.

    > **Observação** Pode ser necessário abrir o Gerenciador de Configurações de Compilação para garantir que as etapas de Compilar e Implantar estejam selecionadas para o projeto UWP.

## Execute o exemplo

Após iniciar o aplicativo, clique no botão **Entrar** para entrar em sua conta organizacional. Após a autenticação, o aplicativo exibe todas as propriedades da sua organização. Crie uma nova preenchendo os detalhes e o aplicativo provisionará um novo grupo do Office 365 para essa propriedade. Nesse ponto, você poderá postar mensagens nas conversas em grupo, adicionar arquivos e criar tarefas.

Você também poderá atualizar os detalhes da propriedade e criar novas. Explore os grupos do Office 365 no seu navegador para encontrar todos os dados usados no aplicativo. Os detalhes da propriedade são armazenados em uma pasta de trabalho do Excel denominada **Data.xlsx**, localizada no grupo **Gerenciadores de Propriedades**. 

### Capturas de tela da plataforma

#### Android

![Exemplo em execução no Android.](Images/PM_Android.png)

#### iOS

![Exemplo em execução no Android.](Images/PM_iOS.png)

#### UWP

![Exemplo em execução no Android.](Images/PM_UWP1.png)

## Como o exemplo afeta os dados da conta

Quando esse exemplo é iniciado pela primeira vez (no locatário do Office 365), um grupo do Office 365 chamado **Gerenciadores de Propriedades** é criado. Nesse grupo, é armazenado um arquivo **Data.xlsx** que hospeda todos os detalhes das diferentes propriedades.

Para cada propriedade criada no aplicativo, um novo grupo do Office 365 é provisionado. Em cada grupo, os arquivos, conversas e recursos de tarefas são usados pelo aplicativo. As tarefas são a única coisa que pode ser excluída (concluída) de dentro do aplicativo. O aplicativo não permite excluir postagens ou arquivos de conversa. 

## Colaboração

Se quiser contribuir para esse exemplo, confira [CONTRIBUTING.MD](/CONTRIBUTING.md).

Este projeto adotou o [Código de Conduta de Código Aberto da Microsoft](https://opensource.microsoft.com/codeofconduct/).  Para saber mais, confira as [Perguntas frequentes sobre o Código de Conduta](https://opensource.microsoft.com/codeofconduct/faq/) ou entre em contato pelo [opencode@microsoft.com](mailto:opencode@microsoft.com) se tiver outras dúvidas ou comentários.

## Recursos adicionais

- [Outros exemplos de conexão usando o Microsoft Graph](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Visão geral do Microsoft Graph](https://developer.microsoft.com/en-us/graph/docs/concepts/overview)
- [Exemplos de código para desenvolvedores do Office](https://developer.microsoft.com/en-us/office/gallery/?filterBy=Samples)
- [Centro de Desenvolvimento do Office](https://developer.microsoft.com/en-us/office)
- [Blog de Simon Jäger no #Office365Dev](http://simonjaeger.com/)

## Direitos autorais
Copyright © 2016 Microsoft. Todos os direitos reservados.

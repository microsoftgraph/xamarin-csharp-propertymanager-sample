---
page_type: sample
products:
- ms-graph
languages:
- csharp
description: "Demuestra cómo usar el Microsoft Graph como el único componente de fondo para una solución completa de administración de propiedades"
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  platforms:
  - Xamarin
  createdDate: 8/3/2016 8:57:27 AM
---
# Muestra de Microsoft Graph Property Manager para un nativo de Xamarin

## Tabla de contenido

* [Requisitos previos](#prerequisites)
* [Registrar y configurar la aplicación](#register-and-configure-the-app)
* [Compilar y depurar](#build-and-debug)
* [Ejecutar la muestra](#run-the-sample)
* [Cómo afecta la muestra a los datos de su cuenta](#how-the-sample-affects-your-account-data)
* [Colaboradores](#contributing)
* [Recursos adicionales](#additional-resources)

Este proyecto de muestra demuestra cómo utilizar el Microsoft Graph como único componente de fondo para una solución completa de gestión de la propiedad. Las muestras cubren características como detalles de la propiedad, conversaciones, archivos y tareas en una aplicación de Xamarin Native.

El propósito de esta muestra es demostrar la capacidad de crear interfaces y experiencias de usuario de plataforma (mediante la implementación de vistas nativas), a la vez que se comparte un código común entre las plataformas y se sobrecarga la solución con el Microsoft Graph. Aprovecha fuertemente los grupos de Office 365 para organizar los datos en propiedades.

> **Nota** La muestra se dirige a la rama beta del Microsoft Graph, que el [cliente del SDK de Microsoft Graph .NET](https://github.com/microsoftgraph/msgraph-sdk-dotnet) no implementa. En cambio, las llamadas de red se hacen con la pila HTTP incorporada hacia el Microsoft Graph para consumir sus recursos.

En los ejemplos se usa el[Biblioteca de autenticación de Microsoft (MSAL)](https://www.nuget.org/packages/Microsoft.Identity.Client) para la autenticación y la biblioteca MvvmCross para que el patrón MVVMa través de las plataformas con Xamarin.

![Capturas de pantalla de la muestra corriendo en Android, iOS y el proyecto UWP.](/Images/PM_OSes.png "La muestra funciona con Android, iOS y UWP.")

### Project

Project | Autor(es)
---------|----------
XamarinNativePropertyManager | [Simon Jäger](http://simonjaeger.com/) (**Microsoft**)

### Historial de versiones

| Versión | fecha | comentarios |
|---------|------|----------|
| 1.0 | 4 de agosto de 2016 | lanzamiento inicial|
|1.1| 4 de abril de 2018 | actualizado para usar la biblioteca de MSAL para la autentificación.


## Requisitos previos

Este ejemplo necesita lo siguiente:  

- [Visual Studio 2017](https://www.visualstudio.com/downloads) con la carga de trabajo [Xamarin](https://www.xamarin.com/visual-studio) instalado
- Windows 10 ([modo de desarrollo habilitado](https://msdn.microsoft.com/library/windows/apps/xaml/dn706236.aspx))
-  Una cuenta de Office 365: si estás construyendo para Office 365 y te falta un inquilino de Office 365, consigue una cuenta de desarrollador en: https://developer.microsoft.com/en-us/office/dev-program.

Si quiere ejecutar el proyecto iOS en esta muestra, necesitará lo siguiente:

- El SDK de iOS más reciente
- La versión de Xcode más reciente
- Mac OS X Yosemite (10.10) y superior
- [Xamarin.iOS](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/mac)

Puede usar el[emulador de Visual Studio para Android](https://www.visualstudio.com/features/msft-android-emulator-vs.aspx) si desea ejecutar el proyecto Android.

## Registrar la aplicación 
 
1. Diríjase a el [registro de aplicaciones de Azure Portal](https://go.microsoft.com/fwlink/?linkid=2083908) para registrar su aplicación. Inicie sesión con **una cuenta profesional o educativa**. 
 
2. Haga clic en **Nuevo registro**. En la página **Registrar una aplicación**, establezca los valores siguientes. 
 
* Establezca **nombre** en **Xamarin Native PropertyManager** 
* Establezca **los tipos de cuenta compatibles** en las**Cuentas en cualquier directorio de la organización**. 
* Deje vacía la opción de **URI de redirección**. 
* Elija **Registrar**. 
 
3. En la página **Xamarin Native PropertyManager**, copie y guarde los valores del **Id. de aplicación (cliente)** y del **Id. de directorio (inquilino)**. Los necesitará más adelante en el paso 7. 
 
4. Seleccione **certificados y secretos** en **administrar**. Seleccione el botón **Nuevo secreto de cliente**. Escriba un valor en **Descripción**, seleccione una opción para **Expira** y luego seleccione **Agregar**. 
 
5. Copie el valor del secreto de cliente antes de salir de la página. Lo necesitará en el siguiente paso. 
 
6. Abra la solución de ejemplo en Visual Studio y, a continuación, abra el archivo **Constants.cs**. Cambie la cadena de **Espacio empresarial** por el **valor de la ID de directorio (espacio empresarial)** que copió anteriormente. De forma similar, cambie la cadena de **ClientIdForAppAuthn** por el **valor identificador de la aplicación (cliente)** y cambie la cadena **ClientSecret** por el valor de secreto de cliente. 
 
7. Volver al Centro de administración de Azure Active Directory Seleccione **Permisos de API** y luego seleccione **Agregar un permiso**. En el panel que se abre, elija **Microsoft Graph** y luego elija **Permisos de aplicación**. 
 
8. Use el cuadro de búsqueda **Seleccionar permisos**para buscar los siguientes permisos: User.Read, Group.ReadWrite.All, Sites.Read.All, Files.ReadWrite.All, Tasks.ReadWrite, Directory.Read.All. Seleccione la casilla de verificación de cada permiso tal y como aparece (tenga en cuenta que los permisos no permanecerán visibles en la lista al seleccionar cada uno de ellos). Seleccione el botón **Agregar permisos** de la parte inferior del panel. 
 
9. Elija el botón **Conceder permisos de administrador para \[nombre del espacio empresarial]**. Seleccione **Sí** para la confirmación que aparece.

## Compilar y depurar

**Nota:** Si observa algún error durante la instalación de los paquetes en el paso 2, asegúrese de que la ruta de acceso local donde colocó la solución no es demasiado larga o profunda. Acercar la solución a la raíz de su unidad resuelve este problema.

1. Abra el archivo Constants.cs en el proyecto**XamarinNativePropertyManager (Portable)** de la solución.

    ![Captura de pantalla del archivo Constants.cs.](/Images/Constants.png "Constants.cs.") 

1. Después de haber cargado la solución en Visual Studio, configura la muestra para usar tu inquilino Azure AD reemplazando el\[TENANT\_ID\_OR\_NAME]valor en la propiedad**autoridad**del archivo Constants.cs.

    ![Capturas de pantalla de la propiedad de la Autoridad en el archivo Constants.cs.](/Images/TenantId.png "Propiedad de la autoridad.") 

1. Configure el ejemplo para usar su Id. de cliente de la aplicación Azure AD reemplazando el valor **\[CLIENT\_ID]** en la propiedad **ClientId** en el archivo **Constants.cs**.

    ![Capturas de pantalla de la propiedad ClientId en el archivo Constants.cs.](/Images/ClientId.png "Propiedad ClientId.") 

1. Abra el archivo **XamarinNativePropertyManager.Droid/Properties/AndroidManifest.xml**. Reemplace el valor`[CLIENT_ID`] con la Id. de su cliente.

    > **Nota:** Si estás usando Visual Studio para Mac, asegúrate de hacer clic en la pestaña**Origen** después de abrir **AndroidManifest.xml**.

1. Abrir el archivo**XamarinNativePropertyManager.iOS/Info.plist**. Seleccione la pestaña **Avanzado** y localice la sección **tipos de URL **. Reemplazar`[CLIENT_ID]`con la Id. de su cliente.

    ![Una captura de pantalla de la sección de tipos de URL del archivo Info.plist](Images/url_in_info_plist.png)

1. Selecciona el proyecto que quieres llevar a cabo. Si selecciona el proyecto Plataforma universal de Windows, debe ejecutar la muestra en una máquina de Windows. Si quieres ejecutar el proyecto iOS, tendrás que conectarte a un [Mac que tenga las herramientas de Xamarin](https://docs.microsoft.com/en-us/xamarin/ios/get-started/installation/windows/connecting-to-mac/)instaladas, o tendrás que construir y ejecutar el proyecto en Visual Studio para Mac. El proyecto Android puede ser construido y ejecutado tanto en Windows como en Mac siempre que el emulador de Android esté instalado.

    ![Captura de pantalla de la barra de herramientas de Visual Studio, con UWP seleccionado como proyecto inicial.](/Images/Projects.png "Seleccione el proyecto inicial.") 

1. Presione F5 para compilar y depurar. Ejecute la solución e inicie sesión con su cuenta personal, de trabajo o de la escuela.

    > **Nota**Es posible que tengas que abrir el Administrador de Configuración de Construcción para asegurarte de que los pasos de Construcción y Despliegue estén seleccionados para el proyecto UWP.

## Ejecutar la muestra

Después de lanzar la aplicación, haga clic en**iniciar sesión** para acceder a su cuenta de organización. Luego de autenticarse, la aplicación muestra todas las propiedades de su organización. Crear uno nuevo rellenando los detalles y la aplicación proveerá un nuevo grupo de Office 365 para esta propiedad. En este punto podrá publicar mensajes en las conversaciones del grupo, añadir archivos y crear tareas.

También podrá actualizar los detalles de la propiedad y crear otros nuevos. Explora los grupos de Office 365 en tu navegador para encontrar todos los datos utilizados dentro de la aplicación. Los detalles de la propiedad se almacenan en un libro de Excel llamado**Data.xlsx**, ubicado en el grupo de** Administradores de Propiedades**. 

### Capturas de pantalla de la plataforma

#### Android

![La muestra se está ejecutando en Android.](Images/PM_Android.png)

#### iOS

![La muestra se está ejecutando en Android.](Images/PM_iOS.png)

#### UWP

![La muestra se está ejecutando en Android.](Images/PM_UWP1.png)

## Cómo afecta la muestra a los datos de su cuenta

Cuando esta muestra se inicia por primera vez (en el inquilino del Office 365) un grupo del Office 365 llamado**administradores de propiedades**es creado. En este grupo, se almacena un archivo de **Data. xlsx** que hospeda todos los detalles de las distintas propiedades.

Para cada propiedad que se crea dentro de la aplicación, se provee un nuevo grupo Office 365. En cada grupo los recursos de archivos, conversaciones y tareas son utilizados por la aplicación. Las tareas son lo único que se puede borrar (completar) desde dentro de la aplicación. La aplicación no ofrece la posibilidad de eliminar mensajes o archivos de conversación. 

## Colaboradores

Si quiere hacer su aportación a este ejemplo, vea [CONTRIBUTING.MD](/CONTRIBUTING.md).

Este proyecto ha adoptado el [Código de conducta de código abierto de Microsoft](https://opensource.microsoft.com/codeofconduct/). Para obtener más información, vea [Preguntas frecuentes sobre el código de conducta](https://opensource.microsoft.com/codeofconduct/faq/) o póngase en contacto con [opencode@microsoft.com](mailto:opencode@microsoft.com) si tiene otras preguntas o comentarios.

## Recursos adicionales

- [Otros ejemplos de Microsoft Graph Connect](https://github.com/MicrosoftGraph?utf8=%E2%9C%93&query=-Connect)
- [Información general de Microsoft Graph](https://developer.microsoft.com/en-us/graph/docs/concepts/overview)
- [Ejemplos de código de Office Developer](https://developer.microsoft.com/en-us/office/gallery/?filterBy=Samples)
- [Centro para desarrolladores de Office](https://developer.microsoft.com/en-us/office)
- [Blog de Simon Jäger en #Office365Dev](http://simonjaeger.com/)

## Derechos de autor
Copyright (c) 2016 Microsoft. Todos los derechos reservados.

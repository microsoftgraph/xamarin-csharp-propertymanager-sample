/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XamarinNativePropertyManager
{
    public static class Constants
    {
		public static string Authority => "https://login.microsoftonline.com/[TENANT_ID_OR_NAME]";

		public static string GraphResource => "https://graph.microsoft.com/";

		public static string ClientId => "[CLIENT_ID]";

		public static Uri RedirectUri => new Uri("[REDIRECT_URI]");

        public static string AppGroupDisplayName => "Property Managers";

        public static string AppGroupDescription => "Group for all of the users of the Property Manager app.";

        public static string AppGroupMail => "propertymanagerapp";

        public static string TaskBucketName => "Property Tasks";

        public static string DataFileName => "Data.xlsx";

        public static string DataFileResourceName => "XamarinNativePropertyManager.Resources." + DataFileName;

        public static string DataFileDataSheet => "Data";

        public static string DataFilePropertyTable => "PropertyTable";

        public static string DataFilePropertyTableColumnStart => "A";

        public static string DataFilePropertyTableColumnEnd => "F";

        public static int DataFilePropertyTableColumns => 6;

        public static string ExcelContentType => "application/xlsx";

        public static string JsonContentType => "application/json";

        public static string StreamContentType => "application/octet-stream";

        public static string[] MediaFileExtensions => new [] { ".png", ".jpg", ".jpeg" };

        public static string[] DocumentFileExtensions => new [] { ".docx", ".xlsx", ".one", ".pptx" };

        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}

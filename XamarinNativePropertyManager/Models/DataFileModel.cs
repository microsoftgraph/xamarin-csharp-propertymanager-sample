/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

namespace XamarinNativePropertyManager.Models
{
    public class DataFileModel
    {
        public DriveItemModel DriveItem { get; set; }
        
        public TableModel<PropertyTableRowModel> PropertyTable { get; set; } 
    }
}

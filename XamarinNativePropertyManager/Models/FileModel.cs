/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

namespace XamarinNativePropertyManager.Models
{
    public class FileModel
    {
        public DriveItemModel DriveItem { get; set; }

        public FileType Type { get; set; }

        public FileModel()
        {
            
        }

        public FileModel(DriveItemModel driveItem, FileType type)
        {
            DriveItem = driveItem;
            Type = type;
        }
    }
}

/*
 *  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license.
 *  See LICENSE in the source repository root for complete license information.
 */

using System.Collections.Generic;
using XamarinNativePropertyManager.Models;

namespace XamarinNativePropertyManager.Services
{
    public interface IConfigService
    {
        UserModel User { get; set; }

        GroupModel AppGroup { get; set; }

        List<GroupModel> Groups { get; set; }

        DataFileModel DataFile { get; set; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using IFix;

[Configure]
public class IFixCfg
{
    [IFix]
    static IEnumerable<Type> hotfix
    {
        get
        {
            return from type in Assembly.Load("Assembly-CSharp").GetTypes()
                   where !type.Name.Contains("<") &&
                         !type.Name.Contains("DebugUtil") &&
                         !type.Name.Contains("DownloadManager") &&
                         !type.Name.Contains("IOManager")
                   select type;
        }
    }
}

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

/**
 * Just an example below.
 */
//[Configure]
//public class IFixCfg
//{
//    [IFix]
//    static IEnumerable<Type> hotfix
//    {
//        get
//        {
//            // 主工程注入
//            IEnumerable<Type> assemblyCSharpList =
//                from type in Assembly.Load("Assembly-CSharp").GetTypes()
//                where IsCanFix(type) && (
//                     (type.Namespace == null
//                        && !type.Name.StartsWith("TssSdk")
//                        && !type.Name.StartsWith("CustomPost"))
//                  || (type.Namespace != null
//                        && !type.Namespace.StartsWith("GCloud")
//                        && !type.Namespace.StartsWith("Msg")
//                        && !type.Namespace.StartsWith("Assets.Script.UniGif")
//                        && !type.Namespace.StartsWith("tss"))
//                                     )
//                select type;
//
//            // plugins下的first-pass注入
//            IEnumerable<Type> firstPassCSharpList =
//                from type in Assembly.Load("Assembly-CSharp-firstpass").GetTypes()
//                where (type.Namespace == null
//                       // 以下根据类名排除
//                       ) ||
//                      (type.Namespace != null &&
//                       // 以下根据命名空间排除
//                       !type.Namespace.StartsWith("Google.Protobuf") &&
//                       !type.Namespace.StartsWith("DG.Tweening") &&
//                       !type.Namespace.StartsWith("FullSerializer") &&
//                       !type.Namespace.StartsWith("FullInspector") &&
//                       !type.Namespace.StartsWith("UniRx") &&
//                       !type.Namespace.StartsWith("TMPro") &&
//                       !type.Namespace.StartsWith("Spine") &&
//                       !type.Namespace.StartsWith("com.tencent.pandora") &&
//                       !type.Namespace.StartsWith("LitJson"))
//                select type;
//
//            return assemblyCSharpList.Concat(firstPassCSharpList);
//        }
//    }
//
//    /// <summary>
//    /// 检测类型能否被热修
//    /// </summary>
//    /// <returns><c>true</c>, if can fix was ised, <c>false</c> otherwise.</returns>
//    /// <param name="t">T.</param>
//    public static bool IsCanFix(Type t)
//    {
//        // 屏蔽掉burst使用到的类型
//        if (t.GetCustomAttribute<BurstCompileAttribute>() != null
//            || typeof(IComponentData).IsAssignableFrom(t)
//            || t.IsValueType)
//        {
//            return false;
//        }
//
//        // 跳过添加了忽略标记的类型
//        if (t.GetCustomAttribute<IFixIgnoreAttribute>() != null)
//        {
//            return false;
//        }
//
//        return true;
//    }
//}

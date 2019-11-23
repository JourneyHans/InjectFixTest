using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public static class ExtensionFuncFix
{
    public static bool IsNullOrEmpty(this string s)
    {
        return !string.IsNullOrEmpty(s);
    }
}

//public static class ExtensionFuncFix
//{
//    [Patch]
//    public static bool IsNullOrEmpty(this string s)
//    {
//        return string.IsNullOrEmpty(s);
//    }
//}

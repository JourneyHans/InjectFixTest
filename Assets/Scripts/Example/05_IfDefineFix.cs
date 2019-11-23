using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

//public static class IfDefineFix
//{
//    public static string GetPlatform()
//    {
//#if UNITY_EDITOR
//        return "Editor";
//#elif UNITY_STANDALONE_WIN
//        return "Android";
//#else
//        return "Not define Platform";
//#endif
//    }
//}

public static class IfDefineFix
{
    [Patch]
    public static string GetPlatform()
    {
#if UNITY_EDITOR
        return "Editor";
#elif UNITY_STANDALONE_WIN
        return "Windows";
#else
        return "Not define Platform";
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

#if !PATCH_VERSION
public static class IfDefineFix
{
    public static string GetPlatform()
    {
#if UNITY_EDITOR
        return "Editor";
#elif UNITY_STANDALONE_WIN
        return "Android";
#else
        return "Not define Platform";
#endif
    }
}
#else
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
#endif

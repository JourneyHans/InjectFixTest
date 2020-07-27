using System.IO;
using UnityEngine;

/// <summary>
/// 路径工具类
/// </summary>
public class PathUtil
{
    /// <summary>
    /// 获取Resource路径
    /// </summary>
    public static string GetResourcePath()
    {
        return Application.dataPath + "/Resources/";
    }

    /// <summary>
    /// 获取数据存放目录（persistentDataPath）
    /// </summary>
    public static string persistentDataPath
    {
        get
        {
#if UNITY_ANDROID || UNITY_IOS
            return Application.persistentDataPath + "/";
#elif UNITY_EDITOR_OSX
            int i = Application.dataPath.LastIndexOf('/');
            return Application.dataPath.Substring(0, i + 1) + "/";
#else
            return "";
#endif
        }
    }

    /// <summary>
    /// 获取可读可写路径，通过WWW的方式
    /// </summary>
    public static string GetPersistentWWWPath()
    {
#if UNITY_ANDROID
        return "file:///" + persistentDataPath;
#elif UNITY_IOS
        return "file://" + persistentDataPath;
#else
        return "";
#endif
    }

    /// <summary>
    /// 获取streamingassets路径，通过WWW的方式
    /// </summary>
    public static string GetLocalStreamingWWWPath()
    {
#if UNITY_EDITOR && !UNITY_EDITOR_OSX
        return "file:///" + Application.streamingAssetsPath + "/";
#elif UNITY_IOS
        return "file://" + Application.streamingAssetsPath + "/";
#elif UNITY_ANDROID
        return Application.streamingAssetsPath + "/";
#else
        return "";
#endif
    }

    public static byte[] ReadStreamingAssetsBytes(string path)
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        var www = new WWW(Application.streamingAssetsPath +"/"+ path);
        while (!www.isDone) {}
        return www.bytes;
#elif !UNITY_EDITOR && UNITY_IPHONE
        return SafeReadAllBytes(Application.streamingAssetsPath+"/" + path);
#else
        return SafeReadAllBytes(Application.streamingAssetsPath + "/" + path);
#endif
    }

    public static byte[] SafeReadAllBytes(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                return null;
            }
            return File.ReadAllBytes(path);
        }
        catch
        {
            // ignored
        }

        return null;
    }
}

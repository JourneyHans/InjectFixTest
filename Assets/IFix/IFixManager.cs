using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using IFix;
using IFix.Core;
using UnityEngine;

public class IFixManager : Singleton<IFixManager>
{
    public static string MainPatchName = "Main_IL";         // Assembly-CSharp.dll的补丁名称
    public static string PluginPatchName = "Plugin_IL";     // Assembly-CSharp-firstpass.dll的补丁名称

    private string _patchStreamingPath;

    public string PatchInfo { set; get; }

    // 捕获的补丁异常信息
    public string InjectException{ set; get; }

    private bool _enableFix = true;

    protected override void Initialize()
    {
        base.Initialize();

    }

    protected override void Uninitialize()
    {
        base.Uninitialize();

    }

    public void StartPatch()
    {
        Debug.Log("[IFixManager:StartPatch]");
        if (!CheckPatchAvailable())
        {
            return;
        }
        string[] patchFiles = {
//            $"{MainPatchName}_{AppUtil.GetAppVersion()}.bytes",
//            $"{PluginPatchName}_{AppUtil.GetAppVersion()}.bytes"
            $"{MainPatchName}_versionCode.bytes",
            $"{PluginPatchName}_versionCode.bytes"
        };
        foreach (string patchFile in patchFiles)
        {
            byte[] patchBytes;
#if READ_EXTERNAL_FILE
            string patchPath = ResUtility.LocalizedDataPath + "IL/" + $"{patchFile}";
            if (File.Exists(patchPath))
            {
                Debug.Log($"[IFixManager] patchPath: {patchPath}");
                patchBytes = File.ReadAllBytes(patchPath);
            }
            else
#endif
            {
                Debug.Log("[IFixManager] 没有加载到外部补丁");
                patchBytes = PathUtil.ReadStreamingAssetsBytes("IL/" + $"{patchFile}");
            }

            if (patchBytes != null && patchBytes.Length > 0)
            {
                try
                {
                    PatchManager.Load(new MemoryStream(patchBytes));
                    Debug.Log($"[IFixManager:FinishPath]{patchFile}");
//                    PatchInfo = AppUtil.GetAppVersion();
                    PatchInfo = "versionCode";
                }
                catch (Exception e)
                {
                    InjectException = e.ToString();
                    Debug.LogError(InjectException);
                }
            }
            else
            {
                Debug.Log($"[IFixManager] patch is NULL? {patchBytes == null}");
                if (patchBytes != null)
                {
                    Debug.Log($"[IFixManager] patch length: {patchBytes.Length}");
                }
                Debug.Log($"{patchFile} not Exists");
            }
        }
    }

    private bool CheckPatchAvailable()
    {
#if UNITY_EDITOR
//        if (!Boot.Instance.EnableIFix)
        if (!_enableFix)
        {
            Debug.Log("[IFixManager:CheckPatchAvailable] Editor Mode: ifix was disabled");
            return false;
        }
#endif
        return true;
    }

    [Patch]
    private void PatchAvailableTest()
    {
        // 注意！！！不要删除这里！！！
        // 这是为了强行出一个补丁作为检测热修是否注入成功！！！
    }
}

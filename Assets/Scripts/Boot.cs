using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using IFix.Core;
using UnityEngine;
using UnityEngine.UI;

public class Boot : SingletonUnity<Boot>
{
    public Button LoadPatchBtn;
    public Button UnloadPatchBtn;

    private string _patchPath;

    private bool _isLoaded = false;

    void Awake()
    {
        _patchPath = Application.streamingAssetsPath + "/IL/Assembly-CSharp.patch.bytes";

        LoadPatchBtn.onClick.AddListener(StartPatch);
        UnloadPatchBtn.onClick.AddListener(UnloadPatch);
    }

    private void StartPatch()
    {
        if (File.Exists(_patchPath))
        {
            _isLoaded = true;
            PatchManager.Load(_patchPath);
            Debug.Log("Patch load finish");
        }
        else
        {
            Debug.Log("Patch file path not exist: " + _patchPath);
        }
    }

    private void UnloadPatch()
    {
        PatchManager.Unload(Assembly.Load("Assembly-CSharp"));
        Debug.Log("Patch unload finish");
    }
}

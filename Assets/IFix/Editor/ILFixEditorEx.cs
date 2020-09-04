using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Player;
using UnityEngine;

public class ILFixEditorEx
{
    public const string PATCH_DEFINE = "PATCH_VERSION";

    [MenuItem("InjectFix/SwitchToPatchMode")]
    public static void SwitchPatchMode()
    {
        string defineSymbolStr = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
        string[] defineSymbols = defineSymbolStr.Split(';');

        bool isPatchMode = false;
        foreach (string defineSymbo in defineSymbols)
        {
            if (defineSymbo == PATCH_DEFINE)
            {
                isPatchMode = true;
            }
        }

        if (!isPatchMode)
        {
            if (string.IsNullOrEmpty(defineSymbolStr))
            {
                defineSymbolStr += PATCH_DEFINE;
            }
            else
            {
                defineSymbolStr = PATCH_DEFINE + ";" + defineSymbolStr;
            }
        }
        else
        {
            defineSymbolStr = defineSymbols.Length == 1 ? "" : defineSymbolStr.Substring(defineSymbolStr.IndexOf(';'));
        }

        SwitchMode(!isPatchMode, defineSymbolStr);
    }

    public static void SwitchMode(bool isPatch, string newSymbols)
    {
        Menu.SetChecked("InjectFix/SwitchToPatchMode", isPatch);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, newSymbols);
        AssetDatabase.Refresh();

//        var outputDir = "Temp/ifix";
//        Directory.CreateDirectory("Temp");
//        Directory.CreateDirectory(outputDir);
//        ScriptCompilationSettings scriptCompilationSettings = new ScriptCompilationSettings();
//        scriptCompilationSettings.group = BuildTargetGroup.Standalone;
//        scriptCompilationSettings.target = BuildTarget.StandaloneWindows;
//        PlayerBuildInterface.CompilePlayerScripts(scriptCompilationSettings, outputDir);
    }
}

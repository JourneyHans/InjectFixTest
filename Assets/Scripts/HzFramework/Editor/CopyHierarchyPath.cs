using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class CopyHierarchyPath
{
    [MenuItem("GameObject/拷贝层级路径", false, 0)]
    static void CopyNodePath()
    {
        string nodePath = string.Empty;
        GetNodePath(Selection.activeGameObject.transform, ref nodePath);

        // 复制到剪切板
        TextEditor editor = new TextEditor();
        editor.text = nodePath;
        editor.SelectAll();
        editor.Copy();
    }

    static void GetNodePath(Transform trans, ref string path)
    {
        if (path == "")
        {
            path = trans.name;
        }
        else
        {
            path = trans.name + "/" + path;
        }

        if (trans.parent != null)
        {
            GetNodePath(trans.parent, ref path);
        }
    }
}

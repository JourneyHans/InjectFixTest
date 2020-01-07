using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

#if !PATCH_VERSION

public struct PlayerSwitchEvent
{
    public bool IsLock;
    public uint Id;
}

public class HandleEvent
{
    public virtual void OnProcess(in int num)
    {

    }
}

public class StructTestFix : HandleEvent
{
    // TODO: 继承关系中函数参数带in关键字的，注入后打包il2cpp会报错
    public override void OnProcess(in int num)
    {
        Debug.Log("[StructTestFix:OnProcess]");
    }
}

#else
public class StructTestFix
{
    [Patch]
    public static string PrintArray()
    {
        char a = 'a';
        char b = 'b';
        char c = 'c';
        char[] array = new[] { a, b, c };
        string result = "";
        foreach (char ch in array)
        {
            result += ch;
        }

        return result;
    }
}
#endif

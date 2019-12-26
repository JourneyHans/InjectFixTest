using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public class OutAndRefFix
{
#if !PATCH_VERSION
    public static void Swap(ref int a, ref int b)
    {
        int temp = b;
        a = b;
        b = temp;
    }

    public static bool GetMiddle(List<int> list, out int? result)
    {
        if (list.Count % 2 == 0)
        {
            Debug.Log("List count is even number");
            result = null;
            return false;
        }

        result = list[list.Count / 2 + 1];
        return true;
    }
#else
    [Patch]
    public static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    [Patch]
    public static bool GetMiddle(List<int> list, out int? result)
    {
        if (list.Count % 2 == 0)
        {
            Debug.Log("List count is even number");
            result = null;
            return false;
        }
    
        result = list[list.Count / 2];
        return true;
    }
#endif
}

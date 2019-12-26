using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public class SimpleFix
{
#if !PATCH_VERSION
    public string Add(int a, int b)
    {
        return $"{a} + {b} = {a - b}";
    }

    public string Add(string s1, string s2)
    {
        return $"{s1} connects {s2} equals {s1}";
    }

    public static string Add(float a, float b)
    {
        return $"{a} + {b} = {a / b}";
    }
#else
    [Patch]
    public string Add(int a, int b)
    {
        return $"{a} + {b} = {a + b}";
    }
    
    [Patch]
    public string Add(string s1, string s2)
    {
        return $"{s1} connects {s2} equals {s1 + s2}";
    }
    
    [Patch]
    public static string Add(float a, float b)
    {
        return $"{a} + {b} = {a + b}";
    }
#endif
}

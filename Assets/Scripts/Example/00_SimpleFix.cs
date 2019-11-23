using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public class SimpleFix
{
//    [Patch]
//    public void Add(int a, int b)
//    {
//        Debug.LogFormat("{0} + {1} = {2}", a, b, a + b);
//    }

    public void Add(int a, int b)
    {
        Debug.LogFormat("{0} + {1} = {2}", a, b, a - b);
    }

    public void Add(string s1, string s2)
    {
        Debug.LogFormat("{0} connects {1} equals {2}", s1, s2, s1);
    }

    public static void Add(float a, float b)
    {
        Debug.LogFormat("{0} + {1} = {2}", a, b, a / b);
    }

//    [Patch]
//    public void Add(int a, int b)
//    {
//        Debug.LogFormat("{0} + {1} = {2}", a, b, a + b);
//    }
//
//    [Patch]
//    public void Add(string s1, string s2)
//    {
//        Debug.LogFormat("{0} connects {1} equals {2}", s1, s2, s1 + s2);
//    }
//
//    [Patch]
//    public static void Add(float a, float b)
//    {
//        Debug.LogFormat("{0} + {1} = {2}", a, b, a + b);
//    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

#if !PATCH_VERSION
public class ArrayInitialFix
{
    public static string PrintArray()
    {
        char[] array = new[] { 'a', 'b', 'd' };
        string result = "";
        foreach (char c in array)
        {
            result += c;
        }

        return result;
    }
}
#else
public class ArrayInitialFix
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

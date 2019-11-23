using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExtend
{
    /// <summary>
    /// 分割字符串，返回Int类型，默认值为0
    /// </summary>
    public static int[] SplitToInt(this string origin, params char[] separator)
    {
        string[] stringArray = origin.Split(separator);
        int[] intArray = new int[stringArray.Length];
        for (int i = 0; i < stringArray.Length; ++i)
        {
            string s = stringArray[i];
            int n;
            if (int.TryParse(s, out n))
            {
                intArray[i] = n;
            }
            else
            {
                intArray[i] = 0;
            }
        }
        return intArray;
    }
}

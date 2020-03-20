using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

#if !PATCH_VERSION
public class EnumParse
{
    public enum ColorEnum
    {
        RED = 0,
        YELLOW = 1,
        BLUE = 2,
    }

    private Dictionary<int, ColorEnum> _idToColorEnumDic = new Dictionary<int, ColorEnum>
    {
        {1, ColorEnum.RED},
        {2, ColorEnum.YELLOW},
        {3, ColorEnum.BLUE},
    };

    public string PrintEnum()
    {
        string result = "";

        foreach (var idToColorEnumPair in _idToColorEnumDic)
        {

        }

        return result;
    }
}

#else
public class EnumParse
{
    public enum ColorEnum
    {
        RED = 0,
        YELLOW = 1,
        BLUE = 2,
    }

    private Dictionary<int, ColorEnum> _idToColorEnumDic = new Dictionary<int, ColorEnum>
    {
        {1, ColorEnum.RED},
        {2, ColorEnum.YELLOW},
        {3, ColorEnum.BLUE},
    };

    [Patch]
    public string PrintEnum()
    {
        string result = "";

        foreach (var idToColorEnumPair in _idToColorEnumDic)
        {

        }

//        for (int i = 0; i < _idToColorEnumDic.Count; i++)
//        {
//            
//        }

        return result;
    }
}
#endif

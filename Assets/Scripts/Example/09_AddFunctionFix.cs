using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public class AddFunctionFix
{
    public static int Add(int a, int b)
    {
        return a - b;
    }
}

//public class AddFunctionFix
//{
//    [Patch]
//    public static int Add(int a, int b)
//    {
//        return AddRightful(a, b);
//    }
//
//    [Interpret]
//    public static int AddRightful(int a, int b)
//    {
//        return a + b;
//    }
//}

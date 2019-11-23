using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public class Parent
{
    public virtual void Print()
    {
        Debug.Log("[Child:Print]");
    }
}

public class Child : Parent
{
    public override void Print()
    {
        Debug.Log("[Parent:Print]");
    }
}

//public class Parent
//{
//    [Patch]
//    public virtual void Print()
//    {
//        Debug.Log("[Parent:Print]");
//    }
//}
//
//public class Child : Parent
//{
//    [Patch]
//    public override void Print()
//    {
//        Debug.Log("[Child:Print]");
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

#if !PATCH_VERSION
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
#else
public class Parent
{
    [Patch]
    public virtual void Print()
    {
        Debug.Log("[Parent:Print]");
    }
}

public class Child : Parent
{
    [Patch]
    public override void Print()
    {
        Debug.Log("[Child:Print]");
    }
}
#endif

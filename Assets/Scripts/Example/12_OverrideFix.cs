using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public class Parent_1
{
    public virtual void OverridePatchTest()
    {

    }

    public virtual void InterpretPatchTest()
    {

    }
}

#if !PATCH_VERSION

public class Child_1 : Parent_1
{
    public override void OverridePatchTest()
    {
        Debug.Log("Parent_1");
    }
}

#else
public class Child_1 : Parent_1
{
    [Patch]
    public override void OverridePatchTest()
    {
        Debug.Log("Child_1_Override");
    }
    
    [Interpret]
    public override void InterpretPatchTest()
    {
        Debug.Log("Child_1_Interpret");
    }
}
#endif

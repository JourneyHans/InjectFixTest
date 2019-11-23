using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public class SetGetFix
{
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}

//public class SetGetFix
//{
//    private string _name;
//
//    public string Name
//    {
//        [Patch]
//        get { return _name + ", now it's fixed"; }
//        [Patch]
//        set { _name = value; }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public static class TemplateFix
{
    public static T GetComponent<T>(this GameObject root, string name)
    {
        return root.transform.Find<T>(name + "///");
    }
}

//public static class TemplateFix
//{
//    [Patch]
//    public static T GetComponent<T>(this GameObject root, string name)
//    {
//        return root.transform.Find<T>(name);
//    }
//}

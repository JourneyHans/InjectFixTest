using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public static class PrivateClassFix
{
    private class MyPrivateClass
    {
        private string name;

        private void SetName()
        {
            name = "MyPrivateClass" + "gaojioaewrijhoajweri";
        }
        public string GetName()
        {
            SetName();
            return name;
        }
    }

    private static readonly MyPrivateClass PrivateClass = new MyPrivateClass();

    public static string GetPrivateClassName()
    {
        return PrivateClass.GetName();
    }
}

//public static class PrivateClassFix
//{
//    private class MyPrivateClass
//    {
//        private string name;
//
//        [Patch]
//        private void SetName()
//        {
//            name = "MyPrivateClass";
//        }
//        public string GetName()
//        {
//            SetName();
//            return name;
//        }
//    }
//
//    private static readonly MyPrivateClass PrivateClass = new MyPrivateClass();
//
//    public static string GetPrivateClassName()
//    {
//        return PrivateClass.GetName();
//    }
//}

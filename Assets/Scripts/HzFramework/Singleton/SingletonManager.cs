using UnityEngine;
using System.Collections.Generic;

public class SingletonManager
{

    public static List<ISingleton> dataList = new List<ISingleton>();

    public static void Add(ISingleton objSinglton)
    {

        dataList.Add(objSinglton);

    }

    public static void ClearAll()
    {

        for (int i = 0; i < dataList.Count; i++)
        {

            if (dataList[i] != null)
                dataList[i].ClearSingleton();

        }

        dataList.Clear();

    }

}


public interface ISingleton
{

    void ClearSingleton();

}
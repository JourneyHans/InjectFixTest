using UnityEngine;
using System.Collections;

public class Singleton<T> : ISingleton where T : new()
{

    private static T instance = default(T);

    public static T Instance
    {

        get
        {

            if (instance == null)
            {

                instance = new T();

                SingletonManager.Add((ISingleton) instance);

            }

            return instance;

        }

    }

    public void ClearSingleton()
    {

        instance = new T();

    }

}

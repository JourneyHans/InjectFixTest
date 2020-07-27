using UnityEngine;
using System.Collections;

public class Singleton<T> : ISingleton where T : Singleton<T>, new()
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                CreateInstance();
            }
            return _instance;
        }
    }

    public static T CreateInstance()
    {
        if (_instance == null)
        {
            _instance = new T();
            _instance.Initialize();
            SingletonManager.Add(_instance);
        }

        return _instance;
    }

    public static void DestroyInstance()
    {
        if (_instance != null)
        {
            _instance.Uninitialize();
            _instance = null;
        }
    }

    protected virtual void Initialize()
    {

    }

    protected virtual void Uninitialize()
    {

    }

    public void ClearSingleton()
    {
        _instance = new T();
    }
}

using UnityEngine;
using System.Collections;

public class SingletonUnity<T> : MonoBehaviour, ISingleton where T : MonoBehaviour
{
    protected static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject go = new GameObject("Temp");
                    instance = go.AddComponent<T>();
#if UNITY_EDITOR
                    go.name = instance.GetType().FullName;
#endif
                }
                SingletonManager.Add((ISingleton) instance);
            }
            return instance;
        }
    }

    public void ClearSingleton()
    {
        instance = default(T);
    }
}

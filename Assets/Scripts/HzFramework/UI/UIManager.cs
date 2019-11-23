using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager: Singleton<UIManager>
{
    private GameObject _uiCamera;               // UI相机
    private GameObject _canvasGameObject;       // UI根节点
    private GameObject _eventSystemGameObject;  // 事件接收器

    private Dictionary<string, UIBase> _uiDic = new Dictionary<string, UIBase>();   // UI字典
    private string _uiRootPath = "Assets/UI/";      // UI预制件的路径

    // UI界面的Canvas层级
    public enum SortOrderLayer
    {
        Zero = 0,
        HomePanel = 100,
        Prompt = 1000,
    }

    // 打开界面的方式
    public enum OpenType
    {
        Add,        // 叠加方式，不会关闭其他界面，也是默认方式
        Replace,    // 替换方式，会关闭上一个界面
    }

    // 初始化
    public void Init()
    {
        _uiCamera = GameObject.Find("UICamera");
        Object.DontDestroyOnLoad(_uiCamera);
        _canvasGameObject = GameObject.Find("UIRoot");
        Object.DontDestroyOnLoad(_canvasGameObject);
        _eventSystemGameObject = GameObject.Find("EventSystem");
        Object.DontDestroyOnLoad(_eventSystemGameObject);
    }

    /// <summary>
    /// 打开一个界面
    /// </summary>
    public T Show<T>(OpenType openType = OpenType.Add, SortOrderLayer layer = SortOrderLayer.HomePanel) where T : UIBase
    {
        string uiName = typeof(T).ToString();
        UIBase uiBase;
        if (_uiDic.ContainsKey(uiName))
        {
            // 界面已经存在，从字典中取出，Active设置为true
            // 且会重新计算层级，且会刷新界面
            uiBase = _uiDic[uiName];
            uiBase.gameObject.SetActive(true);
            uiBase.Refresh();
        }
        else
        {
            // 新开界面
            GameObject uiGO = SimpleLoader.InstantiateGameObject(_uiRootPath + uiName + ".prefab");
            uiGO.transform.SetParent(_canvasGameObject.transform, false);
            uiBase = uiGO.GetComponent<UIBase>();
        }
        uiBase.UIName = uiName;
        uiBase.OrderLayer = layer;

        // 替换形式会关闭上个界面
        if (openType == OpenType.Replace)
        {
            CloseTopUI();
        }

        // 检测必要组件是否存在并处理层级
        CheckComponentAndSortOrder(layer, uiBase);

        // 添加到字典
        if (!_uiDic.ContainsKey(uiName))
        {
            _uiDic.Add(uiName, uiBase);
        }
//        CheckCurrentUIDIC();
        return uiBase as T;
    }

    /// <summary>
    /// 获取一个界面
    /// </summary>
    public T GetUI<T>() where T : UIBase
    {
        string uiName = typeof(T).ToString();
        if (!_uiDic.ContainsKey(uiName))
        {
            return null;
        }
        return _uiDic[uiName] as T;
    }

    // 检测必要组件是否存在并处理层级
    private void CheckComponentAndSortOrder(SortOrderLayer layer, UIBase uiBase)
    {
        Canvas canvas = uiBase.gameObject.GetComponent<Canvas>();
        if (canvas == null)
        {
            canvas = uiBase.gameObject.AddComponent<Canvas>();
        }

        canvas.overrideSorting = true;
        canvas.sortingOrder = GetMaxSortOrder(layer, uiBase.UIName);

        uiBase.UICanvas = canvas;
        uiBase.SortOrder = canvas.sortingOrder;

        GraphicRaycaster raycast = uiBase.gameObject.GetComponent<GraphicRaycaster>();
        if (raycast == null)
        {
            raycast = uiBase.gameObject.AddComponent<GraphicRaycaster>();
        }

        uiBase.Raycast = raycast;
    }

    // 获取指定Layer当前最大的sortingOrder
    public int GetMaxSortOrder(SortOrderLayer layerType, string name)
    {
        int maxOrder = (int)layerType;
//        Debug.Log("----> Start order: " + maxOrder);
        foreach (var uiPair in _uiDic)
        {
            if (maxOrder <= uiPair.Value.SortOrder && name != uiPair.Key)
            {
//                Debug.LogFormat("----> Compare Order: {0}/{1} ", maxOrder, uiPair.Value.SortOrder);
                // 每新加一个界面，sortingOrder会根据当前层级增加
                maxOrder = uiPair.Value.SortOrder + (int)layerType;
            }
        }
//        Debug.Log("----> Result order: " + maxOrder);
        return maxOrder;
    }

    // 关闭一个界面
    public void Close<T>(T t = null) where T : UIBase
    {
        var uiName = t == null ? typeof(T).ToString() : t.GetType().ToString();
        if (!_uiDic.ContainsKey(uiName))
        {
            // 界面已关闭
            return;
        }
        GameObject uiGO = _uiDic[uiName].gameObject;
        Object.Destroy(uiGO);
        _uiDic.Remove(uiName);
    }

    /// <summary>
    /// 关闭指定层上最高的UI
    /// </summary>
    private void CloseTopUI()
    {
        int order = 0;
        UIBase target = null;
        foreach (var uiPair in _uiDic)
        {
            int uiOrder = uiPair.Value.SortOrder;
            if (uiOrder >= order)
            {
                target = uiPair.Value;
            }
        }
        if (target != null)
        {
            target.Close();
        }
    }

    /// <summary>
    /// 刷新所有界面
    /// </summary>
    public void RefreshAll()
    {
        foreach (var uiPair in _uiDic)
        {
            if (uiPair.Value.gameObject.activeSelf)
            {
                uiPair.Value.Refresh();
            }
        }
    }

    public void CheckCurrentUIDIC()
    {
        Debug.Log("=========== Check UI ===========");
        Debug.Log("\tUI count: " + _uiDic.Count);
        foreach (var uiPair in _uiDic)
        {
            Debug.Log("\tName: " + uiPair.Key);
            Debug.Log("\tSortOrder: " + uiPair.Value.SortOrder);
        }
        Debug.Log("================================");
    }
}

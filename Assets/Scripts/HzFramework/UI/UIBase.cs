using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI基类
public class UIBase : MonoBehaviour
{
    public string UIName { set; get; }      // 对应UI名称
    public GraphicRaycaster Raycast { set; get; }
    public Canvas UICanvas { set; get; }    // 控制层级的Canvas
    public UIManager.SortOrderLayer OrderLayer { set; get; }    // 所属层级Layer
    public int SortOrder { set; get; }      // 层级Order

    /// <summary>
    /// 界面刷新方法
    /// 请不要重写这个方法，这个方法提供给外部调用
    /// 如果需要请重写OnRefresh
    /// </summary>
    public void Refresh()
    {
        OnRefresh();
    }

    /// <summary>
    /// 提供给子类重写的刷新方法
    /// </summary>
    protected virtual void OnRefresh()
    {

    }

    /// <summary>
    /// 界面关闭自己的方法
    /// 请不要重写这个方法，如果需要请重写OnClose方法
    /// </summary>
    public void Close()
    {
        OnClose();
        UIManager.Instance.Close(this);
    }

    /// <summary>
    /// 提供给子类重写的关闭方法，用于当界面关闭时还需要进行额外操作
    /// 生命周期在界面彻底销毁前
    /// 如果需要在界面彻底销毁后进行操作，请写在OnDestroy()方法中
    /// </summary>
    protected virtual void OnClose()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtend
{
    /// <summary>
    /// 查找子节点上的某个组件
    /// </summary>
    /// <typeparam name="T">想要的组件类型</typeparam>
    /// <param name='transform'>transform调用</param>
    /// <param name="name">子节点名称</param>
    public static T Find<T>(this Transform transform, string name)
    {
        return transform.Find(name).GetComponent<T>();
    }
}

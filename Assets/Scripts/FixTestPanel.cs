using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixTestPanel : MonoBehaviour
{
    public Text ShowInfo;

    public SinaWeiboDevInfo _test;

    void Awake()
    {
        Button[] buttonList = GetComponentsInChildren<Button>();
        foreach (Button button in buttonList)
        {
            button.onClick.RemoveAllListeners();
            string btnName = button.name;
            button.onClick.AddListener(() => { Invoke($"On{btnName}Call", 0f); });
        }

    }

    /// <summary>
    /// 简单修复示例：对象调用普通函数，类调用静态函数
    /// </summary>
    void OnSimpleFixCall()
    {
        Debug.Log("----- OnSimpleFixCall Began -----");
        SimpleFix sp = new SimpleFix();
        ShowInfo.text = sp.Add(1, 2);
        ShowInfo.text += "\n" + sp.Add("Hello", "World");
        ShowInfo.text += "\n" + SimpleFix.Add(1, 2);
        Debug.Log("----- OnSimpleFixCall Ended -----");
    }

    /// <summary>
    /// 函数参数有带out和ref关键字的修复示例
    /// </summary>
    void OnOutAndRefFixCall()
    {
        int b = 2;
        int a = 1;
        Debug.Log("----- OnOutAndRefFixCall Began -----");
        Debug.Log("Ref test:");
        Debug.Log($"\tBefore swap: {a} : {b}");
        OutAndRefFix.Swap(ref a, ref b);
        Debug.Log($"\tAfter swap: {a} : {b}");
        Debug.Log("Out test:");
        if (OutAndRefFix.GetMiddle(new List<int> {1, 2, 9, 4, 5}, out int? middleNum))
        {
            Debug.Log($"Middle number is {middleNum}");
        }
        Debug.Log("----- OnOutAndRefFixCall Ended -----");
    }

    /// <summary>
    /// 继承修复示例，virtual和override
    /// </summary>
    void OnInheritFixCall()
    {
        Debug.Log("----- OnInheritFixCall Began -----");
        Parent p = new Parent();
        Child c = new Child();
        Debug.Log("Parent call Print:");
        p.Print();
        Debug.Log("Child call Print:");
        c.Print();
        Debug.Log("----- OnInheritFixCall Ended -----");
    }

    /// <summary>
    /// 扩展函数修复示例
    /// </summary>
    void OnExtensionFuncFixCall()
    {
        Debug.Log("----- OnInheritFixCall Began -----");
        string s = "Not null string";
        Debug.Log($"\"{s}\" is null or emypt? {s.IsNullOrEmpty()}");
        Debug.Log("----- OnInheritFixCall Ended -----");
    }

    /// <summary>
    /// 泛型修复示例，暂不支持
    /// </summary>
    void OnTemplateFixCall()
    {
        Debug.Log("----- OnInheritFixCall Began -----");
        GameObject go = GameObject.Find("TemplateFix");
        Text text = go.GetComponent<Text>("TemplateFixText");
        if (text != null)
        {
            Debug.Log("Find object: " + text.name);
        }
        else
        {
            Debug.Log("Cannot find it...");
        }
        Debug.Log("----- OnInheritFixCall Ended -----");
    }

    /// <summary>
    /// 条件宏编译修复示例
    /// </summary>
    void OnIfDefineFixCall()
    {
        Debug.Log("----- OnIfDefineFixCall Began -----");
        ShowInfo.text = $"OnIfDefineFixCall Test: \n\tCurrent Platform is {IfDefineFix.GetPlatform()}";
        Debug.Log("----- OnIfDefineFixCall Ended -----");
    }

    /// <summary>
    /// Set，Get函数修复示例
    /// </summary>
    void OnSetGetFixCall()
    {
        Debug.Log("----- OnSetGetFixCall Began -----");
        SetGetFix test = new SetGetFix();
        test.Name = "NeedFix";
        ShowInfo.text = test.Name;
        Debug.Log("----- OnSetGetFixCall Ended -----");
    }

    /// <summary>
    /// 协程修复测试
    /// </summary>
    void OnCoroutineFixCall()
    {
        Debug.Log("----- OnCoroutineFixCall Began -----");
        CoroutineFix coroutineFix = new CoroutineFix();
        coroutineFix.CoroutineTest();
        Debug.Log("----- OnCoroutineFixCall Ended -----");
    }

    /// <summary>
    /// 私有类测试修复
    /// </summary>
    void OnPrivateClassFixCall()
    {
        Debug.Log("----- OnPrivateClassFixCall Began -----");
        ShowInfo.text = PrivateClassFix.GetPrivateClassName();
        Debug.Log("----- OnPrivateClassFixCall Ended -----");
    }

    /// <summary>
    /// 增加新函数测试修复
    /// </summary>
    void OnAddFunctionFixCall()
    {
        Debug.Log("----- OnAddFunctionFixCall Began -----");
        int a = 2, b = 1;
        ShowInfo.text = $"{a} + {b} = {AddFunctionFix.Add(a, b).ToString()}";
        Debug.Log("----- OnAddFunctionFixCall Ended -----");
    }

    /// <summary>
    /// 数组初始化测试修复
    /// </summary>
    void OnArrayInitialFixCall()
    {
        Debug.Log("----- OnArrayInitialFixCall Began -----");
        ShowInfo.text = ArrayInitialFix.PrintArray();
        Debug.Log("----- OnArrayInitialFixCall Began -----");
    }
}

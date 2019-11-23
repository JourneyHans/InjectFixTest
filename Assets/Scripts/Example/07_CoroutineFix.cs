using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IFix;

public class CoroutineFix
{
    private FixTestPanel _fixTestPanel;

    private const int _excuteTimes = 10;

    public void CoroutineTest()
    {
        _fixTestPanel = GameObject.Find("FixTestPanel").GetComponent<FixTestPanel>();
        _fixTestPanel.StartCoroutine(coroutine());
    }

    private IEnumerator coroutine()
    {
        for (int i = 0; i < _excuteTimes; i++)
        {
            _fixTestPanel.ShowInfo.text = i.ToString();
            yield return new WaitForSeconds(1.0f);
        }
    }
}

//public class CoroutineFix
//{
//    private FixTestPanel _fixTestPanel;
//
//    private const int _excuteTimes = 10;
//
//    public void CoroutineTest()
//    {
//        _fixTestPanel = GameObject.Find("FixTestPanel").GetComponent<FixTestPanel>();
//        _fixTestPanel.StartCoroutine(coroutine());
//    }
//
//    [Patch]
//    private IEnumerator coroutine()
//    {
//        for (int i = 0; i < _excuteTimes * 2; i++)
//        {
//            _fixTestPanel.ShowInfo.text = i.ToString();
//            yield return new WaitForSeconds(0.5f);
//        }
//    }
//}

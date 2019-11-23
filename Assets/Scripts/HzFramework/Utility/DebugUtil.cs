using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

#if UNITY_EDITOR
/// <summary>
/// Debug工具类
/// </summary>
public class DebugUtil
{
    private static Stopwatch stopWatch = new Stopwatch();
    public static void StartTime()
    {
        stopWatch.Reset();
        stopWatch.Start();
    }

    public static void StopTime()
    {
        stopWatch.Stop();
        TimeSpan timeSpan = stopWatch.Elapsed;
        UnityEngine.Debug.LogFormat("时间消耗为：{0}mm", timeSpan.TotalMilliseconds);
    }
}
#endif

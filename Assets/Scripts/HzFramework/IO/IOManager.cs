using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IOManager
{
    /// <summary>
    /// 保存文件，bytes方式
    /// </summary>
    /// <param name="path">保存的地址</param>
    /// <param name="bytes">要保存的内容</param>
    public static void SaveFile(string path, byte[] bytes)
    {
        FileInfo file = new FileInfo(path);
        file.Directory.Create();
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
        {
            fs.Write(bytes, 0, bytes.Length);
        }
    }
}

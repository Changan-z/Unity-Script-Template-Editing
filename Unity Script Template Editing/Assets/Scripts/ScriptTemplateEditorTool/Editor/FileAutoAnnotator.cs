/*************************************************************************
 *  Copyright (C) 2023 Your Name (or Your Company)
 *  Author: Your Name (or Your Company)
 *  Version: 1.0
 *  Date: 2023/10/19
 *
 *  Description:
 *  This is a sample code file with copyright information.
 *  License:
 *  Permission is hereby granted, free of charge, to any person obtaining a copy
 *  of this software and associated documentation files (the "Software"), to deal
 *  in the Software without restriction, including without limitation the rights
 *  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
 *  of the Software, and to permit persons to whom the Software is furnished to
 *  do so, subject to the following conditions:
 *
 *  The above copyright notice and this permission notice shall be included in all
 *  copies or substantial portions of the Software.
 *
 *  THE SOFTWARE IS PROVIDED "AS IS," WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 *  INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
 *  PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 *  HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
 *  OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 *  SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *************************************************************************/

using System;
using System.IO;
using UnityEditor;

namespace CustomTool.ScriptTemplate
{
    public class FileAutoAnnotator : UnityEditor.AssetModificationProcessor
    {
        /// <summary>
        /// 当创建新资源文件时触发
        /// </summary>
        /// <param name="assetPath"></param>
        private static void OnWillCreateAsset(string assetPath)
        {
            assetPath = assetPath.Replace(".meta", string.Empty);

            var fileSuffix = Path.GetExtension(assetPath);

            if (fileSuffix != ".cs" && fileSuffix != ".shader")
                return;

            var nowTime = DateTime.Now;
            var createTime = nowTime.ToShortDateString();
            var copyrightTime = nowTime.Year.ToString();

            var content = File.ReadAllText(assetPath);

            content = content.Replace("#CreateTime#", createTime);
            content = content.Replace("#CopyrightTime#", copyrightTime);

            File.WriteAllText(assetPath, content);

            // 刷新资源数据库，以便在Unity中立即看到更新
            AssetDatabase.Refresh();
        }
    }
}
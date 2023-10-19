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

namespace CustomTool.ScriptTemplate
{
    using System.IO;
    using System.Text;
    using UnityEditor;
    using UnityEngine;

    public class ScriptTemplateEditor : EditorWindow
    {
        private enum EditScriptTemplateType
        {
            BehaviourScript,
            TestScript,
            StandardSurfaceShader,
            UnlitShader,
            ImageEffectShader,
            StateMachineBehaviourScript,
            SubStateMachineBehaviourScript,
            RayTracingShader,
        }

        private static ScriptTemplateEditor instance;
        private static Vector2 scrollPos;

        private static EditScriptTemplateType lastEditScriptsTemplateType = EditScriptTemplateType.RayTracingShader;
        private static EditScriptTemplateType currentEditScriptsTemplateType;
        private static string scriptTemplateContent;



        [MenuItem("自定义工具/脚本模板编辑 &T")]
        private static void ShowScriptTemplateEditor()
        {
            instance = GetWindow<ScriptTemplateEditor>("脚本模板编辑器");
            instance.Show();
        }


        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            currentEditScriptsTemplateType = (EditScriptTemplateType)EditorGUILayout.EnumPopup("脚本模板类型", currentEditScriptsTemplateType);
            if (lastEditScriptsTemplateType != currentEditScriptsTemplateType)
            {
                lastEditScriptsTemplateType = currentEditScriptsTemplateType;
                GetScriptTemplateContent();
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("脚本模板内容");
            EditorGUILayout.Space();
            if (GUILayout.Button("Save", GUILayout.Width(80)))
                SaveScriptTemplate();
            EditorGUILayout.EndHorizontal();

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            scriptTemplateContent = EditorGUILayout.TextArea(scriptTemplateContent, GUILayout.ExpandHeight(true));
            EditorGUILayout.EndScrollView();

            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// 获取脚本模板路径
        /// </summary>
        /// <returns></returns>
        private string GetScriptTemplatePath()
        {
            string scriptPath = string.Empty;
            switch (currentEditScriptsTemplateType)
            {
                case EditScriptTemplateType.BehaviourScript:
                    scriptPath = "81-C# Script-NewBehaviourScript.cs";
                    break;
                case EditScriptTemplateType.TestScript:
                    scriptPath = "83-C# Script-NewTestScript.cs";
                    break;
                case EditScriptTemplateType.StandardSurfaceShader:
                    scriptPath = "83-Shader__Standard Surface Shader-NewSurfaceShader.shader";
                    break;
                case EditScriptTemplateType.UnlitShader:
                    scriptPath = "84-Shader__Unlit Shader-NewUnlitShader.shader";
                    break;
                case EditScriptTemplateType.ImageEffectShader:
                    scriptPath = "85-Shader__Image Effect Shader-NewImageEffectShader.shader";
                    break;
                case EditScriptTemplateType.StateMachineBehaviourScript:
                    scriptPath = "86-C# Script-NewStateMachineBehaviourScript.cs";
                    break;
                case EditScriptTemplateType.SubStateMachineBehaviourScript:
                    scriptPath = "86-C# Script-NewSubStateMachineBehaviourScript.cs";
                    break;
                case EditScriptTemplateType.RayTracingShader:
                    scriptPath = "93-Shader__Ray Tracing Shader-NewRayTracingShader.raytrace";
                    break;
                default:
                    break;
            }
            return Path.Combine(EditorApplication.applicationContentsPath, "Resources", "ScriptTemplates", $"{scriptPath}.txt");
        }


        /// <summary>
        /// 获取脚本模板内容
        /// </summary>
        private void GetScriptTemplateContent()
        {
            try
            {
                string scriptPath = GetScriptTemplatePath();
                if (File.Exists(scriptPath))
                    scriptTemplateContent = File.ReadAllText(scriptPath, Encoding.Default);
                else
                    scriptTemplateContent = string.Empty;
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
                throw;
            }
        }


        /// <summary>
        /// 保存脚本模板
        /// </summary>
        private void SaveScriptTemplate()
        {
            try
            {
                File.WriteAllText(GetScriptTemplatePath(), scriptTemplateContent, Encoding.Default);
                bool closeEditor = EditorUtility.DisplayDialog(
                    "保存模板",
                    "新的脚本模板保存成功！",
                    "关闭",
                    "继续编辑"
                    );
                if (closeEditor)
                    instance.Close();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
                throw;
            }

        }

    }
}
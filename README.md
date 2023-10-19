# Unity-Script-Template-Editing
可以在Unity编辑器中对Unity的脚本模板进行快速编辑。

<b>Unity Version：Unity2020.3.15</b>

可以根据自己的个人需求和喜号来预定义Unity的脚本模板文件。如：在脚本头部添加作者信息，文件描述，版权等信息。

脚本ScriptTemplateEditor提供了一套在Unity编辑器中即可对Unity Editor提供的脚本模板文件进行快速编辑，保存等操作。
  在编辑器中点击：自定义工具->脚本模板编辑或者按下Ctrl+T即可快速进行编辑。
  也可以手动查找进行编辑，文件存储路径：Unity Editor安装位置\Editor\Data\Resources\ScriptTemplates\

文中提供的模板样式：
/*************************************************************************
 *  Copyright (C) #CopyrightTime# Your Name (or Your Company)
 *  Author: Your Name (or Your Company)
 *  Version: 1.0
 *  Date: #CreateTime#
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

因为Unity只会自动设置#SCRIPTNAME#，并不会自动帮我们设置“#CopyrightTime#”，“#CreateTime#”，所以通过脚本FileAutoAnnotator监听Unity Editor下的OnWillCreateAsset(string assetPath)方法来实现脚本创建自动更新这两项内容。

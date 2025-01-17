﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text;
using IWshRuntimeLibrary;
using UAC免提醒.Properties;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Drawing;

namespace UAC免提醒
{
    public partial class Form : System.Windows.Forms.Form
    {
        private const string 快捷方式前缀 = "noUAC.";
        private const string 任务计划文件夹名 = "noUAC\\";
        readonly string[] args;

        public FileDropAdmin_cs.FileDropAdmin FileDroper;
        public Form(string[] args)
        {
            InitializeComponent();
            this.args = args;
        }
        string J_VerInfo;// 软件版本号
        // 程序创建前
        private void Form1_Load(object sender, EventArgs e)
        {
            if (args.Length > 0)
            {
                //Debug.Print(args[0]);
                Handling_File_Drop(args[0]);
            }
            FileDroper = new FileDropAdmin_cs.FileDropAdmin(this);
            FileVersionInfo VerInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
            J_VerInfo = VerInfo.FileVersion;
            J_VerInfo = J_VerInfo.Replace(".0","");
            this.Text = "UAC 免提醒 v" + J_VerInfo;
            //Task.Run(() => Check_Updates(false));
            NotKey();
        }
        // 有文件拖放进来了
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }
        // 处理拖放进来的文件
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            Handling_File_Drop(((string[])e.Data.GetData(typeof(string[])))[0]);
        }
        private void Handling_File(string pathstr) {
            string ext = Path.GetExtension(pathstr).ToLower();
            if (ext == ".exe" || ext == ".bat")
            {
                if (System.IO.File.Exists(pathstr))
                {
                    TextBox_程序位置.Text = pathstr;
                    TextBox_程序名称.Text = Path.GetFileNameWithoutExtension(TextBox_程序位置.Text);
                    TextBox_启动参数.Text = "";
                    TextBox_起始位置.Text = "";
                    TextBox_启动参数.SendToBack();
                    TextBox_起始位置.SendToBack();
                    TextBox_程序位置.BringToFront();
                    TextBox_程序名称.BringToFront();
                }
                else
                {
                    MessageBox.Show("文件不存在！请检查！\n" + pathstr, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (ext == ".lnk")
            {
                if (System.IO.File.Exists(pathstr))
                {
                    WshShell shell = new WshShell();
                    IWshShortcut Shortcut = (IWshShortcut)shell.CreateShortcut(pathstr);
                    if (System.IO.File.Exists(Shortcut.TargetPath))
                    {
                        TextBox_程序位置.Text = Shortcut.TargetPath;
                        TextBox_程序名称.Text = Path.GetFileNameWithoutExtension(TextBox_程序位置.Text);
                        TextBox_启动参数.Text = Shortcut.Arguments;
                        TextBox_起始位置.Text = Shortcut.WorkingDirectory;
                        TextBox_程序位置.BringToFront();
                        TextBox_程序名称.BringToFront();
                        if (TextBox_启动参数.Text != "")
                        {
                            TextBox_启动参数.BringToFront();
                        }
                        else
                        {
                            TextBox_启动参数.SendToBack();
                        }
                        if (TextBox_起始位置.Text != "")
                        {
                            TextBox_起始位置.BringToFront();
                        }
                        else
                        {
                            TextBox_起始位置.SendToBack();
                        }
                    }
                    else
                    {
                        MessageBox.Show("目标文件不存在！请检查！\n" + Shortcut.TargetPath, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("文件不存在！请检查！\n" + pathstr, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("仅支持 .exe .bat .lnk 格式的文件！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 处理拖放进来的文件
        private void Handling_File_Drop(string Drag_File_PATH)
        {
            Debug.Print(Drag_File_PATH);
            Handling_File(Drag_File_PATH);
        }
        // 监视输入框
        private void TextBox_程序名称_TextChanged(object sender, EventArgs e)
        {
            TextBox_程序名称.Text = Regex.Replace(TextBox_程序名称.Text, @"[^\u4e00-\u9fa5_a-zA-Z0-9\.]", "");
            //Debug.Print(TextBox_程序名称.Text);
            Button_添加.Enabled = TextBox_程序名称.Text != "" && TextBox_程序位置.Text != "";
        }
        // 监视输入框
        private void TextBox_程序位置_TextChanged(object sender, EventArgs e)
        {
            Button_添加.Enabled = TextBox_程序名称.Text != "" && TextBox_程序位置.Text != "";
        }
        // 用对话框选择文件
        private void Button_浏览_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Handling_File(openFileDialog1.FileName);
            }
        }
        // 添加、写入
        private void Button_添加_Click(object sender, EventArgs e)
        {
            string 文件夹名称 = 任务计划文件夹名;
            string 项目名;
            // 任务计划中放入文件夹
            //if (!TextBox_程序名称.Text.StartsWith(文件夹名称))
            项目名 = 文件夹名称 + TextBox_程序名称.Text;
            string TempFileName = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + TextBox_程序名称.Text + ".xml";
            string XML_Text = $"{Resources.XML_前}\n{Resources.XML_程序位置_前}{TextBox_程序位置.Text}{Resources.XML_程序位置_后}"
                ;
            if (TextBox_启动参数.Text != "")
            {
                XML_Text = $"{XML_Text}\n{Resources.XML_启动参数_前}{TextBox_启动参数.Text}{Resources.XML_启动参数_后}";
            }
            if (TextBox_起始位置.Text != "")
            {
                XML_Text = $"{XML_Text}\n{Resources.XML_起始位置_前}{TextBox_起始位置.Text}{Resources.XML_起始位置_后}";
            }
            XML_Text = $"{XML_Text}\n{Resources.XML_后}";
            System.IO.File.WriteAllText(TempFileName, XML_Text, Encoding.Unicode);
            Process Schtask = new Process();
            //Debug.Print("/create " + "/tn " + '"' + TextBox_程序名称.Text + '"' + " /xml " + '"' + @TempFileName + '"');
            //Schtasks.Verb = "runas";
            Schtask.StartInfo = new ProcessStartInfo
            {
                FileName = "schtasks.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = "/create " + "/tn " + '"' + 项目名 + '"' + " /xml " + '"' + @TempFileName + '"'
            };
            Schtask.Start();
            Schtask.WaitForExit();
            bool SchtaskOK = Schtask.ExitCode == 0;
            if (!SchtaskOK)
            {
                MessageBox.Show("计划任务添加失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return;
            }
            Create_Shortcut(项目名, 快捷方式前缀 + TextBox_程序名称.Text);
            System.Threading.Thread.Sleep(200);
            System.IO.File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + @"\" + TextBox_程序名称.Text + ".xml");
            MessageBox.Show("UAC白名单添加完成！\n\n快捷方式位于桌面：\n" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + @"\" + 快捷方式前缀 + TextBox_程序名称.Text + "\n\n只有通过该快捷方式运行才不会提示 UAC，快捷方式可复制、移动、重命名。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // 创建快捷方式
        public void Create_Shortcut(string taskname, string lnkname)
        {
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + @"\" + lnkname + ".lnk");
            //Debug.Print(Path.GetDirectoryName(Application.ExecutablePath) + @"\" + TextBox_程序名称.Text + ".lnk");
            shortcut.TargetPath = "schtasks.exe";
            shortcut.Arguments = "/run " + "/tn " + '"' + taskname + '"';
            shortcut.IconLocation = TextBox_程序位置.Text + ", 0";
            shortcut.WindowStyle = 7;
            shortcut.Save();
        }

        private void Button_打开_Click(object sender, EventArgs e)
        {
            Process.Start("taskschd.msc", "/s");
        }
        // 检查更新
        private void Check_Updates(bool Tipprompt)
        {
            string strHTML = WebClient_cs.GetHTTP.Get_HTTP("https://api.xiu2.xyz/ver/uacbmdxgj.txt");
            Debug.Print(strHTML);
            string[] Ver_Info = strHTML.Split('\n');
            if (Ver_Info.Length > 2)
            {
                if (Ver_Info[1] != "")
                {
                    if (Ver_Info[1] != J_VerInfo)
                    {
                        if (MessageBox.Show("发现新版本 [v" + Ver_Info[1] + "]！是否前往更新？", "发现新版本！", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Process.Start(Ver_Info[2]);
                        }
                    }
                    else
                    {
                        if (Tipprompt == true)
                        {
                            MessageBox.Show("当前已是最新版本 " + J_VerInfo + " ！", "信息：", MessageBoxButtons.OK);
                        }
                        
                    }
                }
                else
                {
                    if (Tipprompt == true)
                    {
                        MessageBox.Show("当前已是最新版本 " + J_VerInfo + " ！", "信息：", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                if (Tipprompt == true)
                {
                    MessageBox.Show("当前已是最新版本 " + J_VerInfo + " ！", "信息：", MessageBoxButtons.OK);
                }
            }
        }

        private void CheckBox_添加到右键菜单_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_添加到右键菜单.Checked)
                AddKey();
            else
                DelKey();
        }
        private void AddKey()
        {
            // UAC 免提醒
            if (Registry.GetValue(@"HKEY_CLASSES_ROOT\exefile\shell\NoUACTool\command\", "", null) == null)
            {
                RegistryKey Key1 = Registry.ClassesRoot.CreateSubKey(@"exefile\shell\NoUACTool");
                RegistryKey Key2 = Registry.ClassesRoot.CreateSubKey(@"exefile\shell\NoUACTool\command");
                Key1.SetValue("", "&UAC 免提醒");
                Key1.SetValue("Icon", '"' + Application.ExecutablePath + '"');
                Key2.SetValue("", '"' + Application.ExecutablePath + '"' + " " + '"' + "%1" + '"');
            }
            if (Registry.GetValue(@"HKEY_CLASSES_ROOT\lnkfile\shell\NoUACTool\command\", "", null) == null)
            {
                RegistryKey Key1 = Registry.ClassesRoot.CreateSubKey(@"lnkfile\shell\NoUACTool");
                RegistryKey Key2 = Registry.ClassesRoot.CreateSubKey(@"lnkfile\shell\NoUACTool\command");
                Key1.SetValue("", "&UAC 免提醒");
                Key1.SetValue("Icon", '"' + Application.ExecutablePath + '"');
                Key2.SetValue("", '"' + Application.ExecutablePath + '"' + " " + '"' + "%1" + '"');
            }
        }
        private void DelKey()
        {
            if (Registry.GetValue(@"HKEY_CLASSES_ROOT\exefile\shell\NoUACTool\command\", "", null) != null)
            {
                Registry.ClassesRoot.DeleteSubKeyTree(@"exefile\shell\NoUACTool");
            }
            if (Registry.GetValue(@"HKEY_CLASSES_ROOT\lnkfile\shell\NoUACTool\command\", "", null) != null)
            {
                Registry.ClassesRoot.DeleteSubKeyTree(@"lnkfile\shell\NoUACTool");
            }
        }
        private void NotKey()
        {
            object value = Registry.GetValue(@"HKEY_CLASSES_ROOT\exefile\shell\NoUACTool\command\", "", null);
            object value2 = Registry.GetValue(@"HKEY_CLASSES_ROOT\lnkfile\shell\NoUACTool\command\", "", null);
            checkBox_添加到右键菜单.Checked = value != null || value2 != null;
        }
        // 切换焦点为输入框
        private void Label_程序位置_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox_程序位置.Focus();
        }

        private void Label_程序名称_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox_程序名称.Focus();
        }

        private void Label_启动参数_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox_启动参数.Focus();
        }

        private void Label_起始位置_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox_起始位置.Focus();
        }
        // 置顶输入框并修改背景颜色
        private void TextBox_程序位置_Enter(object sender, EventArgs e)
        {
            if (TextBox_程序位置.Text != "")
                TextBox_程序位置.BringToFront();
            TextBox_程序位置.BackColor = Label_程序位置.BackColor = Color.Gainsboro;
        }

        private void TextBox_程序位置_Leave(object sender, EventArgs e)
        {
            //if (TextBox_程序位置.Text == "")
            //    TextBox_程序位置.SendToBack();
            TextBox_程序位置.BackColor = Label_程序位置.BackColor = Color.WhiteSmoke;
        }

        private void TextBox_程序名称_Enter(object sender, EventArgs e)
        {
            TextBox_程序名称.BringToFront();
            TextBox_程序名称.BackColor = Label_程序名称.BackColor = Color.Gainsboro;
        }

        private void TextBox_程序名称_Leave(object sender, EventArgs e)
        {
            if (TextBox_程序名称.Text == "")
                TextBox_程序名称.SendToBack();
            TextBox_程序名称.BackColor = Label_程序名称.BackColor = Color.WhiteSmoke;
        }

        private void TextBox_启动参数_Enter(object sender, EventArgs e)
        {
            TextBox_启动参数.BringToFront();
            TextBox_启动参数.BackColor = Label_启动参数.BackColor = Color.Gainsboro;
        }

        private void TextBox_启动参数_Leave(object sender, EventArgs e)
        {
            if (TextBox_启动参数.Text == "")
                TextBox_启动参数.SendToBack();
            TextBox_启动参数.BackColor = Label_启动参数.BackColor = Color.WhiteSmoke;
        }

        private void TextBox_起始位置_Enter(object sender, EventArgs e)
        {
            TextBox_起始位置.BringToFront();
            TextBox_起始位置.BackColor = Label_起始位置.BackColor = Color.Gainsboro;
        }

        private void TextBox_起始位置_Leave(object sender, EventArgs e)
        {
            if (TextBox_起始位置.Text == "")
                TextBox_起始位置.SendToBack();
            TextBox_起始位置.BackColor = Label_起始位置.BackColor = Color.WhiteSmoke;
        }

        private void Button_添加_EnabledChanged(object sender, EventArgs e)
        {
            Button_添加.BackColor = Button_添加.Enabled ? Color.MediumSeaGreen : SystemColors.ButtonShadow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = @"1. [拖拽] 或 [浏览] 选择一个应用程序 (.exe) 或快捷方式 (.lnk) 。
2. [程序名称]随意，但必须唯一，不可重复。
3. [启动参数] 与 [起始位置] 均可选。
4. [添加到 UAC 白名单] 后，你的 [桌面] 就会出现一个快捷方式。
—— 只有通过该快捷方式运行才不提示 UAC！(运行后默认拥有管理员权限)
—— 该快捷方式可以复制、移动、重命名，不影响使用！

勾选 [添加软件到右键菜单] 后，右键菜单中可直接为 .exe 或 .lnk 文件制作 UAC 免提醒的快捷方式。

注意：为了方便寻找和删除，添加白名单时 [程序名称] 前会添加 [" + 快捷方式前缀 + "] 标识。";
            MessageBox.Show(text, "使用方法", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Label_程序位置_Click(object sender, EventArgs e)
        {
            if (TextBox_程序位置.Text == "")
                Button_浏览_Click(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/yfdyh000/UACWhitelistTool");
        }
    }
}

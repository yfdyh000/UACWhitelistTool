using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Text;
using IWshRuntimeLibrary;
using UAC白名单小工具.Properties;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Drawing;

namespace UAC白名单小工具
{
    public partial class Form : System.Windows.Forms.Form
    {
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
            this.Text = "UAC白名单小工具 v" + J_VerInfo;
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
        // 处理拖放进来的文件
        private void Handling_File_Drop(string Drag_File_PATH)
        {
            Debug.Print(Drag_File_PATH);
            if (Path.GetExtension(Drag_File_PATH).ToLower() == ".exe" || Path.GetExtension(Drag_File_PATH).ToLower()  == ".bat")
            {
                if (System.IO.File.Exists(Drag_File_PATH))
                {
                    TextBox_程序位置.Text = Drag_File_PATH;
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
                    MessageBox.Show("文件不存在！请检查！" + Environment.NewLine + Drag_File_PATH, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Path.GetExtension(Drag_File_PATH).ToLower() == ".lnk")
            {
                if (System.IO.File.Exists(Drag_File_PATH))
                {
                    WshShell shell = new WshShell();
                    IWshShortcut Shortcut = (IWshShortcut)shell.CreateShortcut(Drag_File_PATH);
                    if (System.IO.File.Exists(Shortcut.TargetPath))
                    {
                        TextBox_程序位置.Text = Shortcut.TargetPath;
                        TextBox_程序名称.Text = Path.GetFileNameWithoutExtension(TextBox_程序位置.Text);
                        TextBox_启动参数.Text = Shortcut.Arguments;
                        TextBox_起始位置.Text = Shortcut.WorkingDirectory;
                        TextBox_程序位置.BringToFront();
                        TextBox_程序名称.BringToFront();
                        if(TextBox_启动参数.Text != "")
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
                        MessageBox.Show("文件不存在！请检查！" + Environment.NewLine + Shortcut.TargetPath, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("文件不存在！请检查！" + Environment.NewLine + Drag_File_PATH, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("只支持拖入 .exe .lnk 格式的文件！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (Path.GetExtension(openFileDialog1.FileName) == ".exe")
                {
                    if (System.IO.File.Exists(openFileDialog1.FileName))
                    {
                        TextBox_程序位置.Text = openFileDialog1.FileName;
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
                        MessageBox.Show("文件不存在！请检查！" + Environment.NewLine + openFileDialog1.FileName, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (Path.GetExtension(openFileDialog1.FileName) == ".lnk")
                {
                    if (System.IO.File.Exists(openFileDialog1.FileName))
                    {
                        WshShell shell = new WshShell();
                        IWshShortcut Shortcut = (IWshShortcut)shell.CreateShortcut(openFileDialog1.FileName);
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
                            MessageBox.Show("文件不存在！请检查！" + Environment.NewLine + Shortcut.TargetPath, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("文件不存在！请检查！" + Environment.NewLine + openFileDialog1.FileName, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("只支持拖入 .exe .lnk 格式的文件！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // 添加、写入
        private void Button_添加_Click(object sender, EventArgs e)
        {
            string 文件夹名称 = "noUAC\\";
            string 项目名;
            // 任务计划中放入文件夹
            //if (!TextBox_程序名称.Text.StartsWith(文件夹名称))
            项目名 = 文件夹名称 + TextBox_程序名称.Text;
            string TempFileName = Path.GetDirectoryName(Application.ExecutablePath) + @"\" + TextBox_程序名称.Text + ".xml";
            string XML_Text = Resources.XML_前 + Environment.NewLine + Resources.XML_程序位置_前 + TextBox_程序位置.Text + Resources.XML_程序位置_后;
            if (TextBox_启动参数.Text != "")
            {
                XML_Text = XML_Text + Environment.NewLine + Resources.XML_启动参数_前 + TextBox_启动参数.Text + Resources.XML_启动参数_后;
            }
            if (TextBox_起始位置.Text != "")
            {
                XML_Text = XML_Text + Environment.NewLine + Resources.XML_起始位置_前 + TextBox_起始位置.Text + Resources.XML_起始位置_后;
            }
            XML_Text = XML_Text + Environment.NewLine + Resources.XML_后;
            System.IO.File.WriteAllText(TempFileName, XML_Text, Encoding.Unicode);
            ProcessStartInfo Schtasks = new ProcessStartInfo
            {
                FileName = "schtasks.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = "/create " + "/tn " + '"' + 项目名 + '"' + " /xml " + '"' + @TempFileName + '"'
            };
            //Debug.Print("/create " + "/tn " + '"' + TextBox_程序名称.Text + '"' + " /xml " + '"' + @TempFileName + '"');
            //Schtasks.Verb = "runas";
            Process.Start(Schtasks);
            Create_Shortcut(项目名, "noUAC." + TextBox_程序名称.Text);
            System.Threading.Thread.Sleep(200);
            System.IO.File.Delete(Path.GetDirectoryName(Application.ExecutablePath) + @"\" + TextBox_程序名称.Text + ".xml");
            MessageBox.Show("UAC白名单添加完成！\n\n快捷方式位于桌面：\n" + System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory) + @"\" + TextBox_程序名称.Text + "\n\n只有通过该快捷方式运行才不会提示 UAC，快捷方式可复制、移动、重命名。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            //Debug.Print(checkBox_添加到右键菜单.Checked.ToString());
            if (checkBox_添加到右键菜单.Checked == true)
            {
                AddKey();
            }
            else
            {
                DelKey();
            }
            
        }
        private void AddKey()
        {
            if (Registry.GetValue(@"HKEY_CLASSES_ROOT\exefile\shell\添加到 UAC 白名单\command\", "", null) == null)
            {
                RegistryKey Key1 = Registry.ClassesRoot.CreateSubKey(@"exefile\shell\添加到 UAC 白名单");
                RegistryKey Key2 = Registry.ClassesRoot.CreateSubKey(@"exefile\shell\添加到 UAC 白名单\command");
                Key1.SetValue("Icon", '"' + Application.ExecutablePath + '"');
                Key2.SetValue("", '"'+ Application.ExecutablePath + '"' + " " + '"' + "%1" + '"');
                
            }
        }
        private void DelKey()
        {
            if (Registry.GetValue(@"HKEY_CLASSES_ROOT\exefile\shell\添加到 UAC 白名单\command\", "", null) != null)
            {
                Registry.ClassesRoot.DeleteSubKeyTree(@"exefile\shell\添加到 UAC 白名单");
            }
        }
        private void NotKey()
        {
            //RegistryKey Key = Registry.ClassesRoot;
            if (Registry.GetValue(@"HKEY_CLASSES_ROOT\exefile\shell\添加到 UAC 白名单\command\", "", null) == null)
            {
                checkBox_添加到右键菜单.Checked = false;
            }
            else
            {
                checkBox_添加到右键菜单.Checked = true;
            }
            //Debug.Print(Reg.GetValue("").ToString());

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
            //TextBox_程序位置.BringToFront();
            TextBox_程序位置.BackColor = Label_程序位置.BackColor = Color.Gainsboro;
        }

        private void TextBox_程序位置_Leave(object sender, EventArgs e)
        {
            if (TextBox_程序位置.Text == "")
                TextBox_程序位置.SendToBack();
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
            Button_添加.BackColor = Button_添加.Enabled  ?  Color.MediumSeaGreen : SystemColors.ButtonShadow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = @"1. [拖拽] 或 [浏览] 选择一个应用程序 (.exe) 或快捷方式 (.lnk) 。
2. [程序名称]随意，但必须唯一 不可重复。
3. [启动参数] 与 [起始位置] 均可选。
4. [添加到 UAC 白名单] 后，你的 [桌面] 就会出现一个快捷方式。
—— 只有通过该快捷方式运行才不提示 UAC！(运行后默认拥有管理员权限)
—— 该快捷方式可以复制、移动、重命名，不影响使用！

勾选 [添加软件到右键菜单] 后，可直接右键 .exe / .lnk 文件添加到 UAC 白名单。

注意：为了方便寻找和删除，添加白名单时 [程序名称] 前会添加 [noUAC.] 标识。";
            MessageBox.Show(text, "使用方法", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

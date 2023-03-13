namespace UAC免提醒
{
    partial class Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.Label_程序名称 = new System.Windows.Forms.Label();
            this.TextBox_程序名称 = new System.Windows.Forms.TextBox();
            this.TextBox_程序位置 = new System.Windows.Forms.TextBox();
            this.Label_程序位置 = new System.Windows.Forms.Label();
            this.Button_添加 = new System.Windows.Forms.Button();
            this.Button_浏览 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Button_打开 = new System.Windows.Forms.Button();
            this.checkBox_添加到右键菜单 = new System.Windows.Forms.CheckBox();
            this.TextBox_启动参数 = new System.Windows.Forms.TextBox();
            this.Label_启动参数 = new System.Windows.Forms.Label();
            this.TextBox_起始位置 = new System.Windows.Forms.TextBox();
            this.Label_起始位置 = new System.Windows.Forms.Label();
            this.Button_帮助 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // Label_程序名称
            // 
            this.Label_程序名称.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_程序名称.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Label_程序名称.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Label_程序名称.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_程序名称.Location = new System.Drawing.Point(-8, 41);
            this.Label_程序名称.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Label_程序名称.Name = "Label_程序名称";
            this.Label_程序名称.Size = new System.Drawing.Size(512, 40);
            this.Label_程序名称.TabIndex = 0;
            this.Label_程序名称.Text = "     程序名称";
            this.Label_程序名称.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_程序名称.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_程序名称_MouseClick);
            // 
            // TextBox_程序名称
            // 
            this.TextBox_程序名称.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBox_程序名称.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_程序名称.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TextBox_程序名称.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TextBox_程序名称.Location = new System.Drawing.Point(16, 52);
            this.TextBox_程序名称.MaxLength = 256;
            this.TextBox_程序名称.Name = "TextBox_程序名称";
            this.TextBox_程序名称.Size = new System.Drawing.Size(464, 18);
            this.TextBox_程序名称.TabIndex = 2;
            this.TextBox_程序名称.TextChanged += new System.EventHandler(this.TextBox_程序名称_TextChanged);
            this.TextBox_程序名称.Enter += new System.EventHandler(this.TextBox_程序名称_Enter);
            this.TextBox_程序名称.Leave += new System.EventHandler(this.TextBox_程序名称_Leave);
            // 
            // TextBox_程序位置
            // 
            this.TextBox_程序位置.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBox_程序位置.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_程序位置.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TextBox_程序位置.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TextBox_程序位置.Location = new System.Drawing.Point(16, 11);
            this.TextBox_程序位置.MaxLength = 1000;
            this.TextBox_程序位置.Name = "TextBox_程序位置";
            this.TextBox_程序位置.ReadOnly = true;
            this.TextBox_程序位置.ShortcutsEnabled = false;
            this.TextBox_程序位置.Size = new System.Drawing.Size(408, 18);
            this.TextBox_程序位置.TabIndex = 0;
            this.TextBox_程序位置.TextChanged += new System.EventHandler(this.TextBox_程序位置_TextChanged);
            this.TextBox_程序位置.Enter += new System.EventHandler(this.TextBox_程序位置_Enter);
            this.TextBox_程序位置.Leave += new System.EventHandler(this.TextBox_程序位置_Leave);
            // 
            // Label_程序位置
            // 
            this.Label_程序位置.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_程序位置.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Label_程序位置.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Label_程序位置.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_程序位置.Location = new System.Drawing.Point(-8, 0);
            this.Label_程序位置.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Label_程序位置.Name = "Label_程序位置";
            this.Label_程序位置.Size = new System.Drawing.Size(512, 40);
            this.Label_程序位置.TabIndex = 4;
            this.Label_程序位置.Text = "     程序位置";
            this.Label_程序位置.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_程序位置.Click += new System.EventHandler(this.Label_程序位置_Click);
            this.Label_程序位置.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_程序位置_MouseClick);
            // 
            // Button_添加
            // 
            this.Button_添加.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Button_添加.Enabled = false;
            this.Button_添加.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button_添加.FlatAppearance.BorderSize = 0;
            this.Button_添加.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_添加.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Button_添加.ForeColor = System.Drawing.SystemColors.Window;
            this.Button_添加.Location = new System.Drawing.Point(-8, 200);
            this.Button_添加.Name = "Button_添加";
            this.Button_添加.Size = new System.Drawing.Size(512, 44);
            this.Button_添加.TabIndex = 5;
            this.Button_添加.Text = "创建 UAC 免提醒快捷方式";
            this.Button_添加.UseVisualStyleBackColor = false;
            this.Button_添加.EnabledChanged += new System.EventHandler(this.Button_添加_EnabledChanged);
            this.Button_添加.Click += new System.EventHandler(this.Button_添加_Click);
            // 
            // Button_浏览
            // 
            this.Button_浏览.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Button_浏览.FlatAppearance.BorderSize = 0;
            this.Button_浏览.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_浏览.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Button_浏览.ForeColor = System.Drawing.SystemColors.Window;
            this.Button_浏览.Location = new System.Drawing.Point(440, 0);
            this.Button_浏览.Name = "Button_浏览";
            this.Button_浏览.Size = new System.Drawing.Size(55, 40);
            this.Button_浏览.TabIndex = 1;
            this.Button_浏览.Text = "浏览";
            this.Button_浏览.UseVisualStyleBackColor = false;
            this.Button_浏览.Click += new System.EventHandler(this.Button_浏览_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.DereferenceLinks = false;
            this.openFileDialog1.Filter = "快捷方式或可执行文件(*.exe;*.bat;*.lnk)|*.exe;*.bat;*.lnk";
            this.openFileDialog1.ReadOnlyChecked = true;
            this.openFileDialog1.ShowReadOnly = true;
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.Title = "选择一个应用程序或快捷方式";
            this.openFileDialog1.ValidateNames = false;
            // 
            // Button_打开
            // 
            this.Button_打开.BackColor = System.Drawing.Color.IndianRed;
            this.Button_打开.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Button_打开.FlatAppearance.BorderSize = 0;
            this.Button_打开.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_打开.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Button_打开.ForeColor = System.Drawing.SystemColors.Window;
            this.Button_打开.Location = new System.Drawing.Point(-8, 242);
            this.Button_打开.Name = "Button_打开";
            this.Button_打开.Size = new System.Drawing.Size(512, 36);
            this.Button_打开.TabIndex = 6;
            this.Button_打开.Text = "去 [任务计划] 手动删除白名单任务";
            this.Button_打开.UseVisualStyleBackColor = false;
            this.Button_打开.Click += new System.EventHandler(this.Button_打开_Click);
            // 
            // checkBox_添加到右键菜单
            // 
            this.checkBox_添加到右键菜单.AutoSize = true;
            this.checkBox_添加到右键菜单.FlatAppearance.BorderSize = 0;
            this.checkBox_添加到右键菜单.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox_添加到右键菜单.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBox_添加到右键菜单.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.checkBox_添加到右键菜单.Location = new System.Drawing.Point(16, 168);
            this.checkBox_添加到右键菜单.Name = "checkBox_添加到右键菜单";
            this.checkBox_添加到右键菜单.Size = new System.Drawing.Size(165, 24);
            this.checkBox_添加到右键菜单.TabIndex = 8;
            this.checkBox_添加到右键菜单.Text = "添加本软件到右键菜单";
            this.checkBox_添加到右键菜单.UseVisualStyleBackColor = true;
            this.checkBox_添加到右键菜单.CheckedChanged += new System.EventHandler(this.CheckBox_添加到右键菜单_CheckedChanged);
            // 
            // TextBox_启动参数
            // 
            this.TextBox_启动参数.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBox_启动参数.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_启动参数.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TextBox_启动参数.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TextBox_启动参数.Location = new System.Drawing.Point(16, 93);
            this.TextBox_启动参数.MaxLength = 23333;
            this.TextBox_启动参数.Name = "TextBox_启动参数";
            this.TextBox_启动参数.Size = new System.Drawing.Size(464, 18);
            this.TextBox_启动参数.TabIndex = 3;
            this.TextBox_启动参数.Enter += new System.EventHandler(this.TextBox_启动参数_Enter);
            this.TextBox_启动参数.Leave += new System.EventHandler(this.TextBox_启动参数_Leave);
            // 
            // Label_启动参数
            // 
            this.Label_启动参数.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_启动参数.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Label_启动参数.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Label_启动参数.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_启动参数.Location = new System.Drawing.Point(-8, 82);
            this.Label_启动参数.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Label_启动参数.Name = "Label_启动参数";
            this.Label_启动参数.Size = new System.Drawing.Size(512, 40);
            this.Label_启动参数.TabIndex = 9;
            this.Label_启动参数.Text = "     启动参数（可选）";
            this.Label_启动参数.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_启动参数.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_启动参数_MouseClick);
            // 
            // TextBox_起始位置
            // 
            this.TextBox_起始位置.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TextBox_起始位置.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox_起始位置.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.TextBox_起始位置.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TextBox_起始位置.Location = new System.Drawing.Point(16, 134);
            this.TextBox_起始位置.MaxLength = 23333;
            this.TextBox_起始位置.Name = "TextBox_起始位置";
            this.TextBox_起始位置.Size = new System.Drawing.Size(464, 18);
            this.TextBox_起始位置.TabIndex = 4;
            this.TextBox_起始位置.Enter += new System.EventHandler(this.TextBox_起始位置_Enter);
            this.TextBox_起始位置.Leave += new System.EventHandler(this.TextBox_起始位置_Leave);
            // 
            // Label_起始位置
            // 
            this.Label_起始位置.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Label_起始位置.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Label_起始位置.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Label_起始位置.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label_起始位置.Location = new System.Drawing.Point(-8, 123);
            this.Label_起始位置.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.Label_起始位置.Name = "Label_起始位置";
            this.Label_起始位置.Size = new System.Drawing.Size(512, 40);
            this.Label_起始位置.TabIndex = 11;
            this.Label_起始位置.Text = "     起始位置（可选）";
            this.Label_起始位置.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label_起始位置.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_起始位置_MouseClick);
            // 
            // Button_帮助
            // 
            this.Button_帮助.BackColor = System.Drawing.Color.White;
            this.Button_帮助.FlatAppearance.BorderSize = 0;
            this.Button_帮助.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_帮助.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Button_帮助.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.Button_帮助.Location = new System.Drawing.Point(420, 164);
            this.Button_帮助.Name = "Button_帮助";
            this.Button_帮助.Size = new System.Drawing.Size(75, 32);
            this.Button_帮助.TabIndex = 7;
            this.Button_帮助.Text = "使用说明";
            this.Button_帮助.UseVisualStyleBackColor = false;
            this.Button_帮助.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(361, 176);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "项目页面";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(495, 273);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.Button_帮助);
            this.Controls.Add(this.Button_添加);
            this.Controls.Add(this.checkBox_添加到右键菜单);
            this.Controls.Add(this.Button_打开);
            this.Controls.Add(this.Button_浏览);
            this.Controls.Add(this.Label_程序位置);
            this.Controls.Add(this.Label_起始位置);
            this.Controls.Add(this.Label_启动参数);
            this.Controls.Add(this.Label_程序名称);
            this.Controls.Add(this.TextBox_起始位置);
            this.Controls.Add(this.TextBox_启动参数);
            this.Controls.Add(this.TextBox_程序位置);
            this.Controls.Add(this.TextBox_程序名称);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UAC 免提醒";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_程序名称;
        private System.Windows.Forms.TextBox TextBox_程序名称;
        private System.Windows.Forms.TextBox TextBox_程序位置;
        private System.Windows.Forms.Label Label_程序位置;
        private System.Windows.Forms.Button Button_添加;
        private System.Windows.Forms.Button Button_浏览;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Button_打开;
        private System.Windows.Forms.CheckBox checkBox_添加到右键菜单;
        private System.Windows.Forms.TextBox TextBox_启动参数;
        private System.Windows.Forms.Label Label_启动参数;
        private System.Windows.Forms.TextBox TextBox_起始位置;
        private System.Windows.Forms.Label Label_起始位置;
        private System.Windows.Forms.Button Button_帮助;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}


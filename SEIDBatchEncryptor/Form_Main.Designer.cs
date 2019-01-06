namespace SEIDBatchEncryptor
{
    partial class Form_Main
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
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button_Open = new System.Windows.Forms.Button();
            this.checkBox_OverWrite = new System.Windows.Forms.CheckBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_Input
            // 
            this.textBox_Input.AllowDrop = true;
            this.textBox_Input.Location = new System.Drawing.Point(202, 41);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(560, 35);
            this.textBox_Input.TabIndex = 1;
            this.textBox_Input.TextChanged += new System.EventHandler(this.textBox_Input_TextChanged);
            this.textBox_Input.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_Input_DragDrop);
            this.textBox_Input.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_Input_DragEnter);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Excel文件|*.xls;*.xlsx|所有文件|*.*";
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(12, 41);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(184, 36);
            this.button_Open.TabIndex = 2;
            this.button_Open.Text = "选择Excel文件";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // checkBox_OverWrite
            // 
            this.checkBox_OverWrite.AutoSize = true;
            this.checkBox_OverWrite.Location = new System.Drawing.Point(12, 105);
            this.checkBox_OverWrite.Name = "checkBox_OverWrite";
            this.checkBox_OverWrite.Size = new System.Drawing.Size(162, 28);
            this.checkBox_OverWrite.TabIndex = 3;
            this.checkBox_OverWrite.Text = "写入源文件";
            this.checkBox_OverWrite.UseVisualStyleBackColor = true;
            // 
            // button_Start
            // 
            this.button_Start.Enabled = false;
            this.button_Start.Location = new System.Drawing.Point(633, 158);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(129, 39);
            this.button_Start.TabIndex = 4;
            this.button_Start.Text = "开始";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(202, 96);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(560, 37);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(241, 158);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(0, 24);
            this.label.TabIndex = 6;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 209);
            this.Controls.Add(this.label);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.checkBox_OverWrite);
            this.Controls.Add(this.button_Open);
            this.Controls.Add(this.textBox_Input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form_Main";
            this.Text = "SEIDBatchEncryptor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.CheckBox checkBox_OverWrite;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label;
    }
}


﻿namespace DotNetSample
{
    partial class FrmMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(70, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 71);
            this.button1.TabIndex = 0;
            this.button1.Text = "控件字体自适应缩放";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(250, 57);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 71);
            this.button2.TabIndex = 0;
            this.button2.Text = "判断.Net Framework版本是否存在";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(673, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 98);
            this.button3.TabIndex = 0;
            this.button3.Text = "demo1 要引用DevExpress.XtraBars.v11.1、DevExpress.XtraBars.v11.1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(673, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 71);
            this.button4.TabIndex = 0;
            this.button4.Text = "自定义做一个右下角弹出框";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(70, 134);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(174, 71);
            this.button5.TabIndex = 0;
            this.button5.Text = "读取资源图片显示";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(70, 211);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(174, 71);
            this.button6.TabIndex = 0;
            this.button6.Text = "ThoughtWorks.QRCode生成二维码";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(250, 134);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(174, 71);
            this.button7.TabIndex = 0;
            this.button7.Text = "透明窗体";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(250, 211);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(174, 71);
            this.button8.TabIndex = 0;
            this.button8.Text = "ListView添加按钮列";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 450);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}


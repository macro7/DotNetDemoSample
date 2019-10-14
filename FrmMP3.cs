using DotNetSample.Utils;
using System;
using System.IO;
using System.Windows.Forms;

namespace DotNetSample
{
    public partial class FrmMP3 : Form
    {
        public FrmMP3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 播放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (Stream temp = Properties.Resources.Windows_Logon)
            {
                var orgbuffer = new byte[temp.Length];
                temp.Read(orgbuffer, 0, (int)temp.Length);
                temp.Close();
                MP3Helper.Stop();
                MP3Helper.Play(orgbuffer, false);  // 第二参数可以 循环播放。 如果要停止 调用MP3Helper.Pause();
            }
        }

        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            MP3Helper.Pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MP3Helper.Stop();
            MP3Helper.Play(textBox1.Text, false);  // 第二参数可以 循环播放。 如果要停止 调用MP3Helper.Pause();
        }
    }
}

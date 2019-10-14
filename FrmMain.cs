using DevExpress.XtraBars.Alerter;
using System;
using System.Windows.Forms;

namespace DotNetSample
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrmAutoSize().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FrmDotNetFrameWorkExists().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AlertControl alert = new AlertControl();
            alert.ShowPinButton = false;
            //alert.ShowCloseButton = false;
            alert.Show(this, caption: "张三", text: "李四", hotTrackedText: "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AlterForm alterForm = new AlterForm(10);
            alterForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new FrmPictureBox().ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new FrmRQCode().ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new FrmListViewDemo().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new FrmOpacity().Show();
        }
    }
}

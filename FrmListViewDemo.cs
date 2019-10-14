using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetSample
{
    public partial class FrmListViewDemo : Form
    {
        //private Button btn = new Button();
        int buttonWidth = 60;
        public FrmListViewDemo()
        {
            InitializeComponent();
            columnHeader1.Width = buttonWidth;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ListViewItem[] lvs = new ListViewItem[3];
            lvs[0] = new ListViewItem(new string[] { "", "行1列1" });
            lvs[1] = new ListViewItem(new string[] { "", "行2列1" });
            lvs[2] = new ListViewItem(new string[] { "", "行3列1" });
            listView1.Items.AddRange(lvs);

            for (var i = 0; i < listView1.Items.Count; i++)
            {
                PictureBox btn = new PictureBox
                {
                    Text = "按钮"
                };
                btn.Click += button_Click;
                btn.Tag = listView1.Items[i].SubItems[1].Text;
                listView1.Controls.Add(btn);
                btn.Size = new Size(buttonWidth, listView1.Items[i].SubItems[0].Bounds.Height);
                btn.Location = new Point(listView1.Items[i].SubItems[0].Bounds.Left,
                        listView1.Items[i].SubItems[0].Bounds.Top);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
            }
        }
        private void button_Click(object sender, EventArgs e)
        {
            var obj = (sender as PictureBox).Tag.ToString();
            MessageBox.Show(obj);
        }
    }
}

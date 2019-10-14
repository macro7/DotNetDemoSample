using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetSample
{
    public partial class FrmAutoSize : Form
    {
        public FrmAutoSize()
        {
            InitializeComponent();
            x = this.panel1.Width;
            y = this.panel1.Height;
            setTag(this);
        }

        #region 控件大小随窗体大小等比例缩放
        private float x;//定义当前窗体的宽度
        private float y;//定义当前窗体的高度
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx);//宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx);//左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy);//顶边距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                    con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //float newx = (this.Width) / x;
            //float newy = (this.Height) / y;
            //setControls(newx, newy, this);
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel1.Width = Convert.ToInt32(this.panel1.Width * 1.2);
            this.panel1.Height = Convert.ToInt32(this.panel1.Height * 1.2);
            float newx = (this.panel1.Width) / x;
            float newy = (this.panel1.Height) / y;
            setControls(newx, newy, this.panel1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel1.Width = Convert.ToInt32(this.panel1.Width / 1.2);
            this.panel1.Height = Convert.ToInt32(this.panel1.Height / 1.2);
            float newx = (this.panel1.Width) / x;
            float newy = (this.panel1.Height) / y;
            setControls(newx, newy, this.panel1);
        }
    }
}

using DotNetSample.Utils;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DotNetSample
{
    public partial class FrmChangeSQLitePassWord : Form
    {
        const string dbName = "testchangepass.db";
        readonly string file = Path.Combine(Path.Combine(Application.StartupPath, "Data"), dbName);
        public FrmChangeSQLitePassWord()
        {
            InitializeComponent();

            if (!File.Exists(file))
            {
                SQLiteHelper.CreateDBFile(dbName);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //label1的字体样式设置
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Font = new System.Drawing.Font("黑体", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            base.OnResize(e);
            int x = (int)(0.5 * (Width - label1.Width));
            int y = label1.Location.Y;
            label1.Location = new System.Drawing.Point(x, y);


            //控件根据窗体的大小变化而变化，等比例放大缩小
            Resize += new EventHandler(Form1_Resize);
            X = Width;
            Y = Height;
            setTag(this);
            Form1_Resize(new object(), new EventArgs());

            //窗体全屏打开
            //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

        string connString()
        {
            var connectionSting = string.IsNullOrEmpty(textBox1.Text.Trim()) ? file + ";" : file + $";Password={textBox1.Text.Trim()};";
            return connectionSting;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            var originalPassword = txtOldPass.Text.Trim();
            var newPassword = txtNewPass.Text.Trim();
            using (var conn = SQLiteHelper.GetConnection(connString()))
            {
                if (!string.IsNullOrEmpty(originalPassword))
                {
                    conn.SetPassword(originalPassword);
                }
                conn.Open();
                if (!string.IsNullOrEmpty(newPassword))
                {
                    conn.ChangePassword(newPassword);
                    conn.Close();
                }
            }
            //SQLiteHelper.ChangePassword(connString(), txtNewPass.Text.Trim(), txtOldPass.Text.Trim());
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (var conn = SQLiteHelper.GetConnection(connString()))
            {
                conn.Open();

                var dt = SQLiteHelper.GetDataTable(conn, "select * from ds");
                MessageBox.Show(conn.State.ToString());
            }
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            using (var conn = SQLiteHelper.GetConnection(connString()))
            {
                conn.Open();

                var t = SQLiteHelper.NewTable(conn, "ds");
            }
        }
        int y = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2 == null)
            {
                createtext();
            }
            button1.Enabled = false;
            Cursor = Cursors.WaitCursor;
            var t = richTextBox1.Text;
            textBox2.MaxLength = 2000;

            for (var i = 0; i < 1000; i++)
            {
                t += i.ToString();
            }

            richTextBox1.Text = t;
            textBox2.Text = "";
            textBox2.Text = t;
            textBox2.Update();
            Refresh();
            panel1.Text = t;

            Thread.Sleep(500);
            button1.Enabled = true;

            y++;
            if (y > 4)
            {
                createtext();
                y = 0;
            }

            Cursor = Cursors.Default;
        }
        System.Windows.Forms.TextBox textBox2;

        void createtext()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    if (c.Name == "textBox2")
                    {
                        c.Text = "";
                        c.Dispose();
                        Controls.Remove(c);
                        textBox2 = new TextBox();
                        break;
                    }
                }
            }
            textBox2 = new System.Windows.Forms.TextBox();
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(645, 12);
            textBox2.MaxLength = 2000;
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ShortcutsEnabled = false;
            textBox2.Size = new System.Drawing.Size(352, 253);
            textBox2.TabIndex = 1;
            textBox2.Text = "1234";
            Controls.Add(textBox2);
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private float X;
        private float Y;
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }

        private void setControl(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)a;
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)a;
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)a;
                Single currentsize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentsize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControl(newx, newy, con);
                }
            }
        }

        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (Width) / X;
            float newy = (Height) / Y;
            setControl(newx, newy, this);
            Text = Width.ToString() + "" + Height.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

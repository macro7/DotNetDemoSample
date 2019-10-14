using System;
using System.Windows.Forms;

namespace DotNetSample
{
    public partial class AlterForm : Form
    {
        int timerOut = 10;
        public AlterForm(int timeout = 0)
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.None;
            ControlBox = false;

            timerOut = timeout;

            TopMost = true;
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - Width,
                Screen.PrimaryScreen.WorkingArea.Height - Height);

            if (timeout > 0)
            {
                timer1.Tick += Timer1_Tick;
                timer1.Interval = 1000;
                timer1.Start();
            }
        }

        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            timerOut--;
            Opacity = Convert.ToDouble(timerOut) / Convert.ToDouble(10.00) * Convert.ToDouble(1.5);
            if (timerOut == 0)
            {
                Close();
            }
        }
    }
}

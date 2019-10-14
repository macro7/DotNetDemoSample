using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Util;

namespace DotNetSample
{
    public partial class FrmRQCode : Form
    {
        public FrmRQCode()
        {
            InitializeComponent();

            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;

        }

        Bitmap Encode(string content)
        {
            QRCodeEncoder encoder = new QRCodeEncoder
            {
                QRCodeVersion = 0
            };
            if (QRCodeUtility.IsUniCode(content))
            {
                //return Encode(content, Encoding.Unicode);
                //支持中文
                return encoder.Encode(content, Encoding.UTF8);
            }
            else
            {
                return encoder.Encode(content, Encoding.ASCII);
            }
        }

        private void richTextBox1_TextChanged(object sender, System.EventArgs e)
        {
            pictureBox1.BackgroundImage = Encode(richTextBox1.Text);
        }
    }
}

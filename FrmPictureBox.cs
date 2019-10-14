using System;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetSample
{
    public partial class FrmPictureBox : Form
    {
        public FrmPictureBox()
        {
            InitializeComponent();
            var uri = new Uri("https://xutuface2face.oss-cn-shanghai.aliyuncs.com/1537689927103%5C.png?Expires=1568259552&OSSAccessKeyId=TMP.hW3JVCQ23C6VDaCzMxnikT1Yb9rLpMk7tJxvPoMow3R9adMdGtcxC5NqdQTZBa3MuyYTwSU918Me8KWjc9Q8BrAE6PzbicoQzrLj1H5RzjwBpRyb5YX5a7ojhCWaRa.tmp&Signature=IbZJKWRwlGP2GCp%2FTO0%2FyC6oCSg%3D");
            System.Net.WebRequest webreq = System.Net.WebRequest.Create(uri.ToString());
            webreq.Timeout = 20000;
            System.Net.WebResponse webres = webreq.GetResponse();

            using (System.IO.Stream stream = webres.GetResponseStream())
            {
                Image i = Image.FromStream(stream);
                i.Save("e:\\1.jpg");  //图片保存
                //pictureBox1.Image = i;  //图片显示
            }
            //Uri uri = new Uri("http://47.92.169.106:81/Modules/Fugao.NIS/Styles/images/login-img.jpg");
            //uri = new Uri("https://xutuface2face.oss-cn-shanghai.aliyuncs.com/1537689927103%5C.png?Expires=1568259552&OSSAccessKeyId=TMP.hW3JVCQ23C6VDaCzMxnikT1Yb9rLpMk7tJxvPoMow3R9adMdGtcxC5NqdQTZBa3MuyYTwSU918Me8KWjc9Q8BrAE6PzbicoQzrLj1H5RzjwBpRyb5YX5a7ojhCWaRa.tmp&Signature=IbZJKWRwlGP2GCp%2FTO0%2FyC6oCSg%3D");
            //Image _image = Image.FromStream(WebRequest.Create(uri).GetResponse().GetResponseStream());
            //this.BackgroundImage = _image;
            BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}

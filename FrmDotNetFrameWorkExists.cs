using System.IO;
using System.Windows.Forms;

namespace DotNetSample
{
    public partial class FrmDotNetFrameWorkExists : Form
    {
        public FrmDotNetFrameWorkExists()
        {
            InitializeComponent();

            string strCmd = @"dir %windir%\\Microsoft.Net\\Framework\\v4.*";
            string versionDotNetFrameWork = ExcuteCmd(strCmd);
            if (!versionDotNetFrameWork.Contains("v4.0.30319"))
            {
                MessageBox.Show("检测到系统可能未安装.Net FrameWork 4.5,如果已安装更高版本则继续运行，否则请安装该环境！");
            }
        }

        public string ExcuteCmd(string c, string workDirectory = null)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WorkingDirectory = workDirectory;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardInput = true;
            process.Start();

            process.StandardInput.WriteLine(c);
            process.StandardInput.AutoFlush = true;
            process.StandardInput.WriteLine("exit");

            StreamReader reader = process.StandardOutput;//截取输出流

            string output = reader.ReadLine();//每次读取一行

            while (!reader.EndOfStream)
            {
                //PrintThrendInfo(output);
                output += reader.ReadLine();
            }

            process.WaitForExit();
            return output;
        }
    }
}

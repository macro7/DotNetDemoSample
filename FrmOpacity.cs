using System.Drawing;
using System.Windows.Forms;

namespace DotNetSample
{
    public partial class FrmOpacity : Form
    {
        public FrmOpacity()
        {
            InitializeComponent();

            TransparencyKey = Color.AliceBlue;
            BackColor = Color.AliceBlue;
        }
    }
}

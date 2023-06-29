using System.Drawing;
using System.Windows.Forms;

namespace Synchronizer.ProgressWindow
{
    public partial class ProgressWindow : Form
    {
        public ProgressWindow()
        {
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right,
                Screen.PrimaryScreen.WorkingArea.Bottom);
            InitializeComponent();
        }
    }
}

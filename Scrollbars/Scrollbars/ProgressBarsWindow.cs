
using System;
using Wisej.Web;

namespace ProgressBars
{
    public partial class ProgressBarsWindow : Form
    {
        public ProgressBarsWindow()
        {
            InitializeComponent();
        }

        private void btnMarqueeProgressBarStart_Click(object sender, EventArgs e)
        {
            marqueeProgressBar.Start();
        }

        private void btnMarqueeProgressBarStop_Click(object sender, EventArgs e)
        {
            marqueeProgressBar.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPAM {
    public partial class SplashScreen : Form {
        public SplashScreen() {
            InitializeComponent();
        }

        public void AppendMaximum(int progress) {
            LoadProgress.Maximum += progress;
        }

        public void UpdateStatus(string? text) {
            if (text is null || text.IsEmpty()) {
                LoadProgress.Style = ProgressBarStyle.Marquee;
                UpdateStatus("Loading... Please wait", 0);
                return;
            }
            LoadProgress.Style = ProgressBarStyle.Blocks;
            UpdateStatus(text, 1);
        }

        public void UpdateStatus(string text, int progressValue) {
            LoadProgress.Value += progressValue;
            StatusLbl.Text = text;
            Invalidate();
        }

        private void SplashScreen_Load(object sender, EventArgs e) {

        }
    }
}

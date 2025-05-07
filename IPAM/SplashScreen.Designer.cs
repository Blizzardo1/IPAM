namespace IPAM {
    partial class SplashScreen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            StatusLbl = new Label();
            LoadProgress = new ProgressBar();
            SuspendLayout();
            // 
            // StatusLbl
            // 
            StatusLbl.BackColor = Color.Transparent;
            StatusLbl.Location = new Point(12, 418);
            StatusLbl.Name = "StatusLbl";
            StatusLbl.Size = new Size(776, 24);
            StatusLbl.TabIndex = 0;
            StatusLbl.Text = "Loading... Please wait";
            StatusLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoadProgress
            // 
            LoadProgress.Dock = DockStyle.Bottom;
            LoadProgress.Location = new Point(0, 440);
            LoadProgress.Maximum = 1;
            LoadProgress.Name = "LoadProgress";
            LoadProgress.Size = new Size(800, 10);
            LoadProgress.Style = ProgressBarStyle.Marquee;
            LoadProgress.TabIndex = 1;
            // 
            // SplashScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LoadProgress);
            Controls.Add(StatusLbl);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashScreen";
            Load += SplashScreen_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label StatusLbl;
        private ProgressBar LoadProgress;
    }
}
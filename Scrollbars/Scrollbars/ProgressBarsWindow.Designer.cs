namespace ProgressBars
{
    partial class ProgressBarsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Wisej.NET Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            marqueeProgressBar = new ProgressBars.Controls.MarqueeProgressBar();
            groupBoxMarqueeProgressBar = new Wisej.Web.GroupBox();
            btnMarqueeProgressBarStart = new Wisej.Web.Button();
            btnMarqueeProgressBarStop = new Wisej.Web.Button();
            groupBoxMarqueeProgressBar.SuspendLayout();
            SuspendLayout();
            // 
            // marqueeProgressBar
            // 
            marqueeProgressBar.Anchor = Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Left | Wisej.Web.AnchorStyles.Right;
            marqueeProgressBar.Location = new System.Drawing.Point(6, 18);
            marqueeProgressBar.Name = "marqueeProgressBar";
            marqueeProgressBar.Size = new System.Drawing.Size(594, 10);
            marqueeProgressBar.TabIndex = 0;
            // 
            // groupBoxMarqueeProgressBar
            // 
            groupBoxMarqueeProgressBar.Anchor = Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Left | Wisej.Web.AnchorStyles.Right;
            groupBoxMarqueeProgressBar.Controls.Add(btnMarqueeProgressBarStop);
            groupBoxMarqueeProgressBar.Controls.Add(marqueeProgressBar);
            groupBoxMarqueeProgressBar.Controls.Add(btnMarqueeProgressBarStart);
            groupBoxMarqueeProgressBar.Cursor = null;
            groupBoxMarqueeProgressBar.Location = new System.Drawing.Point(3, 3);
            groupBoxMarqueeProgressBar.Name = "groupBoxMarqueeProgressBar";
            groupBoxMarqueeProgressBar.Size = new System.Drawing.Size(607, 65);
            groupBoxMarqueeProgressBar.TabIndex = 1;
            groupBoxMarqueeProgressBar.Text = "MarqueeProgressBar";
            // 
            // btnMarqueeProgressBarStart
            // 
            btnMarqueeProgressBarStart.Anchor = Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right;
            btnMarqueeProgressBarStart.Location = new System.Drawing.Point(438, 34);
            btnMarqueeProgressBarStart.Name = "btnMarqueeProgressBarStart";
            btnMarqueeProgressBarStart.Size = new System.Drawing.Size(78, 23);
            btnMarqueeProgressBarStart.TabIndex = 2;
            btnMarqueeProgressBarStart.Text = "Start";
            btnMarqueeProgressBarStart.Click += this.btnMarqueeProgressBarStart_Click;
            // 
            // btnMarqueeProgressBarStop
            // 
            btnMarqueeProgressBarStop.Anchor = Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Right;
            btnMarqueeProgressBarStop.Location = new System.Drawing.Point(522, 34);
            btnMarqueeProgressBarStop.Name = "btnMarqueeProgressBarStop";
            btnMarqueeProgressBarStop.Size = new System.Drawing.Size(78, 23);
            btnMarqueeProgressBarStop.TabIndex = 3;
            btnMarqueeProgressBarStop.Text = "Stop";
            btnMarqueeProgressBarStop.Click += this.btnMarqueeProgressBarStop_Click;
            // 
            // ProgressBarsWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            ClientSize = new System.Drawing.Size(613, 432);
            Controls.Add(groupBoxMarqueeProgressBar);
            Name = "ProgressBarsWindow";
            Text = "Propgress Bars";
            groupBoxMarqueeProgressBar.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private Controls.MarqueeProgressBar marqueeProgressBar;
        private Wisej.Web.GroupBox groupBoxMarqueeProgressBar;
        private Wisej.Web.Button btnMarqueeProgressBarStop;
        private Wisej.Web.Button btnMarqueeProgressBarStart;
    }
}


namespace WF
{
    partial class YesNoForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YesNoForm));
            this.timerForVisible = new System.Windows.Forms.Timer(this.components);
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.borderPanel = new WF.MyPanel();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.borderPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timerForVisible
            // 
            this.timerForVisible.Interval = 40;
            this.timerForVisible.Tick += new System.EventHandler(this.timerForVisible_Tick);
            // 
            // buttonYes
            // 
            resources.ApplyResources(this.buttonYes, "buttonYes");
            this.buttonYes.BackColor = System.Drawing.Color.Gray;
            this.buttonYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.UseVisualStyleBackColor = false;
            this.buttonYes.Click += new System.EventHandler(this.button_Click);
            // 
            // buttonNo
            // 
            resources.ApplyResources(this.buttonNo, "buttonNo");
            this.buttonNo.BackColor = System.Drawing.Color.Gray;
            this.buttonNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.UseVisualStyleBackColor = false;
            this.buttonNo.Click += new System.EventHandler(this.button_Click);
            // 
            // borderPanel
            // 
            resources.ApplyResources(this.borderPanel, "borderPanel");
            this.borderPanel.BackColor = System.Drawing.Color.Transparent;
            this.borderPanel.Controls.Add(this.mainPanel);
            this.borderPanel.ForeColor = System.Drawing.Color.Transparent;
            this.borderPanel.Name = "borderPanel";
            // 
            // mainPanel
            // 
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Controls.Add(this.buttonsPanel, 0, 1);
            this.mainPanel.Controls.Add(this.pictureBox, 0, 0);
            this.mainPanel.Controls.Add(this.label, 1, 0);
            this.mainPanel.Name = "mainPanel";
            // 
            // buttonsPanel
            // 
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.mainPanel.SetColumnSpan(this.buttonsPanel, 2);
            this.buttonsPanel.Controls.Add(this.buttonYes, 0, 0);
            this.buttonsPanel.Controls.Add(this.buttonNo, 1, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Image = global::WF.Properties.Resources.question;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Name = "label";
            // 
            // YesNoForm
            // 
            this.AcceptButton = this.buttonYes;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonNo;
            this.Controls.Add(this.borderPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YesNoForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.YesNoForm_FormClosing);
            this.Load += new System.EventHandler(this.YesNoForm_Load);
            this.borderPanel.ResumeLayout(false);
            this.borderPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyPanel borderPanel;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.TableLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Timer timerForVisible;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label;
    }
}
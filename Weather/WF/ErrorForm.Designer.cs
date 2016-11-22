namespace WF
{
    partial class ErrorForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorForm));
            this.button = new System.Windows.Forms.Button();
            this.borderPanel = new WF.MyPanel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.timerForVisible = new System.Windows.Forms.Timer(this.components);
            this.borderPanel.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button
            // 
            resources.ApplyResources(this.button, "button");
            this.button.BackColor = System.Drawing.Color.Gray;
            this.button.ForeColor = System.Drawing.Color.White;
            this.button.Name = "button";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.button1_Click);
            // 
            // borderPanel
            // 
            resources.ApplyResources(this.borderPanel, "borderPanel");
            this.borderPanel.BackColor = System.Drawing.Color.Transparent;
            this.borderPanel.Controls.Add(this.panelBottom);
            this.borderPanel.Controls.Add(this.panelTop);
            this.borderPanel.Name = "borderPanel";
            // 
            // panelBottom
            // 
            resources.ApplyResources(this.panelBottom, "panelBottom");
            this.panelBottom.Controls.Add(this.button);
            this.panelBottom.Name = "panelBottom";
            // 
            // panelTop
            // 
            resources.ApplyResources(this.panelTop, "panelTop");
            this.panelTop.Controls.Add(this.pictureBox);
            this.panelTop.Controls.Add(this.label);
            this.panelTop.Name = "panelTop";
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::WF.Properties.Resources.error;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.MaximumSize = new System.Drawing.Size(200, 0);
            this.label.Name = "label";
            // 
            // timerForVisible
            // 
            this.timerForVisible.Interval = 40;
            this.timerForVisible.Tick += new System.EventHandler(this.timerForVisible_Tick);
            // 
            // ErrorForm
            // 
            this.AcceptButton = this.button;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.borderPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ErrorForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ErrorForm_FormClosing);
            this.Load += new System.EventHandler(this.ErrorForm_Load);
            this.borderPanel.ResumeLayout(false);
            this.borderPanel.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyPanel borderPanel;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.FlowLayoutPanel panelTop;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Timer timerForVisible;
    }
}
namespace WF
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timerForUpdate = new System.Windows.Forms.Timer(this.components);
            this.timerForVisible = new System.Windows.Forms.Timer(this.components);
            this.borderPanel = new WF.MyPanel();
            this.pictureBoxProgress = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelCity = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelRange = new System.Windows.Forms.Label();
            this.labelComment = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.forecastPanel = new System.Windows.Forms.TableLayoutPanel();
            this.secondPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelSecondDay = new System.Windows.Forms.Label();
            this.pictureBoxSecond = new System.Windows.Forms.PictureBox();
            this.labelSecondTemperature = new System.Windows.Forms.Label();
            this.firstPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelFirstDay = new System.Windows.Forms.Label();
            this.pictureBoxFirst = new System.Windows.Forms.PictureBox();
            this.labelFirstTemperature = new System.Windows.Forms.Label();
            this.thirdPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelThirdDay = new System.Windows.Forms.Label();
            this.pictureBoxThird = new System.Windows.Forms.PictureBox();
            this.labelThirdTemperature = new System.Windows.Forms.Label();
            this.buttonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.contextMenuStrip.SuspendLayout();
            this.borderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.forecastPanel.SuspendLayout();
            this.secondPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecond)).BeginInit();
            this.firstPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirst)).BeginInit();
            this.thirdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThird)).BeginInit();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSettings,
            this.toolStripSeparator,
            this.toolStripMenuItemExit});
            this.contextMenuStrip.Name = "contextMenuStrip";
            resources.ApplyResources(this.contextMenuStrip, "contextMenuStrip");
            // 
            // toolStripMenuItemSettings
            // 
            this.toolStripMenuItemSettings.Name = "toolStripMenuItemSettings";
            resources.ApplyResources(this.toolStripMenuItemSettings, "toolStripMenuItemSettings");
            this.toolStripMenuItemSettings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            resources.ApplyResources(this.toolStripMenuItemExit, "toolStripMenuItemExit");
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gray;
            this.toolTip.ForeColor = System.Drawing.Color.White;
            this.toolTip.OwnerDraw = true;
            this.toolTip.ShowAlways = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // timerForUpdate
            // 
            this.timerForUpdate.Interval = 3600000;
            this.timerForUpdate.Tick += new System.EventHandler(this.Update_Click);
            // 
            // timerForVisible
            // 
            this.timerForVisible.Interval = 40;
            this.timerForVisible.Tick += new System.EventHandler(this.timerForVisible_Tick);
            // 
            // borderPanel
            // 
            resources.ApplyResources(this.borderPanel, "borderPanel");
            this.borderPanel.BackColor = System.Drawing.Color.Transparent;
            this.borderPanel.Controls.Add(this.pictureBoxProgress);
            this.borderPanel.Controls.Add(this.mainPanel);
            this.borderPanel.Name = "borderPanel";
            this.borderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.borderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // pictureBoxProgress
            // 
            resources.ApplyResources(this.pictureBoxProgress, "pictureBoxProgress");
            this.pictureBoxProgress.Name = "pictureBoxProgress";
            this.pictureBoxProgress.TabStop = false;
            this.pictureBoxProgress.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.pictureBoxProgress.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // mainPanel
            // 
            resources.ApplyResources(this.mainPanel, "mainPanel");
            this.mainPanel.Controls.Add(this.labelCity, 0, 0);
            this.mainPanel.Controls.Add(this.rightPanel, 2, 1);
            this.mainPanel.Controls.Add(this.leftPanel, 0, 1);
            this.mainPanel.Controls.Add(this.pictureBoxIcon, 1, 1);
            this.mainPanel.Controls.Add(this.forecastPanel, 0, 2);
            this.mainPanel.Controls.Add(this.buttonsPanel, 0, 3);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.mainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelCity
            // 
            resources.ApplyResources(this.labelCity, "labelCity");
            this.mainPanel.SetColumnSpan(this.labelCity, 3);
            this.labelCity.ForeColor = System.Drawing.Color.White;
            this.labelCity.Name = "labelCity";
            this.labelCity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelCity.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // rightPanel
            // 
            resources.ApplyResources(this.rightPanel, "rightPanel");
            this.rightPanel.Controls.Add(this.labelRange, 0, 2);
            this.rightPanel.Controls.Add(this.labelComment, 0, 1);
            this.rightPanel.Controls.Add(this.labelTemperature, 0, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.rightPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelRange
            // 
            resources.ApplyResources(this.labelRange, "labelRange");
            this.labelRange.ForeColor = System.Drawing.Color.White;
            this.labelRange.Name = "labelRange";
            this.labelRange.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelRange.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelComment
            // 
            resources.ApplyResources(this.labelComment, "labelComment");
            this.labelComment.ForeColor = System.Drawing.Color.White;
            this.labelComment.Name = "labelComment";
            this.labelComment.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelComment.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelTemperature
            // 
            resources.ApplyResources(this.labelTemperature, "labelTemperature");
            this.labelTemperature.ForeColor = System.Drawing.Color.White;
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelTemperature.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // leftPanel
            // 
            resources.ApplyResources(this.leftPanel, "leftPanel");
            this.leftPanel.Controls.Add(this.labelDate, 0, 0);
            this.leftPanel.Controls.Add(this.labelTime, 0, 1);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.leftPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelDate
            // 
            resources.ApplyResources(this.labelDate, "labelDate");
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.Name = "labelDate";
            this.labelDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelDate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelTime
            // 
            resources.ApplyResources(this.labelTime, "labelTime");
            this.labelTime.ForeColor = System.Drawing.Color.White;
            this.labelTime.Name = "labelTime";
            this.toolTip.SetToolTip(this.labelTime, resources.GetString("labelTime.ToolTip"));
            this.labelTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // pictureBoxIcon
            // 
            resources.ApplyResources(this.pictureBoxIcon, "pictureBoxIcon");
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.pictureBoxIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // forecastPanel
            // 
            resources.ApplyResources(this.forecastPanel, "forecastPanel");
            this.forecastPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.SetColumnSpan(this.forecastPanel, 3);
            this.forecastPanel.Controls.Add(this.secondPanel, 1, 0);
            this.forecastPanel.Controls.Add(this.firstPanel, 0, 0);
            this.forecastPanel.Controls.Add(this.thirdPanel, 2, 0);
            this.forecastPanel.Name = "forecastPanel";
            // 
            // secondPanel
            // 
            resources.ApplyResources(this.secondPanel, "secondPanel");
            this.secondPanel.Controls.Add(this.labelSecondDay, 0, 0);
            this.secondPanel.Controls.Add(this.pictureBoxSecond, 0, 1);
            this.secondPanel.Controls.Add(this.labelSecondTemperature, 0, 2);
            this.secondPanel.Name = "secondPanel";
            this.secondPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.secondPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelSecondDay
            // 
            resources.ApplyResources(this.labelSecondDay, "labelSecondDay");
            this.labelSecondDay.ForeColor = System.Drawing.Color.White;
            this.labelSecondDay.Name = "labelSecondDay";
            this.labelSecondDay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelSecondDay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // pictureBoxSecond
            // 
            resources.ApplyResources(this.pictureBoxSecond, "pictureBoxSecond");
            this.pictureBoxSecond.Name = "pictureBoxSecond";
            this.pictureBoxSecond.TabStop = false;
            this.pictureBoxSecond.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.pictureBoxSecond.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelSecondTemperature
            // 
            resources.ApplyResources(this.labelSecondTemperature, "labelSecondTemperature");
            this.labelSecondTemperature.ForeColor = System.Drawing.Color.White;
            this.labelSecondTemperature.Name = "labelSecondTemperature";
            this.labelSecondTemperature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelSecondTemperature.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // firstPanel
            // 
            resources.ApplyResources(this.firstPanel, "firstPanel");
            this.firstPanel.BackColor = System.Drawing.Color.Transparent;
            this.firstPanel.Controls.Add(this.labelFirstDay, 0, 0);
            this.firstPanel.Controls.Add(this.pictureBoxFirst, 0, 1);
            this.firstPanel.Controls.Add(this.labelFirstTemperature, 0, 2);
            this.firstPanel.Name = "firstPanel";
            this.firstPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.firstPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelFirstDay
            // 
            resources.ApplyResources(this.labelFirstDay, "labelFirstDay");
            this.labelFirstDay.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstDay.ForeColor = System.Drawing.Color.White;
            this.labelFirstDay.Name = "labelFirstDay";
            this.labelFirstDay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelFirstDay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // pictureBoxFirst
            // 
            resources.ApplyResources(this.pictureBoxFirst, "pictureBoxFirst");
            this.pictureBoxFirst.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxFirst.Name = "pictureBoxFirst";
            this.pictureBoxFirst.TabStop = false;
            this.pictureBoxFirst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.pictureBoxFirst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelFirstTemperature
            // 
            resources.ApplyResources(this.labelFirstTemperature, "labelFirstTemperature");
            this.labelFirstTemperature.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstTemperature.ForeColor = System.Drawing.Color.White;
            this.labelFirstTemperature.Name = "labelFirstTemperature";
            this.labelFirstTemperature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelFirstTemperature.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // thirdPanel
            // 
            resources.ApplyResources(this.thirdPanel, "thirdPanel");
            this.thirdPanel.Controls.Add(this.labelThirdDay, 0, 0);
            this.thirdPanel.Controls.Add(this.pictureBoxThird, 0, 1);
            this.thirdPanel.Controls.Add(this.labelThirdTemperature, 0, 2);
            this.thirdPanel.Name = "thirdPanel";
            this.thirdPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.thirdPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelThirdDay
            // 
            resources.ApplyResources(this.labelThirdDay, "labelThirdDay");
            this.labelThirdDay.ForeColor = System.Drawing.Color.White;
            this.labelThirdDay.Name = "labelThirdDay";
            this.labelThirdDay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelThirdDay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // pictureBoxThird
            // 
            resources.ApplyResources(this.pictureBoxThird, "pictureBoxThird");
            this.pictureBoxThird.Name = "pictureBoxThird";
            this.pictureBoxThird.TabStop = false;
            this.pictureBoxThird.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.pictureBoxThird.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // labelThirdTemperature
            // 
            resources.ApplyResources(this.labelThirdTemperature, "labelThirdTemperature");
            this.labelThirdTemperature.ForeColor = System.Drawing.Color.White;
            this.labelThirdTemperature.Name = "labelThirdTemperature";
            this.labelThirdTemperature.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.labelThirdTemperature.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // buttonsPanel
            // 
            resources.ApplyResources(this.buttonsPanel, "buttonsPanel");
            this.buttonsPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainPanel.SetColumnSpan(this.buttonsPanel, 3);
            this.buttonsPanel.Controls.Add(this.buttonSettings, 0, 0);
            this.buttonsPanel.Controls.Add(this.buttonExit, 2, 0);
            this.buttonsPanel.Controls.Add(this.buttonUpdate, 1, 0);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.buttonsPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Control_MouseMove);
            // 
            // buttonSettings
            // 
            resources.ApplyResources(this.buttonSettings, "buttonSettings");
            this.buttonSettings.BackColor = System.Drawing.Color.Gray;
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.BackColor = System.Drawing.Color.Gray;
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // buttonUpdate
            // 
            resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
            this.buttonUpdate.BackColor = System.Drawing.Color.Gray;
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.Update_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.borderPanel);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::WF.Properties.Settings.Default, "Position", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = global::WF.Properties.Settings.Default.Position;
            this.Name = "MainForm";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.borderPanel.ResumeLayout(false);
            this.borderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProgress)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.forecastPanel.ResumeLayout(false);
            this.forecastPanel.PerformLayout();
            this.secondPanel.ResumeLayout(false);
            this.secondPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecond)).EndInit();
            this.firstPanel.ResumeLayout(false);
            this.firstPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirst)).EndInit();
            this.thirdPanel.ResumeLayout(false);
            this.thirdPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThird)).EndInit();
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyPanel borderPanel;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.Label labelCity;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.PictureBox pictureBoxProgress;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.TableLayoutPanel rightPanel;
        private System.Windows.Forms.TableLayoutPanel leftPanel;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel buttonsPanel;
        private System.Windows.Forms.TableLayoutPanel forecastPanel;
        private System.Windows.Forms.TableLayoutPanel secondPanel;
        private System.Windows.Forms.Label labelSecondDay;
        private System.Windows.Forms.PictureBox pictureBoxSecond;
        private System.Windows.Forms.Label labelSecondTemperature;
        private System.Windows.Forms.TableLayoutPanel firstPanel;
        private System.Windows.Forms.Label labelFirstDay;
        private System.Windows.Forms.PictureBox pictureBoxFirst;
        private System.Windows.Forms.Label labelFirstTemperature;
        private System.Windows.Forms.TableLayoutPanel thirdPanel;
        private System.Windows.Forms.Label labelThirdDay;
        private System.Windows.Forms.PictureBox pictureBoxThird;
        private System.Windows.Forms.Label labelThirdTemperature;
        private System.Windows.Forms.Timer timerForUpdate;
        private System.Windows.Forms.Timer timerForVisible;


    }
}


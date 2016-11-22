using System;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using NLog;
using Fed.Weather;

namespace WF
{
    //клас (вікно для налаштувань)
    class SettingsDialog:Form
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private OWLanguage language = (OWLanguage) Enum.Parse(typeof(OWLanguage), Properties.Settings.Default.Language);
        private MyPanel borderPanel;
        private TableLayoutPanel tableLayoutPanel;
        private Panel panelButtons;
        private Label labelAPPID;
        private Label labelCity;
        private Label labelLanguage;
        private Label labelIP;
        private Label labelPort;
        private Label labelUser;
        private Label labelPassword;
        private TextBox textBoxAPPID;
        private TextBox textBoxUser;
        private TextBox textBoxPassword;
        private MaskedTextBox maskedTextBoxIP;
        private MaskedTextBox maskedTextBoxPort;
        private ComboBox comboBoxCity;
        private ComboBox comboBoxLanguage;
        private CheckBox checkBoxAutoUpdate;
        private CheckBox checkBoxProxy;
        private CheckBox checkBoxAuthorized;
        private Button buttonOK;
        private Button buttonChancel;
        private ToolTip toolTip;
        private System.Windows.Forms.Timer timerForVisible;
        private IContainer components;
                    
        //конструктор класа
        public SettingsDialog(Form parent)
        {
            Properties.Settings.Default.Save();
            InitializeComponent();
            Owner = parent;
        }

        // перевизначення метода для малювання фона форми
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.Black, Color.Gray, LinearGradientMode.BackwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);  
            }
        }

        // метод для актиавції/деактивації компонентів автентифікації
        private void EnabledAuthorizedControls(bool value)
        {
            labelUser.Enabled = value;
            labelPassword.Enabled = value;
            textBoxUser.Enabled = value;
            textBoxPassword.Enabled = value;
        }

        // метод центрує форму відносно головної форми
        private void SetFormPosition()
        {
            if (Owner != null)
            {
                Point coordinate = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2);
                Rectangle workRect = Screen.GetWorkingArea(this);
                if (coordinate.Y < 0)
                {
                    coordinate.Y = 0;
                }
                if (coordinate.X < 0)
                {
                    coordinate.X = 0;
                }
                if (Width + coordinate.X > workRect.Width)
                {
                    coordinate.X = workRect.Width - Width;
                }
                if (Height + coordinate.Y > workRect.Height)
                {
                    coordinate.Y = workRect.Height - Height;
                }
                Location = coordinate;
            }
        }

        //Visual Studio
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialog));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonChancel = new System.Windows.Forms.Button();
            this.checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
            this.timerForVisible = new System.Windows.Forms.Timer(this.components);
            this.borderPanel = new WF.MyPanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelAPPID = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.textBoxAPPID = new System.Windows.Forms.TextBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.checkBoxProxy = new System.Windows.Forms.CheckBox();
            this.checkBoxAuthorized = new System.Windows.Forms.CheckBox();
            this.maskedTextBoxIP = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxPort = new System.Windows.Forms.MaskedTextBox();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.comboBoxCity = new System.Windows.Forms.ComboBox();
            this.borderPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.BackColor = System.Drawing.Color.Gray;
            this.toolTip.ForeColor = System.Drawing.Color.White;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip_Draw);
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.BackColor = System.Drawing.Color.Gray;
            this.buttonOK.ForeColor = System.Drawing.Color.White;
            this.buttonOK.Name = "buttonOK";
            this.toolTip.SetToolTip(this.buttonOK, resources.GetString("buttonOK.ToolTip"));
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonChancel
            // 
            resources.ApplyResources(this.buttonChancel, "buttonChancel");
            this.buttonChancel.BackColor = System.Drawing.Color.Gray;
            this.buttonChancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonChancel.ForeColor = System.Drawing.Color.White;
            this.buttonChancel.Name = "buttonChancel";
            this.toolTip.SetToolTip(this.buttonChancel, resources.GetString("buttonChancel.ToolTip"));
            this.buttonChancel.UseVisualStyleBackColor = false;
            this.buttonChancel.Click += new System.EventHandler(this.buttonChancel_Click);
            // 
            // checkBoxAutoUpdate
            // 
            resources.ApplyResources(this.checkBoxAutoUpdate, "checkBoxAutoUpdate");
            this.checkBoxAutoUpdate.Checked = global::WF.Properties.Settings.Default.IsAutoUpdate;
            this.checkBoxAutoUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel.SetColumnSpan(this.checkBoxAutoUpdate, 2);
            this.checkBoxAutoUpdate.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::WF.Properties.Settings.Default, "IsAutoUpdate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxAutoUpdate.ForeColor = System.Drawing.Color.White;
            this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
            this.toolTip.SetToolTip(this.checkBoxAutoUpdate, resources.GetString("checkBoxAutoUpdate.ToolTip"));
            this.checkBoxAutoUpdate.UseVisualStyleBackColor = true;
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
            this.borderPanel.Controls.Add(this.tableLayoutPanel);
            this.borderPanel.Name = "borderPanel";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.labelAPPID, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelCity, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.labelLanguage, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.textBoxAPPID, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.comboBoxLanguage, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.checkBoxAutoUpdate, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.labelPassword, 0, 9);
            this.tableLayoutPanel.Controls.Add(this.labelUser, 0, 8);
            this.tableLayoutPanel.Controls.Add(this.labelPort, 0, 6);
            this.tableLayoutPanel.Controls.Add(this.labelIP, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.checkBoxProxy, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.checkBoxAuthorized, 0, 7);
            this.tableLayoutPanel.Controls.Add(this.maskedTextBoxIP, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.maskedTextBoxPort, 1, 6);
            this.tableLayoutPanel.Controls.Add(this.textBoxUser, 1, 8);
            this.tableLayoutPanel.Controls.Add(this.textBoxPassword, 1, 9);
            this.tableLayoutPanel.Controls.Add(this.panelButtons, 0, 10);
            this.tableLayoutPanel.Controls.Add(this.comboBoxCity, 1, 1);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // labelAPPID
            // 
            resources.ApplyResources(this.labelAPPID, "labelAPPID");
            this.labelAPPID.ForeColor = System.Drawing.Color.White;
            this.labelAPPID.Name = "labelAPPID";
            // 
            // labelCity
            // 
            resources.ApplyResources(this.labelCity, "labelCity");
            this.labelCity.ForeColor = System.Drawing.Color.White;
            this.labelCity.Name = "labelCity";
            // 
            // labelLanguage
            // 
            resources.ApplyResources(this.labelLanguage, "labelLanguage");
            this.labelLanguage.ForeColor = System.Drawing.Color.White;
            this.labelLanguage.Name = "labelLanguage";
            // 
            // textBoxAPPID
            // 
            resources.ApplyResources(this.textBoxAPPID, "textBoxAPPID");
            this.textBoxAPPID.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WF.Properties.Settings.Default, "OWID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxAPPID.Name = "textBoxAPPID";
            this.textBoxAPPID.Text = global::WF.Properties.Settings.Default.OWID;
            // 
            // comboBoxLanguage
            // 
            resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            // 
            // labelPassword
            // 
            resources.ApplyResources(this.labelPassword, "labelPassword");
            this.labelPassword.ForeColor = System.Drawing.Color.White;
            this.labelPassword.Name = "labelPassword";
            // 
            // labelUser
            // 
            resources.ApplyResources(this.labelUser, "labelUser");
            this.labelUser.ForeColor = System.Drawing.Color.White;
            this.labelUser.Name = "labelUser";
            // 
            // labelPort
            // 
            resources.ApplyResources(this.labelPort, "labelPort");
            this.labelPort.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::WF.Properties.Settings.Default, "IsProxy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelPort.Enabled = global::WF.Properties.Settings.Default.IsProxy;
            this.labelPort.ForeColor = System.Drawing.Color.White;
            this.labelPort.Name = "labelPort";
            // 
            // labelIP
            // 
            resources.ApplyResources(this.labelIP, "labelIP");
            this.labelIP.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::WF.Properties.Settings.Default, "IsProxy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelIP.Enabled = global::WF.Properties.Settings.Default.IsProxy;
            this.labelIP.ForeColor = System.Drawing.Color.White;
            this.labelIP.Name = "labelIP";
            // 
            // checkBoxProxy
            // 
            resources.ApplyResources(this.checkBoxProxy, "checkBoxProxy");
            this.checkBoxProxy.Checked = global::WF.Properties.Settings.Default.IsProxy;
            this.tableLayoutPanel.SetColumnSpan(this.checkBoxProxy, 2);
            this.checkBoxProxy.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::WF.Properties.Settings.Default, "IsProxy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxProxy.ForeColor = System.Drawing.Color.White;
            this.checkBoxProxy.Name = "checkBoxProxy";
            this.checkBoxProxy.UseVisualStyleBackColor = true;
            // 
            // checkBoxAuthorized
            // 
            resources.ApplyResources(this.checkBoxAuthorized, "checkBoxAuthorized");
            this.checkBoxAuthorized.Checked = global::WF.Properties.Settings.Default.IsAuthorized;
            this.checkBoxAuthorized.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel.SetColumnSpan(this.checkBoxAuthorized, 2);
            this.checkBoxAuthorized.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::WF.Properties.Settings.Default, "IsAuthorized", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxAuthorized.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::WF.Properties.Settings.Default, "IsProxy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxAuthorized.Enabled = global::WF.Properties.Settings.Default.IsProxy;
            this.checkBoxAuthorized.ForeColor = System.Drawing.Color.White;
            this.checkBoxAuthorized.Name = "checkBoxAuthorized";
            this.checkBoxAuthorized.UseVisualStyleBackColor = true;
            this.checkBoxAuthorized.CheckedChanged += new System.EventHandler(this.checkBoxAuthorized_CheckedChanged);
            this.checkBoxAuthorized.EnabledChanged += new System.EventHandler(this.checkBoxAuthorized_EnabledChanged);
            // 
            // maskedTextBoxIP
            // 
            resources.ApplyResources(this.maskedTextBoxIP, "maskedTextBoxIP");
            this.maskedTextBoxIP.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::WF.Properties.Settings.Default, "IsProxy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maskedTextBoxIP.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WF.Properties.Settings.Default, "ProxyIP", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maskedTextBoxIP.Enabled = global::WF.Properties.Settings.Default.IsProxy;
            this.maskedTextBoxIP.Name = "maskedTextBoxIP";
            this.maskedTextBoxIP.Text = global::WF.Properties.Settings.Default.ProxyIP;
            // 
            // maskedTextBoxPort
            // 
            resources.ApplyResources(this.maskedTextBoxPort, "maskedTextBoxPort");
            this.maskedTextBoxPort.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", global::WF.Properties.Settings.Default, "IsProxy", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maskedTextBoxPort.Enabled = global::WF.Properties.Settings.Default.IsProxy;
            this.maskedTextBoxPort.Name = "maskedTextBoxPort";
            // 
            // textBoxUser
            // 
            resources.ApplyResources(this.textBoxUser, "textBoxUser");
            this.textBoxUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WF.Properties.Settings.Default, "ProxyUser", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Text = global::WF.Properties.Settings.Default.ProxyUser;
            // 
            // textBoxPassword
            // 
            resources.ApplyResources(this.textBoxPassword, "textBoxPassword");
            this.textBoxPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WF.Properties.Settings.Default, "ProxyPassword", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Text = global::WF.Properties.Settings.Default.ProxyPassword;
            // 
            // panelButtons
            // 
            resources.ApplyResources(this.panelButtons, "panelButtons");
            this.tableLayoutPanel.SetColumnSpan(this.panelButtons, 2);
            this.panelButtons.Controls.Add(this.buttonOK);
            this.panelButtons.Controls.Add(this.buttonChancel);
            this.panelButtons.Name = "panelButtons";
            // 
            // comboBoxCity
            // 
            resources.ApplyResources(this.comboBoxCity, "comboBoxCity");
            this.comboBoxCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCity.FormattingEnabled = true;
            this.comboBoxCity.Name = "comboBoxCity";
            this.comboBoxCity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBoxCity_KeyDown);
            this.comboBoxCity.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxCity_Validating);
            // 
            // SettingsDialog
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.buttonChancel;
            this.Controls.Add(this.borderPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsDialog";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsDialog_FormClosing);
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.borderPanel.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // метод викликається при створенні форми (перед відображенням)
        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            comboBoxCity.DataSource = new BindingSource(OpenWeather.GetCities(language), null);
            comboBoxCity.DisplayMember = "Key";
            comboBoxCity.ValueMember = "Value";
            comboBoxCity.SelectedValue = Properties.Settings.Default.OWCity;

            comboBoxLanguage.DataSource = Enum.GetValues(typeof(OWLanguage));
            comboBoxLanguage.SelectedItem = language;

            maskedTextBoxPort.Text = Properties.Settings.Default.ProxyPort.ToString();

            if (!checkBoxProxy.Checked)
            {
                EnabledAuthorizedControls(false);
            }

            SetFormPosition();
            timerForVisible.Start();
        }

        //метод викликається перед закриттям головного вікна
        private void SettingsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (; Opacity > 0; Opacity -= 0.1)
            {
                Thread.Sleep(40);
            }
        }

        //метод викликається при перевірці значення в комбобоксі CITY
        private void comboBoxCity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = comboBoxCity.FindStringExact(comboBoxCity.Text) < 0;
            if (e.Cancel)
            {
                new ErrorForm(Global.ErrorCity).ShowDialog();
                buttonOK.Focus();
                comboBoxCity.Text = string.Empty;
            }
        }

        //метод викликається при натисненні на клавішу клавіатури в комбобоксі CITY
        private void comboBoxCity_KeyDown(object sender, KeyEventArgs e)
        {
            comboBoxCity.DroppedDown = false;
        }

        //метод викликається при активації/деактивації чекбокса AUTHORIZED
        private void checkBoxAuthorized_EnabledChanged(object sender, EventArgs e)
        {
            if (!checkBoxAuthorized.Enabled)
            {
                EnabledAuthorizedControls(false);
            }
            else if (checkBoxAuthorized.Checked)
            {
                EnabledAuthorizedControls(true);
            }
        }

        //метод викликається при зміні значення чекбокса AUTHORIZED
        private void checkBoxAuthorized_CheckedChanged(object sender, EventArgs e)
        {
            EnabledAuthorizedControls(checkBoxAuthorized.Checked);
        }

        // метод викликається при малюванні ToolTip
        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }

        //метод ТАЙМЕРА для плавного відображення
        private void timerForVisible_Tick(object sender, EventArgs e)
        {
            if (Opacity < 0.89)
            {
                Opacity += 0.1;
            }
            else
            {
                timerForVisible.Stop();
            }
        }

        //метод викликається при натисненні на кнопку OK
        private void buttonOK_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            int port;
            if (!string.IsNullOrWhiteSpace(textBoxAPPID.Text) && IPAddress.TryParse(maskedTextBoxIP.Text, out ip) && int.TryParse(maskedTextBoxPort.Text, out port) && port >= 0 && port <= 65535)
            {
                Properties.Settings.Default.IsFirst = false;
                Properties.Settings.Default.OWCity = int.Parse(comboBoxCity.SelectedValue.ToString());
                Properties.Settings.Default.Language = comboBoxLanguage.SelectedValue.ToString();
                Properties.Settings.Default.ProxyPort = port;
                Properties.Settings.Default.Save();
                Close();
            }
            else 
            {
                new ErrorForm(Global.SettingsWarning).ShowDialog();
            }
        }

        //метод викликається при натисненні на кнопку CHANCEL
        private void buttonChancel_Click(object sender, EventArgs e)
        {
            if (Owner == null)
            {
                Log.Log(LogLevel.Info, "Вихід з програми");
                Close();
                Environment.Exit(0);
            }
            else
            {
                Properties.Settings.Default.Reload();
                Close();
            }
        }
    }

    //клас (панель, для створення рамки)
    public class MyPanel : Panel 
    {
        // конструктор класа
        public MyPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        // перевизначення метода, який викликає подію Paint
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
            e.Graphics.DrawRectangle(new Pen(Color.Black, 4), 0, 0, ClientSize.Width, ClientSize.Height);
        }
    }
}
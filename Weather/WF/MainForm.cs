using System;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using System.Net;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using NLog;
using Fed.Weather;

namespace WF
{
    //клас (головне вікно)
    public partial class MainForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);
       
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_SHOWWINDOW = 0x0040;

        private const int WS_EX_TOOLWINDOW = 0x00000080;

        private OpenWeather weather;
        private OWLanguage language = (OWLanguage) Enum.Parse(typeof(OWLanguage), Properties.Settings.Default.Language);
        WebProxy proxy;
        private DateTime dateTime;
        private bool close = false;
        private Point oldPoint;

        //конструктор класа
        public MainForm()
        {
           InitializeComponent();
           SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        // перевизначення властивості, яка містить дані котрі використовуються при створенні елемента керування 
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_TOOLWINDOW; 
                return param;
            }
        }

        // перевизначення метода для малювання фона форми
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.Black, Color.Gray, LinearGradientMode.BackwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        // метод для оновлення даних на формі
        private void UpdateData()
        {
            toolStripMenuItemSettings.Enabled = false;
            mainPanel.Visible = false;
            pictureBoxProgress.BringToFront();
            backgroundWorker.RunWorkerAsync();
        }

        // метод виконується в іншому потоці
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                weather.Update();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Помилка при оновленні погоди.");
            }
        }

        // метод виконується по завершенню backgroundWorker_DoWork
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MinimumSize = new Size(256, 256);
            dateTime = weather.LastUpdate ?? DateTime.Now;

            labelCity.Text = weather.Сity;
            labelDate.Text = dateTime.ToShortDateString();
            labelTime.Text = dateTime.ToShortTimeString();
            pictureBoxIcon.Image = weather.Icon;
            labelTemperature.Text = weather.GetTemperature();
            labelComment.Text = weather.Comment;
            labelRange.Text = weather.GetMinMaxTemperature();

            SetForecastControls(labelFirstDay, pictureBoxFirst, labelFirstTemperature, 1);
            SetForecastControls(labelSecondDay, pictureBoxSecond, labelSecondTemperature, 2);
            SetForecastControls(labelThirdDay, pictureBoxThird, labelThirdTemperature, 3);
                       
            mainPanel.Visible = true;
            mainPanel.BringToFront();
            toolTip.SetToolTip(buttonUpdate, DateTime.Now.ToShortTimeString());
            toolStripMenuItemSettings.Enabled = true;
            Refresh();
            MinimumSize = Size;
        }

        //метод заповнює даними прогнозні контроли
        private void SetForecastControls(Label lbDate, PictureBox picture, Label lbTemperature, int day)
        {
            lbDate.Text = dateTime.AddDays(day).ToString("dddd", Thread.CurrentThread.CurrentUICulture).ToLower();
            picture.Image = weather.GetForecastIcon(day);
            toolTip.SetToolTip(picture, weather.GetForecastComment(day));
            lbTemperature.Text = weather.GetForecastMinMaxTemperature(day);
        }

        //метод налаштовує проксі
        private void SetProxy()
        {
            proxy = null;
            if (Properties.Settings.Default.IsProxy)
            {
                proxy = new WebProxy(Properties.Settings.Default.ProxyIP, Properties.Settings.Default.ProxyPort);
                if (Properties.Settings.Default.IsAuthorized)
                {
                    proxy.Credentials = new NetworkCredential(Properties.Settings.Default.ProxyUser, Properties.Settings.Default.ProxyPassword);
                }
            }
        }

        //метод налаштовує таймер
        private void SetTimer()
        {
            if (Properties.Settings.Default.IsAutoUpdate)
            {
                timerForUpdate.Start();
            }
            else
            {
                timerForUpdate.Stop();
            }
        }

        // метод викликається при створенні форми (перед відображенням)
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetProxy();
            weather = new OpenWeather(Properties.Settings.Default.OWID, Properties.Settings.Default.OWCity, language, Fed.Weather.Scale.Celsius, proxy);
            UpdateData();
            SetTimer();
            timerForVisible.Start();
        }

        //метод викликається при активації форми
        private void MainForm_Activated(object sender, EventArgs e)
        {
            SetWindowPos(Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }
        

        //метод викликається перед закриттям форми
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close || e.CloseReason == CloseReason.WindowsShutDown)
            {
                Properties.Settings.Default.Save();
                notifyIcon.Dispose();
                for (; Opacity > 0; Opacity -= 0.1)
                {
                    Thread.Sleep(40);
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        //метод викликається при натисканні клавіші миші на CONTROL
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            oldPoint = e.Location;
        }

        //метод викликається при переміщенні курсора миші по CONTROL
        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point cur = e.Location;
                Left += cur.X - oldPoint.X;
                Top += cur.Y - oldPoint.Y;
            }
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

        //метод викликається при натисненні на кнопку або пункті меню EXIT
        private void Exit_Click(object sender, EventArgs e)
        {
            close = true;
            Close();
        }

        //метод викликається при натисненні на кнопку або пункті меню SETTINGS
        private void Settings_Click(object sender, EventArgs e)
        {
            Activate();
            string key = Properties.Settings.Default.OWID;
            int city = Properties.Settings.Default.OWCity;
            bool autoUpdate = Properties.Settings.Default.IsAutoUpdate;
            bool isProxy = Properties.Settings.Default.IsProxy;
            string ip = Properties.Settings.Default.ProxyIP;
            int port = Properties.Settings.Default.ProxyPort;
            bool isAuthorized = Properties.Settings.Default.IsAuthorized;
            string user = Properties.Settings.Default.ProxyUser;
            string password = Properties.Settings.Default.ProxyPassword;

            new SettingsDialog(this).ShowDialog();

            if (language != (OWLanguage) Enum.Parse(typeof(OWLanguage), Properties.Settings.Default.Language))
            {
                if (new YesNoForm().ShowDialog() == DialogResult.Yes)
                {
                    buttonExit.PerformClick();
                    System.Diagnostics.Process.Start(Application.ExecutablePath);
                }
            }

            if (autoUpdate != Properties.Settings.Default.IsAutoUpdate)
            {
                SetTimer();
            }

            if (isProxy != Properties.Settings.Default.IsProxy || (isProxy && isAuthorized != Properties.Settings.Default.IsAuthorized) || (isProxy && (ip != Properties.Settings.Default.ProxyIP || port != Properties.Settings.Default.ProxyPort)) || (isProxy && isAuthorized && (user != Properties.Settings.Default.ProxyUser || password != Properties.Settings.Default.ProxyPassword)))
            {
                SetProxy();
                weather.Proxy = proxy;
            }

            if (key != Properties.Settings.Default.OWID || city != Properties.Settings.Default.OWCity)
            {
                weather.IdCity = Properties.Settings.Default.OWCity;
                weather.IdClient = Properties.Settings.Default.OWID;
                UpdateData();
            }
        }

        //метод викликається при натисненні на кнопку UPDATE або при автооновленні погоди (таймер)
        private void Update_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}
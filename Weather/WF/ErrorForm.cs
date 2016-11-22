using System;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Windows.Forms;

namespace WF
{
    //клас (вікно помилок)
    public partial class ErrorForm : Form
    {
        //конструктор класа
        public ErrorForm(string text)
        {
            InitializeComponent();
            label.Text = text;           
        }

        // перевизначення метода для малювання фона форми
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.Black, Color.Gray, LinearGradientMode.BackwardDiagonal))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        // метод викликається при створенні форми (перед відображенням)
        private void ErrorForm_Load(object sender, EventArgs e)
        {
            timerForVisible.Start();
        }

        //метод викликається перед закриттям форми
        private void ErrorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (; Opacity > 0; Opacity -= 0.1)
            {
                Thread.Sleep(40);
            }
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

        //метод викликається при натисненні на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
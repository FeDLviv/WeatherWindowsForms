using System;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using NLog;
using Fed.Weather;

namespace WF
{
    static class Program
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        [STAThread] // вказує запускати програму в одному потоці
        static void Main()
        {
            OWLanguage language = (OWLanguage) Enum.Parse(typeof(OWLanguage), Properties.Settings.Default.Language);
            MemberInfo[] arrInfo = language.GetType().GetMember(language.ToString());
            object[] attributes = arrInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(((DescriptionAttribute)attributes[0]).Description);

            bool instance = false;
            using (new Mutex(true, "FeD_Lviv.Weather", out instance))
            {
                if (instance)
                {
                    Log.Info("Запуск програми");

                    Application.EnableVisualStyles(); // підключення візуальних стилів
                    Application.SetCompatibleTextRenderingDefault(false); // задається значения по замовчуванню для властивості UseCompatibleTextRendering (для всіх компонентів, які мають дану властивість)

                    if (Properties.Settings.Default.IsFirst)
                    {
                        new SettingsDialog(null).ShowDialog();
                        if (language != (OWLanguage)Enum.Parse(typeof(OWLanguage), Properties.Settings.Default.Language))
                        {
                            language = (OWLanguage)Enum.Parse(typeof(OWLanguage), Properties.Settings.Default.Language);
                            arrInfo = language.GetType().GetMember(language.ToString());
                            attributes = arrInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(((DescriptionAttribute)attributes[0]).Description);
                        }
                    }

                    Application.Run(new MainForm());

                    Log.Log(LogLevel.Info, "Вихід з програми");
                }
                else
                {
                    ErrorForm form =  new ErrorForm(Global.OnlyInstance);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.ShowDialog();
                }
            }
        }
    }
}
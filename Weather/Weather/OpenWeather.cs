using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.ComponentModel;
using System.Xml;
using System.Net;
using System.Drawing;

namespace Fed.Weather
{
    /// <summary>
    /// Клас, представляє собою погодний довідник (погода в даний час, погодний прогноз на 6 днів). Реалізує інтерфейси: IDisposable, ICloneable.
    /// </summary>
    public class OpenWeather : IDisposable, ICloneable
    {
        // статичні поля для внутрішнього користування - URL на OpenWeatherMap (погода, прогноз та іконки)
        private static readonly string CurrentUrl = "http://api.openweathermap.org/data/2.5/weather?mode=xml";
        private static readonly string ForecastUrl = "http://api.openweathermap.org/data/2.5/forecast/daily?mode=xml";
        private static readonly string IconUrl = "http://api.openweathermap.org/img/w/";

        // статичні поля для внутрішнього користування - XPath вирази 
        private static readonly string ExpressionTemperature = "/current/temperature/@value";
        private static readonly string ExpressionMinTemperature = "/weatherdata/forecast/time[1]/temperature/@min";
        private static readonly string ExpressionMaxTemperature = "/weatherdata/forecast/time[1]/temperature/@max";
        private static readonly string ExpressionComment = "/current/weather/@value";
        private static readonly string ExpressionIcon = "/current/weather/@icon";
        private static readonly string ExpressionLastUpdate = "/current/lastupdate/@value";
        private static readonly string ExpressionForecastTemperature = "/weatherdata/forecast/time/temperature";
        private static readonly string ExpressionForecastSymbol = "/weatherdata/forecast/time/symbol";

        // поля для внутрішнього користування - тільки для читання
        private readonly WebClient web = new WebClient();
        private readonly XmlDocument currentDoc = new XmlDocument();
        private readonly XmlDocument forecastDoc = new XmlDocument();

        // поля для внутрішнього користування
        private string currentUrl;
        private string forecastUrl;
        private string idClient;
        private int idCity;
        private OWLanguage language;

        /// <summary>
        /// Подія, яка відбувається при зміні даних об'єкта (ключ на OpenWeatherMap, id населеного пункта та мова)
        /// </summary>
        public event EventHandler DataChange;

        /// <summary>
        /// Конструктор, ініціалізує новий екземпляр класа OpenWeather, вказується APPID, номер населеного пункта, мова, температурна шкала та налаштування проксі сервера.
        /// </summary>
        /// <param name="idClient">APPID (API key) на сайті: http://openweathermap.org/ .</param>
        /// <param name="idCity">ID (номер населеного пункта).</param>
        /// <param name="language">Мова, по замовчуванню українська (OWLanguage.uk).</param>
        /// <param name="scale">Температурна шкала, по замовчуванню, шкала Цельсія (Scale.Celsius).</param>
        /// <param name="proxy">Проксі сервер, по замовчуванню, не застосовується (null).</param>
        public OpenWeather(string idClient, int idCity, OWLanguage language = OWLanguage.uk, Scale scale = Scale.Celsius,
            WebProxy proxy = null)
        {
            IdClient = idClient;
            IdCity = idCity;
            Language = language;
            TemperatureScale = scale;
            Proxy = proxy;
            web.Encoding = Encoding.UTF8;
            web.Proxy = proxy;
        }

        /// <summary>
        /// Конструктор копіювання, ініціалізує новий екземпляр класа OpenWeather.
        /// </summary>
        /// <param name="value">Об'єкт, з якого робиться копія.</param>
        /// <author>Danatlol</author>
        public OpenWeather(OpenWeather value)
        {
            IdClient = value.IdClient;
            IdCity = value.IdCity;
            Language = value.Language;
            TemperatureScale = value.TemperatureScale;
            Proxy = value.Proxy;
            web.Encoding = Encoding.UTF8;
            web.Proxy = value.Proxy;
        }

        /// <summary>
        /// Дозволяє отримувати або задавати ключ клієнта (APPID) на OpenWeatherMap.
        /// </summary>
        public string IdClient
        {
            get { return idClient; }
            set
            {
                if (IdClient != value)
                {
                    idClient = value;
                    OnDataChange(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Дозволяє отримувати або задавати код населеного пункта (ID).
        /// </summary>
        public int IdCity
        {
            get { return idCity; }
            set
            {
                if (IdCity != value)
                {
                    idCity = value;
                    OnDataChange(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Дозволяє отримувати або задавати мову для відображення погоди.
        /// </summary>
        public OWLanguage Language
        {
            get { return language; }
            set
            {
                if (Language != value)
                {
                    language = value;
                    OnDataChange(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Дозволяє отримувати або задавати температурну шкалу, в якій буде відображатися погода.
        /// </summary>
        public Scale TemperatureScale { get; set; }

        /// <summary>
        /// Дозволяє отримувати або задавати проксі сервер для об'єкта.
        /// </summary>
        public WebProxy Proxy
        {
            get { return web.Proxy as WebProxy; }
            set { web.Proxy = value; }
        }

        /// <summary>
        /// Дозволяє отримати назву населеного пункта, назва повертається на мові, яка вказана для об'єкта даного класа.
        /// </summary>
        public string Сity
        {
            get
            {
               return (from list in GetCities(language) where list.Value == idCity select list.Key).First();
            }
        }

        /// <summary>
        /// Дозволяє отримати температуру з останнього оновлення погоди.
        /// </summary>
        public int? Temperature
        {
            get
            {
                try
                {
                    string temp = currentDoc.SelectSingleNode(ExpressionTemperature).InnerText;
                    return FormatScaleTemperature(double.Parse(temp, CultureInfo.InvariantCulture));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Дозволяє отримати мінімальну температуру (прогнозовану на сьогоднішню добу).
        /// </summary>
        public int? MinTemperature
        {
            get
            {
                try
                {
                    string temp = forecastDoc.SelectSingleNode(ExpressionMinTemperature).InnerText;
                    return FormatScaleTemperature(double.Parse(temp, CultureInfo.InvariantCulture));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Дозволяє отримати максимальну температуру (прогнозовану на сьогоднішню добу).
        /// </summary>
        public int? MaxTemperature
        {
            get
            {
                try
                {
                    string temp = forecastDoc.SelectSingleNode(ExpressionMaxTemperature).InnerText;
                    return FormatScaleTemperature(double.Parse(temp, CultureInfo.InvariantCulture));
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Дозволяє отримати короткий коментар про погоду з останнього оновлення погоди.
        /// </summary>
        public string Comment
        {
            get
            {
                try
                {
                    return currentDoc.SelectSingleNode(ExpressionComment).InnerText;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Дозволяє отримати URL погодної іконки з останнього оновлення погоди.
        /// </summary>
        public string URLIcon
        {
            get
            {
                try
                {
                    string number = currentDoc.SelectSingleNode(ExpressionIcon).InnerText;
                    return IconUrl + number;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Дозволяє отримати погодну іконку з останнього оновлення погоди.
        /// </summary>
        public Image Icon
        {
            get
            {
                try
                {
                    string temp = currentDoc.SelectSingleNode(ExpressionIcon).InnerText;
                    return (Image) Properties.Resources.ResourceManager.GetObject(temp);
                }
                catch (Exception)
                {
                    return Properties.Resources.ResourceManager.GetObject("null") as Image;
                }
            }
        }

        /// <summary>
        /// Дозволяє отримати дату та час останнього оновлення погоди.
        /// </summary>
        public DateTime? LastUpdate
        {
            get
            {
                try
                {
                    string temp = currentDoc.SelectSingleNode(ExpressionLastUpdate).InnerText;
                    return DateTime.Parse(temp).ToLocalTime();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Метод повертає колекцію ("ключ-значення"/"населений пункт-код населеного пункта").
        /// </summary>
        /// <param name="language">Мова, на якій будуть видаватися назви населених пунктів.</param>
        /// <returns>Колекція, яка містить назви населених пунктів та їх коди для OpenWeatherMap.</returns>
        public static SortedList<string, int> GetCities(OWLanguage language)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.cities);
            SortedList<string, int> list = new SortedList<string, int>();
            foreach (XmlNode x in doc.SelectNodes("/list/city"))
            {
                list.Add(x.Attributes[language.ToString()].Value, int.Parse(x.Attributes["id"].Value));
            }
            return list;
        }

        /// <summary>
        /// Метод застосовується для оновлення даних про погоду. 
        /// Якщо були змінені налаштування екземпляра класа (ключ на OpenWeatherMap, id населеного пункта, мова або проксі сервер), для правильного відображення потрібно власноруч викликати даний метод.
        /// </summary>
        /// <exception cref="System.Net.WebException"></exception>>
        /// <exception cref="System.PlatformNotSupportedException"></exception>>
        /// <exception cref="System.Xml.XmlException"></exception>>
        public void Update()
        {
            try
            {
                currentDoc.LoadXml(web.DownloadString(currentUrl));
                forecastDoc.LoadXml(web.DownloadString(forecastUrl));
            }
            finally
            {
                web.Dispose();
            }
        }

        /// <summary>
        /// Метод повертає температуру (з останнього оновлення погоди), яка відображається форматованою стрічкою.
        /// </summary>
        /// <returns>Температура.</returns>
        public string GetTemperature()
        {
            return FormatStringTemperature(Temperature);
        }

        /// <summary>
        /// Метод повертає мінімальну та максимальну температури (прогнозовані на сьогоднішню добу), які відображаються форматованою стрічкою.
        /// </summary>
        /// <returns>Прогнозована температура на дану добу.</returns>
        public string GetMinMaxTemperature()
        {
            string min = FormatStringTemperature(MinTemperature);
            string max = FormatStringTemperature(MaxTemperature);
            if (min != null && max != null)
            {
                return min + " ... " + max;
            }
            return null;
        }

        /// <summary>
        /// Метод повертає мінімальну та максимальну температури (прогнозовані на наступну n добу), які відображаються форматованою стрічкою.
        /// Погода може прогнозуватися максимум на 6 днів.
        /// </summary>
        /// <param name="day">Вказується номер доби, відрахунок розпочинається з завтрашнього дня. Тобто, прогноз на наступний день (day = 1).</param>
        /// <returns>Прогнозована температура.</returns>
        public string GetForecastMinMaxTemperature(int day)
        {
            if (day > 0 && day < 7)
            {
                try
                {
                    XmlNodeList list = forecastDoc.SelectNodes(ExpressionForecastTemperature);
                    string temp = list[day].Attributes["min"].InnerText;
                    string min = FormatStringTemperature(FormatScaleTemperature(double.Parse(temp, CultureInfo.InvariantCulture)));
                    temp = list[day].Attributes["max"].InnerText;
                    string max = FormatStringTemperature(FormatScaleTemperature(double.Parse(temp, CultureInfo.InvariantCulture)));
                    if (min != null && max != null)
                    {
                        return min + " ... " + max;
                    }
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Метод повертає короткий коментар про погоду (прогнозований на наступну n добу).
        /// Погода може прогнозуватися максимум на 6 днів.
        /// </summary>
        /// <param name="day">Вказується номер доби, відрахунок розпочинається з завтрашнього дня. Тобто, прогноз на наступний день (day = 1).</param>
        /// <returns>Прогнозований коментар погоди.</returns>
        public string GetForecastComment(int day)
        {
            if (day > 0 && day < 7)
            {
                try
                {
                    XmlNodeList list = forecastDoc.SelectNodes(ExpressionForecastSymbol);
                    return list[day].Attributes["name"].InnerText;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Метод повертає URL погодної іконки (прогнозованої на наступну n добу).
        /// Погода може прогнозуватися максимум на 6 днів.
        /// </summary>
        /// <param name="day">Вказується номер доби, відрахунок розпочинається з завтрашнього дня. Тобто, прогноз на наступний день (day = 1).</param>
        /// <returns>URL прогнозованої погодної іконки.</returns>
        public string GetForecastURLIcon(int day)
        {
            if (day > 0 && day < 7)
            {
                try
                {
                    XmlNodeList list = forecastDoc.SelectNodes(ExpressionForecastSymbol);
                    return IconUrl + list[day].Attributes["var"].InnerText;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Метод повертає погодну іконку (прогнозовану на наступну n добу).
        /// Погода може прогнозуватися максимум на 6 днів.
        /// </summary>
        /// <param name="day">Вказується номер доби, відрахунок розпочинається з завтрашнього дня. Тобто, прогноз на наступний день (day = 1).</param>
        /// <returns>Прогнозована погодна іконка.</returns>
        public Image GetForecastIcon(int day)
        {
            if (day > 0 && day < 7)
            {
                try
                {
                    XmlNodeList list = forecastDoc.SelectNodes(ExpressionForecastSymbol);
                    return (Image) Properties.Resources.ResourceManager.GetObject(list[day].Attributes["var"].InnerText);
                }
                catch (Exception)
                {
                    return Properties.Resources.ResourceManager.GetObject("null") as Image;
                }
            }
            return Properties.Resources.ResourceManager.GetObject("null") as Image;
        }

        /// <summary>
        /// Метод, викликає подію DataChange
        /// </summary>
        /// <param name="ea">Додаткова інформація про подію.</param>
        protected virtual void OnDataChange(EventArgs ea)
        {
            currentUrl = CurrentUrl + "&lang=" + Language + "&id=" + IdCity + "&APPID=" + IdClient;
            forecastUrl = ForecastUrl + "&lang=" + Language + "&id=" + IdCity + "&APPID=" + IdClient;
            if (DataChange != null)
            {
                DataChange(this, ea);
            }
        }

        /// <summary>
        /// Метод повертає температуру в залежності від вказаної для об'єкта температурної шкали.
        /// </summary>
        /// <param name="value">Температура, задається по шкалі Кельвіна.</param>
        /// <returns>Температура.</returns>
        private int? FormatScaleTemperature(double value)
        {
            switch (TemperatureScale)
            {
                case Scale.Celsius:
                    return (int) Math.Round(value - 273.15, MidpointRounding.AwayFromZero);
                case Scale.Kelvin:
                    return (int) Math.Round(value, MidpointRounding.AwayFromZero);
                case Scale.Fahrenheit:
                    return (int) Math.Round(1.8 * (value - 273) + 32, MidpointRounding.AwayFromZero);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Метод повертає температуру, яка відображається форматованою стрічкою.
        /// </summary>
        /// <param name="temperature">Температура.</param>
        /// <returns>Температура.</returns>
        private string FormatStringTemperature(int? temperature)
        {
            if (temperature != null)
            {
                StringBuilder text;
                switch (TemperatureScale)
                {
                    case Scale.Celsius:
                        text = new StringBuilder(string.Format(temperature + ((char)176).ToString() + "C"));
                        return temperature > 0 ? text.Insert(0, "+").ToString() : text.ToString();
                    case Scale.Kelvin:
                        text = new StringBuilder(string.Format(temperature + " K"));
                        return temperature > 0 ? text.Insert(0, "+").ToString() : text.ToString();
                    case Scale.Fahrenheit:
                        text = new StringBuilder(string.Format(temperature + ((char)176).ToString() + "F"));
                        return temperature > 0 ? text.Insert(0, "+").ToString() : text.ToString();
                    default:
                        return null;
                }
            }
            return null;
        }

        /// <summary>
        /// Індексатор, завдяки якому, можна отримувати дані по прогнозу погоди.
        /// Погода може прогнозуватися максимум на 6 днів.
        /// </summary>
        /// <param name="day">Вказується номер доби, відрахунок розпочинається з завтрашнього дня. Тобто, прогноз на наступний день (day = 1).</param>
        /// <param name="level">Вказується рівень (1 - температура, 2 - короткий коментар, 3 - URL іконки).</param>
        /// <returns></returns>
        public string this[int day, int level]
        {
            get
            {
                if (day > 0 && day < 7)
                {
                    switch (level)
                    {
                        case 1:
                            return GetForecastMinMaxTemperature(day);
                        case 2:
                            return GetForecastComment(day);
                        case 3:
                            return GetForecastURLIcon(day);
                        default:
                            return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Метод інтерфейса IDisposable, застосовується для вивільнення ресурсів.
        /// </summary>
        public void Dispose()
        {
            web.Dispose();
        }

        /// <summary>
        /// Метод інтерфейса ICloneable, застосовується для клонування об'єкта (глибокого копіювання).
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new OpenWeather(IdClient, IdCity, Language, TemperatureScale, Proxy);
        }

        /// <summary>
        /// Перевизначення методу ToString().
        /// </summary>
        /// <returns>Об'єкт даного класу, представлений стрічкою.</returns>
        public override string ToString()
        {
            string proxy;
            string authentication;
            if (Proxy == null)
            {
                proxy = "-";
                authentication = "-";
            }
            else 
            {
                proxy = Proxy.Address.ToString();
                authentication = Proxy.Credentials != null ? "+" : "-";
            }
            return "APPID=" + idClient + " ID city=" + idCity + " Language=" + Language + " Temperature scale=" + TemperatureScale + " PROXY=" + proxy + " authentication=" + authentication;
        }
    }

    /// <summary>
    /// Перечислення, мов.
    /// </summary>
    public enum OWLanguage
    {
        /// <summary>
        /// Українська мова.
        /// </summary>
        [Description("uk-UA")]
        uk,
        /// <summary>
        /// Англійська мова.
        /// </summary>
        [Description("en-US")]
        en,
        /// <summary>
        /// Російська мова. 
        /// </summary>
        [Description("ru-RU")]
        ru
    }

    /// <summary>
    /// Перечислення, температурних шкал.
    /// </summary>
    public enum Scale
    {
        /// <summary>
        /// Шкала Цельсія
        /// </summary>
        Celsius, 
        /// <summary>
        /// Шкала Кельвіна
        /// </summary>
        Kelvin, 
        /// <summary>
        /// Шкала Фаренгейта
        /// </summary>
        Fahrenheit
    }
}
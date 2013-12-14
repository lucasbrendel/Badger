using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using System.Windows;
using System.Windows.Media;
using MahApps.Metro;

namespace Badger.Managers
{
    public class SystemSettingsManager
    {
        private const string _themeString = "BadgerTheme";
        private const string _accentString = "BadgerAccent";

        /// <summary>
        /// 
        /// </summary>
        public SystemSettingsManager()
        {
            
        }

        public static void Startup()
        {
            BlobCache.ApplicationName = "Badger";

            AccentColorData accent = new AccentColorData();
            Theme theme = Theme.Light;

            BlobCache.LocalMachine.GetObjectAsync<AccentColorData>(_accentString)
                .Subscribe(x => accent = x);

            BlobCache.LocalMachine.GetObjectAsync<Theme>(_themeString)
                .Subscribe(x => theme = x);

            if (accent.Name != null)
            {
                ChangeAccent(accent);
            }

            if (theme != null)
            {
                if ((Theme)theme == Theme.Dark)
                {
                    SetThemeDark();
                }
                else
                {
                    SetThemeLight();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Save(string key, object value, Type type)
        {
            BlobCache.LocalMachine.InsertObject(key, value);
        }     
  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Load(string key)
        {
            var val = BlobCache.LocalMachine.GetObjectAsync<object>(key);
            return val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public static void ChangeAccent(object sender)
        {
            var t = sender as AccentColorData;
            var theme = ThemeManager.DetectTheme(Application.Current);
            var accent = ThemeManager.DefaultAccents.First(x => x.Name == t.Name);
            ThemeManager.ChangeTheme(Application.Current, accent, theme.Item1);

            BlobCache.LocalMachine.InsertObject(_accentString, t);
        }

        /// <summary>
        /// Change the theme to the Dark Theme
        /// </summary>
        public static void SetThemeDark()
        {
            var theme = ThemeManager.DetectTheme(Application.Current);
            ThemeManager.ChangeTheme(Application.Current, theme.Item2, Theme.Dark);

            //Save theme to cache
            BlobCache.LocalMachine.InsertObject(_themeString, Theme.Dark);
        }

        /// <summary>
        /// Change the theme to the Light Theme
        /// </summary>
        public static void SetThemeLight()
        {
            var theme = ThemeManager.DetectTheme(Application.Current);
            if (theme != null)
            { 
            ThemeManager.ChangeTheme(Application.Current, theme.Item2, Theme.Light);
                }

            //save theme to cache
            BlobCache.LocalMachine.InsertObject(_themeString, Theme.Light);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<AccentColorData> GetSystemAccents()
        {
            return ThemeManager.DefaultAccents
                               .Select(a => new AccentColorData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                               .ToList();
        }
    }

        /// <summary>
    /// Class for aggregating and changing the accent color
    /// </summary>
    public class AccentColorData
    {
        /// <summary>
        /// Name of the accent color
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color of the accent
        /// </summary>
        public Brush ColorBrush { get; set; }
    }
}

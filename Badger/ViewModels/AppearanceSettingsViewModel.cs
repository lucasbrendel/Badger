using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.Windows.Input;
using MahApps.Metro;
using System.Windows.Media;
using System.Windows;
using Badger.Commands;
using Badger.Managers;

namespace Badger.ViewModels
{
    /// <summary>
    /// Setting Item to change the Theme and Accent Colors
    /// </summary>
    [Export(typeof(IBadgerSettingsItemViewModel))]
    public class AppearanceSettingsViewModel : BadgerSettingsItemViewModel
    {
        private List<AccentColorData> _accentColors;

        /// <summary>
        /// Default Constructor
        /// </summary>
        [ImportingConstructor]        
        public AppearanceSettingsViewModel()
        {
            this.DisplayName = "Appearance";

            this._accentColors = SystemSettingsManager.GetSystemAccents();
        }

        /// <summary>
        /// List of all accent colors supported by MahApps.Metro
        /// </summary>
        public List<AccentColorData> AccentColors
        {
            get { return _accentColors; }
            set
            {
                if (value != _accentColors)
                {
                    _accentColors = value;
                }
            }
        }

        /// <summary>
        /// Change the theme to the Dark Theme
        /// </summary>
        public void SetThemeDark()
        {
            SystemSettingsManager.SetThemeDark();
        }

        /// <summary>
        /// Change the theme to the Light Theme
        /// </summary>
        public void SetThemeLight()
        {
            SystemSettingsManager.SetThemeLight();
        }

        private ICommand changeAccentCommand;

        /// <summary>
        /// Command to trigger changing the accent color
        /// </summary>
        public ICommand ChangeAccentCommand
        {
            get { return this.changeAccentCommand ?? (changeAccentCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => SystemSettingsManager.ChangeAccent(x) }); }
        }
    }


}

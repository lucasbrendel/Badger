﻿using System;
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

namespace Badger.ViewModels
{
    /// <summary>
    /// 
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

            this._accentColors = ThemeManager.DefaultAccents
                                            .Select(a => new AccentColorData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                            .ToList();
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
        
    }

    public class AccentColorData
    {
        public string Name { get; set; }
        public Brush ColorBrush { get; set; }

        private ICommand changeAccentCommand;

        public ICommand ChangeAccentCommand
        {
            get { return this.changeAccentCommand ?? (changeAccentCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => ChangeAccent(x) }); }
        }

        private void ChangeAccent(object sender)
        {
            var theme = ThemeManager.DetectTheme(Application.Current);
            var accent = ThemeManager.DefaultAccents.First(x => x.Name == this.Name);
            ThemeManager.ChangeTheme(Application.Current, accent, theme.Item1);
        }
    }
}

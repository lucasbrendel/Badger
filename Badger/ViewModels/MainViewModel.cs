using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace Badger.ViewModels
{
    [Export(typeof(MainViewModel))]
    public class MainViewModel : PropertyChangedBase, IHaveDisplayName
    {
        private string _displayName = "Badger";

        #region IHaveDisplayName Members

        /// <summary>
        /// The Title of the View
        /// </summary>
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                if (value != _displayName)
                {
                    _displayName = value;

                    NotifyOfPropertyChange(() => DisplayName);
                }
            }
        }

        #endregion

        private readonly IWindowManager _windowManager;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="windowManager"></param>
        [ImportingConstructor]
        public MainViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
        }

        /// <summary>
        /// Opens the view model to configure application settings
        /// </summary>
        public void ConfigureSettings()
        {
            _windowManager.ShowWindow(new BadgerSettingsViewModel(new List<IBadgerSettingsItemViewModel>()));
        }
    }
}

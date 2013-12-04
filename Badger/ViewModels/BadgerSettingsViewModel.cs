using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Badger.ViewModels
{
    public class BadgerSettingsViewModel : PropertyChangedBase, IBadgerSettingsViewModel
    {
        private string _displayName = "Badger Settings";

        #region IHaveDisplayName Members

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
    }
}

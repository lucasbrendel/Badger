using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badger.ViewModels
{
    public class BadgerSettingsItemViewModel : IBadgerSettingsItemViewModel
    {
        private string _displayName;

        #region IHaveDisplayName Members

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }

        #endregion
    }
}

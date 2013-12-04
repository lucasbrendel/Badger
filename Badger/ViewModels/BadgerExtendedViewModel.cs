using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Badger.ViewModels
{
    [Export(typeof(BadgerExtendedViewModel))]
    public class BadgerExtendedViewModel : PropertyChangedBase, IHaveDisplayName
    {
        private string _displayName = "Extended Badger";

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

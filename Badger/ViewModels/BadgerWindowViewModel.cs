using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Badger.ViewModels
{
    [Export(typeof(BadgerWindowViewModel))]
    public class BadgerWindowViewModel : PropertyChangedBase, IBadgerWindowViewModel
    {
        private string _displayName = "Extended Badger View";

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

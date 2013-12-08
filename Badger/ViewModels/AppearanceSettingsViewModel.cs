using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace Badger.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IBadgerSettingsItemViewModel))]
    public class AppearanceSettingsViewModel : IBadgerSettingsItemViewModel, IHaveDisplayName
    {
        private string _displayName;

        /// <summary>
        /// Default Constructor
        /// </summary>
        [ImportingConstructor]        
        public AppearanceSettingsViewModel()
        {
            this.DisplayName = "Appearance";
        }



        #region IHaveDisplayName Members

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

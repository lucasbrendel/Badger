using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Badger.ViewModels
{
    [Export(typeof(IBadgerSettingsItemViewModel))]
    public class WebSettingsViewModel : BadgerSettingsItemViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        [ImportingConstructor]
        public WebSettingsViewModel()
        {
            this.DisplayName = "Web";
        }
    }
}

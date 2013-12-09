using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;

namespace Badger.ViewModels
{
    public class BadgerSettingsViewModel
    {
        private List<IBadgerSettingsItemViewModel> _settingsOptions;

        [ImportMany]
        public List<IBadgerSettingsItemViewModel> SettingsOptions
        {
            get { return _settingsOptions; }
            set
            {
                _settingsOptions = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public BadgerSettingsViewModel(List<IBadgerSettingsItemViewModel> _settings)
        {
            try
            {
                var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
                var container = new CompositionContainer(catalog);

                container.ComposeParts(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

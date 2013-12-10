using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badger.Managers
{
    public interface ISystemSettingLoader
    {
        string Save(string key, object value);

        object Load(string key);
    }
}

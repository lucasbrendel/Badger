using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akavache;

namespace Badger.Managers
{
    public class SystemSettingsManager
    {
        public SystemSettingsManager()
        {
            BlobCache.ApplicationName = "Badger";
        }

        public static void Save(string key, object value)
        {
            BlobCache.LocalMachine.InsertObject(key, value);
        }     
  
        public static void LoadAsync(string key)
        {
            //var val = await BlobCache.LocalMachine.GetObjectAsync<object>(key);
        }
    }
}

using LibraryReport.Interfaces;
using LibraryReport.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryReport.IOC
{
    class DependencyInjector : Injector, IRegistry
    {
        private IDictionary<Type, IList<object>> beans;
        private IDictionary<Type, object> storage;

        public DependencyInjector()
        {
            beans = new Dictionary<Type, IList<object>>();
            storage = new Dictionary<Type, object>();
        }

        public object Inject(Type type)
        {
            Type typeFromStorage = storage.Keys.FirstOrDefault(e => e.Equals(type));
            if (typeFromStorage != null)
            {
                return storage[typeFromStorage];
            }

            object instance = beans[type] == null ?
                Activator.CreateInstance(type) :
                Activator.CreateInstance(type, beans[type].ToArray(), null);

            storage.Add(type, instance);

            return instance;
        }


        public void RegisterBean(Type type, params object[] args)
        {
            if (args.Length == 0)
            {
                beans.Add(type, null);
                return;
            }
            beans.Add(type, args);
        }
    }
}

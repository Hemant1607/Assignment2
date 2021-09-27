using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Chords
{
    class Get
    {
        public static object GetPropertyValue(object name,string NameProperty )
        {
            PropertyInfo property=name.GetType().GetProperty(NameProperty);
            return property.GetValue(name);
        }

        public static void SetPropetyValue(object name,string NameProperty,object value)
        {
            PropertyInfo property = name.GetType().GetProperty(NameProperty);
            property.SetValue(name, value);
        }

        public static object InvokeMethod(object name,string MethodName,object[] args)
        {
            Type[] types = args.Select(x => x.GetType()).ToArray();

            MethodInfo method = name.GetType().GetMethod(MethodName, types);

            return method.Invoke(name, args);
        }
    }
}

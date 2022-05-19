using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoDS
{
    public class Dynamic : DynamicObject
    {
        public Dictionary<string, object> properties = new Dictionary<string, object>();

        //public object this[string propertyName]
        //{
        //    get { return properties[propertyName]; }
        //    set { AddProperty(propertyName, value); }
        //}
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (properties.ContainsKey(binder.Name))
            {
                result = properties[binder.Name];
                return true;
            }
            else if (binder.Name == null || binder.Name == "")
            {
                result = "EmptyKeyException";
                return false;
            }
            else
            {
                result = "UnknownKeyException";
                return false;
            }
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            //properties[binder.Name] = value;
            AddProperty(binder.Name, value);
            return true;
        }

        public void AddProperty(string keyName, object value)
        {
            if (keyName == null)
            {
                throw new ArgumentException();
            }
            else if (keyName == null || keyName == "")
            {
                throw new ArgumentException();
            }
            else if (Regex.IsMatch(keyName, "^[^0-9][a-zA-Z0-9]*$"))
            {
                throw new ArgumentException();
            }
            else
            {
                properties[keyName] = value;
            }

        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Automation
{
    public enum PropertyType
    {
        Id,
        Name,
        XPath,
        LinkText,
        CSSName,
        ClassName
    }
    public class Properties
    {
        public Properties()
        { }

        private Properties(string value) { Value = value; }
        public string Value { get; set; }

        public static Properties Id { get { return new Properties("Id"); } }
        public static Properties Name { get { return new Properties("Name"); } }
        public static Properties Class { get { return new Properties("Class"); } }
        public static Properties Xpath { get { return new Properties("XPath"); } }
        public static Properties ValueAttribute { get { return new Properties("ValueAttribute"); } }
        public static IWebDriver driver { get; set; }

    }
}

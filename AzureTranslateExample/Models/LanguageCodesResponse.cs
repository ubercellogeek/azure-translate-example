using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace AzureTranslateExample.Models
{
     /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays", IsNullable = false)]
    public partial class ArrayOfstring
    {

        private string[] stringField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("string")]
        public string[] @string
        {
            get
            {
                return this.stringField;
            }
            set
            {
                this.stringField = value;
            }
        }
    }
}
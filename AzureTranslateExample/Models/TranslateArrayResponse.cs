using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace AzureTranslateExample.Models
{
    
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2", IsNullable = false)]
    public partial class ArrayOfTranslateArrayResponse
    {

        private ArrayOfTranslateArrayResponseTranslateArrayResponse[] translateArrayResponseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TranslateArrayResponse")]
        public ArrayOfTranslateArrayResponseTranslateArrayResponse[] TranslateArrayResponse
        {
            get
            {
                return this.translateArrayResponseField;
            }
            set
            {
                this.translateArrayResponseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    public partial class ArrayOfTranslateArrayResponseTranslateArrayResponse
    {

        private string fromField;

        private ArrayOfTranslateArrayResponseTranslateArrayResponseOriginalTextSentenceLengths originalTextSentenceLengthsField;

        private string translatedTextField;

        private ArrayOfTranslateArrayResponseTranslateArrayResponseTranslatedTextSentenceLengths translatedTextSentenceLengthsField;

        /// <remarks/>
        public string From
        {
            get
            {
                return this.fromField;
            }
            set
            {
                this.fromField = value;
            }
        }

        /// <remarks/>
        public ArrayOfTranslateArrayResponseTranslateArrayResponseOriginalTextSentenceLengths OriginalTextSentenceLengths
        {
            get
            {
                return this.originalTextSentenceLengthsField;
            }
            set
            {
                this.originalTextSentenceLengthsField = value;
            }
        }

        /// <remarks/>
        public string TranslatedText
        {
            get
            {
                return this.translatedTextField;
            }
            set
            {
                this.translatedTextField = value;
            }
        }

        /// <remarks/>
        public ArrayOfTranslateArrayResponseTranslateArrayResponseTranslatedTextSentenceLengths TranslatedTextSentenceLengths
        {
            get
            {
                return this.translatedTextSentenceLengthsField;
            }
            set
            {
                this.translatedTextSentenceLengthsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    public partial class ArrayOfTranslateArrayResponseTranslateArrayResponseOriginalTextSentenceLengths
    {

        private byte intField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public byte @int
        {
            get
            {
                return this.intField;
            }
            set
            {
                this.intField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.datacontract.org/2004/07/Microsoft.MT.Web.Service.V2")]
    public partial class ArrayOfTranslateArrayResponseTranslateArrayResponseTranslatedTextSentenceLengths
    {

        private byte intField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public byte @int
        {
            get
            {
                return this.intField;
            }
            set
            {
                this.intField = value;
            }
        }
    }
}
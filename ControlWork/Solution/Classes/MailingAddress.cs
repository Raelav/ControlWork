using System;
using Solution.Interfaces;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Collections.Generic;
using Solution.View;
using Solution.Factories;

namespace Solution.Classes
{
    public class MailingAddress : IMailingAddress, IStudyAssignment
    {
        private string _city;
        private string _homeAddress;
        private string _name;
        private string _postalCode;
        private string _street;

        private Dictionary<string, string> replacementFormat = new Dictionary<string, string>();

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                replacementFormat["город"] = value;
            }
        }
        public string HomeAddress
        {
            get { return _homeAddress; }
            set
            {
                _homeAddress = value;
                replacementFormat["адрес"] = value;
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                replacementFormat["название"] = value;
            }
        }
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                _postalCode = value;
                replacementFormat["индекс"] = value;
            }
        }
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                replacementFormat["улица"] = value;
            }
        }

        public MailingAddress(string name = "ForExample", string city = "Alapayevsk"
            , string street = "Lenina", string homeAddress = "1 apt.1", string postalCode = "624600")
        {
            City = city;
            Name = name;
            Street = street;
            HomeAddress = homeAddress;
            PostalCode = postalCode;
        }

        public void CreateAdvertisement()
        {
            WorkWithMicrosoftWord(Properties.Resources.advertising, "advertising");
        }

        public void CreateEnvelope()
        {
            WorkWithMicrosoftWord(Properties.Resources.envelope, "envelope");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template">Template extracted from resources</param>
        /// <param name="typeName">Name of the required template</param>
        private void WorkWithMicrosoftWord(byte[] template, string typeName)
        {
            Application app = new Application();
            var wayToResult = CreateFile(typeName);
            File.WriteAllBytes(wayToResult, template);           
            object missing = Type.Missing;
            var doc = GetDocument(app, wayToResult, typeName.Substring(0, 1).ToUpper() + typeName.Substring(1), missing);
            OpenSolution(missing, app, doc);
        }

        /// <summary>
        /// Create empty file for writing a template
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        private string CreateFile(string typeName)
        {
            var path = $"{Environment.CurrentDirectory}//{Name}{typeName}.docx";
            File.Create(path).Close();        
            return path;
        }

        /// <summary>
        /// replaces the specified areas with the corresponding value
        /// </summary>
        /// <param name="missing"></param>
        /// <param name="app"></param>
        /// <param name="doc"></param>
        private void OpenSolution(object missing, Application app, Document doc)
        {
            foreach(var e in replacementFormat)
            {
                object findText = e.Key;
                object replaceWith = e.Value;
                object replace = 2;

                app.Selection.Find.Execute(ref findText, ref missing, ref missing, ref missing,
    ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceWith,
    ref replace, ref missing, ref missing, ref missing, ref missing);
            }
            doc.Save();      
            app.Visible = true;
        }

        /// <summary>
        /// Prepare document for writing
        /// </summary>
        /// <param name="app"></param>
        /// <param name="template"></param>
        /// <param name="typeName"></param>
        /// <param name="missing"></param>
        /// <returns></returns>
        private Document GetDocument(Application app, string template, string typeName, object missing)
        {
            Document doc = null;
            object fileName = template;
            object falseValue = false;
            object trueValue = true;

            doc = app.Documents.Open(ref fileName, ref missing, ref falseValue,
ref missing, ref missing, ref missing, ref missing, ref missing,
ref missing, ref missing, ref missing, ref missing, ref missing,
ref missing, ref missing, ref missing);

            app.Selection.Find.ClearFormatting();
            app.Selection.Find.Replacement.ClearFormatting();

            return doc;
        }

        public void Run()
        {
            new MailingAddressView().Main(new MailingAddressFactory());
        }
    }
}

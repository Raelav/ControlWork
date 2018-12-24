using System;
using Solution.Interfaces;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Collections.Generic;

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

        public MailingAddress(string name, string city, string street, string homeAddress, string postalCode)
        {
            City = city;
            Name = name;
            Street = street;
            HomeAddress = homeAddress;
            PostalCode = postalCode;
        }
        public MailingAddress() : this("ForExample", "Alapayevsk", "Lenina", "1 apt.1", "624600") { }

        public void CreateAdvertisement()
        {
            WorkInMicrosoftWord("advertising");
        }

        public void CreateEnvelope()
        {
            WorkInMicrosoftWord("envelope");
        }

        private void WorkInMicrosoftWord(string type)
        {
            Application app = new Application();
            var template = Environment.CurrentDirectory + "\\MailingAddress\\" + type + ".docx";
            object missing = Type.Missing;
            var doc = GetDocument(app, template, type.Substring(0, 1).ToUpper() + type.Substring(1), missing);
            OpenSolution(missing, app, doc);
        }

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

        private Document GetDocument(Application app, string template, string typeName, object missing)
        {
            Document doc = null;

            object fileName = CreateFile(typeName, template);
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

        private string CreateFile(string typeName, string template)
        {
            int copyNum = 1;
            CreateCopyOfTemplate(ref copyNum, typeName, template);
            return $"{Environment.CurrentDirectory}\\MailingAddress\\{Name}{typeName}{copyNum}.docx";
        }

        private void CreateCopyOfTemplate(ref int copyNum, string typeName, string template)
        {
            try
            {
                File.Copy(template, $"{Environment.CurrentDirectory}\\MailingAddress\\{Name}{typeName}{copyNum}.docx");
            }
            catch (IOException e)
            {
                copyNum++;
                CreateCopyOfTemplate(ref copyNum, typeName, template);
            }
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}

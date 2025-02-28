using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HISPlus
{
    public static class WordHelper
    {
        private static Microsoft.Office.Interop.Word.Application _wordApp;
        public static Microsoft.Office.Interop.Word.Application WordApp
        {
            get
            {
                if (!WordAppIsOpen())
                {
                    _wordApp = new Microsoft.Office.Interop.Word.Application();
                    _wordApp.DocumentBeforeClose += _wordApp_DocumentBeforeClose;
                }

                return _wordApp;
            }
        }

        public static event ApplicationEvents4_DocumentBeforeCloseEventHandler BeforeCloseWordDoc;

        private static string _lastOpenedDocUniqueID;

        static void _wordApp_DocumentBeforeClose(Document Doc, ref bool Cancel)
        {
            if (BeforeCloseWordDoc != null)
            {
                BeforeCloseWordDoc(Doc, ref Cancel);
                if (Cancel)
                    return;
            }

            if (GetDocumentUniqueID(Doc) == _lastOpenedDocUniqueID)//if it's our opened Doc. not other word Docs
                WordDoc = null;
        }
        
        public static Document WordDoc;

        public const string WordDocumentIsAlreadyOpenMessage = "Word Document is already open";

        public static void CreateNewDocument()
        {
            if (WordDoc != null)
                throw new Exception(WordDocumentIsAlreadyOpenMessage);

            WordDoc = WordApp.Documents.Add();
            _lastOpenedDocUniqueID = GetDocumentUniqueID(WordDoc);
        }

        public static void OpenDocument(string filePath)
        {
            if (WordDoc != null)
                throw new Exception(WordDocumentIsAlreadyOpenMessage);

            object missing = Missing.Value;
            object filename = (string)filePath;
            object readOnly = false;
            object isVisible = true;

            WordDoc = WordApp.Documents.Open(ref filename, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
            WordDoc.Activate();
            _lastOpenedDocUniqueID = GetDocumentUniqueID(WordDoc);
        }

        public static string GetDocumentUniqueID(Document wordDoc)
        {
            return wordDoc.FullName;
        }

        public static bool WordAppIsOpen()
        {
            var wordAppIsOpen = false;

            if (_wordApp != null)
            {
                try
                {
                    var version = _wordApp.Version;//Testing word app
                    wordAppIsOpen = true;
                }
                catch
                {
                }
            }

            return wordAppIsOpen;
        }
    }
}

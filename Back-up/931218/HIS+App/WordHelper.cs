using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HISPlus
{
    public class WordHelper
    {
        public static Document WordDoc;

        public const string WordDocumentIsAlreadyOpenMessage = "Word Document is already open";

        public static void CreateNewDocument(Application wordApp)
        {
            if (WordDoc != null)
                throw new Exception(WordDocumentIsAlreadyOpenMessage);

            WordDoc = wordApp.Documents.Add();
        }

        public static void OpenDocument(Application wordApp, string filePath)
        {
            if (WordDoc != null)
                throw new Exception(WordDocumentIsAlreadyOpenMessage);

            object missing = Missing.Value;
            object filename = (string)filePath;
            object readOnly = false;
            object isVisible = true;

            WordDoc = wordApp.Documents.Open(ref filename, ref missing,
                        ref readOnly, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref isVisible, ref missing, ref missing,
                        ref missing, ref missing);
            WordDoc.Activate();
        }

        public bool WordAppIsOpen(Application wordApp)
        {
            try
            {
                var visible = wordApp.Visible;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

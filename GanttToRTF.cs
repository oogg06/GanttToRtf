using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Net.Sgoliver.NRtfTree.Core;
using Net.Sgoliver.NRtfTree.Util;

using System.Xml;

namespace GanttToWord
{
    /// <summary>
    /// Converts a file created by Gantt Project to a Microsoft Word Document
    /// </summary>
    class GanttToRTFConverter
    {
        private string path;
        private string rtfPath;
        RtfDocument doc;

        public GanttToRTFConverter(string path)
        {
            this.path = path;
            rtfPath = path.Remove( path.Length-3, 3);
            rtfPath = rtfPath + "rtf";
            doc = new RtfDocument(rtfPath);
        }

        public void convert(string wordDocumentPath)
        {

            XmlDocument xmlOrigin = new XmlDocument();
            xmlOrigin.Load(path);

            XmlNodeList tasks = xmlOrigin.GetElementsByTagName("task");
            RtfTextFormat format = new RtfTextFormat();
            format.size = 20;
            format.bold = true;
            format.underline = true;

            foreach (XmlElement elem in tasks)
            {
                doc.AddText(elem.GetAttribute("id"), format);
                doc.AddText(elem.GetAttribute("name"), format);
                doc.AddNewLine();
            }

            
            doc.Close();
        }
    }
}

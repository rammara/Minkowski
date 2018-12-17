using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Minkowski.Code
{
    public static class XmlIO
    {
        private static string GetDirectory()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        } // GetDirectory

        private const string DEFAULT_FILENAME = "st_events.xml";
        public static IEnumerable<SpaceTimeEvent> LoadEvents(string filename = null)
        {
            if (null == filename) filename = DEFAULT_FILENAME;
            string path = Path.Combine(GetDirectory(), filename);
            if (File.Exists(path))
            {
                try
                {
                    XDocument doc = XDocument.Load(filename);
                    return doc.Descendants("event").Select(node => new SpaceTimeEvent()
                    {
                        Label = (string)node.Element("label") ?? "<no label>",
                        Color = System.Drawing.Color.FromArgb(
                            alpha: (int)((int?)node.Element("color").Element("a") ?? 255),
                            red: (int)((int?)node.Element("color").Element("r") ?? 255), 
                            green: (int)((int?)node.Element("color").Element("g") ?? 255), 
                            blue: (int)((int?)node.Element("color").Element("b") ?? 255) ),
                        Position = (double)((double?)node.Element("pos") ?? 0.0d),
                        Time = (double)((double?)node.Element("time") ?? 0.0d)
                    });
                }
                catch(Exception ex)
                {
                    using (System.Diagnostics.EventLog applog = new System.Diagnostics.EventLog())
                    {
                        applog.Source = System.Reflection.Assembly.GetCallingAssembly().FullName;
                        applog.WriteEntry($"LoadEvents error: {ex.Message}", System.Diagnostics.EventLogEntryType.Error);
                    } // using applog
                    return null;
                }
            }
            else
            {
                return null;
            }
        } // LoadEvents

        public static int SaveEvents(IEnumerable<SpaceTimeEvent> events, string filename = null)
        {
            int error = 0x10;
            if (null == filename) filename = DEFAULT_FILENAME;
            string path = Path.Combine(GetDirectory(), filename);

            XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            XElement root = new XElement("events");
            foreach(var e in events)
            {
                XElement xevent = new XElement("event");
                XElement xlabel = new XElement("label") { Value = e.Label };
                XElement xpos = new XElement("pos") { Value = e.Position.ToString(CultureInfo.InvariantCulture) };
                XElement xtime = new XElement("time") { Value = e.Time.ToString(CultureInfo.InvariantCulture) };
                XElement xcolor = new XElement("color");
                XElement xca = new XElement("a") { Value = e.Color.A.ToString() };
                XElement xcr = new XElement("r") { Value = e.Color.R.ToString() };
                XElement xcg = new XElement("g") { Value = e.Color.G.ToString() };
                XElement xcb = new XElement("b") { Value = e.Color.B.ToString() };
                xcolor.Add(new XElement[] { xca, xcr, xcg, xcb });
                xevent.Add(new XElement[] { xlabel, xpos, xtime, xcolor });
                root.Add(xevent);
            } // foreach
            doc.Add(root);
            try
            {
                if (File.Exists(filename)) File.Delete(filename);
                error = 0x8;
                doc.Save(filename);
                error = 0;
            }
            catch(Exception ex)
            {
                using (System.Diagnostics.EventLog applog = new System.Diagnostics.EventLog())
                {
                    applog.Source = System.Reflection.Assembly.GetCallingAssembly().FullName;
                    applog.WriteEntry($"LoadEvents error: {ex.Message}", System.Diagnostics.EventLogEntryType.Error);
                } // using applog
            }
            return error;
        } // SaveEvents
    } // class XmlIO
} // namespace

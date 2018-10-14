using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string stringa = "Converti il file";
      //string path = @"C:\Users\rosol\Desktop\MyTest.gpx";
        public string element;
        public string lat;
        public string lon;
        public string ele;
        public string time;
        public int count = 0;
        
        private void button(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                
                    XmlTextReader reader = new XmlTextReader(openFileDialog1.FileName);
                // Create a file to write to.
               // if (!File.Exists(openFileDialog1.FileName))
               // {
                    using (StreamWriter sw = File.CreateText(openFileDialog1.FileName.Replace("xml" , "gpx")))
                    {
                        sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><gpx creator=\"Garmin Desktop App\" version=\"1.1\" xsi:schemaLocation=\"http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd http://www.garmin.com/xmlschemas/WaypointExtension/v1 http://www8.garmin.com/xmlschemas/WaypointExtensionv1.xsd http://www.garmin.com/xmlschemas/TrackPointExtension/v1 http://www.garmin.com/xmlschemas/TrackPointExtensionv1.xsd http://www.garmin.com/xmlschemas/GpxExtensions/v3 http://www8.garmin.com/xmlschemas/GpxExtensionsv3.xsd http://www.garmin.com/xmlschemas/ActivityExtension/v1 http://www8.garmin.com/xmlschemas/ActivityExtensionv1.xsd http://www.garmin.com/xmlschemas/AdventuresExtensions/v1 http://www8.garmin.com/xmlschemas/AdventuresExtensionv1.xsd http://www.garmin.com/xmlschemas/PressureExtension/v1 http://www.garmin.com/xmlschemas/PressureExtensionv1.xsd http://www.garmin.com/xmlschemas/TripExtensions/v1 http://www.garmin.com/xmlschemas/TripExtensionsv1.xsd http://www.garmin.com/xmlschemas/TripMetaDataExtensions/v1 http://www.garmin.com/xmlschemas/TripMetaDataExtensionsv1.xsd http://www.garmin.com/xmlschemas/ViaPointTransportationModeExtensions/v1 http://www.garmin.com/xmlschemas/ViaPointTransportationModeExtensionsv1.xsd http://www.garmin.com/xmlschemas/CreationTimeExtension/v1 http://www.garmin.com/xmlschemas/CreationTimeExtensionsv1.xsd http://www.garmin.com/xmlschemas/AccelerationExtension/v1 http://www.garmin.com/xmlschemas/AccelerationExtensionv1.xsd http://www.garmin.com/xmlschemas/PowerExtension/v1 http://www.garmin.com/xmlschemas/PowerExtensionv1.xsd http://www.garmin.com/xmlschemas/VideoExtension/v1 http://www.garmin.com/xmlschemas/VideoExtensionv1.xsd\" xmlns=\"http://www.topografix.com/GPX/1/1\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:wptx1=\"http://www.garmin.com/xmlschemas/WaypointExtension/v1\" xmlns:gpxtrx=\"http://www.garmin.com/xmlschemas/GpxExtensions/v3\" xmlns:gpxtpx=\"http://www.garmin.com/xmlschemas/TrackPointExtension/v1\" xmlns:gpxx=\"http://www.garmin.com/xmlschemas/GpxExtensions/v3\" xmlns:trp=\"http://www.garmin.com/xmlschemas/TripExtensions/v1\" xmlns:adv=\"http://www.garmin.com/xmlschemas/AdventuresExtensions/v1\" xmlns:prs=\"http://www.garmin.com/xmlschemas/PressureExtension/v1\" xmlns:tmd=\"http://www.garmin.com/xmlschemas/TripMetaDataExtensions/v1\" xmlns:vptm=\"http://www.garmin.com/xmlschemas/ViaPointTransportationModeExtensions/v1\" xmlns:ctx=\"http://www.garmin.com/xmlschemas/CreationTimeExtension/v1\" xmlns:gpxacc=\"http://www.garmin.com/xmlschemas/AccelerationExtension/v1\" xmlns:gpxpx=\"http://www.garmin.com/xmlschemas/PowerExtension/v1\" xmlns:vidx1=\"http://www.garmin.com/xmlschemas/VideoExtension/v1\">");
                        //sw.WriteLine("<gpx version=\"1.0\">");
                        //sw.WriteLine("<name>Example gpx</name>");
                        sw.WriteLine("<trk><name>Example gpx</name><number>1</number><trkseg>");
                        while (reader.Read())
                        {
                            
                            switch (reader.NodeType)
                            {
                                case XmlNodeType.Element: // The node is an element.
                                    
                                    if (reader.Name == "FixType") {
                                        element = "fixtype";
                                       // sw.WriteLine("element = fixtype");
                                       // sw.WriteLine(reader.Name);
                                        //Console.WriteLine(reader.Name);
                                    }
                                    

                                    /* sw.Write("<" + reader.Name);
                                     sw.WriteLine(">");*/
                                    break;
                                case XmlNodeType.Text: //Display the text in each element.
                                    if (element == "fixtype")
                                    {
                                       // sw.WriteLine("element != fixtype");
                                        //Console.WriteLine(reader.Value);
                                        element = null;
                                        
                                    }
                                    else
                                    {
                                        
                                        if (count == 4) { count = 0;
                                            
                                            sw.WriteLine("<trkpt lat=\"" + lat.Replace(",", ".") + "\" lon=\"" + lon.Replace(",", ".") + "\"><ele>" + ele + "</ele><time>" + time.Replace(",", "T") + "Z</time></trkpt>"); }
                                        if (count == 0) { time= reader.Value; }
                                        if (count == 1) { lat = reader.Value; }
                                        if (count == 2) { lon = reader.Value; }
                                        if (count == 3) { ele = reader.Value; }
                                        //sw.WriteLine(count);
                                        
                                        count++;
                                        //element = null;
                                    }
                                    break;

                            }
                            
                        }
                        sw.WriteLine("</trkseg></trk>");
                        sw.WriteLine("</gpx>");
                    }
                //}
                
            }


        }
        
        }
    
}

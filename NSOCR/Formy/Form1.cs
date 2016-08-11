using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace NSOCR
{
    public partial class Form1 : Form
    {
        private Słownik FormSłow;
        private Klasy.MySQLConector SQLConnect;
        private OpenFileDialog show = new OpenFileDialog();
        private Thread WorkThreadOCR1;
        private List<string> FileList;
        private bool OCRWork1;
        public bool ProgramWork;
        private Klasy.Process _process;

        public Form1()
        {
            InitializeComponent();
            show.Multiselect = true;
            show.Filter = "Images (*.BMP;*.JPG;*.PDF)|*.BMP;*.JPG;*.pdf|" + "All files (*.*)|*.*";
            FormSłow = new Słownik();
            WorkThreadOCR1 = new Thread(ThreadOCR1);
            WorkThreadOCR1.Priority = ThreadPriority.Lowest;
            PanelWait.Visible = false;
            OCRWork1 = false;
            ProgramWork = true;
            WorkThreadOCR1.Start();
            SQLConnect = new Klasy.MySQLConector();
        }

        //Wybranie pliku oraz uruchomienie obliczeń
        private void button1_Click(object sender, EventArgs e)
        {
            FileList = new List<string>();
            if (show.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in show.FileNames)
                {
                    FileList.Add(file);
                    OCRWork1 = true;
                }
            }
        }
        //koniec programu 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgramWork = false;
        }
        //Menu dla słownika
        private void słowaKluczoweToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSłow.ShowDialog();
        }

        //=====================obsługa wielowątkowości===========================================
        private void ThreadOCR1()
        {
            while (ProgramWork)
            {
                WorkThreadOCR1.Priority = ThreadPriority.Lowest;
                while (OCRWork1)
                {
                    Invoke(new Action(() => { PanelWait.Show(); }));
                    WorkThreadOCR1.Priority = ThreadPriority.Highest;
                    foreach (string file in FileList)
                    {
                        _process = new Klasy.Process();
                        _process.InsertDate(file);
                    }
                    OCRWork1 = false;
                    Invoke(new Action(() => { PanelWait.Hide(); }));
                }
            }
        }
    }
}
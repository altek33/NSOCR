using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NSOCR
{
    public partial class Słownik : Form
    {
        private List<Dictionary> Słowniki = new List<Dictionary>();

        //Struktura zawierająca nazwę oraz ścieżkę do słownika
        private struct Dictionary
        {
            public string Name;
            public string Path;
        }

        public Słownik()
        {
            InitializeComponent();
        }

        //Dodanie słowników do listy
        private void Słownik_Load(object sender, EventArgs e)
        {
            LoadDictionary("Data Sprzedaży", "DictionaryDataSprzedaży.txt");
            LoadDictionary("Data Wystawienia", "DictionaryDataWystawienia.txt");
            LoadDictionary("Faktura Początek", "DictionaryFakturaBegine.txt");
            LoadDictionary("Faktura Koniec", "DictionaryFakturaEnd.txt");
            LoadDictionary("NIP Nabywcy", "DictionaryNIPNabywcy.txt");
            LoadDictionary("NIP Sprzedawcy", "DictionaryNIPSprzedawcy.txt");
            LoadDictionary("Termin Zapłaty", "DictionaryTerminZapłaty.txt");
            LoadDictionary("Waluty", "DictionaryWaluty.txt");
            List<string> temp = new List<string>();
            foreach (Dictionary name in Słowniki)
                temp.Add(name.Name);
            comboBox1.DataSource = temp;
            comboBox1.DisplayMember = "Name";
        }

        private void LoadDictionary(string name, string path)
        {
            Dictionary Dic = new Dictionary();
            Dic.Name = name;
            Dic.Path = @"Dictionary\" + path;
            Słowniki.Add(Dic);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            StreamReader sr;
            foreach (Dictionary Dic in Słowniki)
            {
                if (comboBox1.SelectedItem == Dic.Name)
                {
                    sr = new StreamReader(Dic.Path);
                    string state;
                    while ((state = sr.ReadLine()) != null)
                    {
                        richTextBox1.AppendText(state + "\n");
                    }
                    sr.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Dictionary Dic in Słowniki)
            {
                if (comboBox1.SelectedItem == Dic.Name)
                {
                    using (StreamWriter writer = new StreamWriter(Dic.Path, false, Encoding.Unicode))
                    {
                        foreach (string text in richTextBox1.Lines)
                            writer.WriteLine(text);
                    }
                }
            }
        }

        private void Słownik_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            richTextBox1.Text = "";
            this.Close();
        }
    }
}
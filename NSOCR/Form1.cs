using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace NSOCR
{
    public partial class Form1 : Form
    {
        public string Barcode;
        private OCREngine OCR;
        private TextFinder TxtFind;
        private WaitForm Wait;

        public Form1()
        {
            InitializeComponent();
            OCR = new OCREngine();
            Wait = new WaitForm();

        }

        private void button1_Click(object sender, EventArgs e)
        {
 
            string wynik;
            TxtFind = new TextFinder();
            OpenFileDialog show = new OpenFileDialog();
            if (show.ShowDialog() == DialogResult.OK)
            {

                wynik = OCR.ReadImage(show.FileName);
                richTextBox1.Text = wynik;
                TextBoxBoughtDate.Text = TxtFind.FindDate(wynik, "DictionaryTerminZapłaty.txt");
                TextBoxCashIn.Text = TxtFind.FindDate(wynik, "DictionaryDataSprzedaży.txt");
                TextBoxDateOfIssue.Text = TxtFind.FindDate(wynik, "DictionaryDataWystawienia.txt");
                TextBoxBoughtNip.Text = TxtFind.FindNIP(wynik, "DictionaryNIPNabywcy.txt");
                TextBoxSellerNip.Text = TxtFind.FindNIP(wynik, "DictionaryNIPSprzedawcy.txt");
                TextBoxFaktu.Text = TxtFind.FindNrFaktury(wynik, "DictionaryFakturaBegine.txt", "DictionaryFakturaEnd.txt");
                TextBoxBarcode.Text = OCR.Barcode(wynik);
                List<string>Currency = TxtFind.FindCurrency(wynik, "DictionaryWaluty.txt");
                TextBoxToPay.Text = TxtFind.FindToPay(wynik, "DictionaryDoZapłaty.txt" )+ Currency[0];
            }
        }

    }
}
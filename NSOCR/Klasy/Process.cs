using System;
using System.Windows.Forms;

namespace NSOCR.Klasy
{
    internal class Process
    {
        public Klasy.Informacje Data;
        public Klasy.SQLTable SQLDate;
        private Klasy.OCREngine OCR = new OCREngine();
        private Klasy.TextFinder TxtFind = new TextFinder();
        private Klasy.MySQLConector SQL = new MySQLConector();

        public void InsertDate(string Path)
        {
            string NrObcy;
            string DataWyst;
            string DataZakup;
            string Waluta1;
            string Waluta2;
            string Kwota1;
            string Kwota2;
            string NIPSprz;
            string NIPKup;
            string Barcode;
            string nrLeasingu;
            try
            {
                Data = new Informacje();
                SQLDate = new SQLTable();
                SQL = new MySQLConector();
                string wynik = OCR.ReadImage(Path);
                NIPKup = TxtFind.FindNIP(wynik, "DictionaryNIPSprzedawcy.txt");
                NIPSprz = TxtFind.FindNIP(wynik, "DictionaryNIPNabywcy.txt");
                DataWyst = TxtFind.FindDate(wynik, "DictionaryDataWystawienia.txt");
                DataZakup = TxtFind.FindDate(wynik, "DictionaryDataSprzedaży.txt");
                NrObcy = TxtFind.FindNrFaktury(wynik, "DictionaryFakturaBegine.txt", "DictionaryFakturaEnd.txt");
                nrLeasingu = TxtFind.FindNrUmowy(wynik, "DictionaryLeasing.txt");
                Kwota1 = TxtFind.FindToPay(wynik, "DictionaryDoZapłaty.txt");
                Kwota2 = TxtFind.SecondPay(wynik, "DictionaryDoZapłatyDwa.txt");
                Waluta1 = TxtFind.FindCurrency(wynik, "DictionaryWaluty.txt")[0];
                Waluta2 = TxtFind.FindCurrency(wynik, "DictionaryWaluty.txt")[1];
                Barcode = OCR.Barcode(Path);
                Data = SQLDate.SetData(NIPKup, NIPSprz, NrObcy,nrLeasingu, DataWyst, DataZakup, Kwota1, Waluta1, Kwota2,Waluta2, Barcode);
                SQL.InsertToDB(Data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z odczytem pliku\nupewnij się że wybrany plik jest fakturą\n" + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
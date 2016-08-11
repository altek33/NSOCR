using System;
using System.Numerics;

namespace NSOCR.Klasy
{
    public struct Informacje
    {
        public BigInteger NIPSprzedawcy;
        public BigInteger NIPNabywcy;
        public string NrObcy;
        public string NrLeasingu;
        public DateTime _DataWystawienia;
        public DateTime _DataZakupu;
        public double Kwota1;
        public string Waluta1;
        public double Kwota2;
        public string Waluta2;
        public float Barcode;

    }

    internal class SQLTable
    {
        public Informacje info;

        private DateTime SetDate(string data)
        {
            if (data != null)
            {
                if (data.Length > 6)
                {
                    data = data.Insert(4, "-");
                    data = data.Insert(7, "-");
                }
                return DateTime.Parse(data);
            }
            else
                return (DateTime.Parse("0000-00-00"));
        }

        private string SetLeasingFormat(string number)
        {
            if(number!=null)
            {
                number = number.Insert(5, "/");
                number = number.Insert(8, "/");
                number = number.Insert(11, "/");
            }
            return number;

        }

        public Informacje SetData(string NIPSprzedawcy, string NIPNabywcy, string NRObcy, string NrLeasingu, string DataWystawienia, string DataZakupu, string Kwota1, string waluta1, string Kwota2, string waluta2, string barcode)
        {
            info.NIPNabywcy = BigInteger.Parse(NIPNabywcy);
            info.NIPSprzedawcy = BigInteger.Parse(NIPSprzedawcy);
            info.NrObcy = NRObcy;
            info._DataWystawienia = SetDate(DataWystawienia);
            info._DataZakupu = SetDate(DataZakupu);
            info.NrLeasingu = SetLeasingFormat(NrLeasingu);
            if (Kwota1 != null)
            {
                info.Kwota1 = double.Parse(Kwota1.Substring(0, Kwota1.Length - 2));
                info.Kwota1 += (double.Parse(Kwota1.Substring(Kwota1.Length - 2, 2))) / 100;
            }
            else { Kwota1 = null; }
            info.Waluta1 = waluta1;

            if (Kwota2 != null)
            {
                info.Kwota2 = double.Parse(Kwota2.Substring(0, Kwota2.Length - 2));
                info.Kwota2 += (double.Parse(Kwota2.Substring(Kwota2.Length - 2, 2))) / 100;
            }
            else { Kwota1 = null; }
            info.Waluta2 = waluta2;

            info.Barcode = float.Parse(barcode);
            return info;
        }
    }
}
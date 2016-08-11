using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NSOCR.Klasy
{
    internal class TextFinder
    {
        private List<string> Currency = new List<string>();
        private List<string> Dictionary;
        private string FakturaNumber;
        private int Pos;
        private string SelectedWord;

        //======================Wyszukiwanie indeksu słowa===================================
        private void FindWordIndex(string Text, string NameDictionary)
        {
            LoadDictionary(NameDictionary);
            Pos = 0;
            foreach (string word in Dictionary)
            {
                SelectedWord = word;
                Pos = Text.IndexOf(word);
                if (Pos > 0)
                {
                    break;
                }
            }
        }

        //======================Wyszukiwanie indeksu słowa w określonym zakresie=============
        private void FindWordIndex(string Text, int PosBeg, int PosEnd)
        {
            if (PosBeg > 0 && PosEnd > 0)
            {
                FakturaNumber = null;
                for (int i = PosBeg; i <= PosEnd; i++)
                    FakturaNumber += Text[i];
                Pos = FakturaNumber.IndexOf("nr");
            }
        }

        //========================załadowanie słowników======================================
        private void LoadDictionary(string NameDictionary)
        {
            Dictionary = new List<string>();
            string line;
            StreamReader sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"Dictionary\", NameDictionary), Encoding.Unicode);
            while ((line = sr.ReadLine()) != null)
                Dictionary.Add(line);
            sr.Close();
        }

        //====================== wyszukiwanie dat============================================
        public string FindDate(string text, string NameDictionary)
        {
            FindWordIndex(text, NameDictionary);
            int pos = Pos;
            string Date = "";
            if (pos >= 0)
            {
                for (int i = pos; i < pos + 50; i++)
                {
                    if ((int)text[i] >= (int)'0' && (int)text[i] <= (int)'9')
                    {
                        Date += text[i];
                        if (Date.Length == 8)
                            return Date;
                    }
                    else
                    {
                        Date = "";
                    }
                }
            }
            return "20000101";
        }

        //====================== wyszukiwanie NIPU===========================================
        public string FindNIP(string text, string NameDictionary)
        {
            FindWordIndex(text, NameDictionary);
            string NIP = null;
            int pos = Pos;
            for (int i = pos; i <= pos + text.Length; i++)
            {
                if ((int)text[i] >= (int)'0' && (int)text[i] <= (int)'9')
                {
                    NIP += text[i];
                    if (NIP.Length == 10)
                        break;
                }
                else
                {
                    NIP = null;
                }
            }
            return NIP;
        }

        //====================== wyszukiwanie nr Faktury=====================================
        public string FindNrFaktury(string text, string NameDictionaryBegine, string NameDictionaryEnd)
        {
            string number = null;
            FindWordIndex(text, NameDictionaryBegine);
            int BeginePos = Pos;
            FindWordIndex(text, NameDictionaryEnd);
            int EndPos = Pos;
            FindWordIndex(text, BeginePos, EndPos);
            int pos = Pos;
            if (pos == -1)
                return "Błąd";
            else
            {
                for (int i = pos + 2; i <= FakturaNumber.Length; i++)
                {
                    if (FakturaNumber[i] == 'o' || FakturaNumber[i] == 'O')

                    {
                        break;
                    }
                    number += FakturaNumber[i];
                }
                return number;
            }
        }

        //===========================  Nr Umowy    ==========================================
        public string FindNrUmowy(string text, string Dictionary)
        {
            string Lising = null;
            FindWordIndex(text, Dictionary);
            int pos = Pos;
            if (pos != null)
            {
                for (int i = pos + SelectedWord.Length; i <= text.Length; i++)
                {
                    Lising += text[i];
                    if (Lising.Length == 9)
                        break;
                }
            }
            return Lising;
        }

        //===========================kwota do zapłacenia ===================================>
        public string FindToPay(string text, string Dictionary)
        {
            string money = null;
            FindWordIndex(text, Dictionary);
            int pos = Pos;
            for (int i = pos + 9; i <= text.Length; i++)
            {
                char ste = text[i];
                if ((int)text[i] >= (int)'0' && (int)text[i] <= (int)'9')
                    money += text[i];
                else
                {
                    pos = i;
                    break;
                }
            }
            return money;

        }

        public string SecondPay(string text, string Dictionary)
        {
            string money = null;
            FindWordIndex(text, Dictionary);
            int pos = Pos;
            if (pos != null)
            {
                for (int i = pos + 4; i <= text.Length; i++)
                {
                    char ste = text[i];
                    if ((int)text[i] >= (int)'0' && (int)text[i] <= (int)'9')
                        money += text[i];
                    else
                    {
                        pos = i;
                        break;
                    }
                }
            }
            return money;

        }
        public List<string> FindCurrency(string text, string NameDictionary)
        {
            Currency.Clear();
            LoadDictionary(NameDictionary);
            foreach (string currency in Dictionary)
            {
                if (text.IndexOf(currency) >= 0)
                    Currency.Add(currency);
            }
            return Currency;
        }

        //=======================kwota do zapłacenia=========================================<
    }
}
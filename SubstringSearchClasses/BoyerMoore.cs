using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubstringSearchClasses
{
    public class BoyerMooreAlgorithm: ISubstringSearch
    {
        int[] stopTable = new int[(int)char.MaxValue]; //столько же сколько всевозможных символов
        int[] suffixTable; //короткие суффиксы в конце

        public List<int> IndexesOf(string pattern, string text)
        {
            List<int> indexes = new List<int>();
            int m = pattern.Length;
            suffixTable = new int[m];

            GetStopTable(pattern);
            GetSuffixTable(pattern);

            //List<string> ar = new List<string>(); ОТЛАДКА
            //for (int i = 0; i < stopTable.Length; i++)
            //{
            //    if (stopTable[i] != 0)
            //        ar.Add(stopTable[i].ToString() + (char)i);
            //}

            for (int curIndex = m - 1; curIndex < text.Length; curIndex++) 
            {
                int indexInText = curIndex;
                int indexInPattern = m - 1;
                while (indexInPattern > -1 && pattern[indexInPattern] == text[indexInText])
                {
                    indexInText--;
                    indexInPattern--;
                }


                if (indexInPattern == -1) // -1 - это случай совпадения подстроки
                {
                    indexes.Add(curIndex - m + 1);
                    continue;
                }

                if (indexInText != curIndex)
                {
                    indexInText++;
                    indexInPattern++;
                }

                /////////////StopSymbol/////////////
                int shiftForStopMark = stopTable[text[indexInText]] <= 0 ? m : stopTable[text[indexInText]];

                /////////////Suffix/////////////
                int shiftForSuffixMark = indexInPattern == m - 1 ? 0 : suffixTable[indexInPattern];

                curIndex += Math.Max(shiftForSuffixMark, shiftForStopMark) - 1; // -1 т.к в for +1 в любом случае
            }

            return indexes;
        }

        private void GetSuffixTable(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--) // с конца
            {
                string window = str.Substring(i); // окно - то, что ищем - суффикс

                int j = i;
                while (window.Length != 0) // пока окно не ушло за начало строки (за индекс 0)
                {
                    j--;

                    if (j < 0)
                    {
                        window = window.Substring(1); // уменьшаем окно если оно ушло за начало строки - будем искать теперь такое окно
                    }

                    if (EqualityOfWords(window.ToString(), str.Substring(j > 0 ? j : 0, window.Length))) // то есть когда ушли за начало -
                                                                                                        // проверяем равенства суффикса и префикса
                    {
                        suffixTable[i] = i - j;
                        break;
                    }
                }
            }
        }

        private void GetStopTable(string str)
        {
            for (int i = str.Length - 1; i >= 0; i--) // смотрим с конца - что раньше не встречалось добавили
            {
                if (stopTable[str[i]] == 0)
                {
                    stopTable[str[i]] = str.Length - i - 1;

                    if (i == str.Length - 1) // проверим условие - последний символ и есть повторения -> то номер этого вхождения
                    {
                        int j = i;
                        while (j > 0)
                        {
                            j--;
                            if (str[i] == str[j])
                            {
                                stopTable[str[i]] = str.Length - j - 1;
                                break;
                            }
                        }
                        if (stopTable[str[i]] == str.Length - i - 1)
                            stopTable[str[i]] = str.Length;
                    }
                }
            }
        }

        private bool EqualityOfWords(string s1, string s2)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i])
                    return false;
            }

            return true;
        }
    }
}

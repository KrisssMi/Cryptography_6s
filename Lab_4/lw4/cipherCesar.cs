using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lw4
{
    class cipherCesar
    {
        char[] alphabetRus = { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я' };
        public char[] AlphabetRus { get => alphabetRus; set => alphabetRus = value; }   // создание свойства для доступа к приватному полю

        public string codeCesar(String fileText, string keyWord)    
        {
            string result = "";
            char[] codeAlphabet = GetCodeAlphabet(keyWord);         // получаем кодовый алфавит
            for (int i = 0; i < fileText.Length; i++)               // проходим по всему тексту
            {
                for (int j = 0; j < AlphabetRus.Length; j++)    
                {
                    if (fileText[i] == AlphabetRus[j])              // если символ текста равен символу из алфавита
                    {
                        result += codeAlphabet[j];
                        break;
                    }

                }
            }
            return result;
        }

        public string decodeCesar(String fileText, string keyWord)  
        {
            string result = "";
            char[] codeAlphabet = GetCodeAlphabet(keyWord);
            for (int i = 0; i < fileText.Length; i++)
            {
                for (int j = 0; j < AlphabetRus.Length; j++)
                {
                    if (fileText[i] == codeAlphabet[j])            // если символ текста равен символу из кодового алфавита
                    {
                        result += AlphabetRus[j];
                        break;
                    }

                }
            }
            return result;
        }

        public char[] GetCodeAlphabet(string keyWord)               // получаем кодовый алфавит
        {
            char[] result = new char[100];  
            bool flag = false;
            int count = 0;
            for (int i = 0; i < keyWord.Length; i++)
            {
                result[i] = keyWord[i]; 
                count++;
            }
            for (int a = 0; a < AlphabetRus.Length; a++)            // проходим по всему алфавиту
            {
                for (int c = 0; c < keyWord.Length; c++)            // проверяем, есть ли символ в ключевом слове
                {
                    if (result[c] == AlphabetRus[a])    
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    result[count] = AlphabetRus[a];
                    count++;
                }

                flag = false;
            }
            return result;
        }

        public int[] CountChar(char[] alph, String fileText)        // подсчет символов
        {   
            int[] count = new int[alph.Length];                     // массив для подсчета символов
            for (int i = 0; i < alph.Length; i++)
            {
                count[i] = fileText.ToUpper().Where(el => el == alph[i]).Count();   
            }
            return count;
        }
    }
}
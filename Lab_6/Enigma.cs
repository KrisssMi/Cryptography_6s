using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cripta_Lab6
{
class Enigma
    {
        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      
        private  string rotorVIII = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
        private  string rotorII = "AJDKSIRUXBLHWTMCQGZNPYFVOE";     
        private  string rotorIV = "ESOVPZJAYQUIRHXLNFTGKDCMWB";

        private const string reflectorBconf = "AYBRCUDHEQFSGLIPJXKNMOTZVW";

        private  int settingL = 0;
        private  int settingM = 0;
        private  int settingR = 0;
   
        public Dictionary<char, char> useReflector { get; set; }    

        Dictionary<char,char> GetReflector(string nameReflector)    
        {
            Dictionary<char, char> result = new Dictionary<char, char>();
            for (int i = 0; i < nameReflector.Length; i += 2)
            {
                result.Add(nameReflector[i], nameReflector[i + 1]);
                result.Add(nameReflector[i+1], nameReflector[i]);
            }

            return result;
        }

        Dictionary<int, char> GetDictionary(string param)
        {
            Dictionary<int, char> result = new Dictionary<int, char>();
            for (int i = 0; i < param.Length; i++)
            {
                result.Add(i, param[i]);
            }

            return result;
        }

        public char Encript(char charForEncrypt)
        {
            char resultChar= ' ';
            Dictionary<int, char> lRotor = GetDictionary(rotorVIII),    
                   mRotor = GetDictionary(rotorII) ,
                   rRotor = GetDictionary(rotorIV),
                   alphabetDictionary = GetDictionary(alphabet);

            Dictionary<char, char> useReflector = GetReflector(reflectorBconf);

            bool circleM = false;   // Переменные для проверки на круговой переход

            int numberChar = alphabetDictionary.Where(v => v.Value == charForEncrypt).FirstOrDefault().Key; 

            forwardStepRotor(rRotor, alphabetDictionary, ref resultChar, ref numberChar);                   Console.WriteLine($"Символ {charForEncrypt} после правого ротора {resultChar}");
            forwardStepRotor(mRotor, alphabetDictionary, ref resultChar, ref numberChar);                   Console.WriteLine($"Символ {charForEncrypt} после центрального ротора  {resultChar}");
            forwardStepRotor(lRotor, alphabetDictionary, ref resultChar, ref numberChar);                   Console.WriteLine($"Символ {charForEncrypt} после левого ротора  {resultChar}");

            char t = useReflector.Where(k => k.Key == resultChar).FirstOrDefault().Value; ; // Переменная для проверки на букву
            if (char.IsLetter(t))
            {
                resultChar = t;
                numberChar = alphabetDictionary.Where(v => v.Value == resultChar).FirstOrDefault().Key;
            }                                                                                               //Console.WriteLine($"Символ {charForEncrypt} после рефлектора {resultChar}");

            backStepRotor(lRotor, alphabetDictionary, ref resultChar, ref numberChar);                      //Console.WriteLine($"Символ {charForEncrypt} после левого ротора  {resultChar}");
            backStepRotor(mRotor, alphabetDictionary, ref resultChar, ref numberChar);                      //Console.WriteLine($"Символ {charForEncrypt} после центрального ротора  {resultChar}");
            backStepRotor(rRotor, alphabetDictionary, ref resultChar, ref numberChar);                      //Console.WriteLine($"Символ {charForEncrypt} после правого ротора {resultChar}");
        
            if (settingR % 26 != 0 || settingR == 0)
            {
                settingR += 1;
                updateSettingRotor(ref rotorIV, 2);
            }
            else if(settingR % 26 == 1)
            {
                settingR = 0;
                settingR += 1;
                updateSettingRotor(ref rotorIV, 2);
            }

            if (settingM % 26 != 0 || settingM == 0)
            {
                settingM += 1;
                updateSettingRotor(ref rotorII, 2);
            }
            else if (settingM % 26 == 1)
            {
                settingM = 0;
                settingM += 1;
                updateSettingRotor(ref rotorII, 2);
                if(settingL % 26 == 0)
                {
                    settingL += 1;
                    updateSettingRotor(ref rotorVIII, 1);
                }
                else if (settingL % 26 == 1)
                {
                    settingL = 0;
                    settingL += 1;
                    updateSettingRotor(ref rotorVIII, 1);
                }
            }
            return resultChar;
        }

        void updateSettingRotor(ref string rotor, int step) // Обновление настроек роторов
        {
            string removeChar = "";

            for (int i = 0; i < step; i++)
                removeChar += rotor[i];

            rotor = rotor.Remove(0, step);
            rotor += removeChar;
        }

        void forwardStepRotor(Dictionary<int, char> rotor, Dictionary<int, char> alph, ref char character, ref int numberChar)  // Перемещение символа по ротору
        {
            int num = numberChar;
            character = rotor.Where(k => k.Key == num).FirstOrDefault().Value;
            char s = character;
            numberChar = alph.Where(v => v.Value == s).FirstOrDefault().Key;
        }

        void backStepRotor(Dictionary<int, char> rotor, Dictionary<int, char> alph, ref char character, ref int numberChar) 
        {
            char s = character;
            numberChar = rotor.Where(v => v.Value == s).FirstOrDefault().Key;
            int num = numberChar;
            character = alph.Where(k => k.Key == num).FirstOrDefault().Value;
        }
    }
}

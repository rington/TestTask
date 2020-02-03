using System;
using System.Collections.Generic;

namespace TestTaskGlobalLogic
{
    public class Program
    {
        public enum Language
        {
            English,
            Ukrainian
        };

        static void Main(string[] args)
        {
            var choosedLang = LanguageCheck();
            var stringNumber = NumberInput(choosedLang);
            DividingStringOnPart(stringNumber, choosedLang, out var integerPart, out var decimalPart);

            var numberToWords = ConvertWholeNumberToWords(integerPart, decimalPart, choosedLang);
            Console.WriteLine(numberToWords);

            Console.ReadKey();
        }

        public static Dictionary<int, string> englishDictionary = new Dictionary<int, string>
        {
            {0, "zero"},
            {1, "one "},
            {2, "two "},
            {3, "three "},
            {4, "four "},
            {5, "five "},
            {6, "six "},
            {7, "seven "},
            {8, "eight "},
            {9, "nine "},
            {10, "ten "},
            {11, "eleven "},
            {12, "twelve "},
            {13, "thirteen "},
            {14, "fourteen "},
            {15, "fifteen "},
            {16, "sixteen "},
            {17, "seventeen "},
            {18, "eighteen "},
            {19, "nineteen "},
            {20, "twenty"},
            {30, "thirty"},
            {40, "forty"},
            {50, "fifty"},
            {60, "sixty"},
            {70, "seventy"},
            {80, "eighty"},
            {90, "ninety"},
            {100, " hundred "},
            {1000, " thousand "},
            {1000000, " million "},
            {1000000000, " billion "}

        };

        public static Dictionary<int, string> ukrainianDictionary = new Dictionary<int, string>
        {
            {0, "нуль"},
            {1, "один "},
            {2, "два "},
            {3, "три "},
            {4, "чотири "},
            {5, "п'ять "},
            {6, "шiсть "},
            {7, "ciм "},
            {8, "вiсiм "},
            {9, "дев'ять "},
            {10, "десять "},
            {11, "одинадцять "},
            {12, "дванадцять "},
            {13, "тринадцять "},
            {14, "чотирнадцять "},
            {15, "п'ятнадцять "},
            {16, "шiстнадцять "},
            {17, "сiмнадцять "},
            {18, "вiсiмнадцять "},
            {19, "дев'ятнадцять "},
            {20, "двадцять "},
            {30, "тридцять "},
            {40, "сорок "},
            {50, "п'ядесят "},
            {60, "шiстдесят "},
            {70, "сiмдесят "},
            {80, "вiсiмдесят "},
            {90, "дев'яносто "},
            {100, "сто "},
            {200, "двiстi " },
            {300, "триста " },
            {400, "чотириста " },
            {500, "п'ятсот " },
            {600, "шiстсот " },
            {700, "сiмсот " },
            {800, "вiсiмсот " },
            {900, "дев'ятсот " }

        };


        public static Language LanguageCheck()
        {
            while (true)
            {
                Console.WriteLine(
                    $"Choose your language! \nFor ENGLISH please input 1. \nFor UKRAINIAN please input 2.");
                var langChoose = Console.ReadLine();

                switch (langChoose)
                {
                    case "1":
                        Console.WriteLine($"Your language is {Language.English}.");
                        return Language.English;
                    case "2":
                        Console.WriteLine($"Your language is {Language.Ukrainian}.");
                        return Language.Ukrainian;
                    default:
                        Console.WriteLine($"WRONG INPUT! You have to input 1 or 2 for continue! ");
                        break;
                }
            }
        }

        public static string NumberInput(Language language)
        {
            var stringNumber = string.Empty;
            switch (language)
            {
                case Language.English:
                    Console.WriteLine($"Input number for conversion: ");
                    stringNumber = ReadNumberFromConsoleEng();
                    return stringNumber;
                case Language.Ukrainian:
                    Console.WriteLine($"Введiть число для перетворення: ");
                    stringNumber = ReadNumberFromConsoleUa();
                    return stringNumber;
            }

            return stringNumber;
        }

        public static void DividingStringOnPart(string stringNumber, Language lang, out int intPart, out int? decimPart)
        {
            var partHolder = new[]
            {
                string.Empty,
                string.Empty
            };
            intPart = 0;
            decimPart = null;
            if (lang == Language.English)
            {
                partHolder = stringNumber.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                intPart = Convert.ToInt32(partHolder[0]);

                if (partHolder.Length == 1)
                {
                    return;
                }

                if (partHolder[1].Length == 1)
                {
                    decimPart = Convert.ToInt32(partHolder[1]) * 10;
                    return;
                }

                if (partHolder[1].Length == 2)
                {
                    decimPart = Convert.ToInt32(partHolder[1]);
                    return;
                }

                if (partHolder[1].Length > 2)
                {
                    decimPart = Convert.ToInt32(partHolder[1].Substring(0, 2));
                    return;
                }

                return;
            }

            if (lang == Language.Ukrainian)
            {
                partHolder = stringNumber.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                intPart = Convert.ToInt32(partHolder[0]);

                if (partHolder.Length == 1)
                {
                    return;
                }

                if (partHolder[1].Length == 1)
                {
                    decimPart = Convert.ToInt32(partHolder[1]) * 10;
                    return;
                }

                if (partHolder[1].Length == 2)
                {
                    decimPart = Convert.ToInt32(partHolder[1]);
                    return;
                }

                if (partHolder[1].Length > 2)
                {
                    decimPart = Convert.ToInt32(partHolder[1].Substring(0, 2));
                    return;
                }

                return;
            }

            throw new Exception("Error");
        }

        public static string ConvertDollarsNumberToWords(int intPart)
        {
            if (intPart == 0)
                return string.Empty;
            if (intPart < 20)
                return englishDictionary[intPart];
            if (intPart < 100)
                return intPart % 10 == 0
                    ? englishDictionary[intPart]
                    : englishDictionary[intPart / 10 * 10] + "-" + ConvertDollarsNumberToWords(intPart % 10);
            if (intPart < 1000)
                return englishDictionary[intPart / 100] + englishDictionary[100] +
                       ConvertDollarsNumberToWords(intPart % 100);
            if (intPart < 1000000)
                return ConvertDollarsNumberToWords(intPart / 1000) + englishDictionary[1000] +
                       (intPart % 1000 > 0 ? ConvertDollarsNumberToWords(intPart % 1000) : string.Empty);
            if (intPart < 1000000000)
                return ConvertDollarsNumberToWords(intPart / 1000000) + englishDictionary[1000000] +
                       ConvertDollarsNumberToWords(intPart % 1000000);
            if (intPart <= Int32.MaxValue)
                return ConvertDollarsNumberToWords(intPart / 1000000000) + englishDictionary[1000000000] +
                       ConvertDollarsNumberToWords(intPart % 1000000000);

            return string.Empty;
        }
        public static string ConvertGrivnasNumberToWords(int intPart)
        {
            var thousand = string.Empty;
            var million = string.Empty;
            var billion = string.Empty;

            
            if (intPart == 0)
                return string.Empty;
            if (intPart == 1)
                return $"одна ";
            if (intPart == 2)
                return $"двi ";
            if (intPart < 20)
                return ukrainianDictionary[intPart];
            if (intPart < 100)
                return intPart % 10 == 0
                    ? ukrainianDictionary[intPart]
                    : ukrainianDictionary[intPart / 10 * 10] + ConvertGrivnasNumberToWords(intPart % 10);

            if (intPart < 1000)
                return ukrainianDictionary[intPart / 100 * 100] + ConvertGrivnasNumberToWords(intPart % 100);
            if (intPart < 1000000)
            {
             
                if (intPart / 1000 % 10 <= 4 && intPart / 1000 % 10 > 1)
                    thousand = $"тисячi ";
                if (intPart / 1000 % 10 == 1)
                    thousand = $"тисяча ";
                if ((intPart / 1000).ToString().Length >= 2 && intPart / 1000 % 100 > 4 && intPart / 1000 % 100 < 20)
                    thousand = $"тисяч ";
                if ((intPart / 1000).ToString().Length >= 2 && intPart / 1000 % 100 % 10 == 0)
                    thousand = $"тисяч ";


                return ConvertGrivnasNumberToWords(intPart / 1000) + thousand +
                       (intPart % 1000 > 0 ? ConvertGrivnasNumberToWords(intPart % 1000) : string.Empty);
            }

            if (intPart < 1000000000)
            {
                million = $"мiльйонiв ";
                if (intPart / 1000000 % 10 <= 3 && intPart / 1000000 % 10 > 1)
                    million = $"мiльйони ";
                if (intPart / 1000000 % 10 == 1)
                    million = $"мiльйон ";
                
                
                return ConvertGrivnasNumberToWords(intPart / 1000000) + million +
                       ConvertGrivnasNumberToWords(intPart % 1000000);
            }

            if (intPart <= Int32.MaxValue)
            {
                billion = $"мiльярди";
                if (intPart / 1000000000 % 10 == 1)
                    billion = $"мiльярд";
                    return ConvertGrivnasNumberToWords(intPart / 1000000000) + billion +
                           ConvertGrivnasNumberToWords(intPart % 1000000000);
            }

            return string.Empty;
        }

        public static string ConvertCentsNumberToWords(int? centsNumber)
        {
            if (centsNumber < 20)
                return englishDictionary[(int)centsNumber];
            if (centsNumber < 100)
                return centsNumber % 10 == 0
                    ? englishDictionary[(int)centsNumber]
                    : englishDictionary[(int)centsNumber / 10 * 10] + "-" +
                      ConvertCentsNumberToWords(centsNumber % 10);

            return string.Empty;
        }
        public static string ConvertKopiykasNumberToWords(int? kopiykasNumber)
        {
            if (kopiykasNumber == 1)
                return $"одна";
            if (kopiykasNumber == 2)
                return $"двi";
            if (kopiykasNumber < 20)
                return ukrainianDictionary[(int)kopiykasNumber];
            if (kopiykasNumber < 100)
                return kopiykasNumber % 10 == 0
                    ? ukrainianDictionary[(int)kopiykasNumber]
                    : ukrainianDictionary[(int)kopiykasNumber / 10 * 10] +
                      ConvertKopiykasNumberToWords(kopiykasNumber % 10);

            return string.Empty;
        }
        public static string ConvertWholeNumberToWords(int intNumber, int? decimNumber, Language language)
        {
            switch (language)
            {
                case Language.English:
                    if (intNumber == 0 && decimNumber.Equals(null))
                        return string.Empty;
                    if (ConvertDollarsNumberToWords(intNumber).Equals(string.Empty))
                        return decimNumber == 1
                            ? $"{ConvertCentsNumberToWords(decimNumber)} cent"
                            : $"{ConvertCentsNumberToWords(decimNumber)} cents";

                    if (decimNumber.Equals(null))
                        return $"{ConvertDollarsNumberToWords(intNumber)} dollars";

                    if (decimNumber == 1 && intNumber != 1)
                        return
                            $"{ConvertDollarsNumberToWords(intNumber)} dollars and {ConvertCentsNumberToWords(decimNumber)} cent";

                    if (decimNumber == 1 && intNumber == 1)
                        return
                            $"{ConvertDollarsNumberToWords(intNumber)} dollar and {ConvertCentsNumberToWords(decimNumber)} cent";

                    if (intNumber == 1 && decimNumber != 1)
                        return
                            $"{ConvertDollarsNumberToWords(intNumber)} dollar and {ConvertCentsNumberToWords(decimNumber)} cents";

                    return
                        $"{ConvertDollarsNumberToWords(intNumber)} dollars and {ConvertCentsNumberToWords(decimNumber)} cents";
                case Language.Ukrainian:
                    var kopiyka = string.Empty;
                    var grivnya = string.Empty;

                    switch (intNumber % 10)
                    {
                        case 1:
                            grivnya = $"гривня";
                            break;;
                        case 2:
                            grivnya = $"гривнi";
                            break;
                        case 3:
                            grivnya = $"гривнi";
                            break;
                        case 4:
                            grivnya = $"гривнi";
                            break;

                        default:
                            grivnya = $"гривень";
                            break;
                    }

                    if (intNumber % 100 > 5 && intNumber % 100 < 20)
                        grivnya = $"гривень";

                    switch (decimNumber)
                    {
                        case 1:
                            kopiyka = $"копiйка";
                            break; ;
                        case 2:
                            kopiyka = $"копiйки";
                            break;
                        case 3:
                            kopiyka = $"копiйки";
                            break;
                        case 4:
                            kopiyka = $"копiйки";
                            break;
                            
                        default:
                            kopiyka = $"копiйок";
                            break;
                    }
                    if (intNumber == 0 && decimNumber.Equals(null))
                        return string.Empty;
                    if (ConvertGrivnasNumberToWords(intNumber).Equals(string.Empty))
                        return $"{ConvertKopiykasNumberToWords(decimNumber)} {kopiyka}";
                    
                    
                    if (decimNumber.Equals(null))
                        return $"{ConvertGrivnasNumberToWords(intNumber)} {grivnya}";

                    if (decimNumber == 1 && intNumber != 1)
                        return
                            $"{ConvertGrivnasNumberToWords(intNumber)} {grivnya} {ConvertKopiykasNumberToWords(decimNumber)} {kopiyka}";

                    if (decimNumber == 1 && intNumber == 1)
                        return
                            $"{ConvertGrivnasNumberToWords(intNumber)} {grivnya} {ConvertKopiykasNumberToWords(decimNumber)} {kopiyka}";

                    if (intNumber == 1 && decimNumber != 1)
                        return
                            $"{ConvertGrivnasNumberToWords(intNumber)} {grivnya} {ConvertKopiykasNumberToWords(decimNumber)} {kopiyka}";

                    return
                        $"{ConvertGrivnasNumberToWords(intNumber)} {grivnya} {ConvertKopiykasNumberToWords(decimNumber)} {kopiyka}";
            }

            return string.Empty;

        }

        public static string ReadNumberFromConsoleEng()
        {
            var result = string.Empty;
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (result.Length > 0)
                        {
                            result = result.Remove(result.Length - 1, 1);
                            Console.Write(key.KeyChar + " " + key.KeyChar);
                        }

                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return result;
                    default:
                        if (char.IsDigit(key.KeyChar) || key.KeyChar.Equals('.'))
                        {
                            Console.Write(key.KeyChar);
                            result += key.KeyChar;
                        }

                        break;
                }
            }
        }

        public static string ReadNumberFromConsoleUa()
        {
            var result = string.Empty;
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (result.Length > 0)
                        {
                            result = result.Remove(result.Length - 1, 1);
                            Console.Write(key.KeyChar + " " + key.KeyChar);
                        }

                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return result;
                    default:
                        if (char.IsDigit(key.KeyChar) || key.KeyChar.Equals(','))
                        {
                            Console.Write(key.KeyChar);
                            result += key.KeyChar;
                        }

                        break;
                }
            }
        }
    }
}

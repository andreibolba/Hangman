using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hangman.Tools
{
    public class Tool
    {
        public static List<string> readWords(string fileName)
        {
            string file= @"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Words\"+fileName;
            string[] lines = System.IO.File.ReadAllLines(file);
            List<string> words = new List<string>();
            foreach (string line in lines)
                words.Add(line);
            return words;
        }

        public static string getTextFirstTime(string text)
        {
            string newText = null;
            if (text == null)
                return null;
            foreach (char word in text)
            {
                if (word == ' ')
                    newText=newText+ word;
                else
                    newText += "-";
            }
            return newText;
        }

        public static string getWord(List<string> words)
        {
            Random random = new Random();
            int index=random.Next(words.Count);
            return words[index].ToUpper();
        }

        public static string oneLetterTry(string lines,string text,string letter)
        {
            string newText = null;
            for (int i = 0; i < text.Length; i++)
                if (text[i].ToString() == letter)
                    newText += letter;
                else if (text[i].ToString() == " ")
                    newText += " ";
                else if (lines[i] >= 'A' && lines[i] <= 'Z')
                    newText += lines[i];
                else
                    newText += "-";
            return newText;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static List<string> images()
        {
            List<string> photos = new List<string>();
            photos.Add("./image/stage/part_one.png");
            photos.Add("./image/stage/life_one.png");
            photos.Add("./image/stage/life_two.png");
            photos.Add("./image/stage/life_three.png");
            photos.Add("./image/stage/life_four.png");
            photos.Add("./image/stage/life_five.png");
            photos.Add("./image/stage/life_six.png");
            photos.Add("./image/stage/gameover.png");

            return photos;
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

        public static string oneLetterTry(string lines,string text,string letter, ref bool hasChanged)
        {
            string newText = null;
            for (int i = 0; i < text.Length; i++)
                if (text[i].ToString() == letter)
                {
                    newText += letter;
                    hasChanged = true;
                }
                else if (text[i].ToString() == " ")
                    newText += " ";
                else if (lines[i] >= 'A' && lines[i] <= 'Z')
                    newText += lines[i];
                else
                    newText += "-";
            return newText;
        }

        public static List<Users> readUsers()
        {
            StreamReader r = new StreamReader(@"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Files\users.json");
            string jsonString = r.ReadToEnd();
            List<Users> users = new List<Users>();
            users = JsonConvert.DeserializeObject<List<Users>>(jsonString);
            return users;
        }

        public static string getPath(List<Users> users, string id)
        {
            foreach (Users user in users)
                if (user.ID == id)
                    return user.PicPath;
            return null;
        }
    }
}

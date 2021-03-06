using Hangman.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hangman.Model
{
    public class Tool
    {
        public static List<User> users;
        public static List<Game> games = readGames();

        public static string getStartWord(string fileName)
        {
            string file = @"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Words\" + fileName;
            string[] lines = System.IO.File.ReadAllLines(file);
            List<string> words = new List<string>();
            foreach (string line in lines)
                words.Add(line);
            Random random = new Random();
            int index = random.Next(words.Count);
            return words[index].ToUpper();
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

        public static ObservableCollection<string> progressPic()
        {
            ObservableCollection<string> photos = new ObservableCollection<string>();
            photos.Add("./image/lock.png");
            photos.Add("./image/lock.png");
            photos.Add("./image/lock.png");
            photos.Add("./image/lock.png");
            photos.Add("./image/lock.png");

            return photos;
        }

        public static List<string> profileImages()
        {
            List<string> photos = new List<string>();
            photos.Add("./image/users/userimg1.png");
            photos.Add("./image/users/userimg2.png");
            photos.Add("./image/users/userimag3.jpg");
            photos.Add("./image/users/userimg4.png");
            photos.Add("./image/users/userimg5.png");

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

        public static List<User> readUsers()
        {
            StreamReader r = new StreamReader(@"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Files\users.json");
            string jsonString = r.ReadToEnd();
            users = new List<User>();
            users = JsonConvert.DeserializeObject<List<User>>(jsonString);
            return users;
        }

        public static void addUser(User user)
        {
            users.Add(user);
            string json = JsonConvert.SerializeObject(users.ToArray());
            System.IO.File.WriteAllText(@"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Files\users.json", json);
        }

        public static void update(User user)
        {
            for(int index=0;index<users.Count();index++)
                if(users[index].ID==user.ID)
                {
                    users[index] = user;
                    break;
                }
            string json = JsonConvert.SerializeObject(users.ToArray());
            System.IO.File.WriteAllText(@"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Files\users.json", json);
        }

        public static string getPath(List<User> users, int id)
        {
            foreach (User user in users)
                if (user.ID == id)
                    return user.PicPath;
            return null;
        }

        public static string getProfilePath(string path)
        {
            int slesh = 3,index=path.Length-1;
            string newPath = null;
            while(index>=0&&slesh!=0)
            {
                if (path[index] == '/')
                    slesh--;
                index--;
            }
            newPath = path.Substring(index+1);
            newPath = "." + newPath;
            return newPath;
        }

        public static int getId()
        {
            if (users.Count == 0)
                return 0;
            int index=users.Count-1;
            int id = users[index].ID;
            return ++id;
        }

        public static int getIdGame()
        {
            if (games.Count == 0)
                return 0;
            int index = games.Count - 1;
            int id = games[index].Id;
            return ++id;
        }

        public static User getUser(int id)
        {
            foreach (User user in users)
                if (user.ID == id)
                    return user;
            return new User();
        }

        public static User getUserByUsername(string username)
        {
            foreach (User user in users)
                if (user.UserName == username)
                    return user;
            return new User();
        }

        public static void deleteUser(User user)
        {
            users.Remove(user);
            string json = JsonConvert.SerializeObject(users.ToArray());
            System.IO.File.WriteAllText(@"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Files\users.json", json);
            List<Game> newGames=new List<Game>();
            foreach (Game game in games)
                if (game.UserId != user.ID)
                    newGames.Add(game);
            games.Clear();
            games=newGames;
            json = JsonConvert.SerializeObject(games.ToArray());
            System.IO.File.WriteAllText(@"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Files\games.json", json);
        }

        public static ObservableCollection<string> getUsernames()
        {
            readUsers();
            ObservableCollection<string> usernames=new ObservableCollection<string>();
            foreach(User user in users)
                usernames.Add(user.UserName);
            return usernames;

        }

        public static bool isUsernameValid(string username)
        {
            foreach(User user in users)
                if(user.UserName==username)
                    return false;
            return true;
        }

        public static List<Game> readGames()
        {
            StreamReader r = new StreamReader(@"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Files\games.json");
            string jsonString = r.ReadToEnd();
            games = new List<Game>();
            games = JsonConvert.DeserializeObject<List<Game>>(jsonString);
            return games;
        }
        
        public static void addGame(Game game)
        {
            games.Add(game);
            string json = JsonConvert.SerializeObject(games.ToArray());
            System.IO.File.WriteAllText(@"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Files\games.json", json);
        }

        public static void deleteGame(Game game)
        {
            games.Remove(game);
            string json = JsonConvert.SerializeObject(games.ToArray());
            System.IO.File.WriteAllText(@"J:\FMI-AnII\Semestrul_2\MVP\Hangman\Hangman\Files\games.json", json);
        }

        public static ObservableCollection<Game> getGames(int id)
        {
            ObservableCollection<Game> savedGames = new ObservableCollection<Game>();
            foreach(Game game in games)
                if(game.UserId==id)
                    savedGames.Add(game);
            return savedGames;
        }

        public static Game getGame(int id)
        {
            foreach(Game game in games)
                if(game.Id==id)
                    return game;
            return null;
        }
    }
}

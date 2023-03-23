using System;

namespace LegacyApp.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            AddUser(args);
        }

        public static void AddUser(string[] args)
        {
            // DO NOT CHANGE THIS FILE AT ALL
            
            var userService = new UserService();
            var addResult = userService.AddUser("Pooya", "Alamirpour", "P.Alamirpour@gmail.com", new DateTime(1986, 10, 20), 4);
            Console.WriteLine("Adding Pooya Alamirpour was " + (addResult ? "successful" : "unsuccessful"));
        }
    }
}
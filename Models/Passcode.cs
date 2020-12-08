using System;

namespace RandomPasscode.Models
{
    public class Passcode
    {
        public static Random rand = new Random();

        public static string Main = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public string CodePass;

        public Passcode()
        {
            for (int i = 0; i < 11; i++)
            {
                char r = Main[rand.Next(0, Main.Length)];
                CodePass += r;
            }
            
        }
    }
}
using System;
using System.Timers;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;

namespace testic
{
    internal class Program
    {

        

            
        
        static void Main()
        {
            string text = "Сегодняшний день начался с утренней пробежки по парку, где встретил много знакомых лиц. Погода была прохладной, но солнечной, и это добавило мне энергии" +
                     " на весь день. После тренировки я пошел в кафе, чтобы выпить кофе и почитать газету. Затем отправился на работу, где меня ожидало много дел. Но я справился со" +
                     " всеми задачами и даже уложился в сроки. Вечером я встретился с друзьями в ресторане, где мы провели отлично время, обсуждая последние новости и планируя " +
                     "будущие поездки. В целом, день был насыщенным и интересным.";
            int mistakes = 0;
            int count = 0;
            int len = 0;
            int time = 59;
            int pos = 0;
            int pos2 = 0;
            List<Records> chel = new List<Records>();


            Console.WriteLine("Добро пожаловать в тест на скорость печатания: 'Быстрые пальчики залог успеха'. " +
                "\nПеред началом теста введите свое имя (либо ник) для таблицы лидеров.");
            string name = Console.ReadLine();
           
            Console.WriteLine("Нажмите Enter для начала теста. " +
                "После того как вы нажмете Enter таймер сразу запуститься!!!");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Thread txt = new Thread(_ =>
                {
                    while (time > 0)
                    {
                        Console.SetCursorPosition(0, 16);
                        Console.WriteLine("00:" + time--);
                        Console.ResetColor();


                        Thread.Sleep(1000);
                    }

                });





                Console.SetCursorPosition(0, 7);
                Console.WriteLine(text);

                txt.Start();

                while (len < text.Length && time > 0)
                {

                    char c = Console.ReadKey(true).KeyChar;


                    if (c == text[len])
                    {

                        len++;
                        pos2++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(pos2, pos);
                        if (pos2 >= 118)
                        {
                            pos2 = 0;
                            pos = pos + 1;
                        }
                        else
                        {
                            len = len;
                        }
                        Console.Write(c);

                    }
                    else
                    {
                        mistakes++;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                }
            }
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("Поздравляем вы закончили тест.");
            Console.WriteLine("Ваше имя(ник): " +  name);
            Console.WriteLine("Ваша скорость печати: " + len + " сим/мин");
            Records newchel = new Records();
            newchel.name = name;
            newchel.record = len;
            chel.Add(newchel);

            string json = JsonConvert.SerializeObject(newchel);
            File.WriteAllText("D:\\CHEL.json", json);
            Console.WriteLine("Нажмите Enter, чтобы продолжить.");
            Console.ReadLine();
            

            Console.Clear();

        }
    }
}

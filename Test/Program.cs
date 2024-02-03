using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp74
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Post post1 = new Post();

            post1.NumViews = Input("Введите количество просмотров на посте");
            post1.NumComments = Input("Введите количество комментариев на посте");
            post1.NumReactions = Input("Введите количество реакций на посте"); 

            Post post2 = new Post(200, 30, 15);

            Post post3 = new Post(post1);

            post1.Show();
            Console.WriteLine();

            post2.Show();
            Console.WriteLine();

            post3.Show();
            Console.WriteLine();

            int subscribers = 1000;
            double engagement1 = Post.Engagement(post1, subscribers);
            double engagement2 = post2.Engagement(subscribers);
            Console.WriteLine("Вовлеченность подписчиков (Static): " + engagement1);
            Console.WriteLine("Вовлеченность подписчиков (Non-static): " + engagement2);
        }
        static double Input(string mes = "")
        {
            Console.WriteLine(mes);
            double parametr;
            bool Ok;
            do
            {
                string buf = Console.ReadLine();
                Ok = double.TryParse(buf, out parametr);
                if ((!Ok) || (parametr < 0))
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
                }
            } while (!Ok);
            return parametr;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp74
{
    internal class laba9
    {
        static void Main(string[] args)
        {
            int subscribers = 1000;

            Post post1 = new Post();
            Random random = new Random();
            post1.NumViews = Input("Количество просмотров на посте: ");
            post1.NumComments = Input("Количество комментариев на посте: ");
            post1.NumReactions = Input("Количество реакций на посте: "); 

            Post post2 = new Post(random.Next(0, 100), random.Next(0, 100), random.Next(0, 100));

            Post post3 = new Post(post1);

            post1.Show();
            double engagement1 = Post.Engagement(post1, subscribers);
            Console.WriteLine("Вовлеченность подписчиков (Static): " + engagement1);
            Console.WriteLine();

            post2.Show();
            double engagement2 = post2.Engagement(subscribers);
            Console.WriteLine("Вовлеченность подписчиков (Non-static): " + engagement2);
            Console.WriteLine();

            post3.Show();
            double engagement3 = Post.Engagement(post3, subscribers);
            Console.WriteLine("Вовлеченность подписчиков (Static): " + engagement3);
            Console.WriteLine();

            Console.WriteLine("----------------РАБОТА С ОПЕРАЦИЯМИ------------------");
            Console.WriteLine();
            Console.WriteLine("_____Использование унарной операции \"!\"_____");
            // Префиксные инкременты
            post1.Show();
            Post post4 = !post1;
            Console.WriteLine("После увеличения количества реакций на единицу при помощи унарной операции: ");
            post4.Show();
            Console.WriteLine();

            Console.WriteLine("_____Использование унарной операции \"++\"_____");
            //Постфиксные инкременты
            post4 = post1++;
            Console.WriteLine("После увеличения количества просмотров на единицу при помощи унарной операции: ");
            post1.Show();
            post4.Show();
            Console.WriteLine();

            // Префиксные инкременты
            post4 = ++post1;
            Console.WriteLine("После увеличения количества просмотров на единицу при помощи унарной операции: ");
            post1.Show();
            post4.Show();
            Console.WriteLine();

            Console.WriteLine("_____Использование операции явного приведения типа \"bool\"_____");
            bool result = (bool)post2;
            if (result == true) Console.WriteLine($"{result} - у поста есть хотя бы один комментарий или одна реакция при ненулевом количестве просмотров");
            else Console.WriteLine($"{result} - у поста нет просмотров, или нет хотя бы одного комментария или реакции");
            Console.WriteLine();

            Console.WriteLine("_____Использование операции неявного приведения типа \"double\"_____");
            double sweep = post2;
            Console.WriteLine($"{sweep}% - процент охвата");
            Console.WriteLine();

            Console.WriteLine("_____Использование бинарной операции \"==\"_____");
            bool result1 = post1 == post2;
            if (result1 == true) Console.WriteLine($"{result1} - оба поста имеют одинаковые показатели");
            else Console.WriteLine($"{result1} - хотя бы один показатель постов отличается");
            Console.WriteLine();

            Console.WriteLine("_____Использование бинарной операции \"!=\"_____");
            bool result2 = post1 != post2;
            if (result2 == true) Console.WriteLine($"{result2} - хотя бы один показатель постов отличается");
            else Console.WriteLine($"{result2} - оба поста имеют одинаковые показатели");
            Console.WriteLine();

            Console.WriteLine($"Количество созданных объектов при работе с классом: {Post.GetCount}");

            Console.WriteLine();

            Console.WriteLine("-----------------РАБОТА С КОЛЛЕКЦИЯМИ ----------------");
            Console.WriteLine();
            Console.WriteLine("_____Создание коллекции при помощи ДСЧ_____");
            PostArray n1 = new PostArray(3);
            n1.Show();
            Console.WriteLine();

            Console.WriteLine("_____Создание коллекции при помощи ввода_____");

            int Length;
            Console.WriteLine("Введите длину массива: ");
            bool isConvert = int.TryParse(Console.ReadLine(), out Length);
            if (!isConvert)
                Console.WriteLine("Неверный формат числа");
            double[] numViews = NumViews(Length);
            double[] numComments = NumComments(Length);
            double[] numReactions = NumReactions(Length);
            PostArray n2 = new PostArray(Length, numViews, numComments, numReactions);
            Console.WriteLine("Полученный массив: ");
            n2.Show();
            Console.WriteLine();

            Console.WriteLine("_____Создание коллекции при помощи глубоко копирования_____");
            PostArray n3 = new PostArray(n2);
            n3.Show();
            Console.WriteLine();

            Console.WriteLine("____Изменение элемента при помощи индекса в коллекции ДСЧ___ (set)");
            n1[0] = new Post(100, 100, 100);
            n1.Show();
            Console.WriteLine();
            Console.WriteLine("Проверка сохранности второго массива:");
            n2.Show() ;
            Console.WriteLine();

            Console.WriteLine("____Изменение элемента при помощи индекса в коллекции ДСЧ___ (get)");
            n1[0] = new Post(100, 100, 100);
            Console.WriteLine($"Измененный эллемент для поста: {n1[0]}");
            Console.WriteLine();
            Console.WriteLine("Проверка сохранности второго массива:");
            n2.Show();
            Console.WriteLine();

            Console.WriteLine("Изменение несуществующего элемента при помощи индекса: (set)");
            try 
            {
                n2[100] = new Post(100, 100, 100);
                n2.Show() ;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine();

            Console.WriteLine("Изменение несуществующего элемента при помощи индекса: (get)");
            try
            {
                n2[100] = new Post(100, 100, 100);
                Console.WriteLine(n2[100]);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.WriteLine();

            Console.WriteLine("--------- ОБЩИЙ КОЭФФИЦИЕНТ ВОВЛЕЧЕННОСТИ ------------");
            double engagementRate = EngagementRate(n1, 1000);
            Console.WriteLine($"Коэффициент вовлеченности: {engagementRate}");
            Console.WriteLine();
            Console.WriteLine($"Количество созданных объектов при работе с коллекциями: {PostArray.GetCount}");
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
            } while (!Ok);
            return parametr;
        }

        public static double EngagementRate(PostArray post, double numSubscribers)
        {
            double engagement = 0;

            for (int i = 0; i < post.Length; i++)
            {
                engagement += (post[i].NumViews + post[i].NumReactions + post[i].NumComments) / numSubscribers * 100;
            }

            return engagement;
        }
        /// <summary>
        /// Функции ввода 
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        static double[] NumViews(int Length)
        {
            double [] numViews = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine($"Введите количество просмотров на посте {i + 1}");
                numViews[i] = double.Parse(Console.ReadLine());
            }
            return numViews;
        }
        static double[] NumComments(int Length)
        {
            double[] numComments = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine($"Введите количество комментариев на посте {i + 1}");
                numComments[i] = double.Parse(Console.ReadLine());
            }
            return numComments;
        }
        static double[] NumReactions(int Length)
        {
            double[] numReactions = new double[Length];
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine($"Введите количество реакций на посте {i + 1}");
                numReactions[i] = double.Parse(Console.ReadLine());
            }
            return numReactions;
        }
    }
}

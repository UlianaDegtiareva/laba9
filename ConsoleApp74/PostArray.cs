using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp74
{
    public class PostArray
    {
        public Post[] network = null;
        static int countarr = 0;
        private static Random random = new Random();
        public int Length
        {         get => network.Length;
     
        }
        public PostArray(int size) 
        {
            network = new Post[size]; // Создаем массив указанного размера
            for (int i = 0; i < size; i++) 
            {
                Post post = new Post(random.Next(0,100), random.Next(0,100), random.Next(0,100));
                network[i] = post; // Добавляем созданный объект в массив
            }
            countarr++;
        }
        public PostArray()
        {
            network = new Post[0]; // Создаем пустой массив
        }
        public PostArray(PostArray other)
        {
            network = new Post[other.Length]; // Создаем массив с размером, равным длине переданного объекта класса PostArray
            for (int i = 0; i < other.Length; i++)
            {
                network[i] = new Post(other.network[i]); // Создаем копию каждого объекта класса Post и добавляем его в массив
            }
            countarr++;
        }
        public PostArray(int Length, double[] numViews, double[] numComments, double[] numReactions)
        {
            network = new Post[Length];
            for (int i = 0; i < Length; i++)
            {
                network[i] = new Post(numViews[i], numComments[i], numReactions[i]);
            }
            countarr++;
        }
        public void Show()
        {
            foreach (Post post in network)
            {
                Console.WriteLine($"{post.NumViews} просмотров. {post.NumComments} комментариев. {post.NumReactions} реакций.");
            }
        }
        public Post this[int index]
        { 
            get 
            {
                if (0 <= index && index < network.Length)
                    return network[index];
                else throw new Exception("Индекс выходит за пределы коллекции");
            }
            set 
            {
                if (0 <= index && index < network.Length)
                    network[index] = value;
                else Console.WriteLine("Индекс выходит за пределы коллекции");
            }
        }
        public static int GetCount => countarr;
    }
}

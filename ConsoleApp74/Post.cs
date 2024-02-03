using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp74
{
    public class Post
    {
        private double numViews;
        private double numComments;
        private double numReactions;
        static int count;
        public double NumViews
        { 
            get { return numViews; }
            set 
            {
                if (value < 0)
                {
                    Console.WriteLine("Error!");
                    numViews = 0;
                }
                else numViews = value;
            }
        }
        public double NumComments
        {
            get { return numComments; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error!");
                    numComments = 0;
                }
                else numComments = value;
            }
        }
        public double NumReactions
        {
            get { return numReactions; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Error!");
                    numReactions = 0;
                }
                else numReactions = value;
            }
        }
        public Post() 
        {
            NumViews = 100;
            NumComments = 94;
            NumReactions = 100;
            count++;
        }
        public Post(double numViews, double numComments, double numReactions)
        {
            NumViews = numViews;
            NumComments = numComments;
            NumReactions = numReactions;

            count++;
        }
        public Post(Post post)
        {
            NumViews = post.numViews;
            NumComments = post.numComments;
            NumReactions = post.numReactions;
            count++;
        }
        public void Show()
        {
            Console.WriteLine($"{NumViews} просмотров. {NumComments} комментариев. {NumReactions} реакций.");
        }
        public override string ToString()
        {
            return $"{NumViews} просмотров. {NumComments} комментариев. {NumReactions} реакций.";
        }
        public static double Engagement(Post post, int subscribers)
        {
            double engagement = (post.numViews + post.numComments + post.numReactions) / subscribers * 100;
            if (engagement > 100)
            {
                engagement = 100;
            }
            else return Math.Round(engagement, 2);
            return engagement;
        }
        public double Engagement(int subscribers)
        {
            double engagement = (numViews + numComments + numReactions) / subscribers * 100;
            if (engagement > 100)
            {
                engagement = 100;
            }
            else return Math.Round(engagement, 2);
            return engagement;
        }
        public static Post operator !(Post post)
        {
            Post result = new Post(post);
            result.NumReactions = result.NumReactions + 1;
            return result;
        }
        public static Post operator ++(Post post)
        {
            Post result = new Post(post);
            result.NumViews = result.NumViews + 1;
            return result;
        }
        public static explicit operator bool(Post post)
        {
            return (post.NumComments > 0 || post.NumReactions > 0) && post.NumViews != 0;
        }
        public static implicit operator double(Post post)
        {
            int subscribers = 1000;
            double sweep = (post.NumViews / subscribers) * 100;
            return Math.Round(sweep, 2);
        }
        public static bool operator ==(Post post1, Post post2)
        {
            return post1.Equals(post2);
        }
        public static bool operator !=(Post post1, Post post2)
        {
            return !post1.Equals(post2);
        }
        public static int GetCount => count;

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Post otherPost = (Post)obj;

            return NumViews.Equals(otherPost.NumViews) &&
                   NumComments.Equals(otherPost.NumComments) &&
                   NumReactions.Equals(otherPost.NumReactions);
        }
    }
}

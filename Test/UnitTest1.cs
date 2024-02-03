using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp74;
using System.IO;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Post expected = new Post(100, 300, 35);
            //Act
            Post actual = new Post(100, 300, 35);
            //Assert
            Assert.AreEqual(expected.NumComments, actual.NumComments);
            Assert.AreEqual(expected.NumViews, actual.NumViews);
            Assert.AreEqual(expected.NumReactions, actual.NumReactions);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            Post expected = new Post(0, 0, 0);
            //Act
            Post actual = new Post(-1,-1,-1);
            //Assert
            Assert.AreEqual(expected.NumComments, actual.NumComments);
            Assert.AreEqual(expected.NumViews, actual.NumViews);
            Assert.AreEqual(expected.NumReactions, actual.NumReactions);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            Post expected = new Post(100,100,100);
            //Act
            Post actual = new Post(expected);
            //Assert
            Assert.AreEqual(expected.NumComments, actual.NumComments);
            Assert.AreEqual(expected.NumViews, actual.NumViews);
            Assert.AreEqual(expected.NumReactions, actual.NumReactions);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            Post expected = new Post(100, 100, 100);
            int subscribers = 1000;
            //Act
            double engagement = Post.Engagement(expected, subscribers);
            //Assert
            Assert.AreEqual(30, engagement);
        }
        [TestMethod]
        public void TestMethod5()
        {
            //Arrange
            Post expected = new Post(100, 100, 100);
            int subscribers = 1000;
            //Act
            double engagement = expected.Engagement(subscribers);
            //Assert
            Assert.AreEqual(30, engagement);
        }
        [TestMethod]
        public void TestMethod6()
        {
            //Arrange
            Post expected = new Post();
            //Act
            Post actual = new Post();
            //Assert
            Assert.AreEqual(expected.NumComments, actual.NumComments);
            Assert.AreEqual(expected.NumViews, actual.NumViews);
            Assert.AreEqual(expected.NumReactions, actual.NumReactions);
        }
        [TestMethod]
        public void TestMethod7() 
        {
            // Arrange
            Post post = new Post();
            // Act
            Post result = !post;
            // Assert
            Assert.AreEqual(post.NumReactions + 1, result.NumReactions);
        }
        [TestMethod]
        public void TestMethod8() 
        {
            // Arrange
            Post post = new Post();
            // Act
            Post result = new Post(post);
            result++;
            // Assert
            Assert.AreEqual(post.NumViews + 1, result.NumViews);
        }
        [TestMethod]
        public void TestMethod9() 
        {
            // Arrange
            Post post = new Post
            {
                NumComments = 1,
                NumReactions = 1,
                NumViews = 1
            };
            // Act
            bool result = (bool)post;
            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMethod10() 
        {
            // Arrange
            Post post = new Post(0, 0, 0);
            // Act
            bool result = (bool)post;
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestMethod11() 
        {
            // Arrange
            Post post1 = new Post
            {
                NumViews = 100,
                NumComments = 50,
                NumReactions = 20
            };
            Post post2 = new Post
            {
                NumViews = 100,
                NumComments = 50,
                NumReactions = 20
            };
            // Act
            bool result = post1.Equals(post2);
            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMethod12() 
        {
            // Arrange
            Post post1 = new Post
            {
                NumViews = 100,
                NumComments = 50,
                NumReactions = 20
            };
            Post post2 = new Post
            {
                NumViews = 200,
                NumComments = 50,
                NumReactions = 20
            };
            // Act
            bool result = post1.Equals(post2);
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestMethod13() 
        {
            // Arrange
            Post post = new Post { NumViews = 500 };
            // Act
            double sweep = post;
            // Assert
            Assert.AreEqual(50.0, sweep);
        }
        [TestMethod]
        public void TestMethod14() 
        {
            // Arrange
            Post post1 = new Post { NumViews = 100 };
            Post post2 = new Post { NumViews = 100 };
            // Act
            bool result = post1 == post2;
            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMethod15() 
        {
            // Arrange
            Post post1 = new Post { NumViews = 100 };
            Post post2 = new Post { NumViews = 200 };
            // Act
            bool result = post1 == post2;
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestMethod16() 
        {
            // Arrange
            Post post1 = new Post { NumViews = 100 };
            Post post2 = new Post { NumViews = 200 };
            // Act
            bool result = post1 != post2;
            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMethod17() 
        {
            // Arrange
            Post post1 = new Post { NumViews = 100 };
            Post post2 = new Post { NumViews = 100 };
            // Act
            bool result = post1 != post2;
            // Assert
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestMethod18() 
        {
            // Arrange
            int size = 5;

            // Act
            PostArray postArray = new PostArray(size);

            // Assert
            Assert.AreEqual(size, postArray.Length);
            for (int i = 0; i < postArray.Length; i++)
            {
                Post post = postArray[i];
                Assert.IsNotNull(post); // Проверяем, что каждый объект в массиве не является null
            }
        }
        [TestMethod]
        public void TestMethod19()
        {
            // Arrange & Act
            PostArray postArray = new PostArray();

            // Assert
            Assert.AreEqual(0, postArray.Length);
        }
        [TestMethod]
        public void TestMethod20()
        {
            // Arrange
            PostArray postArray = new PostArray(3);
            postArray[0] = new Post(10, 20, 30);
            postArray[1] = new Post(40, 50, 60);
            postArray[2] = new Post(70, 80, 90);

            // Act
            PostArray copiedArray = new PostArray(postArray);

            // Assert
            Assert.AreEqual(postArray.Length, copiedArray.Length);
            for (int i = 0; i < postArray.Length; i++)
            {
                Assert.AreNotSame(postArray[i], copiedArray[i]); // Проверяем, что каждый объект в массиве - глубокая копия
                Assert.AreEqual(postArray[i], copiedArray[i]); // Проверяем, что свойства каждого объекта совпадают
            }
        }
        [TestMethod]
        public void TestMethod21() 
        {
            // Arrange
            PostArray postArray = new PostArray(5);
            postArray.network[0] = new Post(10, 5, 2);

            // Act
            Post post = postArray[0];

            // Assert
            Assert.IsNotNull(post);
            Assert.AreEqual(10, post.NumViews);
            Assert.AreEqual(5, post.NumComments);
            Assert.AreEqual(2, post.NumReactions);
        }
        [TestMethod]
        public void TestMethod22() 
        {
            // Arrange
            PostArray postArray = new PostArray(3);
            Post post = new Post(10, 5, 2);

            // Act
            postArray[0] = post;

            // Assert
            Assert.AreEqual(post, postArray.network[0]);
        }
        [TestMethod]
        public void TestMethod23() 
        {
            // Arrange
            PostArray postArray = new PostArray(3);
            // Act
            try
            {
                Post post = postArray[100];
            }
            catch (Exception ex) 
            {
                Assert.AreEqual("Индекс выходит за пределы коллекции", ex.Message);
            }
        }
        [TestMethod]
        public void TestMethod24()
        {
            // Arrange
            PostArray postArray = new PostArray(3);
            // Act
            try
            {
                Post post = postArray[-10];
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Индекс выходит за пределы коллекции", ex.Message);
            }
        }
        [TestMethod]
        public void TestMethod25()
        {
            // Arrange
            int length = 3;
            double[] numViews = { 1000, 2000, 3000 };
            double[] numComments = { 50, 100, 150 };
            double[] numReactions = { 10, 20, 30 };
            // Act
            PostArray postArray = new PostArray(length, numViews, numComments, numReactions);
            // Assert
            Assert.AreEqual(length, postArray.network.Length);
            for (int i = 0; i < length; i++)
            {
                Assert.AreEqual(numViews[i], postArray.network[i].NumViews);
                Assert.AreEqual(numComments[i], postArray.network[i].NumComments);
                Assert.AreEqual(numReactions[i], postArray.network[i].NumReactions);
            }
        }
    }
}

using NUnit.Framework;
using ClassLib.Subscribes;
using ClassLib.Timer;
using System.Linq;
using System.Collections.Generic;
using Test.Utils;


namespace UTest
{
    public class Tests
    {
        private List<ISubscriber> subs;
        private ConsoleReader reader;

        [SetUp]
        public void Setup()
        {
            reader = new ConsoleReader();
            subs = new List<ISubscriber>
            {
                new User("kate"),
                new User("tom"),
                new Admin("mary")
            };

        }

        [Test]
        public void TimerConstructor()
        {
            var publisher = new CountDown(subs);
            Assert.AreEqual(subs.Count, publisher.Subscribers.Count);
        }

        [Test]
        public void TestAddSubscriber()
        {
            var countDown = new CountDown();
            for (int i = 0; i < subs.Count; i++)
            {
                countDown.AddSubscriber(subs[i]);
                Assert.AreEqual(i + 1, countDown.Subscribers.Count);
            }
        }

        [Test]
        public void TestRemoveSubscriber()
        {
            var countDown = new CountDown(subs);

            for (int i = subs.Count - 1; i >= 0; i--)
            {
                countDown.DeleteSubscriber(subs[i]);
                Assert.AreEqual(i, countDown.Subscribers.Count);
            }
        }

        [Test]
        public void TestNotificationSub()
        {
            var countDown = new CountDown(subs);
            string message = new string("Hi!");
            string expectedOutput = string.Join("\r\n", subs.Select(sub => $"{sub} получил сообщение \"{message}\""));
            expectedOutput += "\r\n";
            countDown.NotificationSub(message);
            string output = reader.GetOutput();
            Assert.AreEqual(expectedOutput, output);
        }

    }
}
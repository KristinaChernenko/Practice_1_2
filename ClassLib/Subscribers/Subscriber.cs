using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Subscribes
{
    public interface ISubscriber
    {
        string ToString();
        void GetMessage(string state);
    }

    public class Admin : ISubscriber
    {
        private readonly string _nickname;
        public string name => $"Администратор {_nickname}";

        public Admin(string nickname)
        {
            _nickname = nickname;
        }

        public override string ToString()
        {
            return name;
        }

        public void GetMessage(string message)
        {
            Console.WriteLine(name + $" получил сообщение \"{message}\"");
        }
    }

    public class User : ISubscriber
    {
        private readonly string _nickname;
        public string name => $"Пользователь {_nickname}";

        public User(string nickname)
        {
            _nickname = nickname;
        }

        public override string ToString()
        {
            return name;
        }

        public void GetMessage(string message)
        {
            Console.WriteLine(name + $" получил сообщение \"{message}\"");
        }
    }
}

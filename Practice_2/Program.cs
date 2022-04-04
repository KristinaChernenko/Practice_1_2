using ClassLib.Subscribes;
using ClassLib.Timer;

public class Program
{
    public static void Main(string[] args)
    {
        List<ISubscriber> subs = new List<ISubscriber>();
        ITimer timer = new CountDown();

        string str = "Меню \n" +
                        "1 - Добавить пользователя \n" +
                        "2 - Добавить администратора \n" +
                        "3 - Удалить подписчика \n" +
                        "4 - Оповещение подписчиков \n" +
                        "0 - Выход из программы";

        ISubscriber subscriber;
        string nick, subsList;
        double timeout;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(str);

            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    Console.Clear();
                    Console.Write("Введите имя пользователя: ");
                    nick = Console.ReadLine()!;
                    subscriber = new User(nick);
                    timer.AddSubscriber(subscriber);
                    subs.Add(subscriber);
                    break;

                case '2':
                    Console.Clear();
                    Console.Write("Введите имя администратора: ");
                    nick = Console.ReadLine()!;
                    subscriber = new Admin(nick);
                    timer.AddSubscriber(subscriber);
                    subs.Add(subscriber);
                    break;

                case '3':
                    Console.Clear();
                    if (subs.Count == 0)
                    {
                        Console.WriteLine("Подписчиков нет");
                    }
                    subsList = string.Join("\n", subs.Select((sub, index) => $"{index + 1} - {sub}"));
                    Console.WriteLine("Выберите номер:");
                    Console.WriteLine(subsList);
                    char input = Console.ReadKey().KeyChar;
                    subscriber = subs[input - '1'];
                    timer.DeleteSubscriber(subscriber);
                    subs.Remove(subscriber);
                    break;

                case '4':
                    Console.Clear();
                    string message = "Hello, Subscriber!";
                    Console.Write("Введите время ожидания: ");
                    while (!double.TryParse(Console.ReadLine()!.Replace('.', ','), out timeout)) { }
                    timer.NotificationSub(message, timeout);
                    Console.WriteLine("Нажмите на любую кнопку, чтобы выйти в главное меню...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}

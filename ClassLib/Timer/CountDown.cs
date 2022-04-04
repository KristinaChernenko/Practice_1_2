using ClassLib.Subscribes;

namespace ClassLib.Timer
{
    public interface ITimer
    {
        void AddSubscriber(ISubscriber subscriber);
        void DeleteSubscriber(ISubscriber subscriber);
        void NotificationSub(string message, double timeout);
    }

    public class CountDown : ITimer
    {
        private List<ISubscriber> _subscribers;
        public List<ISubscriber> Subscribers => _subscribers;

        public CountDown()
        {
            _subscribers = new();
        }
        public CountDown(List<ISubscriber> subscribers)
        {
            _subscribers = new(subscribers);
        }

        public void AddSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }


        public void DeleteSubscriber(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }


        public void NotificationSub(string message, double timeout = 0)
        {
            Thread.Sleep((int)(timeout * 1000));
            _subscribers.ForEach(subscriber => subscriber.GetMessage(message));
        }
    }
}

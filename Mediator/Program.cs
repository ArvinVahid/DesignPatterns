namespace Mediator
{
    internal class Program
    {
        public interface IChatRoomMediator
        {
            void SendMessage(string message, User user);
        }

        public class ChatRoom : IChatRoomMediator
        {
            private Dictionary<string, User> _users = new Dictionary<string, User>();

            public void RegisterUser(User user)
            {
                if (!_users.ContainsKey(user.Name))
                {
                    _users.Add(user.Name, user);
                }
            }

            public void SendMessage(string message, User user)
            {
                foreach (var u in _users.Values)
                {
                    if (u != user)
                    {
                        u.Receive(message);
                    }
                }
            }
        }

        public abstract class User
        {
            protected IChatRoomMediator _chatRoom;
            public User(string name, IChatRoomMediator chatRoom)
            {
                Name = name;
                _chatRoom = chatRoom;
            }

            public string Name { get; set; }

            public abstract void Send(string message);
            public abstract void Receive(string message);
        }

        public class ChatUser : User
        {
            public ChatUser(string name, IChatRoomMediator chatRoom) : base(name, chatRoom)
            {
                
            }

            public override void Receive(string message)
            {
                Console.WriteLine($"{Name} {message}");
            }

            public override void Send(string message)
            {
                Console.WriteLine($"{Name} {message}");
            }
        }
        

        static void Main(string[] args)
        {
            IChatRoomMediator chatRoom = new ChatRoom();

            User user1 = new ChatUser("Alice", chatRoom);
            User user2 = new ChatUser("Bob", chatRoom);
            User user3 = new ChatUser("Charlie", chatRoom);

           ((ChatRoom)chatRoom).RegisterUser(user1);
           ((ChatRoom)chatRoom).RegisterUser(user2);
           ((ChatRoom)chatRoom).RegisterUser(user3);

            user1.Send("Hello everyone");
            user2.Send("Hi Alice !");
        }
    }
}
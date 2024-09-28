namespace Test;

class Program
{
    static void Main(string[] args)
    {
        GroupChatMediator mediator = new GroupChatMediator();
        
        GroupChat gp1 = new GroupChat("Group chat 1");
        GroupChat gp2 = new GroupChat("Group chat 2");

        User user1 = new User("Arvin");
        User user2 = new User("Shahram");
        User user3 = new User("Mohammad");
        
        user1.JoinGroupChat(gp1, mediator);
        user2.JoinGroupChat(gp1, mediator);
        user2.JoinGroupChat(gp2, mediator);
        user3.JoinGroupChat(gp2, mediator);
        
        user1.SendMessageGroupChat(gp1, mediator, "Salam");
        user2.SendMessageGroupChat(gp1, mediator, "Hello");
    }

    public class GroupChatMediator : IChatGroup
    {
        public void AddUser(User user, GroupChat groupChat)
        {
            groupChat.AddUser(user);
        }

        public void SendMessage(User user, GroupChat groupChat, string message)
        {
            groupChat.SendMessage(user, message);
        }
    }
    
    public interface IChatGroup
    {
        void AddUser(User user, GroupChat groupChat);
        
        //kodom user to kodom chat mikhad che messagi ro befreste?
        void SendMessage(User user, GroupChat groupChat, string message);
    }
    
    public class User
    {
        private string _name;
        private List<GroupChat> _groupChats = new List<GroupChat>();
        public User(string name)
        {
            _name = name;
        }

        public void JoinGroupChat(GroupChat groupChat, IChatGroup mediator)
        {
            mediator.AddUser(this, groupChat);
        }

        public void SendMessageGroupChat(GroupChat groupChat, IChatGroup mediator, string message)
        {
            mediator.SendMessage(this,groupChat, message);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"{_name} received {message}");
        }
    }

    public class GroupChat
    {
        private string _name;
        private List<User> _users = new List<User>();
        public GroupChat(string name)
        {
            _name = name;
        }
        public void AddUser(User user)
        {
            _users.Add(user);
        }

        //baraye ki che chizi ersal she
        public void SendMessage(User user, string message)
        {
            foreach (var u in _users)
            {
                if (u != user)
                {
                    u.ReceiveMessage(message);
                }
            }
        }
    }
}
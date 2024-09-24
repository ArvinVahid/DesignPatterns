namespace BridgePattern
{
    internal class Program
    {
        public interface IMessageSender
        {
            void SendMessage(string content);
        }

        public abstract class Message
        {
            protected IMessageSender _messageSender;
            public Message(IMessageSender messageSender)
            {
                _messageSender = messageSender;
            }

            public abstract void Send(string content);
        }

        public class EmailSender : IMessageSender
        {
            public void SendMessage(string content)
            {
                Console.WriteLine($"Sending Email with content {content}");
            }
        }

        public class SmsSender : IMessageSender
        {
            public void SendMessage(string content)
            {
                Console.WriteLine($"Sending SMS with content {content}");
            }
        }

        public class ShortMessage : Message
        {
            public ShortMessage(IMessageSender messageSender) : base(messageSender)
            {
            }

            public override void Send(string content)
            {
                if (content.Length <= 10)
                {
                    // Console.WriteLine($"Sending short SMS with content {content}")
                    _messageSender.SendMessage(content);
                }
                else
                {
                    Console.WriteLine("Content too long for a short message");
                }
            }
        }

        public class LongMessage : Message
        {
            public LongMessage(IMessageSender messageSender) : base(messageSender)
            {
                
            }

            public override void Send(string content)
            {
                _messageSender.SendMessage(content);
            }
        }

        static void Main(string[] args)
        {
            IMessageSender emailSender = new EmailSender();
            IMessageSender smsSender = new SmsSender();

            Message shortEmail = new ShortMessage(emailSender);
            Message longSms = new LongMessage(smsSender);

            shortEmail.Send("Hello");
            longSms.Send("This is a longer message sent via SMS");
        }
    }

    
}
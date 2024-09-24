using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BridgePattern.Program;

namespace BridgePattern
{
    internal class Standard
    {
        public abstract class Message
        {
            public abstract void Send(string content);
        }

        public class ShortEmailMessage : Message
        {
            public override void Send(string content)
            {
                if (content.Length <= 10)
                {
                    Console.WriteLine($"Sending short EMAIL with content {content}");
                }
                else
                {
                    Console.WriteLine("Content too long for a short Email");
                }
            }
        }

        public class LongEmailMessage : Message
        {
            public override void Send(string content)
            {
                Console.WriteLine($"Sending Long EMAIL with content {content}");
            }
        }

        public class ShortSmsMessage : Message
        {
            public override void Send(string content)
            {
                if (content.Length <= 10)
                {
                    Console.WriteLine($"Sending short SMS with content {content}");
                }
                else
                {
                    Console.WriteLine("Content too long for a short message");
                }
            }
        }

        public class LongSmsMessage : Message
        {
            public override void Send(string content)
            {
                Console.WriteLine($"Sending Long SMS with content {content}");
            }
        }
    }
}

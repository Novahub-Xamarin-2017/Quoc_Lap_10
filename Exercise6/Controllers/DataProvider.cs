using System.Collections.Generic;
using Exercise6.Models;

namespace Exercise6.Controllers
{
    class DataProvider
    {
        public List<object> Notifications { get; set; }

        private static DataProvider sInstance;

        internal static DataProvider Instance => sInstance ?? (sInstance = new DataProvider());

        private DataProvider()
        {
            Notifications = new List<object>
            {
                new CallNotification("John", "9:30 AM"),
                new CallNotification("John", "9:30 AM"),
                new CallNotification("Rob", "9:40 AM"),
                new MessageNotification("Sandy", "Hey, what's up?", "9:42 AM"),
                new CallNotification("Peter", "9:45 AM"),
                new MessageNotification("John", "Are you writing blog?", "9:48 AM"),
                new CallNotification("Jack", "9:50 AM"),
                new CallNotification("Bob", "9:55 AM"),
                new MessageNotification("Kora", "Thanks dude", "9:57 AM"),
                new CallNotification("Sandy", "10:00 AM"),
                new CallNotification("Kate", "10:05 AM"),
                new MessageNotification("Nick", "Let's hang up", "10:10 AM"),
                new CallNotification("Roger", "10:15 AM"),
                new CallNotification("Sid", "10:20 AM"),
                new CallNotification("Kora", "10:25 AM"),
                new CallNotification("Nick", "10:30 AM"),
                new MessageNotification("Rose", "Bring me some chocolates", "1035:10 AM"),
                new CallNotification("Mia", "10:40 AM"),
                new CallNotification("Scott", "10:45 AM")
            };
        }
    }
}
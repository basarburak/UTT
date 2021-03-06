using System.Collections.Concurrent;
using System.Collections.Generic;

namespace UTT
{
    public class User
    {
        public string Name { get; set; }

        private static ConcurrentDictionary<string, User> _users = new ConcurrentDictionary<string, User>();

        public static void AddUser(string user)
        {
            _users.TryAdd(user, new User
            {
                Name = user
            });
        }

        public static void Remove(string user)
        {
            _users.TryRemove(user, out _);
        }

        public static IEnumerable<User> GetUsers() => _users.Values;
    }
}
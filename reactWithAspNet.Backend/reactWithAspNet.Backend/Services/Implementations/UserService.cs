using System;
using System.Collections.Generic;
using System.Linq;
using reactWithAspNet.Backend.Models;

namespace reactWithAspNet.Backend.Services.Implementations
{
    public class UserService : IUserService
    {
        private static List<User> users = new List<User>();
        private static int count = 1;
        private static readonly string[] names = { "Adam", "Anna", "Szymon", "Sylwia", "Marta", "Przemysław", "Konrad", "Michał", "Piotr" };
        private static readonly string[] surnames = { "Kowalski", "Nowak", "Smith", "Młot", "Długi", "Biały", "Pocieszny", "Wojewódzki", "Zamiejski" };
        private static readonly string[] extensions = { "@gmail.com", "@hotmail.com", "@me.com", "@icloud.com", "@msn.com", "@jabber.com", "@wp.pl", "@onet.pl", "@ms.pl" };

        public UserService()
        {
            var random = new Random();
            for (int i = 0; i < 8; i++)
            {
                var name = names[random.Next(names.Length)];
                var surname = surnames[random.Next(surnames.Length)];
                var extension = extensions[random.Next(extensions.Length)];

                var user = new User
                {
                    Id = count++,
                    Name = name + " " + surname,
                    Email = name.ToLower() + "." + surname.ToLower() + extension,
                    Document = random.Next(0, int.MaxValue).ToString(),
                    Phone = "+48 987 765 543"
                };

                users.Add(user);
            }
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.SingleOrDefault(u => u.Id == id);
        }

        public User Create(User newUser)
        {
            newUser.Id = count++;
            users.Add(newUser);
            return newUser;
        }

        public void Update(int id, User updatedUser)
        {
            var user = users.SingleOrDefault(u => u.Id == id);

            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                user.Document = updatedUser.Document;
                user.Phone = updatedUser.Phone;
            }
        }

        public void Delete(int id)
        {
            users.RemoveAll(u => u.Id == id);
        }
    }
}

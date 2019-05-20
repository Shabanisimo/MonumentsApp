using MonumentsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonumentsApp.Functions;
using System.Data.Entity;
using System.Security.Cryptography;

namespace MonumentsApp.Functions
{
    class DataBaseFunctions
    {
        private static MonumentsAppContext _db = new MonumentsAppContext();

        public static User Auth(string login, string password)
        {
            password = Md5(password);

            var user2 = _db.Users.FirstOrDefault(x => x.Login == "useruser");
            user2.IsAdmin = false;
            _db.Entry(user2).State = EntityState.Modified;
            var user3 = _db.Users.FirstOrDefault(x => x.Login == "adminadmin");
            user3.IsAdmin = true;
            _db.Entry(user3).State = EntityState.Modified;
            _db.SaveChanges();

            var user = _db.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            return user;
        }

        public static async void Registration(User user)
        {
            user.Password = Md5(user.Password);
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public static string Md5(string toCrypt)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(toCrypt);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));
            return sb.ToString();
        }
    }
}

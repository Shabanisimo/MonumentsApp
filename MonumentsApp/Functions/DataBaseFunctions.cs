using MonumentsApp.Models;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Common;
using System.Data;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace MonumentsApp.Functions
{
    class DataBaseFunctions
    {
        private static MonumentsAppContext _db = new MonumentsAppContext();

        public static User Auth(string login, string password)
        {
            password = Md5(password);
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
        public static bool UserOnBase(string login)
        {
            if (_db.Users.FirstOrDefault(x => x.Login == login) != null)
                return true;
            else return false;
        }
        public static Monument getMonumentInfoById(int id)
        {
            return _db.Monuments.FirstOrDefault(x => x.id == id);
        }

        public static List<Monument> GetAllMonuments()
        {
            return _db.Monuments.ToList();
        }

        public static void createMonument(Monument newMonument)
        {
            _db.Monuments.Add(newMonument);
            _db.SaveChanges();
        }

        public static async void updateMonument(int id, Monument newMonument)
        {
            var monument = await _db.Monuments.FirstOrDefaultAsync(x => x.id == id);
            monument.Name = newMonument.Name;
            monument.Country = newMonument.Country;
            monument.City = newMonument.City;
            monument.Year = newMonument.Year;
            monument.Street = newMonument.Street;
            monument.Info = newMonument.Info;
            monument.Img = newMonument.Img;
            _db.Entry(monument).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public static void removeMonument(int id)
        {
            var obj = _db.Monuments.First(x => x.id == id);
            _db.Monuments.Remove(obj);
            _db.SaveChanges();
        }
    }
}

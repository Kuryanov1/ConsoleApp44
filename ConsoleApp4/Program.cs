using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Program
    {

        public static void Main(string[] args)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                string filePath = @"C:\rr\test.txt";
                List<User> people = new List<User>();
                List<string> lines = File.ReadAllLines(filePath).ToList();
                foreach (var line in lines)
                {
                    
                    string[] entries = line.Split(' ');
                    User newUser = new User();
                    newUser.LastName = entries[0];
                    newUser.Name = entries[1];
                    newUser.MiddleName = entries[2];
                    newUser.Age = Convert.ToDateTime(entries[3]);
                    db.Users.Add(newUser);
                        
                }
          
                db.SaveChanges();
                



                // получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {

                    Console.WriteLine($" Фамилия: {u.LastName} | Имя: {u.Name} | Отчество: {u.MiddleName} |Возраст: {u.Age}"); //Вывод всех объектов

                }
                }
                Console.Read();
            }
        }
    }

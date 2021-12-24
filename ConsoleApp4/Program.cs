using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp4
{
    public class Program
    {

        public static void Main(string[] args)
        {
            int t,f,p,k,i;
            t = 0;
            f = 0;
            p = 0;
            i = 0;
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                
                Console.WriteLine("Укажите полный путь к файлу \n Пример C:\\rr\\test.txt");
                string filePath = Console.ReadLine();
                /*string filePath = @"C:\rr\test.txt";*/
                if (File.Exists(filePath))
                {
                 List<User> people = new List<User>();
                 List<string> lines = File.ReadAllLines(filePath).ToList();
                  foreach (var line in lines)
                  {

                    string[] entries = line.Split(' ');
                    User newUser = new User();
                        try
                        {
                            
                            if (entries[0] != null)
                            { newUser.LastName = entries[0]; }
                            else
                            {
                                break;
                            }

                            if (entries[1] != null)
                            { newUser.Name = entries[1]; }
                            else
                            {
                                break;
                            }

                            if (entries[2] != null)
                            { newUser.MiddleName = entries[2]; }
                            else
                            {
                                break;
                            }

                            if (entries[3] != null)
                            { newUser.Age = Convert.ToDateTime(entries[3]); }
                            else
                            {
                                 break;   
                            }
                            p = ++p;
                        }
                        catch
                        {
                            i = ++i;
                            k = p+i;
                            f = ++f;
                            Console.WriteLine("Ошибка в строке:" + k);
                        }
                        finally
                        {
                            t = ++t;
                        }
                    db.Users.Add(newUser);
                        
                  }
                    db.SaveChanges();
                    Console.WriteLine("Всего строк:" + t);
                    Console.WriteLine("Ошибочных строк:" + f);
                    Console.WriteLine("Загруженно:" + p);

                    
                }
                
                else

                {
                    Console.WriteLine("Путь указан неверно");
                    Console.Read();
                }

                /*// получаем объекты из бд и выводим на консоль
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                {

                    Console.WriteLine($" Фамилия: {u.LastName} | Имя: {u.Name} | Отчество: {u.MiddleName} |Возраст: {u.Age}"); //Вывод всех объектов

                }*/
            }
                Console.Read();
            }
        }
    }

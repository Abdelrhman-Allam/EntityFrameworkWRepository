using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ConsoleApplication1.Entities;
using ConsoleApplication1.Configuration;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context()){
                
                //context.Database.CreateIfNotExists();
                Database.SetInitializer(new Initializer());
              /*  insert 
               * var person = new Person()
                {
                    FirstName = "Abdelrhman",
                    LastName = "Mohamed"
                };

                context.Pepole.Add(person);
                context.SaveChanges();
               */

                /* retrive
                var savedPeople = context.Pepole;
                foreach (var person in savedPeople)
                {
                    Console.WriteLine(person.FirstName);
                    Console.ReadKey();
                }
                 */

                /*
                 * update
                 
                var savedPeople = context.People;
                if (savedPeople.Any())
                {
                    var person = savedPeople.First();
                    person.FirstName = "Abdelrman 2";
                    person.LastName = "Allam 2";

                    context.SaveChanges();

                }
                 */
 /* 
  * delete
  */
                /*Database.SetInitializer(new Initializer());
                int personId = 2;
                var person = context.People.Find(personId);
                if (person != null)
                {
                    context.People.Remove(person);
                    context.SaveChanges();
                }
                 */
              /*  var person = new Person()
                {
                    FirstName = "Abdelrhman",
                    LastName = "Mohamed",
                    MiddleName = "A",
                    IsActive = true
                };

                person.Phones.Add(new Phone{ PhoneNumber = "01008909322 " });
                person.Phones.Add(new Phone{ PhoneNumber = "5039532 " });

                context.People.Add(person);
                context.SaveChanges();
                */
/*                var query = from person in context.People
                            where person.HeighInFeet >= 6
                            select person;

                var methodQuery = context.People.Where(p => p.HeighInFeet >= 6);
                */
/*                var person2 = new Person(){
                    FirstName = "A",
                    MiddleName = "M",
                    LastName = "A"
                };
                context.Entry(person2).State = EntityState.Added;
 */

                var people = context.People
                    .Where(p => p.PersonState == PersonState.Active)
                    .OrderBy(p => p.FirstName)
                    .ThenBy(p => p.LastName)
                    .Select(p => new
                    {
                        p.FirstName,
                        p.LastName,
                        p.PersonType.TypeName
                    });

            }

        }
    }
}

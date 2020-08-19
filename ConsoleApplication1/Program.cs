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

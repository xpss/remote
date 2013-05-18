using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomApp.Repo;

namespace TempHelpTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var credRepo = new CredentialsRepo();
            
            //Console.WriteLine(credRepo.Login("xpss", "5189215").ToString());

            //credRepo.Add(3, "Aleh", "111");
            //credRepo.Delete(3);

            //Console.WriteLine(credRepo.Test());

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using LibraryGesper;

namespace ChargementGesper
{
    class Program
    {
        static void Main(string[] args)
        {
            Données données = new Données();
            
            try
            {
                données.ConnexionBDD();
                Console.WriteLine("La connexion a réussie");
            }
            catch (Exception)
            {

                Console.WriteLine("La connexion à la base de données a échouée"); ;
            }

            Console.WriteLine();
            données.ChargerDiplomes(données.ConnexionBDD());
            Console.WriteLine();
            données.ChargerServices(données.ConnexionBDD());
            Console.WriteLine();
            données.ChargerEmployes(données.ConnexionBDD());
            Console.WriteLine();
            données.ChargerLesDiplomesDesEmployes(données.ConnexionBDD());
            Console.WriteLine();
            données.ChargerLesEmployesDesServices(données.ConnexionBDD());
            Console.WriteLine();
            données.ChargerLesEmployesTitulairesDesDiplomes(données.ConnexionBDD());
            Console.WriteLine();
            données.AfficherDiplomes();
            Console.WriteLine();
            données.AfficherEmployes();
            Console.WriteLine();
            données.AfficherServices();

            Console.ReadLine();
        }
    }
}

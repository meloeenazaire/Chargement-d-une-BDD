using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace LibraryGesper
{
    public class Données
    {
        /*          Données membres         */

        private List<Diplome> lesDiplomes;
        private List<Employe> lesEmployes;
        private List<Service> lesServices;

        MySqlDataReader Rdr;
        private string sCnx;

        /*          Constructeur            */

        /// <summary>
        /// Constructeur de la classe Données
        /// </summary>
        public Données()
        {
            lesDiplomes = new List<Diplome>();
            lesEmployes = new List<Employe>();
            lesServices = new List<Service>();
        }

        /*          Méthodes            */

        public void AfficherDiplomes()
        {
            Console.WriteLine("AFFICHAGE DES DIPLÔMES");
            foreach (Diplome d in lesDiplomes)
            {
                Console.WriteLine(d);
            }
        }
        public void AfficherServices()
        {
            Console.WriteLine("AFFICHAGE DES SERVICES");
            foreach (Service s in lesServices)
            {
                Console.WriteLine(s);
            }
        }
        public void AfficherEmployes()
        {
            Console.WriteLine("AFFICHAGE DES EMPLOYES");
            foreach (Employe e in lesEmployes)
            {
                Console.WriteLine(e);
            }
        }

        public void Charger()
        {
        }

        /// <summary>
        /// Chargement des employés dans la collection lesDiplomes
        /// </summary>
        /// <param name="Cnx"></param>
        public void ChargerDiplomes(MySqlConnection Cnx)
        {          
            Diplome unDiplome;
            MySqlCommand Cmd = new MySqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from diplome;";

            Rdr = Cmd.ExecuteReader();
            Console.WriteLine("LES DIPLÔMES :");
            while (Rdr.Read())
            {
                unDiplome = new Diplome(Int32.Parse(Rdr["dip_id"].ToString()), Rdr["dip_libelle"].ToString());
                lesDiplomes.Add(unDiplome);
                Console.WriteLine(unDiplome);
            }
            
            
        }

        /// <summary>
        /// Chargement des employés dans la collection lesEmployes
        /// </summary>
        /// <param name="Cnx"></param>
        public void ChargerEmployes(MySqlConnection Cnx)
        {
            Employe unEmploye;
            MySqlCommand Cmd = new MySqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from employe;";

            Rdr = Cmd.ExecuteReader();
            Console.WriteLine("LES EMPLOYES : ");

            while (Rdr.Read())
            {
                unEmploye = new Employe(Int32.Parse(Rdr["emp_id"].ToString()), (Rdr["emp_nom"].ToString()), Rdr["emp_prenom"].ToString(), Char.Parse(Rdr["emp_sexe"].ToString()), Byte.Parse(Rdr["emp_cadre"].ToString()), Decimal.Parse(Rdr["emp_salaire"].ToString()));
                lesEmployes.Add(unEmploye);
                Console.WriteLine(unEmploye);
            }

        } 
        /// <summary>
        /// Méthode qui permet de charger les diplômes des différents employés
        /// </summary>
        /// <param name="Cnx"></param>
        public void ChargerLesDiplomesDesEmployes(MySqlConnection Cnx)
        {
            MySqlCommand Cmd = new MySqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from posseder;";
            
            Rdr = Cmd.ExecuteReader();

            Console.WriteLine("LES DIPLÔMES DES EMPLOYES : ");

            foreach (Employe e in lesEmployes)
            {
                Cmd.CommandText = "select * from posseder where pos_employe=e.Id;";

                while (Rdr.Read())
                {
                    int i = 0;
                    while (i < lesDiplomes.Count && lesDiplomes[i].Id != Int32.Parse(Rdr["pos_diplome"].ToString()))
                    {
                        i++;
                    }

                    if (lesDiplomes[i].Id == Int32.Parse(Rdr["pos_diplome"].ToString()))
                    {
                        e.LesDiplomes.Add(lesDiplomes[i]);
                    }
                    Console.WriteLine(lesDiplomes[i]);
                }
            }

        }

        /// <summary>
        /// Méthode qui charge les employes des différents services
        /// </summary>
        /// <param name="Cnx"></param>
        public void ChargerLesEmployesDesServices(MySqlConnection Cnx)
        {
            MySqlCommand Cmd = new MySqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from employe;";

            Rdr = Cmd.ExecuteReader();

            Console.WriteLine("LES EMPLOYES DES SERVICES : ");

            foreach (Service s in lesServices)
            {
                
                Cmd.CommandText = "select * from employe where emp_service=s.ser-id;";

                while (Rdr.Read())
                {
                    int i = 0;
                    while (i < lesEmployes.Count && lesEmployes[i].Id != Int32.Parse(Rdr["emp_id"].ToString()))
                    {
                        i++;
                    }

                    if (lesEmployes[i].Id == Int32.Parse(Rdr["emp_id"].ToString()))
                    {
                        s.LesEmployesDuService.Add(lesEmployes[i]);
                    }
                    Console.WriteLine(lesEmployes[i]);
                }
            }

        }


        /// <summary>
        ///Méthode qui charge les employés qui ont un diplôme 
        /// </summary>
        /// <param name="Cnx"></param>
        public void ChargerLesEmployesTitulairesDesDiplomes(MySqlConnection Cnx)
        {
            MySqlCommand Cmd = new MySqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandType = CommandType.Text; 

            Console.WriteLine("LES EMPLOYES TITULAIRES DE DIPLÔMES : ");

            foreach (Diplome d in lesDiplomes)
            {

                Cmd.CommandText = "select * from posseder where pos_diplome = d.dip_id;";
                Rdr = Cmd.ExecuteReader();

                while (Rdr.Read())
                {
                    int i = 0;
                    while (i < lesEmployes.Count && lesEmployes[i].Id != Int32.Parse(Rdr["pos_employe"].ToString()))
                    {
                        i++;
                    }

                    if (lesEmployes[i].Id == Int32.Parse(Rdr["pos_employe"].ToString()))
                    {
                        d.LesEmployesDuDiplome.Add(lesEmployes[i]);
                        
                    }
                }
                Rdr.Close();
            }
        }

        /// <summary>
        /// Chargement des employés dans la collection lesServices
        /// </summary>
        /// <param name="Cnx">paramètre de connexion à la base de données</param>
        public void ChargerServices(MySqlConnection Cnx)
        {
            Service unService;

            MySqlCommand Cmd = new MySqlCommand();
            Cmd.Connection = Cnx;
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "select * from service;";

            Rdr = Cmd.ExecuteReader();
            Console.WriteLine("LES SERVICES : ");

            while (Rdr.Read())
            {
                if (Rdr["ser_type"].ToString()=="P")
                {
                    unService= new Service(Int32.Parse(Rdr["ser_id"].ToString()), Rdr["ser_designation"].ToString(), Char.Parse(Rdr["ser_type"].ToString()), Rdr["ser_produit"].ToString(), Int32.Parse(Rdr["ser_capacite"].ToString()));
                }
                else
                {
                    unService = new Service(Int32.Parse(Rdr["ser_id"].ToString()), Rdr["ser_designation"].ToString(), Char.Parse(Rdr["ser_type"].ToString()), Decimal.Parse(Rdr["ser_budget"].ToString()));
                }
                
                lesServices.Add(unService);
                Console.WriteLine(unService);
            }
             
        }

        public void ChargerXML()
        {
        }

        /// <summary>
        /// Méhode qui établit la connnexion à la base de données gespermn
        /// </summary>
        /// <returns> retourne la connexion à la base de données</returns>
        public MySqlConnection ConnexionBDD()
        {
            sCnx = "user=root; password=siojjr; database=gespermn; host=localhost";
            MySqlConnection Cnx = new MySqlConnection(sCnx);

            Cnx.Open();

            return Cnx;
        }

        /// <summary>
        /// Méthode qui déconnecte de la base de données gespermn
        /// </summary>
        /// <param name="Cnx">paramètre de connexion à la base de données</param>
        public void DeconnexionBDD(MySqlConnection Cnx)
        {
            Cnx.Close();
        }
        public void SauverXML()
        {
        }
        public void Sauver()
        {
        }
        public void ToutCharger()
        {
        }
        public void ToutSauvegarder()
        {
        }

        /*          Propriété             */





    }
}

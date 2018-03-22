using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LibraryGesper
{
    public class Service
    {
        /*          Données membres         */

        private int id;
        private string designation;
        private char type;
        private string produit;
        private int capacité;
        private decimal budget;
        private int dernierId;

        private List<Employe> lesEmployesDuService;

        /*          Constructeur          */
        
        /// <summary>
        /// Constructeur d'un service production
        /// </summary>
        /// <param name="id">n° service</param>
        /// <param name="designation">nom du service</param>
        /// <param name="type">type du produit fabriqué par le service</param>
        /// <param name="produit">nom du produit fabriqué par le service</param>
        /// <param name="capacite">capacité de production du produit</param>
        public Service(int id, string designation, char type, string produit, int capacité)
        {
            this.id = id;
            this.designation = designation;
            this.type = type;
            this.produit = produit;
            this.capacité = capacité;

            this.budget = 0;
            this.dernierId = 0;

            lesEmployesDuService = new List<Employe>();
        }

        /// <summary>
        /// Constructeur d'un service commercial
        /// </summary>
        /// <param name="id">n° service</param>
        /// <param name="designation">nom du service</param>
        /// <param name="type">type du produit vendu par le service</param>
        /// <param name="budget">budget du service commercial</param>
        public Service(int id, string designation, char type, decimal budget)
        {
            this.id = id;
            this.designation = designation;
            this.type = type;
            this.budget = budget;

            this.produit=" ";
            this.capacité=0;
            this.dernierId = 0;

            lesEmployesDuService = new List<Employe>();
        }

        /// <summary>
        /// Constructeur d'un service administratif
        /// </summary>
        /// <param name="produit">nom du produit</param>
        /// <param name="designation">nom du service</param>
        public Service(string produit, string designation)
        {
            this.produit = produit;
            this.designation = designation;
            this.dernierId = 0;
            lesEmployesDuService = new List<Employe>();
        }

        /*          Méthodes            */


        public void MajElementXML(XmlDocument xmlDoc, XmlElement xmlLesServices)
        {
        }

        /// <summary>
        /// Préparation de la suppression
        /// </summary>
        public void PreparerSuppression()
        {
        }

        /// <summary>
        /// Modification du ToString de la classe Object
        /// </summary>
        /// <returns>chaîne de caractère</returns>
        public override string ToString()
        {
            return string.Format("Service n° : {0}, désignation : {1}, type :{2}, et produit: {3}, capacité du service: {4}, budget du service: {5}", id, designation, type, produit, capacité, budget);
        }


        /*          Accesseurs          */

        /// <summary>
        /// accesseurs sur le numéro du service
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// accesseurs sur la désignaion 
        /// </summary>
        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        /// <summary>
        /// accesseurs sur le type 
        /// </summary>
        public char Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// accesseurs sur le produit
        /// </summary>
        public string Produit
        {
            get { return produit; }
            set { produit = value; }
        }

        /// <summary>
        /// accesseurs sur la capacité
        /// </summary>
        public int Capacité
        {
            get { return capacité; }
            set { capacité = value; }
        }

        /// <summary>
        /// accesseurs sur le budget
        /// </summary>
        public decimal Budget
        {
            get { return budget; }
            set { budget = value; }
        }

        /// <summary>
        /// accesseurs sur la collection "liste des employés du service"
        /// </summary>
        public List<Employe> LesEmployesDuService
        {
            get { return lesEmployesDuService; }
            set { lesEmployesDuService = value; }
        }

    }
}

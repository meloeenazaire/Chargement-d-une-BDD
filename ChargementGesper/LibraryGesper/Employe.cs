using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGesper
{
    public class Employe
    {
        ///<summary>
        ///<summary>
        /*          Données membres         */

        private int id;
        private string nom;
        private string prenom;
        private char sexe;
        private byte cadre;
        private decimal salaire;
        private Service leService;
        private List<Diplome> lesDiplomes;
        
        /*              Constructeur          */
        
        /// <summary>
        /// Constructeur des employés
        /// </summary>
        /// <param name="id">n° de l'employé</param>
        /// <param name="nom">nom de l'employé</param>
        /// <param name="prenom">prenom de l'employé</param>
        /// <param name="sexe">sexe de l'employé</param>
        /// <param name="cadre">cadre de l'employé</param>
        /// <param name="salaire">salaire de l'employé</param>
        public Employe(int id, string nom, string prenom, char sexe, byte cadre, decimal salaire)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.cadre = cadre;
            this.salaire = salaire;

            Service leService;
            lesDiplomes = new List<Diplome>();
        }

        /*          Méthodes            */

        /// <summary>
        /// Modification du ToString de la classe Object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string chaine;
            chaine =string.Format("Employé n° : {0}, nom : {1}, prénom :{2}, et sexe: {3}", id,nom,prenom,sexe);

            if (cadre==1)
            {
                chaine += string.Format("C'est un cadre, salaire {0} de l'employé", salaire);
            }
            else
            {
                chaine += string.Format("Ce n'est pas cadre, salaire {0} de l'employé", salaire);
            }
            return chaine;
        }

        /*          Accesseurs          */

        /// <summary>
        /// Accesseurs sur l'id de l'employe
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Accesseurs sur le nom de l'employe
        /// </summary>
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /// <summary>
        /// Accesseurs sur le prenom de l'employe
        /// </summary>
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        /// <summary>
        /// Accesseurs sur le sexe de l'employe
        /// </summary>
        public char Sexe
        {
            get { return sexe; }
            set { sexe = value; }
        }

        /// <summary>
        /// Accesseurs sur le cadre de l'employe
        /// </summary>
        public byte Cadre
        {
            get { return cadre; }
            set { cadre = value; }
        }

        /// <summary>
        /// Accesseurs sur le salaire de l'employe
        /// </summary>
        public decimal Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        /// <summary>
        /// Accesseurs sur le service
        /// </summary>
        internal Service LeService
        {
            get { return leService; }
            set { leService = value; }
        }

        /// <summary>
        /// Accesseurs sur la collection de la liste des diplômes
        /// </summary>
        internal List<Diplome> LesDiplomes
        {
            get { return lesDiplomes; }
            set { lesDiplomes = value; }
        }
    }
}

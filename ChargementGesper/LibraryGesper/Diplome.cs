using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryGesper
{
    public class Diplome
    {
        /*          Données membres          */

        private int id;
        private string libellé;
        private List<Employe> lesEmployesDuDiplome;

        /*          Constructeur          */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">n° du diplôme</param>
        /// <param name="libellé">libellé du diplôme</param>
        public Diplome(int id, string libellé)
        {
            this.id = id;
            this.libellé = libellé;

            lesEmployesDuDiplome = new List<Employe>();
        }

        /*          Méthodes            */

        /// <summary>
        /// Modification de la méthode ToString de la classe Object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Diplôme n° : {0}, libéllé : {1}", id, libellé);
        }
        /*          Accesseurs          */

        /// <summary>
        /// accesseurs sur l'id du diplome
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// accesseurs sur le libéllé du diplome
        /// </summary>
        public string Libellé
        {
            get { return libellé; }
            set { libellé = value; }
        }

        /// <summary>
        /// accesseurs sur la collection de la liste des diplomes des employés
        /// </summary>
        public List<Employe> LesEmployesDuDiplome
        {
            get { return lesEmployesDuDiplome; }
            set { lesEmployesDuDiplome = value; }
        }

    }
}

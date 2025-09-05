using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ProjetCegep.Dto;
using ProjetCegep.Modeles;

namespace ProjetCegep.Controler
{
    public class CegepControler
    {
        private static CegepControler instance;

        public static CegepControler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CegepControler();
                }
                return instance;
            }
        }

        private CegepControler() { }

        private Cegep monCegep;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unCegep"></param>
        /// <returns></returns>
        public bool CreerCegep(CegepDto unCegep)
        {
            monCegep = new Cegep(unCegep.Nom, unCegep.Adresse, unCegep.Ville, unCegep.Province, unCegep.CodePostal, unCegep.Telephone, unCegep.Courriel);
            return monCegep != null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool SupprimerCegep()
        {
            monCegep = null;
            return monCegep == null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unCegep"></param>
        /// <returns></returns>
        public bool ModifierCegep(CegepDto unCegep)
        {
            if (monCegep != null)
            {
                monCegep.Nom = unCegep.Nom;
                monCegep.Adresse = unCegep.Adresse;
                monCegep.Ville = unCegep.Ville;
                monCegep.Province = unCegep.Province;
                monCegep.CodePostal = unCegep.CodePostal;
                monCegep.Telephone = unCegep.Telephone;
                monCegep.Courriel = unCegep.Courriel;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void ChargerDonnes()
        {
            if (File.Exists("Cegep.xml"))
            {
                XmlSerializer leFichierCegep = new XmlSerializer(typeof(Cegep));
                FileStream fichierLogique;

                fichierLogique = File.OpenRead("Cegep.xml");
                monCegep = (Cegep)leFichierCegep.Deserialize(fichierLogique);
                fichierLogique.Close();

            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void SauvegarderDonnes()
        {
            if (File.Exists("Cegep.xml"))
            {
                File.Delete("Cegep.xml");
            }
            XmlSerializer leFichierCegep = new XmlSerializer(typeof(Cegep));
            FileStream fichierLogique;

            using (fichierLogique = File.OpenWrite("Cegep.xml"))
            {
                leFichierCegep.Serialize(fichierLogique, monCegep);
            }
        }
    }
}

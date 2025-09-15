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
        /// <returns></returns>
        public List<DepartementDto> ObtenirListeDepartement()
        {
            List<DepartementDto> listeDepartementDto = new List<DepartementDto>();
            if (monCegep != null)
            {
                foreach (Departement departement in monCegep.ObtenirListeDepartement())
                {
                    listeDepartementDto.Add(new DepartementDto(departement));
                }
            }
            return listeDepartementDto;
        }
        /// <summary>
        /// obtient le département voulue
        /// </summary>
        /// <param name="unDepartement"></param>
        /// <returns></returns>
        public DepartementDto ObtenirDepartement(DepartementDto unDepartement) 
        {
            if (monCegep != null)
            {
                Departement departement = monCegep.ObtenirDepartement(new Departement(unDepartement.No, unDepartement.Nom, unDepartement.Description));
                if (departement != null)
                {
                    return new DepartementDto(departement);
                }
            }
            return null;
        }
        /// <summary>
        /// ajoute un département au cégep
        /// </summary>
        /// <param name="unDepartement"></param>
        /// <returns></returns>
        public bool AjouterDepartement(DepartementDto unDepartement)
        {
            if (monCegep != null)
            {
                if (!monCegep.SiDepartementPresent(new Departement(unDepartement.No, unDepartement.Nom, unDepartement.Description)))
                {
                    monCegep.listeDepartement.Add(new Departement(unDepartement.No, unDepartement.Nom, unDepartement.Description));
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// supprime le département du cégep
        /// </summary>
        /// <param name="unDepartement"></param>
        /// <returns></returns>
        public bool SupprimerDepartement(DepartementDto unDepartement)
        {
            if (monCegep != null)
            {
                return monCegep.listeDepartement.Remove(new Departement(unDepartement.No, unDepartement.Nom, unDepartement.Description));
            }
            return false;
        }

        /// <summary>
        /// ajoute un enseignant à un département
        /// </summary>
        /// <param name="unDepartement"></param>
        /// <param name="unEnseignant"></param>
        /// <returns></returns>
        public bool AjouterEnseignant(DepartementDto unDepartement, EnseignantDto unEnseignant)
        {
            var dep = monCegep.ObtenirDepartement(new Departement(unDepartement.No,unDepartement.Nom,unDepartement.Description));
            return dep?.AjouterEnseignant(new Enseignant(unEnseignant.NoEmploye, unEnseignant.Prenom, unEnseignant.Nom, unEnseignant.Adresse, unEnseignant.Ville, unEnseignant.Province, unEnseignant.CodePostal, unEnseignant.Telephone, unEnseignant.Courriel)) ?? false;

        }
        /// <summary>
        /// Modifie un enseignant
        /// </summary>
        /// <param name="departement"></param>
        /// <param name="enseignant"></param>
        /// <returns></returns>
        public bool ModifierEnseignant(DepartementDto departement, EnseignantDto enseignant)
        {
            var dep = monCegep.ObtenirDepartement(new Departement(departement.No, departement.Nom, departement.Description));
            var ens = dep?.ObtenirEnseignant(new Enseignant(enseignant.NoEmploye, enseignant.Prenom, enseignant.Nom, enseignant.Adresse, enseignant.Ville, enseignant.Province, enseignant.CodePostal, enseignant.Telephone, enseignant.Courriel));
            if (ens != null)
            {
                ens.Prenom = enseignant.Prenom;
                ens.Nom = enseignant.Nom;
                ens.Adresse = enseignant.Adresse;
                ens.Ville = enseignant.Ville;
                ens.Province = enseignant.Province;
                ens.CodePostal = enseignant.CodePostal;
                ens.Telephone = enseignant.Telephone;
                ens.Courriel = enseignant.Courriel;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Supprime l'enseignant
        /// </summary>
        /// <param name="departement"></param>
        /// <param name="enseignant"></param>
        /// <returns></returns>
        public bool SupprimerEnseignant(DepartementDto departement, EnseignantDto enseignant)
        {
            var dep = monCegep.ObtenirDepartement(new Departement(departement.No, departement.Nom, departement.Description));
            return dep?.EnleverEnseignant(new Enseignant(enseignant.NoEmploye, enseignant.Prenom, enseignant.Nom, enseignant.Adresse, enseignant.Ville, enseignant.Province, enseignant.CodePostal, enseignant.Telephone, enseignant.Courriel)) ?? false;
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

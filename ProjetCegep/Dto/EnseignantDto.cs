using ProjetCegep.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCegep.Dto
{
    public class EnseignantDto
    {
        public int NoEmploye { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }
        public string CodePostal { get; set; }
        public string Telephone { get; set; }
        public string Courriel { get; set; }

        public EnseignantDto(Enseignant unEnsegniant) 
        {
            Nom = unEnsegniant.Nom;
            Prenom = unEnsegniant.Prenom;
            NoEmploye = unEnsegniant.NoEmploye;
            Adresse = unEnsegniant.Adresse;
            Ville = unEnsegniant.Ville;
            Province = unEnsegniant.Province;
            CodePostal = unEnsegniant.CodePostal;
            Telephone = unEnsegniant.Telephone;
            Courriel = unEnsegniant.Courriel;

        }

        public EnseignantDto(int unNoEmploye, string unPrenom, string unNom, string uneAdresse, string uneVille, string uneProvince, string unCodePostal, string unTelephone, string unCourriel)
        {
            NoEmploye = unNoEmploye;
            Prenom = unPrenom;
            Nom = unNom;
            Adresse = uneAdresse;
            Ville = uneVille;
            Province = uneProvince;
            CodePostal = unCodePostal;
            Telephone = unTelephone;
            Courriel = unCourriel;
        }
    }
}

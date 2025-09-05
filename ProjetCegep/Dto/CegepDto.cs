using ProjetCegep.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCegep.Dto
{
    public class CegepDto
    { 
       /// <summary>
       /// 
       /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Ville { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CodePostal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Courriel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unCegep"></param>
        public CegepDto(Cegep unCegep) 
        {
            Nom = unCegep.Nom;
            Adresse = unCegep.Adresse;
            Ville = unCegep.Ville;
            Province = unCegep.Province;
            CodePostal = unCegep.CodePostal;
            Telephone = unCegep.Telephone;
            Courriel = unCegep.Courriel;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unNom"></param>
        /// <param name="uneAdresse"></param>
        /// <param name="uneVille"></param>
        /// <param name="uneProvince"></param>
        /// <param name="unCodePostal"></param>
        /// <param name="unTelephone"></param>
        /// <param name="unCourriel"></param>
        public CegepDto(string unNom = "", string uneAdresse = "", string uneVille = "", string uneProvince = "", string unCodePostal = "", string unTelephone = "", string unCourriel = "")
        {
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

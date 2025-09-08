using ProjetCegep.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCegep.Dto
{
    public class DepartementDto
    {
        public string No { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        

        public DepartementDto(Departement unDepartement) 
        {
            No = unDepartement.No;
            Nom = unDepartement.Nom;
            Description = unDepartement.Description;
            
        }

        public DepartementDto(string unNo = "", string unNom = "", string uneDescription = "")
        {
            No = unNo;
            Nom = unNom;
            Description = uneDescription;
            
        }
    }
}

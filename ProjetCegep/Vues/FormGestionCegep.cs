using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using ProjetCegep.Controler;
using ProjetCegep.Dto;
using ProjetCegep.Modeles;

namespace ProjetCegep.Vues
{
   public partial class FormGestionCegep : Form
   {
        //Cegep monCegep;  //Objet Cégep qui comprend la structure complète d'un cégep...

        /// <summary>
        /// Constructeur du formulaire Gestion Cégep
        /// </summary>
        public FormGestionCegep()
        {
            InitializeComponent();
            CegepControler.Instance.ChargerDonnes();
            RemplirListes();
        }

        /// <summary>
        /// Méthode qui permet d'enregistrer le cégep et les listes dans un fichier XML.  Par la suite, on quitte l'application 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CegepControler.Instance.SauvegarderDonnes();
            Application.Exit();
        }

        /// <summary>
        /// Permet de remplir les différentes listes du formulaire 
        /// </summary>
        public void RemplirListes()
        {
            lbxDepartement.Items.Clear();
            lbxDepartementInfoCegep.Items.Clear();
            cbxDepartementEnseignant.Items.Clear(); 
            if (CegepControler.Instance != null)
                foreach (DepartementDto departement in CegepControler.Instance.ObtenirListeDepartement())
                {
                    lbxDepartement.Items.Add(departement.Nom.ToString());
                    lbxDepartementInfoCegep.Items.Add(departement.Nom.ToString());
                    cbxDepartementEnseignant.Items.Add(departement.Nom.ToString());
                }
        }

        //Onglet Gestion enseignants...

        /// <summary>
        /// Méthode qui permet de mettre à jour les différentes listes d'enseignants
        /// </summary>
        /// <param name="unDepartement">Le département qui à été sélectionné</param>
        public void AfficherListeEnseignantGestionEnseignant(DepartementDto unDepartement)
        {
            lbxEnseignantsSaisie.Items.Clear();
            foreach (Enseignant enseignant in unDepartement.ObtenirListeEnseignant())
            {
                lbxEnseignantsSaisie.Items.Add(enseignant.NoEmploye + "  " + enseignant.Prenom + " " + enseignant.Nom);
            }
        }

/// <summary>
/// Méthode qui permet d'ajouter un enseignant dans un département qui a été sélectionné dans la liste
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
private void BtnAjouterEnseignant_Click(object sender, EventArgs e)
        {
            DepartementDto monDepartement , departement;
            departement = new DepartementDto("", cbxDepartementEnseignant.Text, "");
            if (departement != null)
            {
                monDepartement = CegepControler.Instance.ObtenirDepartement(departement);
                CegepControler.Instance.AjouterEnseignant(monDepartement, new EnseignantDto(int.Parse(edtNoEmploye.Text), edtPrenomEnseignant.Text, edtNomEnseignant.Text, edtAdresseEnseignant.Text, edtVilleEnseignant.Text, EdtProvinceEnseignant.Text, edtCodePostalEnseignant.Text, edtTelephoneEnseignant.Text, edtCourrielEnseignant.Text));
                MessageBox.Show("L'enseignant " + edtNomEnseignant.Text +" "+ edtPrenomEnseignant.Text + " à été ajouté");
                RemplirListes();
                AfficherListeEnseignantGestionEnseignant(monDepartement);
                Refresh();
            }
            else
            {
                MessageBox.Show("Erreur dans la sélection du département.");
            }
        }

        /// <summary>
        /// Méthode qui permet d'afficher la liste des enseignants après avoir sélectionner un département dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CbxDepartementEnseignant_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartementDto monDepartement, departement;
            departement = new DepartementDto("", cbxDepartementEnseignant.Text, "");
            monDepartement = CegepControler.Instance.ObtenirDepartement(departement);
            
            //Departement monDepartement, leDepartementAChercher;

            //leDepartementAChercher = new Departement("", cbxDepartementEnseignant.Text, "");

            //monDepartement = monCegep.ObtenirDepartement(leDepartementAChercher);

            //AfficherListeEnseignantGestionEnseignant(monDepartement);
        }


        /// <summary>
        /// Méthode qui permet de modifier un enseignant déjà dans la liste
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModifierEnseignant_Click(object sender, EventArgs e)
        {
            CegepControler.Instance.ModifierEnseignant(new DepartementDto("", cbxDepartementEnseignant.Text, ""), new EnseignantDto(int.Parse(edtNoEmploye.Text), edtPrenomEnseignant.Text, edtNomEnseignant.Text, edtAdresseEnseignant.Text, edtVilleEnseignant.Text, EdtProvinceEnseignant.Text, edtCodePostalEnseignant.Text, edtTelephoneEnseignant.Text, edtCourrielEnseignant.Text));
            MessageBox.Show("L'enseignant " + edtNoEmploye.Text + " à été modifié");
            RemplirListes();
            AfficherListeEnseignantGestionEnseignant(new DepartementDto("", cbxDepartementEnseignant.Text, ""));

        }

        /// <summary>
        /// Méthode pour supprimer un enseignant de la liste de sont département
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSupprimerEnseignant_Click(object sender, EventArgs e)
        {
            CegepControler.Instance.SupprimerEnseignant(new DepartementDto("", cbxDepartementEnseignant.Text, ""), new EnseignantDto(int.Parse(edtNoEmploye.Text), edtPrenomEnseignant.Text, edtNomEnseignant.Text, edtAdresseEnseignant.Text, edtVilleEnseignant.Text, EdtProvinceEnseignant.Text, edtCodePostalEnseignant.Text, edtTelephoneEnseignant.Text, edtCourrielEnseignant.Text));
            MessageBox.Show("L'enseignant " + edtNoEmploye.Text + " à été supprime");
            RemplirListes();
            AfficherListeEnseignantGestionEnseignant(new DepartementDto("", cbxDepartementEnseignant.Text, ""));

        }

        //Onglet Gestion départements

        /// <summary>
        /// Méthode qui permet d'ajouter un départemetn à la liste des départements du cégep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAjouterDepartement_Click(object sender, EventArgs e)
        {
            CegepControler.Instance.AjouterDepartement(new DepartementDto(edtNoDepartement.Text, edtNomDepartement.Text, edtDescriptionDepartement.Text));
            RemplirListes();
            Refresh();
            
        }

        /// <summary>
        /// Métode qui permet de supprimer un département de la liste des département du cégep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSupprimerGestionDepartement_Click(object sender, EventArgs e)
        {
            CegepControler.Instance.SupprimerDepartement(new DepartementDto(edtNoDepartement.Text, edtNomDepartement.Text, edtDescriptionDepartement.Text));
            RemplirListes();
            MessageBox.Show(edtNoDepartement.Text + "\na bien été enlevé."); 
        }

        //Onglet Info Cégep

        /// <summary>
        /// Méthode qui permet de créer un cégep avec le constructeur paramétré.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAjouterCegep_Click(object sender, EventArgs e)
        {
            //TODO: Vérifier si un cégep existe déjà avant d'en créer un nouveau.
            CegepControler.Instance.CreerCegep(new CegepDto(edtNomCegep.Text,edtAdresseCegep.Text, edtVilleCegep.Text, edtProvinceCegep.Text, edtCodePostalCegep.Text, edtTelephoneCegep.Text, edtCourrielCegep.Text));
            MessageBox.Show(edtNomCegep.Text + "\n a bien été crée.");
        }

        /// <summary>
        /// Méthode qui permet de modifier les informations du cégep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModifierCegep_Click(object sender, EventArgs e)
        {
            CegepControler.Instance.ModifierCegep(new CegepDto(edtNomCegep.Text, edtAdresseCegep.Text, edtVilleCegep.Text, edtProvinceCegep.Text, edtCodePostalCegep.Text, edtTelephoneCegep.Text, edtCourrielCegep.Text));
            MessageBox.Show(edtNomCegep.Text + "\na bien été modifié.");
        }

        /// <summary>
        /// Méthode qui permet de suprimmer l'objet cégep
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSupprimerCegep_Click(object sender, EventArgs e)
        {
            CegepControler.Instance.SupprimerCegep();
            MessageBox.Show(edtNomCegep.Text + " a bien été supprimé.");
            RemplirListes();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGestionCegep_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuitterToolStripMenuItem_Click(this, null);
        }

        
    }
}

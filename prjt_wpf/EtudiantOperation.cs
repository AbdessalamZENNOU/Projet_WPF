using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjt_wpf
{
    class EtudiantOperation
    {

        DataClasses1DataContext cl = new DataClasses1DataContext();

        public List<string> getNomfiliere()
        {
            List<string> ListeFiliere = new List<string>();
            var x = from c in cl.filieres select new { c.nom_filiere };
            foreach (var i in x)
            {
                ListeFiliere.Add(i.nom_filiere);

            }

            return ListeFiliere;

        }

        //pour recuperer les donnees dans radgridview
        public List<etudiant> getaletudiant()
        {

            List<etudiant> Listeetudiant = new List<etudiant>();
            var x = from c in cl.etudiants select new { c.cne, c.nom, c.prenom, c.dateNaiss, c.id_filiere  };
            foreach (var y in x)
            {
                etudiant et = new etudiant();

                et.cne = y.cne;
                et.nom = y.nom;
                et.prenom = y.prenom;
                et.dateNaiss = y.dateNaiss;
                et.id_filiere = y.id_filiere;


                Listeetudiant.Add(et);

            }

            return Listeetudiant;

        }
        //affiher pour chaque combobox 
        public List<etudiant> getchaquefiliere(String v)
        {
            GestionEtudiant ft = new GestionEtudiant();
            List<etudiant> Listeetudiant = new List<etudiant>();
            var x = (from c in cl.etudiants join d in cl.filieres on c.id_filiere equals d.id_filiere where d.nom_filiere == v select new { c.cne, c.nom, c.prenom, c.dateNaiss, c.tof });
            foreach (var y in x)
            {
                etudiant et = new etudiant();

                et.cne = y.cne;
                et.nom = y.nom;
                et.prenom = y.prenom;
                et.dateNaiss = y.dateNaiss;
                et.tof= y.tof;


                Listeetudiant.Add(et);

            }

            return Listeetudiant;
        }



        //pour recuperer les donnee dans le Raddatafrom

        public List<etudiant> geAlleudiant()
        {

            List<etudiant> Listeetudiant = new List<etudiant>();
            var x = from c in cl.etudiants select new { c.cne, c.nom, c.prenom, c.dateNaiss , c.tof };
            foreach (var y in x)
            {
                etudiant et = new etudiant();

                et.cne = y.cne;
                et.nom = y.nom;
                et.prenom = y.prenom;
                et.dateNaiss = y.dateNaiss;
                et.tof = y.tof;

                Listeetudiant.Add(et);

            }

            return Listeetudiant;

        }
        //supprimer
       
        public void Delete(String id)
        {
            List<etudiant> Listeetudiant = new List<etudiant>();

            var x = (from c in cl.etudiants
                     where c.cne == id.ToString()
                     select c).SingleOrDefault();
            cl.etudiants.DeleteOnSubmit(x);
            cl.SubmitChanges();
            Listeetudiant.Remove(x);


        }
        //ajouterr

        public void ajouter(etudiant etudiant)
        {
            List<etudiant> Listeetudiant = new List<etudiant>();

            etudiant f = new etudiant();
            f.cne = etudiant.cne;
            f.nom = etudiant.nom;
            f.prenom = etudiant.prenom;
            f.dateNaiss = etudiant.dateNaiss;

            f.id_filiere = etudiant.id_filiere; 

            cl.etudiants.InsertOnSubmit(f);
            cl.SubmitChanges();
            Listeetudiant.Add(f);

        }
        //resp 
        public String getcheffiliere(String v)
        {
            filiere FR = new filiere();
            var x = from c in cl.filieres where c.nom_filiere == v select new { c.respo };
            foreach (var y in x)
            {
                FR.respo = y.respo;

            }
            return FR.respo;

        }
        //modifier 
        public void modifier(etudiant etudiant)
        {
            var x = (from f in cl.etudiants
                     where f.cne == etudiant.cne
                     select f).SingleOrDefault();

            x.nom = etudiant.nom;
            x.prenom = etudiant.prenom;
            x.dateNaiss = etudiant.dateNaiss;
            x.id_filiere= etudiant.id_filiere;
            cl.SubmitChanges();
        }

    }
}


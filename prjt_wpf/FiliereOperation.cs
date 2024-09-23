using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace prjt_wpf
{
    class FiliereOperation
    {
        DataClasses1DataContext cl;
        ObservableCollection<filiere> liste1;
      public FiliereOperation(DataClasses1DataContext cl, ObservableCollection<filiere> liste1) {
            this.cl = cl;
            this.liste1 = liste1;
        }

        public void ajouter(string nomFiliere, string responsable)
        {
            if (cl.filieres.Any(exf => exf.nom_filiere == nomFiliere))
            {
                MessageBox.Show("Le nom de la filière existe déjà.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            filiere f = new filiere();

            f.nom_filiere = nomFiliere;
            f.respo = responsable;

            cl.filieres.InsertOnSubmit(f);
            cl.SubmitChanges();
            liste1.Add(f);

            MessageBox.Show("Ajout effectué avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        public void supprimer(int id)
        {
            var x = (from c in cl.filieres
                     where c.id_filiere == id
                     select c).SingleOrDefault();
            if (x != null)
            {
                cl.filieres.DeleteOnSubmit(x);
                cl.SubmitChanges();
                liste1.Remove(x);

                MessageBox.Show("Suppression effectuée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Élément non trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void modifier(int id, string nomFiliere, string responsable)
        {
            var x = (from c in cl.filieres where c.id_filiere == id select c).SingleOrDefault();

            if (x != null)
            {
                int i = liste1.IndexOf(x);
                liste1.Remove(x);

                x.id_filiere = id;
                x.nom_filiere = nomFiliere;
                x.respo = responsable;
                cl.SubmitChanges();
                liste1.Insert(i, x);

                MessageBox.Show("Modification effectuée avec succès.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Élément non trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public ObservableCollection<filiere> afficher()
        {
            var x = from c in cl.filieres select c;
            foreach (var i in x)
            {
                liste1.Add(i);
            }
            return liste1;
        }

    }
}

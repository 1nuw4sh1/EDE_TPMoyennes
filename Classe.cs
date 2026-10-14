using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Classe
    {
        #region Proriétés & Constructeur
        public string nomClasse;
        public List<Eleve> eleves = new();
        public List<string> matieres = new();


        public Classe(string nom_classe)
        {
            nomClasse = nom_classe;
        }
        #endregion

        #region Méthodes
        public void ajouterEleve(string prenomEleve, string nomEleve)
        {
            if (eleves.Count >= 30)
            {
                Console.WriteLine("Impossible d'ajouter un nouvel élève, la classe est déjà pleine.");
                return;
            }
            eleves.Add(new Eleve(prenomEleve, nomEleve));
        }
        public void ajouterMatiere(string nomMatiere)
        {
            if (matieres.Count >= 10)
            {
                Console.WriteLine("Impossible d'ajouter une nouvelle matière, la classe a déjà le maximum de matières.");
                return;
            }
            matieres.Add(nomMatiere);

            // Initialiser la liste de notes pour la nouvelle matière dans chaque élève existant
            int matiereIndex = matieres.Count - 1;
            foreach (var eleve in eleves)
            {
                if (!eleve.notesMatieres.ContainsKey(matiereIndex))
                    eleve.notesMatieres[matiereIndex] = new List<float>();
            }
        }
        public float moyenneMatiere(int matiere)
        {
            double sommeMoyennesMatiere = 0.0;
            for (int ieleve = 0; ieleve < eleves.Count; ieleve++)
            {
                sommeMoyennesMatiere += eleves[ieleve].moyenneMatiere(matiere);
            }
            return MathF.Truncate((float) sommeMoyennesMatiere / eleves.Count * 100) / 100;
        }
        public float moyenneGeneral()
        {
            double sommeMoyennesGenerales = 0.0;
            for (int imatiere = 0; imatiere < matieres.Count; imatiere++)
            {
                sommeMoyennesGenerales += moyenneMatiere(imatiere);
            }
            return MathF.Truncate((float) sommeMoyennesGenerales / matieres.Count * 100) / 100;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Eleve
    {
        #region Proriétés & Constructeur
        public string prenom;
        public string nom;
        public Dictionary<int, List<float>> notesMatieres = new();


        public Eleve(string prenom_eleve, string nom_eleve)
        {
            prenom = prenom_eleve;
            nom = nom_eleve;
        }
        #endregion

        #region Méthodes
        public void ajouterNote(Note note)
        {   
            if (notesMatieres.Values.Sum(liste => liste.Count) >= 200)
            {
                Console.WriteLine("Impossible d'ajouter une note, l'élève a déjà 200 notes cette année.");
                return; 
            }
            notesMatieres[note.matiere].Add(note.note);
        }
        public float moyenneMatiere(int matiere)
        {
            double sommeNotes = 0.0;
            for (int inotes = 0; inotes < notesMatieres[matiere].Count; inotes++)
            {
                sommeNotes += notesMatieres[matiere][inotes];
            }
            return MathF.Truncate((float) sommeNotes / notesMatieres[matiere].Count * 100) / 100;
        }
        public float moyenneGeneral()
        {
            double sommeMoyennes = 0.0;
            for (int imatiere = 0; imatiere < notesMatieres.Count; imatiere++)
            {
                sommeMoyennes += moyenneMatiere(imatiere);
            }
            return MathF.Truncate((float) sommeMoyennes / notesMatieres.Count * 100) / 100;
        }
        #endregion
    }
}

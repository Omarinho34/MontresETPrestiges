using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MontresETPrestiges
{
    public class Montre
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Description { get; set; }
        public DateTime Date_ajout { get; set; }
        public int Quantite { get; set; }
        public string? Prix { get; set; }
        public int Genre_id { get; set; }
        public int Type_id { get; set; }
        public int Matiere_id { get; set; }
        public int Couleur_id { get; set; }
        public int Mouvement_id { get; set; }
        public int Marque_id { get; set; }
        public int? SeuilAlerte {  get; set; }
        public string AffichageIdNom => $"#{Id} {Nom}";
    }
    public class Status
    {
        public int Id_commande { get; set; }
        public int Id_status { get; set; }
        public string? Libelle { get; set; }
        public DateTime Date_status { get; set; }
    }

}

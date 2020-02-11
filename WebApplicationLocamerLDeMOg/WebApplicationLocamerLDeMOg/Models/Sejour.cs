//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationLocamerLDeMOg.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sejour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sejour()
        {
            this.DetailReserv = new HashSet<DetailReserv>();
            this.DetailSej = new HashSet<DetailSej>();
        }
    
        public int idSejour { get; set; }
        public System.DateTime dateDebut { get; set; }
        public System.DateTime dateFin { get; set; }
        public Nullable<int> idCli { get; set; }
        public Nullable<int> idCate { get; set; }
    
        public virtual Categorie Categorie { get; set; }
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailReserv> DetailReserv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailSej> DetailSej { get; set; }
    }
}

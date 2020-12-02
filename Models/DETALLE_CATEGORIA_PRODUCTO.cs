namespace Sistema_TuTienda_Lizarraga_Belizario_Loja.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DETALLE_CATEGORIA_PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DETALLE_CATEGORIA_PRODUCTO()
        {
            CATEGORIA_PRODUCTO = new HashSet<CATEGORIA_PRODUCTO>();
        }

        [Key]
        public int ID_DETALLE_CATEGORIA { get; set; }

        [Required]
        [StringLength(20)]
        public string NOMBRE { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCRIPCION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CATEGORIA_PRODUCTO> CATEGORIA_PRODUCTO { get; set; }
    }
}

namespace SiparisTakip.Entities.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_CariBakiye
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IsyeriID { get; set; }

        [StringLength(150)]
        public string IsyeriAdi { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CariID { get; set; }

        [StringLength(200)]
        public string CariAdi { get; set; }

        [StringLength(200)]
        public string CariAdresi { get; set; }

        [StringLength(20)]
        public string CariIl { get; set; }

        [StringLength(20)]
        public string CariIlce { get; set; }

        [StringLength(200)]
        public string CariVergiDairesi { get; set; }

        [StringLength(11)]
        public string TcKimlikNo { get; set; }

        [StringLength(25)]
        public string CariVergiNo { get; set; }

        public int? CariGrupID { get; set; }

        [StringLength(50)]
        public string CariGrupAdi { get; set; }

        public byte? SatisTarifesi { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal SabitIskontoOrani { get; set; }

        [StringLength(20)]
        public string TAPDKSicilNo { get; set; }

        [StringLength(20)]
        public string CepTelNo { get; set; }

        public decimal? Alacak { get; set; }

        public decimal? Borc { get; set; }

        public decimal? Bakiye { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(32)]
        public string BakiyeDurumu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SonRutTarihi { get; set; }
    }
}

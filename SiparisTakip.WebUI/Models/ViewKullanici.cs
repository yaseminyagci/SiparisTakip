using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiparisTakip.WebUI.Models
{
    public class ViewKullanici
    {   [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} kodu boş geçilemez")]
        [MinLength(4, ErrorMessage = "{0} kodu en az {1} olmalı")]
        [MaxLength(8, ErrorMessage = "{0} kodu en fazla {1} karakterden oluşabilir")]
        public string KullaniciKodu { get; set; }
        [DisplayName("Parola")]
        [Required(ErrorMessage = "{0}  boş geçilemez")]
        [MinLength(4, ErrorMessage = "{0} en az {1} olmalı")]
        [MaxLength(8, ErrorMessage = "{0} en fazla {1} karakterden oluşabilir")]
        public string Parola { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysBase.Core.Models
{
    public class ApiBasvuruRequest
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public string Kanal { get; set; }
        public int? Durum { get; set; }
        public string KayitID { get; set; }
        public string SiparisAdi { get; set; }
        public string Sirket { get; set; }
        public string VergiNo { get; set; }
        public string VergiDairesi { get; set; }
        public string TCKimlikNo { get; set; }
        public string AdSoyad { get; set; }
        public DateTime? DogumTarihi { get; set; } // Format: "dd/MM/yyyy"
        public string DogumYeri { get; set; }
        public string Eposta { get; set; }
        public string Uyruk { get; set; }
        public DateTime? IlkKullanmaTarihi { get; set; }
        public DateTime? SonKullanmaTarihi { get; set; }
        public string IPAdresi { get; set; }
        public string TeslimatAdresi { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string PostaKodu { get; set; }
        public string Telefon { get; set; }
        public string CepTelefonu { get; set; }
        public string Fax { get; set; }
        public string KurulumAdresiDetay { get; set; }
        public string KurulumAdresiIl { get; set; }
        public string KurulumAdresiIlce { get; set; }
        public string KurulumAdresiPostaKodu { get; set; }
        public string KurulumAdresiTelefon { get; set; }
        public string KurulumAdresiCepTelefonu { get; set; }
        public string KurulumAdresiFax { get; set; }
        public string FaturaAdresiDetay { get; set; }
        public string FaturaAdresiIl { get; set; }
        public string FaturaAdresiIlce { get; set; }
        public string FaturaAdresiPostaKodu { get; set; }
        public string FaturaAdresiTelefon { get; set; }
        public string FaturaAdresiCepTelefonu { get; set; }
        public string FaturaAdresiFax { get; set; }
        public string Aciklama { get; set; }
        public bool EmailAdresiSertifikadaGorulsun { get; set; }
        public string ProjeAdi { get; set; }
        public string OdemeSekli { get; set; }
        public decimal? OdemeMiktari { get; set; }
        public bool KurulumVarMi { get; set; }
        public string FirmaUnvani { get; set; }
        public int? Yil { get; set; }
        public bool Avukat { get; set; }
        public bool Izin { get; set; }
        public string Pass { get; set; }
        public bool KimlikDogrulandi { get; set; }
        public string PasaportNo { get; set; }
        //public List<Urun> Urunler { get; set; } = new List<Urun>();
        public bool Istest { get; set; }
        public string GuvenlikSozcugu { get; set; }
        public bool OnayTik { get; set; }
        public bool KVKonayTik { get; set; }
        public string TCSeriNo { get; set; }
        public string GizliSoru { get; set; }
        public string DeliveryType { get; set; }
        public string NVIDogrulama { get; set; }
        public string PdfErisimToken { get; set; }
        public bool IsEdevlet { get; set; }
        public string EmuhurKisi { get; set; }
        public string EmuhurTC { get; set; }
        public string EmuhurVergiIl { get; set; }
        public string EmuhurVergiDairesi { get; set; }
        public string EmuhurVergiNo { get; set; }
        public string IkinciKisiTC { get; set; }
        public string KepAdres { get; set; }
        public string Dosya { get; set; }
        public int ProjectProductId { get; set; }
        public int OdemeTipi { get; set; }//1:kredikartı,2havale
        public string OdemeCevap { get; set; }
        public decimal OdemeTutar { get; set; }
        public int SiparisKodu { get; set; }
        public bool CrmGonderim { get; set; }
        public ProjectProduct ProjectProduct { get; set; }
        public string IkinciKisiAdSoyad { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//sadece insert ederken çalış
        public DateTime CreatedDate { get; set; } = DateTime.Now;//otomatik olarak tarih atar
    }
}

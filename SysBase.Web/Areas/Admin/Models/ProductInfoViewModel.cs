namespace SysBase.Web.Areas.Admin.Models
{
    public class ProductInfoViewModel
    {
        public int ProductId { get; set; } // `@item.Id` değerine denk gelir.
        public bool Secim { get; set; } // Checkbox değeri.
        public float Amount { get; set; } // Miktar bilgisi.
    }
}

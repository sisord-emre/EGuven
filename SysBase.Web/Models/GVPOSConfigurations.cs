namespace SysBase.Web.Models
{
    public static class GVPOSConfigurations
    {
        //GARANTI VPos definations
        public const string MerchandID = "7000679";
        public const string SubMerchandID = null;
        public const string SecureKey = "1234578";

        //GARANTI Terminal definations
        public const string TerminalID_For_XML = "30691297";
        public const string TerminalID_For_3D_PAY = "30691298";
        public const string TerminalID_For_3D_OOS_PAY = "30691299";
        public const string TerminalID_For_OOS_PAY = "30691300";
        public const string TerminalID_For_3D_FULL = "30691301";

        //GARANTI Provision user definations
        public const string ProvUserID_AUT = "PROVAUT";
        public const string ProvUserID_FRN = "PROVRFN";
        public const string ProvUserID_OOS = "PROVOOS";
        public const string ProvUserID_3DS = "GARANTI";
        public const string ProvUserPassword = "123qweASD/";

        //3D Secure configs
        public const string HostUriSuccessPath = "/thanks";
        public const string HostUriFailPath = "/paymenterror";

        //Credit card details for 3D
        public const string Credit_Card_Number_For_3D = "4282209004348015";
        public const string Credit_Card_Cvv2_For_3D = "123";
        public const int Credit_Card_Month_For_3D = 7;
        public const int Credit_Card_Year_For_3D = 19;

        //Order address details
        public const string Order_Address_Name = "MERKEZ";
        public const string Order_Address_City = "İstanbul";
        public const string Order_Address_District = "Pendik";
        public const string Order_Address_Text = "Çamçeşme Mah. Tersane Cad. No:15 Üst Kaynarca/Pendik - İstanbul";
        public const string Order_Address_PostalCode = "34890";
        public const string Order_Address_Phone = "+902166622000";

        //Customer details
        public const string Customer_Email = "eticaret@garanti.com.tr";
        public const string Customer_IPAddress = "192.168.0.1";
    }
}

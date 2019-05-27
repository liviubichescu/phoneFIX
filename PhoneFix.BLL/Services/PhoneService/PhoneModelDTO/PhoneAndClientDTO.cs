namespace PhoneFix.BLL.Services.PhoneService
{
    public class PhoneAndClientDTO
    {

        public int phoneID { get; set; }
        public int clientID { get; set; }
        public string brand { get; set; }
        public string type { get; set; }
        public string IMEI { get; set; }
        public string owner { get; set; }

    }
}

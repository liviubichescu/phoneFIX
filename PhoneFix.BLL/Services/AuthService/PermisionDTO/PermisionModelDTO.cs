namespace PhoneFix.BLL.Services.AuthService.PermisionDTO
{
    public class PermisionModelDTO
    {
        public int permisionID { get; set; }
        public bool? viewService { get; set; }
        public bool? viewRepair { get; set; }
        public bool? addClient { get; set; }
        public bool? addPhones { get; set; }
        public bool? addService { get; set; }
        public bool? addRepair { get; set; }
        public bool? viewClients { get; set; }
        public bool? viewPhones { get; set; }
    }
}

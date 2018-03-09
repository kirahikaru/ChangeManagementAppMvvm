
namespace DataLayer.Models
{
    public class OUser : PclaAuditObjectBase
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsActiveDir { get; set; }
    }
}

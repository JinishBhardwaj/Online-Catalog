using System.Collections.Generic;

namespace OnlineCatalog.Data.Model
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }

        public int ProvinceId { get; set; }
        public virtual Province Province { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

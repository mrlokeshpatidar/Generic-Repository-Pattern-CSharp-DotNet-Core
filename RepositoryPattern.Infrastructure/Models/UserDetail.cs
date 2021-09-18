using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Infrastructure.Models
{
    public class UserDetail 
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("Name")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name length can't be more than 50 and less then 5.")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [DisplayName("WebSite")]
        [Url(ErrorMessage = "Invalid Web Url")]
        public string WebSite { get; set; }

        [DisplayName("Address")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Name length can't be more than 200 and less then 5.")]
        public string Address { get; set; }

        [DisplayName("CreateDate")]
        public Nullable<DateTime> CreateDate { get; set; }

        [DisplayName("CreatedBy")]
        public Nullable<int> CreatedBy { get; set; }

        [DisplayName("UpdateDate")]
        public Nullable<DateTime> UpdateDate { get; set; }

        [DisplayName("UpdatedBy")]
        public Nullable<int> UpdatedBy { get; set; }

        [DisplayName("IsVisible")]
        public Nullable<bool> IsVisible { get; set; }

    }
}

namespace WinFormsCampusApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class user
    {
        [Key]
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        public DateTime? email_verified_at { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [StringLength(100)]
        public string remember_token { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }
    }
}

﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estiven_API_Xamarin.API.Data.Models
{
    public class User : IdentityUser
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual UserRole Role { get; set; }
    }

}

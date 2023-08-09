﻿using Estiven_API_Xamarin.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estiven_API_Xamarin.API.Data.Models
{
    public class UserRole
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoleId { get; set; }

        [Required]
        public string Name { get; set; }

        public RoleType Type { get; set; }
    }
}

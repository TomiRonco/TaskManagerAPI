﻿using System.ComponentModel.DataAnnotations;

namespace taskManaggerAPI.Data.Models
{
    public class ClientPostDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
        public string UserType { get; set; } = "Client";
    }
}

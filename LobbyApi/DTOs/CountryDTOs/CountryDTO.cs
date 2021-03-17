using LobbyApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyApi.DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Weather_App.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Entries { get; set; }
    }
}

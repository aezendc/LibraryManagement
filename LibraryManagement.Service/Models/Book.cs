using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Service.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        [RegularExpression(@"^\d{13}$", ErrorMessage = "ISBN must be a 13-digit number.")]
        public string ISBN { get; set; } = string.Empty;
    }
}

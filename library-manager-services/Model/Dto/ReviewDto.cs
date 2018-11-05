using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Models.Dto
{
    public class ReviewDto
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Rate is required.")]
        public int Rate { get; set; }
        
        [Required(ErrorMessage = "UserId is required.")]
        public long UserId { get; set; }
        
        [Required(ErrorMessage = "BookId is required.")]
        public long BookId { get; set; }
        
        [Required(ErrorMessage = "Issued date is required.")]
        public DateTime Issued { get; set; }
        
        public DateTime Returned { get; set; }
    }
}
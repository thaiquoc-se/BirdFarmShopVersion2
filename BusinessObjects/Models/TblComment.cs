using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public partial class TblComment
    {
        public int CommentId { get; set; }
        public int BirdId { get; set; }
        public int UserId { get; set; }
        public DateTime? CommentDate { get; set; }

        [Required]
        public string? Content { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be 1 to 5")]
        public int? Rating { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual TblUser User { get; set; } = null!;
    }
}

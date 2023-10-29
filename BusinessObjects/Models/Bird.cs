using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Models
{
    public partial class Bird
    {
        public Bird()
        {
            TblComments = new HashSet<TblComment>();
            TblOrderDetails = new HashSet<TblOrderDetail>();
            Tblchildrenbirds = new HashSet<Tblchildrenbird>();
        }

        public int BirdId { get; set; }
        [Required]
        public string BirdName { get; set; } = null!;
        public int UserId { get; set; }
        public int? Estimation { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? WeightofBirds { get; set; }
        [Required]
        public string? BirdDescription { get; set; }
        [Required]
        public bool? BirdStatus { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int? Quantity { get; set; }

        public virtual TblUser User { get; set; } = null!;
        public virtual ICollection<TblComment> TblComments { get; set; }
        public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; }
        public virtual ICollection<Tblchildrenbird> Tblchildrenbirds { get; set; }
    }
}

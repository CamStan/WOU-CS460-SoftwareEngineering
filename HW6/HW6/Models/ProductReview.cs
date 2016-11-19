namespace HW6.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Production.ProductReview")]
    public partial class ProductReview
    {
        public int ProductReviewID { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string ReviewerName { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReviewDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(3850)]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using BootstrapBlazor.Components;
using System.ComponentModel;

namespace iDss.X.Models
{
    [Index(nameof(awb), IsUnique = true)]
    public class AWBInventory : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(15)]
        [Required]
        public string awb { get; set; }

        [Required]
        [ValidateNever]
        [Display(Name = "Branch")]
        public int branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [StringLength(50)]
        public string userlock { get; set; }

        public int flagprint { get; set; } = 1;
    }


}

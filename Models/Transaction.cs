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
    public class ShipmentDetail : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(15)]
        [Display(Name = "AWB")]
        [Required]
        public string awb { get; set; }

        [StringLength(100)]
        [Display(Name = "ReffNo")]
        public string? refno { get; set; }

        [StringLength(30)]
        public string? apireqid { get; set; }

        [StringLength(30)]
        [Display(Name = "DO Number")]
        public string? donumber { get; set; }

        [StringLength(30)]
        [Display(Name = "Buyer Order No")]
        public string? buyerorderno { get; set; }

        [StringLength(10)]
        [Display(Name = "Linehaul")]
        [Required]
        public string linehaul { get; set; }

        [StringLength(50)]
        [Display(Name = "Delivery Item")]
        [Required]
        public string deliveryitem { get; set; }

        [StringLength(15)]
        [Display(Name = "Pickup No")]
        public String? pickupno { get; set; }
        [ForeignKey("pickupno")]
        [ValidateNever]
        public PickupRequest PickupRequest { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateOnly pickupdate { get; set; }

        [StringLength(10)]
        [Display(Name = "HUB")]
        [Required]
        public string hubcode { get; set; }

        [Display(Name = "Pieces")]
        [Required]
        public int pieces { get; set; }

        [Display(Name = "Actual Weight")]
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal actweight { get; set; }

        [Display(Name = "Volume Weight")]
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal volweight { get; set; }

        [Display(Name = "Charge Weight")]
        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal chargeweight { get; set; }

        [StringLength(10)]
        [Required]
        public string unitweight { get; set; } = "kg";

        [StringLength(10)]
        [Display(Name = "Service")]
        [Required]
        public string service { get; set; } = "kg";

        [StringLength(30)]
        [Display(Name = "Packing Type")]
        [Required]
        public string? packingtype { get; set; }

        [StringLength(50)]
        [Display(Name = "Content")]
        [Required]
        public string content { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Item Value")]
        public decimal? itemvalue { get; set; }

        [StringLength(10)]
        [Display(Name = "Currency")]
        [Required]
        public string curr { get; set; } = "IDR";

        public int isinsurance { get; set; } = 0;

        [StringLength(100)]
        [Display(Name = "Notes")]
        public string? intruction { get; set; }

        [StringLength(10)]
        [Display(Name = "SLA")]
        public string? sla { get; set; }

        [StringLength(10)]
        [Required]
        public string trxtype { get; set; }

        [StringLength(50)]
        public string? session { get; set; }

        [StringLength(20)]
        [Display(Name = "Voucher Code")]
        public string? vouchercode { get; set; }

        public int iscod { get; set; } = 0;

        public int isnfd { get; set; } = 0;

        public int isrev { get; set; } = 0;

        public int isedit { get; set; } = 0;

        public int isnotif { get; set; } = 0;

        public int isprint { get; set; } = 0;

    }

}

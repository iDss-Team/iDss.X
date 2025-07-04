using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using BootstrapBlazor.Components;
using System.ComponentModel;

namespace iDss.X.Models
{
    [Index(nameof(pickupno), IsUnique = true)]
    public class PickupRequest : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [AutoGenerateColumn(Ignore = true)]
        public int id { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Pickup No")]
        public string pickupno { get; set; }

        [StringLength(30)]
        public string? apireqid { get; set; }

        [StringLength(15)]
        [Required]
        public string pickuptype { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "Account")]
        public String acctno { get; set; }
        [ForeignKey("acctno")]
        [ValidateNever]
        public Account Account { get; set; }

        [Display(Name = "Account Name")]
        [Required]
        public String acctname { get; set; }


        [StringLength(200)]
        [Display(Name = "Pickup Point")]
        public String? pickuppoint { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        public String addr { get; set; }

        [StringLength(6)]
        [Required]
        [Display(Name = "District")]
        public String distid { get; set; }
        [ForeignKey("distid")]
        [ValidateNever]
        public District District { get; set; }

        [StringLength(5, ErrorMessage = "Postal Code cannot be longer than 5 characters.")]
        [Display(Name = "Postal Code")]
        public String? postcode { get; set; }

        [StringLength(100)]
        public String? latitude { get; set; }

        [StringLength(100)]
        public String? longitude { get; set; }

        [StringLength(50)]
        [Display(Name = "PIC Name")]
        public String? picname { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        public String? phone { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [EmailAddress]
        public String? email { get; set; }

        [ValidateNever]
        [Display(Name = "Branch")]
        public int? branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [StringLength(50, ErrorMessage = "Branch Name cannot be longer than 50 characters.")]
        public string? branchname { get; set; }

        [StringLength(10)]
        [Display(Name = "Courier")]
        public String? couriercode { get; set; }
        [ForeignKey("couriercode")]
        [ValidateNever]
        public Courier Courier { get; set; }

        [StringLength(50, ErrorMessage = "Courier Name cannot be longer than 50 characters.")]
        public string? couriername { get; set; }

        [StringLength(20)]
        [Display(Name = "Transport Type")]
        public string? transporttype { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Pickup Date")]
        [Required]
        public DateOnly pickupdate { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public TimeOnly timefrom { get; set; } 

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Required]
        public TimeOnly timeto { get; set; }

        [StringLength(200, ErrorMessage = "notes cannot be longer than 50 characters.")]
        [Display(Name = "Notes")]
        public string? notes { get; set; }

        [NotMapped]
        public virtual ICollection<PickupStatusPool> PickupStatusPools { get; set; } = new List<PickupStatusPool>();

        [NotMapped]
        public virtual ICollection<ShipmentDetail> ShipmentDetails { get; set; } = new List<ShipmentDetail>();

        [NotMapped]
        public virtual ICollection<TrxStaging> TrxStagings { get; set; } = new List<TrxStaging>();

        [NotMapped]
        public virtual ICollection<SuccessPickup> SuccessPickups { get; set; } = new List<SuccessPickup>();

		[NotMapped]
		public virtual ICollection<CancelPickup> CancelPickups { get; set; } = new List<CancelPickup>();

		[NotMapped]
		public virtual ICollection<ReschedulePickup> ReschedulePickups { get; set; } = new List<ReschedulePickup>();

		[NotMapped]
		public virtual ICollection<ReassignPickup> ReassignPickups { get; set; } = new List<ReassignPickup>();

		[NotMapped]
		public virtual ICollection<UnsuccessPickup> UnsuccessPickups { get; set; } = new List<UnsuccessPickup>();
    }

    public class PickupStatusPool : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(15)]
        [Required]
        [Display(Name = "Pickup No")]
        public String pickupno { get; set; }
        [ForeignKey("pickupno")]
        [ValidateNever]
        public PickupRequest PickupRequest { get; set; }

        [StringLength(20)]
        [Required]
        public string pickupstatus { get; set; }

        [StringLength(100, ErrorMessage = "remarks cannot be longer than 50 characters.")]
        public string? remarks { get; set; }

    }

    public class PickupRegular : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(15)]
        [Required]
        public string pickuptype { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "Account")]
        public String acctno { get; set; }
        [ForeignKey("acctno")]
        [ValidateNever]
        public Account Account { get; set; }

        [Display(Name = "Account Name")]
        [Required]
        public String acctname { get; set; }

        [StringLength(200)]
        [Display(Name = "Pickup Point")]
        public String? pickuppoint { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        public String addr { get; set; }

        [StringLength(6)]
        [Required]
        [Display(Name = "District")]
        public String distid { get; set; }
        [ForeignKey("distid")]
        [ValidateNever]
        public District District { get; set; }

        [StringLength(5, ErrorMessage = "Postal Code cannot be longer than 5 characters.")]
        [Display(Name = "Postal Code")]
        public String? postcode { get; set; }

        [StringLength(100)]
        [Display(Name = "Latitude")]
        public String? latitude { get; set; }

        [StringLength(100)]
        [Display(Name = "Longitude")]
        public String? longitude { get; set; }

        [StringLength(50)]
        [Display(Name = "PIC Name")]
        public String? picname { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        public String? picphone { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public String? picemail { get; set; }

        [Display(Name = "Branch")]
        public int? branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [StringLength(10)]
        [Display(Name = "Courier")]
        public String? couriercode { get; set; }
        [ForeignKey("couriercode")]
        [ValidateNever]
        public Courier Courier { get; set; }

        [StringLength(50, ErrorMessage = "Courier Name cannot be longer than 50 characters.")]
        [Required]
        public string couriername { get; set; }

        [StringLength(20)]
        [Display(Name = "Transport Type")]
        public string? transporttype { get; set; }

        [StringLength(200, ErrorMessage = "notes cannot be longer than 50 characters.")]
        [Display(Name = "Notes")]
        public string? notes { get; set; }

        public int isautodispatch { get; set; } = 0;

        [NotMapped]
        public virtual ICollection<PickupSchedule> PickupSchedules { get; set; } = new List<PickupSchedule>();

    }

    public class PickupSchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int puregid { get; set; }
        [ForeignKey("puregid")]
        [ValidateNever]
        public PickupRegular PickupRegular { get; set; }

        [StringLength(10)]
        public string pickupday { get; set; }

        [Required]
        [Display(Name = "Shift")]
        public int shift { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Time From")]
        [Required]
        public TimeOnly timefrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Time To")]
        [Required]
        public TimeOnly timeto { get; set; }

    }

	public class SuccessPickup: CommonField3
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		[StringLength(15)]
		[Required]
		public string pickupno { get; set; }
		[ForeignKey("pickupno")]
		[ValidateNever]
		public PickupRequest PickupRequest { get; set; }

		[StringLength(20)]
		[Required]
		public string pickupstatus { get; set; }

		[StringLength(100)]
		public string? latitude { get; set; }

		[StringLength(100)]
		public string? longitude { get; set; }

		[StringLength(100)]
		public string? attach1 { get; set; }

		[StringLength(100)]
		public string? attach2 { get; set; }

		[Column(TypeName = "decimal(18,0)")]
		[Required]
		public decimal cashreceived { get; set; } = 0;

		[StringLength(100, ErrorMessage = "remarks cannot be longer than 50 characters.")]
		public string? remarks { get; set; }

	}

	public class CancelPickup: CommonField3
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		[StringLength(15)]
		[Required]
		public string pickupno { get; set; }
		[ForeignKey("pickupno")]
		[ValidateNever]
		public PickupRequest PickupRequest { get; set; }

		[StringLength(20)]
		[Required]
		public string pickupstatus { get; set; }

		[Required]
		public int reasonid { get; set; }

		[StringLength(100, ErrorMessage = "Reason Name cannot be longer than 50 characters.")]
		[Required]
		[Display(Name = "Reason Name")]
		public string reasonname { get; set; }

		[StringLength(50, ErrorMessage = "Requestor cannot be longer than 50 characters.")]
		[Required]
		[Display(Name = "Requestor")]
		public string requestor { get; set; }

		[StringLength(100)]
		public string? attachment { get; set; }

		[StringLength(100, ErrorMessage = "remarks cannot be longer than 50 characters.")]
		public string? remarks { get; set; }

	}

	public class ReschedulePickup : CommonField3
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		[StringLength(15)]
		[Required]
		public string pickupno { get; set; }
		[ForeignKey("pickupno")]
		[ValidateNever]
		public PickupRequest PickupRequest { get; set; }

		[StringLength(20)]
		[Required]
		public string pickupstatus { get; set; }

		[Required]
		public int reasonid { get; set; }

		[StringLength(100, ErrorMessage = "Reason Name cannot be longer than 50 characters.")]
		[Required]
		[Display(Name = "Reason Name")]
		public string reasonname { get; set; }

		[StringLength(50, ErrorMessage = "Requestor cannot be longer than 50 characters.")]
		[Required]
		[Display(Name = "Requestor")]
		public string requestor { get; set; }

		[StringLength(100, ErrorMessage = "remarks cannot be longer than 50 characters.")]
		public string? remarks { get; set; }

	}

	public class ReassignPickup : CommonField3
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		[StringLength(15)]
		[Required]
		public string pickupno { get; set; }
		[ForeignKey("pickupno")]
		[ValidateNever]
		public PickupRequest PickupRequest { get; set; }

		[StringLength(20)]
		[Required]
		public string pickupstatus { get; set; }

		[Required]
		public int reasonid { get; set; }

		[StringLength(100, ErrorMessage = "Reason Name cannot be longer than 50 characters.")]
		[Required]
		[Display(Name = "Reason Name")]
		public string reasonname { get; set; }

		[StringLength(50, ErrorMessage = "Previous Courier cannot be longer than 50 characters.")]
		[Required]
		[Display(Name = "Previous Courier")]
		public string prevcourier { get; set; }

		[StringLength(100, ErrorMessage = "remarks cannot be longer than 50 characters.")]
		public string? remarks { get; set; }

	}

	public class UnsuccessPickup : CommonField3
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }

		[StringLength(15)]
		[Required]
		public string pickupno { get; set; }
		[ForeignKey("pickupno")]
		[ValidateNever]
		public PickupRequest PickupRequest { get; set; }

		[StringLength(20)]
		[Required]
		public string pickupstatus { get; set; }

		[Required]
		public int reasonid { get; set; }

		[StringLength(100, ErrorMessage = "Reason Name cannot be longer than 50 characters.")]
		[Required]
		[Display(Name = "Reason Name")]
		public string reasonname { get; set; }

		[StringLength(100, ErrorMessage = "remarks cannot be longer than 50 characters.")]
		public string? remarks { get; set; }

	}

}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using BootstrapBlazor.Components;
using System.ComponentModel;
using System.Numerics;

namespace iDss.X.Models
{
    [Index(nameof(awb), IsUnique = true)]
    public class ShipmentDetail : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

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
        public string service { get; set; }

        [StringLength(30)]
        [Display(Name = "Packing Type")]
        [Required]
        public string? packingtype { get; set; }

        [StringLength(50)]
        [Display(Name = "Content")]
        [Required]
        public string content { get; set; }

        [Column(TypeName = "decimal(18,0)")]
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

        [NotMapped]
        public ShipperDetail ShipperDetail { get; set; }

        [NotMapped]
        public ConsigneeDetail ConsigneeDetail { get; set; }

        [NotMapped]
        public PaymentDetail PaymentDetail { get; set; }

        [NotMapped]
        public VoidTransaction VoidTransaction { get; set; }
    }

    [Index(nameof(awb), IsUnique = true)]
    public class ShipperDetail : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(15)]
        [Display(Name = "AWB")]
        [Required]
        public string awb { get; set; }

        [Required]
        [Display(Name = "Branch Ori")]
        public int branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [StringLength(30)]
        [Display(Name = "Account")]
        public String? acctno { get; set; }
        [ForeignKey("acctno")]
        [ValidateNever]
        public Account Account { get; set; }

        [StringLength(50, ErrorMessage = "Shipper Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Name")]
        public string shippername { get; set; }

        [StringLength(50, ErrorMessage = "Attention Name cannot be longer than 50 characters.")]
        [Display(Name = "Attention Name")]
        public string attname { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        public string addr1 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        public string? addr2 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        public string? addr3 { get; set; }

        [StringLength(3)]
        [Required]
        public string countrycode { get; set; } = "ID";

        [StringLength(6)]
        [Required]
        [Display(Name = "District")]
        public string distid { get; set; }
        [ForeignKey("distid")]
        [ValidateNever]
        public District District { get; set; }

        [StringLength(50)]
        [Display(Name = "City")]
        public string? cityname { get; set; }

        [StringLength(50)]
        [Display(Name = "Province")]
        public string? provname { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string? postcode { get; set; }

        [StringLength(100)]
        public string? shplat { get; set; }

        [StringLength(100)]
        public string? shplong { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        public string? phone { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? email { get; set; }

        [StringLength(10, ErrorMessage = "Origin Code cannot be longer than 10 characters.")]
        [Display(Name = "Origin Code")]
        [Required]
        public string oricode { get; set; }

        [StringLength(10, ErrorMessage = "Cost Center cannot be longer than 10 characters.")]
        [Display(Name = "Cost Center")]
        public string? costcenter { get; set; }

        [NotMapped]
        public ShipmentDetail ShipmentDetail { get; set; }
    }

    [Index(nameof(awb), IsUnique = true)]
    public class ConsigneeDetail : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(15)]
        [Display(Name = "AWB")]
        [Required]
        public string awb { get; set; }

        [Display(Name = "Branch Cnee")]
        public int? branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [StringLength(30)]
        [Display(Name = "Account")]
        public String? acctno { get; set; }
        [ForeignKey("acctno")]
        [ValidateNever]
        public Account Account { get; set; }

        [StringLength(50, ErrorMessage = "Consignee Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Name")]
        public string cnename { get; set; }

        [StringLength(50, ErrorMessage = "Attention Name cannot be longer than 50 characters.")]
        [Display(Name = "Attention Name")]
        public string attname { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        public string addr1 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        public string? addr2 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        public string? addr3 { get; set; }

        [StringLength(3)]
        [Required]
        public string countrycode { get; set; } = "ID";

        [StringLength(6)]
        [Required]
        [Display(Name = "District")]
        public string distid { get; set; }
        [ForeignKey("distid")]
        [ValidateNever]
        public District District { get; set; }

        [StringLength(50)]
        [Display(Name = "City")]
        public string? cityname { get; set; }

        [StringLength(50)]
        [Display(Name = "Province")]
        public string? provname { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string? postcode { get; set; }

        [StringLength(100)]
        public string? cnelat { get; set; }

        [StringLength(100)]
        public string? cnelong { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        public string? phone { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? email { get; set; }

        [StringLength(10, ErrorMessage = "Origin Code cannot be longer than 10 characters.")]
        [Display(Name = "Destination Code")]
        [Required]
        public string descode { get; set; }

        [StringLength(10, ErrorMessage = "Cost Center cannot be longer than 10 characters.")]
        [Display(Name = "Cost Center")]
        public string? costcenter { get; set; }

        [NotMapped]
        public ShipmentDetail ShipmentDetail { get; set; }
    }

    public class CneeDirectory : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50, ErrorMessage = "Consignee Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Name")]
        public string cnename { get; set; }

        [StringLength(50, ErrorMessage = "Attention Name cannot be longer than 50 characters.")]
        [Display(Name = "Attention Name")]
        public string attname { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        public string addr1 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        public string? addr2 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        public string? addr3 { get; set; }

        [StringLength(3)]
        [Required]
        public string countrycode { get; set; } = "ID";

        [StringLength(6)]
        [Required]
        [Display(Name = "District")]
        public string distid { get; set; }
        [ForeignKey("distid")]
        [ValidateNever]
        public District District { get; set; }

        [StringLength(50)]
        [Display(Name = "City")]
        public string? cityname { get; set; }

        [StringLength(50)]
        [Display(Name = "Province")]
        public string? provname { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string? postcode { get; set; }

        [StringLength(100)]
        public string? cnelat { get; set; }

        [StringLength(100)]
        public string? cnelong { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        public string? phone { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? email { get; set; }

        [StringLength(10, ErrorMessage = "Origin Code cannot be longer than 10 characters.")]
        [Display(Name = "Destination Code")]
        [Required]
        public string descode { get; set; }

        [StringLength(10, ErrorMessage = "Cost Center cannot be longer than 10 characters.")]
        [Display(Name = "Cost Center")]
        public string? costcenter { get; set; }
    }

    [Index(nameof(awb), IsUnique = true)]
    public class PaymentDetail : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(15)]
        [Display(Name = "AWB")]
        [Required]
        public string awb { get; set; }

        [StringLength(30)]
        [Required]
        [Display(Name = "Payment Type")]
        public string paymenttype { get; set; }

        [StringLength(30)]
        [Display(Name = "Payment Gateway")]
        public string? paymentgateway { get; set; }

        [StringLength(10)]
        [Required]
        [Display(Name = "Payment Status")]
        public string? paymentstatus { get; set; }

        [NotMapped]
        public ShipmentDetail ShipmentDetail { get; set; }
    }

    public class CostItem : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(15)]
        [Display(Name = "AWB")]
        [Required]
        public string awb { get; set; }

        [StringLength(30)]
        [Required]
        public string componetname { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        [Required]
        public decimal debit { get; set; } = 0;

        [Column(TypeName = "decimal(18,0)")]
        [Required]
        public decimal credit { get; set; } = 0;
    }

    public class UnitItem : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(15)]
        [Display(Name = "AWB")]
        [Required]
        public string awb { get; set; }

        [StringLength(30, ErrorMessage = "Item Code cannot be longer than 30 characters.")]
        [Display(Name = "Item Code")]
        public string? itemcode { get; set; }

        [StringLength(50, ErrorMessage = "Item Name cannot be longer than 50 characters.")]
        [Display(Name = "Item Name")]
        public string? itemname { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal actweight { get; set; } = 1;

        [Column(TypeName = "decimal(10,0)")]
        [Required]
        public decimal length { get; set; } = 0;

        [Column(TypeName = "decimal(10,0)")]
        [Required]
        public decimal width { get; set; } = 0;

        [Column(TypeName = "decimal(10,0)")]
        [Required]
        public decimal height { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        [Required]
        public decimal volweight { get; set; } = 0;
    }

    public class CheckpointPool : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(15)]
        [Display(Name = "AWB")]
        [Required]
        public string awb { get; set; }

        [StringLength(3)]
        [Required]
        public string cpcode { get; set; }

        [StringLength(50)]
        public string? cpname { get; set; }

        [StringLength(100)]
        [Display(Name = "Notes")]
        public string? remarks { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime cpdatetime { get; set; }

        [StringLength(100)]
        public string? latitude { get; set; }

        [StringLength(100)]
        public string? longitude { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public int branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [StringLength(50)]
        [Display(Name = "Branch Name")]
        public String? branchname { get; set; }

        [StringLength(10)]
        [Display(Name = "Courier")]
        public String? couriercode { get; set; }
        [ForeignKey("couriercode")]
        [ValidateNever]
        public Courier Courier { get; set; }

        [StringLength(50)]
        [Display(Name = "Recipient")]
        public String? recipient { get; set; }

        [Display(Name = "Relation")]
        public int? relationid { get; set; }
        [ForeignKey("relationid")]
        [ValidateNever]
        public Relation Relation { get; set; }

        [Display(Name = "Reason")]
        public int? reasonid { get; set; }
        [ForeignKey("reasonid")]
        [ValidateNever]
        public ReasonUN ReasonUN { get; set; }

        [Required]
        public int attempt { get; set; } = 1;

        [Required]
        public int islastpoint { get; set; } = 1;

        [Required]
        public int isoversla { get; set; } = 0;
    }

    public class Attachment : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(15)]
        [Display(Name = "AWB")]
        [Required]
        public string awb { get; set; }

        [StringLength(3)]
        [Required]
        public string cpcode { get; set; }

        [StringLength(100)]
        public string? url1 { get; set; }

        [StringLength(100)]
        public string? url2 { get; set; }

        [StringLength(100)]
        public string? url3 { get; set; }

        [StringLength(100)]
        public string? url4 { get; set; }

        [StringLength(100)]
        public string? url5 { get; set; }

        [StringLength(100)]
        public string? urlsignature { get; set; }

        [Required]
        public int isadjust { get; set; } = 0;
    }

    [Index(nameof(awb), IsUnique = true)]
    public class VoidTransaction : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(15)]
        [Display(Name = "AWB")]
        [Required]
        public string awb { get; set; }

        [Required]
        [Display(Name = "Branch")]
        public int branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [StringLength(50)]
        public string? requestpoint { get; set; }

        [StringLength(200)]
        [Display(Name = "Reason")]
        [Required]
        public string reasonvoid { get; set; }

        [Required]
        public int approval { get; set; } = 0;

        [StringLength(200)]
        [Display(Name = "Approver")]
        public string? approver { get; set; }

        [StringLength(100)]
        [Display(Name = "Remarks")]
        public string remarks { get; set; }

        [NotMapped]
        public ShipmentDetail ShipmentDetail { get; set; }
    }

    public class GeneralPrice : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [StringLength(10)]
        [Display(Name = "Origin Type")]
        [Required]
        public string oritype { get; set; }

        [StringLength(15)]
        [Display(Name = "Origin ID")]
        [Required]
        public string oricode { get; set; }

        [StringLength(10)]
        [Display(Name = "Destination Type")]
        [Required]
        public string destype { get; set; }

        [StringLength(15)]
        [Display(Name = "Destination ID")]
        [Required]
        public string descode { get; set; }

        [StringLength(10)]
        [Display(Name = "Service")]
        public string? service { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Min Weight")]
        public decimal? minweight { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Min Weight")]
        public decimal? maxweight { get; set; }

        [Display(Name = "Min Pieces")]
        public int? minpiece { get; set; }

        [Display(Name = "Min Pieces")]
        public int? maxpiece { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "Price")]
        public decimal price { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "Additional Price")]
        public decimal? addprice { get; set; } = 0;

        public int? slafrom { get; set; }

        public int? slato { get; set; }
    }

	public class TrxStaging : CommonField2
	{
		//Shipment Detail]
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long id { get; set; }

		[StringLength(15)]
		[Display(Name = "AWB")]
		public string? awb { get; set; }

		[StringLength(100)]
		[Display(Name = "ReffNo")]
		public string? refno { get; set; }

		[StringLength(15)]
		[Display(Name = "Pickup No")]
		public string? pickupno { get; set; }
		[ForeignKey("pickupno")]
		[ValidateNever]
		public PickupRequest PickupRequest { get; set; }

		[StringLength(30)]
		public string? apireqid { get; set; }

		[StringLength(30)]
		[Display(Name = "DO Number")]
		public string? donumber { get; set; }

		[StringLength(30)]
		[Display(Name = "Buyer Order No")]
		public string? buyerorderno { get; set; }

		[DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
		public DateOnly? pickupdate { get; set; }

		[StringLength(10)]
		[Display(Name = "Linehaul")]
		[Required]
		public string linehaul { get; set; }

		[StringLength(50)]
		[Display(Name = "Delivery Item")]
		[Required]
		public string deliveryitem { get; set; }

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
		public string service { get; set; }

		[StringLength(30)]
		[Display(Name = "Packing Type")]
		[Required]
		public string? packingtype { get; set; }

		[StringLength(50)]
		[Display(Name = "Content")]
		[Required]
		public string content { get; set; }

		[Column(TypeName = "decimal(18,0)")]
		[Display(Name = "Item Value")]
		public decimal? itemvalue { get; set; }

		[StringLength(10)]
		[Display(Name = "Currency")]
		[Required]
		public string curr { get; set; } = "IDR";

		[StringLength(100)]
		[Display(Name = "Notes")]
		public string? intruction { get; set; }

        [StringLength(10)]
        [Required]
        public string trxtype { get; set; } = "api";

		[StringLength(50)]
		public string? session { get; set; }
        
        
		//Shipper Detail
		[Required]
		[Display(Name = "Branch Ori")]
		public int branchori { get; set; }
		[ForeignKey("branchori")]
		[ValidateNever]
		public Branch BranchOri { get; set; }

		[StringLength(30)]
		[Display(Name = "Account")]
		public String? acctno { get; set; }
		[ForeignKey("acctno")]
		[ValidateNever]
		public Account Account { get; set; }

		[StringLength(50, ErrorMessage = "Shipper Name cannot be longer than 50 characters.")]
		[Required]
		[Display(Name = "Name")]
		public string shippername { get; set; }

		[StringLength(50, ErrorMessage = "Attention Name cannot be longer than 50 characters.")]
		[Display(Name = "Attention Name")]
		public string s_attname { get; set; }

		[StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
		[Display(Name = "Address")]
		[Required]
		public string s_addr1 { get; set; }

		[StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
		public string? s_addr2 { get; set; }

		[StringLength(3)]
		[Required]
		public string s_countrycode { get; set; } = "ID";

		[StringLength(6)]
		[Required]
		[Display(Name = "District")]
		public string s_distid { get; set; }
		[ForeignKey("s_distid")]
		[ValidateNever]
		public District DistrictOri { get; set; }

		[StringLength(50)]
		[Display(Name = "City")]
		public string? s_cityname { get; set; }

		[StringLength(50)]
		[Display(Name = "Province")]
		public string? s_provname { get; set; }

		[StringLength(10)]
		[Display(Name = "Postal Code")]
		public string? s_postcode { get; set; }

		[StringLength(100)]
		public string? shplat { get; set; }

		[StringLength(100)]
		public string? shplong { get; set; }

		[StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
		[Display(Name = "Phone")]
		public string? s_phone { get; set; }

		[StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
		[Display(Name = "Email")]
		[EmailAddress]
		public string? s_email { get; set; }

		[StringLength(10, ErrorMessage = "Origin Code cannot be longer than 10 characters.")]
		[Display(Name = "Origin Code")]
		[Required]
		public string oricode { get; set; }

		[StringLength(10, ErrorMessage = "Cost Center cannot be longer than 10 characters.")]
		[Display(Name = "Cost Center")]
		public string? costcenter { get; set; }


		//Consignee Detail
		[Display(Name = "Branch Cnee")]
		public int? branchcne { get; set; }
		[ForeignKey("branchcne")]
		[ValidateNever]
		public Branch BranchCne { get; set; }

		[StringLength(50, ErrorMessage = "Consignee Name cannot be longer than 50 characters.")]
		[Required]
		[Display(Name = "Name")]
		public string cnename { get; set; }

		[StringLength(50, ErrorMessage = "Attention Name cannot be longer than 50 characters.")]
		[Display(Name = "Attention Name")]
		public string c_attname { get; set; }

		[StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
		[Display(Name = "Address")]
		[Required]
		public string c_addr1 { get; set; }

		[StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
		public string? c_addr2 { get; set; }

		[StringLength(3)]
		[Required]
		public string c_countrycode { get; set; } = "ID";

		[StringLength(6)]
		[Required]
		[Display(Name = "District")]
		public string c_distid { get; set; }
		[ForeignKey("c_distid")]
		[ValidateNever]
		public District DistrictCne { get; set; }

		[StringLength(50)]
		[Display(Name = "City")]
		public string? c_cityname { get; set; }

		[StringLength(50)]
		[Display(Name = "Province")]
		public string? c_provname { get; set; }

		[StringLength(10)]
		[Display(Name = "Postal Code")]
		public string? c_postcode { get; set; }

		[StringLength(100)]
		public string? cnelat { get; set; }

		[StringLength(100)]
		public string? cnelong { get; set; }

		[StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
		[Display(Name = "Phone")]
		public string? c_phone { get; set; }

		[StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
		[Display(Name = "Email")]
		[EmailAddress]
		public string? c_email { get; set; }

		[StringLength(10, ErrorMessage = "Origin Code cannot be longer than 10 characters.")]
		[Display(Name = "Destination Code")]
		[Required]
		public string descode { get; set; }


		//Other Detail

		[StringLength(100)]
		public string? attach1 { get; set; }

		[StringLength(100)]
		public string? attach2 { get; set; }

		[StringLength(20)]
		[Display(Name = "Voucher Code")]
		public string? vouchercode { get; set; }

		public int isinsurance { get; set; } = 0;

		public int iscod { get; set; } = 0;

		[StringLength(10)]
		public string? codtype { get; set; }

		[Column(TypeName = "decimal(18,0)")]
		[Required]
		public decimal codamount { get; set; } = 0;

		public int isnfd { get; set; } = 0;

		public int isrev { get; set; } = 0;

		public int isnotif { get; set; } = 0;

		public int isdrop { get; set; } = 0;

		public int isprod { get; set; } = 0;


		//Payment Detail
		[Column(TypeName = "decimal(18,0)")]
		[Required]
		public decimal deliverycost { get; set; } = 0;

		[Column(TypeName = "decimal(18,0)")]
		[Required]
		public decimal packingcost { get; set; } = 0;

		[Column(TypeName = "decimal(18,0)")]
		[Required]
		public decimal insurancecost { get; set; } = 0;

		[Column(TypeName = "decimal(18,0)")]
		[Required]
		public decimal addcost { get; set; } = 0;

		[Column(TypeName = "decimal(18,0)")]
		[Required]
		public decimal totaldiscount { get; set; } = 0;

		[StringLength(30)]
		[Required]
		[Display(Name = "Payment Type")]
		public string paymenttype { get; set; } = "Invoice";

		[StringLength(30)]
		[Display(Name = "Payment Gateway")]
		public string? paymentgateway { get; set; }

		[StringLength(100)]
		[Display(Name = "Reference Pay ID")]
		public string? refpayid { get; set; }

		[StringLength(10)]
		[Required]
		[Display(Name = "Payment Status")]
		public string? paymentstatus { get; set; }
	}

}

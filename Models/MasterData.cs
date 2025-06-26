using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using BootstrapBlazor.Components;
using System.ComponentModel;

namespace iDss.X.Models
{
    public class Branch : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [AutoGenerateColumn(Ignore = true)]
        public int branchid { get; set; }

        [StringLength(50, ErrorMessage = "Branch Name cannot be longer than 50 characters.")]
        [Display(Name = "Branch Name")]
        [Required]
        [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true, GroupName = "General", GroupOrder = 1, ComponentType = typeof(BootstrapInput<string>))]
        public String branchname { get; set; }

        [StringLength(10)] 
        [Display(Name = "Branch Code")]
        [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true, GroupName = "General", GroupOrder = 1, Cols = 4, ComponentType = typeof(BootstrapInput<string>))]
        public String? branchcode { get; set; }

        [StringLength(10)]
        [Display(Name = "Branch Type")]
        [AutoGenerateColumn(Order = 5, GroupName = "General", GroupOrder = 1, ComponentType = typeof(BootstrapInput<string>))]
        public String? branchtype { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        [AutoGenerateColumn(Order = 30, GroupName = "Location", GroupOrder = 2, Cols = 12, ComponentType = typeof(Textarea))]
        public String addr1 { get; set; }

        [StringLength(300)]
        [AutoGenerateColumn(Order = 31, GroupName = "Location", GroupOrder = 2, Cols = 6, Visible = false, ComponentType = typeof(BootstrapInput<string>))]
        public String? addr2 { get; set; }

        [StringLength(300)]
        [AutoGenerateColumn(Order = 32, GroupName = "Location", GroupOrder = 2, Cols = 6, Visible = false, ComponentType = typeof(BootstrapInput<string>))]
        public String? addr3 { get; set; }

        [StringLength(10)]
        [ValidateNever]
        [Required]
        [Display(Name = "Village")]
        [AutoGenerateColumn(Order = 35, GroupName = "Location", GroupOrder = 2, Visible = false, ComponentType = typeof(Select<string>), LookupServiceKey = "branch.villages")]
        public String villid { get; set; }
        [ForeignKey("villid")]
        [ValidateNever]
        [AutoGenerateColumn(Ignore = true)]
        public Village? Village { get; set; }

        [StringLength(50)]
        [AutoGenerateColumn(Order = 36, Visible = false, GroupName = "Location", GroupOrder = 2, Readonly = true, ComponentType = typeof(BootstrapInput<string>))]
        public String? distname { get; set; }

        [StringLength(50)]
        [AutoGenerateColumn(Order = 37, Visible = false, GroupName = "Location", GroupOrder = 2, Readonly = true, ComponentType = typeof(BootstrapInput<string>))]
        public String? cityname { get; set; }

        [StringLength(50)]
        [AutoGenerateColumn(Order = 38, Visible = false, GroupName = "Location", GroupOrder = 2, Readonly = true, ComponentType = typeof(BootstrapInput<string>))]
        public String? provname { get; set; }

        [StringLength(5, ErrorMessage = "Postal Code cannot be longer than 5 characters.")]
        [Display(Name = "Postal Code")]
        [AutoGenerateColumn(Order = 39, Visible = false, GroupName = "Location", GroupOrder = 2, ComponentType = typeof(BootstrapInput<string>))]
        public String? postcode { get; set; }

        [StringLength(100)]
        [Display(Name = "Latitude")]
        [Required]
        [AutoGenerateColumn(Order = 41, Visible = false, GroupName = "Location", GroupOrder = 2, ComponentType = typeof(BootstrapInput<string>))]
        public String latitude { get; set; }

        [StringLength(100)]
        [Display(Name = "Longitude")]
        [Required]
        [AutoGenerateColumn(Order = 42, Visible = false, GroupName = "Location", GroupOrder = 2, ComponentType = typeof(BootstrapInput<string>))]
        public String longitude { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [AutoGenerateColumn(Order= 10, Visible = false, GroupName = "General", GroupOrder = 1, ComponentType = typeof(BootstrapInput<string>))]
        public String? phone { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [AutoGenerateColumn(Order = 11, Visible = false, GroupName = "General", GroupOrder = 1, ComponentType = typeof(BootstrapInput<string>))]
        public String? phonealt { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [EmailAddress]
        [AutoGenerateColumn(Order = 12, Visible = false, GroupName = "General", GroupOrder = 1, ComponentType = typeof(BootstrapInput<string>))]
        public String? email { get; set; }

        [StringLength(50)]
        [Display(Name = "HO Name")]
        [AutoGenerateColumn(Order = 90, Visible = false, GroupName = "General", GroupOrder = 1, ComponentType = typeof(BootstrapInput<string>))]
        public String? honame { get; set; }

        [StringLength(50)]
        [Display(Name = "PIC Name")]
        [AutoGenerateColumn(Order = 15, Visible = false, GroupName = "General", GroupOrder = 1, ComponentType = typeof(BootstrapInput<string>))]
        public String? picname { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "PIC Phone No")]
        [AutoGenerateColumn(Order = 17, Visible = false, GroupName = "General", GroupOrder = 1, ComponentType = typeof(BootstrapInput<string>))]
        public String? picno { get; set; }

        [StringLength(3)]
        [AutoGenerateColumn(Order = 20, Visible = false, GroupName = "General", GroupOrder = 1, ComponentType = typeof(BootstrapInput<string>))]
        public String? citycode { get; set; }

        [StringLength(10)]
        [Display(Name = "Branch Size")]
        public String? branchsize { get; set; }

        public List<Courier> couriers {  get; set; } 

        [NotMapped]
        public virtual ICollection<ShipperDetail> Shippers { get; set; } = new List<ShipperDetail>();

        [NotMapped]
        public virtual ICollection<ConsigneeDetail> Consignees { get; set; } = new List<ConsigneeDetail>();
    }

    [Index(nameof(couriercode), IsUnique = true)]
    public class Courier : CommonField2
    {
        [Key]
        [StringLength(30)]
        [Display(Name = "NIP")]
        [Required]
        public String nip { get; set; }

        [StringLength(10)]
        [Required]
        public String couriercode { get; set; }

        [StringLength(50, ErrorMessage = "Courier Name cannot be longer than 50 characters.")]
        [Required]
        public String couriername { get; set; }

        [StringLength(6)]
        [ValidateNever]
        [Required]
        [Display(Name = "District")]
        public String distid { get; set; }
        [ForeignKey("distid")]
        [ValidateNever]
        public District District { get; set; }

        [ValidateNever]
        [Required]
        [Display(Name = "Branch")]
        public int branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Required]
        public String phone { get; set; }

        [Display(Name = "Delivery Frequency")]
        public int? freqdelivery { get; set; }

        [Display(Name = "Fuel Quota")]
        public int? fuelquota { get; set; }

        public int? status { get; set; }

        [NotMapped]
        public string branchname { get; set; }

        [NotMapped]
        public virtual ICollection<PickupRequest> PickupRequests { get; set; } = new List<PickupRequest>();

        [NotMapped]
        public virtual ICollection<CheckpointPool> CheckpointPools { get; set; } = new List<CheckpointPool>();

        [NotMapped]
        public virtual ICollection<PickupRegular> PickupRegulars { get; set; } = new List<PickupRegular>();

    }

    public class Industry : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [AutoGenerateColumn(Ignore = true)]
        public int id { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Industry Name")]
        [AutoGenerateColumn(Order = 70, Cols = 12, Searchable = true, Filterable = true)]
        public String industryname { get; set; }

        [Display(Name = "Description")]
        [AutoGenerateColumn(Order = 70, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
        public String? description { get; set; }

        [AutoGenerateColumn(Ignore = true)]
        [NotMapped]
        public virtual ICollection<CIF> CIFs { get; set; } = new List<CIF>();

    }

    public class CIF : CommonField2
    {
        [Key]
        [StringLength(30)]
        [Required]
        [Display(Name = "CIF")]
        public String cif { get; set; }

        [StringLength(150, ErrorMessage = "CIF Name cannot be longer than 150 characters.")]
        [Display(Name = "CIF Name" )]
        public String? cifname { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a industry")]
        [Required]
        [Display(Name = "Industry")]
        public int industryid { get; set; }
        [ForeignKey("industryid")]
        [ValidateNever]
        public Industry Industry { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a branch")]
        [Required]
        [Display(Name = "Branch")]
        public int branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [ValidateNever]
        [NotMapped]
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    }

    public class Account : CommonField2
    {
        [Key]
        [StringLength(30)]
        [Display(Name = "Account No")]
        public String acctno { get; set; }

        [StringLength(150, ErrorMessage = "Account Name cannot be longer than 150 characters.")]
        [Required]
        [Display(Name = "Account Name")]
        public String acctname { get; set; }

        [StringLength(30)]
        [ValidateNever]
        [Required]
        [Display(Name = "CIF")]
        public String cif { get; set; }
        [ForeignKey("cif")]
        [ValidateNever]
        public CIF CIF { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a branch")]
        [Required]
        [Display(Name = "Branch")]
        public int branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever]
        public Branch Branch { get; set; }

        [StringLength(50)]
        [Display(Name = "Line of Business")]
        public String? lob { get; set; }

        [StringLength(10)]
        [Display(Name = "Cost Center")]
        public String? costcenter { get; set; }

        [StringLength(30)]
        [Display(Name = "Rekening No")]
        public String? bankacctno { get; set; }

        [StringLength(30)]
        [Display(Name = "Bank Name")] 
        public String? bankacctname { get; set; }

        [StringLength(10)]
        [Display(Name = "Bank Code")] 
        public String? bankcode { get; set; }

        [StringLength(30)]
        [Display(Name = "FRP No")] 
        public String? frp { get; set; }

        [DisplayFormat(DataFormatString = "{yyyy/MMM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Agreement Date")]
        public DateTime? agreedate { get; set; }

        [DisplayFormat(DataFormatString = "{yyyy/MMM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expired Date")]
        public DateTime? agreeexpire { get; set; }

        [StringLength(30)]
        [Display(Name = "Term of Payment")]
        public String? termofpayment { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        [Display(Name = "Credit Limit")]
        public decimal? creditlimit { get; set; }

        [StringLength(30)]
        [Display(Name = "Credit Period")]
        public String? creditperiod { get; set; }

        public int? iscod { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "COD Fee")]
        public decimal? feecod { get; set; }

        [Display(Name = "Intl Transaction")]
        public int? isintl { get; set; } = 0;

        public int? isnl { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Discount Rates")]
        public decimal? discrates { get; set; }

        [Display(Name = "DO Transaction")]
        public int? isrev { get; set; } = 0;

        [Display(Name = "Trace in Apps")]
        public int? istrace { get; set; } = 0;

        [Display(Name = "VAT")]
        public int? isvat{ get; set; } = 0;

        //option : exclude & include
        [StringLength(10)]
        [Display(Name = "VAT Type")]
        public String? vattype { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "PPN")]
        public decimal? ppn { get; set; }

        //option : ncs & customer
        [StringLength(10)]
        [Display(Name = "VAT Type")]
        public String? stampcosttype { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Management Fee")]
        public decimal? mgmtfee{ get; set; }

        [NotMapped]
        public virtual ICollection<AccountAddr> AccountAddrs { get; set; } = new List<AccountAddr>();

        [NotMapped]
        public virtual ICollection<AccountCro> AccountCros { get; set; } = new List<AccountCro>();

        [NotMapped]
        public virtual ICollection<ShipperDetail> Shippers { get; set; } = new List<ShipperDetail>();

        [NotMapped]
        public virtual ICollection<ConsigneeDetail> Consignees { get; set; } = new List<ConsigneeDetail>();

    }

    public class AccountAddr : CommonField1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int id { get; set; }

        [StringLength(30)]
        [ValidateNever]
        [Required]
        [Display(Name = "Account")]
        public String acctno { get; set; }
        [ForeignKey("acctno")]
        [ValidateNever]
        public Account Account { get; set; }

        [StringLength(10)]
        [Display(Name = "Address Type")]
        [Required]
        public string addrtype { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        public string addr1 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address 2")]
        public string? addr2 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address 3")]
        public string? addr3 { get; set; }

        [StringLength(6)]
        [ValidateNever]
        [Required]
        [Display(Name = "District")]
        public String distid { get; set; }
        [ForeignKey("distid")]
        [ValidateNever]
        public District District { get; set; }

        [StringLength(50)]
        [Display(Name = "City")]
        public string? cityname { get; set; }

        [StringLength(50)]
        [Display(Name = "Province")]
        public string? provname { get; set; }

        [StringLength(5)]
        [Display(Name = "Postal Code")]
        public string? postcode { get; set; }

        [StringLength(100)]
        public string? latitude { get; set; }

        [StringLength(100)]
        public string? longitude { get; set; }

        [StringLength(50)]
        [Display(Name = "PIC Name")]
        public string? picname { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        public string? phone { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? email { get; set; }
    }

    [Keyless]
    public class BranchAccount : CommonField1
    {
        [ValidateNever][Required][Display(Name = "Branch")] public int branchid { get; set; }
        [ForeignKey("branchid")][ValidateNever] public Branch Branch { get; set; }

        [StringLength(30)][ValidateNever][Required][Display(Name = "Account")] public String acctno { get; set; }
        [ForeignKey("acctno")][ValidateNever] public Account Account { get; set; }
    }

    public class CRO : CommonField2
    {
        [Key][StringLength(10)] public String crocode { get; set; }

        [StringLength(50)]
        [Display(Name = "CRO Name")]
        [Required]
        public String croname { get; set; }

        [ValidateNever][Required][Display(Name = "Branch")] public int branchid { get; set; }
        [ForeignKey("branchid")][ValidateNever] public Branch Branch { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string? email { get; set; }

        [StringLength(30)]
        [Display(Name = "NIP")]
        public string? nip { get; set; }

        [Display(Name = "Sales Target")] 
        public int? salestarget { get; set; }

        [DisplayFormat(DataFormatString = "{yyyy/MMM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Join Date")]
        public DateTime? joindate { get; set; }

        [NotMapped]
        public virtual ICollection<AccountCro> AccountCros { get; set; } = new List<AccountCro>();

    }

    [Keyless]
    public class AccountCro : CommonField1
    {
        [StringLength(30)][ValidateNever][Required][Display(Name = "Account")] public String acctno { get; set; }
        [ForeignKey("acctno")][ValidateNever] public Account Account { get; set; }

        [StringLength(10)][ValidateNever][Required][Display(Name = "CRO")] public String crocode { get; set; }
        [ForeignKey("crocode")][ValidateNever] public CRO CRO { get; set; }
    }

    public class Province : CommonField2
    {
        [Key]
        [StringLength(2)]
        [Required]
        [AutoGenerateColumn(Order = 1)]
        [Display(Name = "Province ID")]
        public String provid { get; set; }

        [StringLength(50)]
        [AutoGenerateColumn(Order = 2)]
        [Display(Name = "Province")]
        [Required]
        public String provname { get; set; }

    }

    public class City : CommonField2
    {
        [Key]
        [StringLength(4)]
        [Display(Name = "City ID")]
        [Required]
        public String cityid { get; set; }

        [StringLength(50, ErrorMessage = "City Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "City Name")]
        public String cityname { get; set; }

        [StringLength(50, ErrorMessage = "City Merger cannot be longer than 50 characters.")] 
        public String? citymerger { get; set; }

        [StringLength(3)]
        [Display(Name = "City Code")]
        public String? citycode { get; set; }

        [StringLength(3)]
        [Display(Name = "HUB Code")]
        public String hubcode { get; set; }


        [StringLength(2)]
        [ValidateNever]
        [Required]
        [Display(Name = "Province")] 
        public String provid { get; set; }
        [ForeignKey("provid")]
        [ValidateNever] 
        public Province Province { get; set; }
    }

    public class District : CommonField2
    {
        [Key]
        [StringLength(6)]
        [Display(Name = "District ID")]
        [Required]
        public String distid { get; set; }

        [StringLength(50, ErrorMessage = "District Name cannot be longer than 50 characters.")]
        [Display(Name = "District Name")]
        [Required]
        public String distname { get; set; }

        [StringLength(4)]
        [ValidateNever]
        [Required]
        [Display(Name = "City")] 
        public String cityid { get; set; }
        [ForeignKey("cityid")]
        [ValidateNever] 
        public City City { get; set; }

    }

    public class Village : CommonField2
    {
        [Key]
        [StringLength(10)]
        [Display(Name = "Village ID")]
        [Required]
        public String villid { get; set; }

        [StringLength(50, ErrorMessage = "Village Name cannot be longer than 50 characters.")]
        [Display(Name = "Village Name")]
        public String? villname { get; set; }

        [StringLength(6)]
        [ValidateNever]
        [Required]
        [Display(Name = "District")] 
        public String distid { get; set; }
        [ForeignKey("distid")] 
        [ValidateNever] 
        public District District { get; set; }
    }

    public class Checkpoint : CommonField3
    {
        [Key]
        [StringLength(3)]
        [Display(Name = "Checkpoint Code")]
        [Required]
        [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = true, Sortable = true, Cols = 5)]
        public string cpcode { get; set; }

        [StringLength(50)]
        [Display(Name = "Checkpoint Name")]
        [Required]
        [AutoGenerateColumn(Order = 20, Filterable = true, Searchable = true, Cols = 7)]
        public string cpname { get; set; }

        [AutoGenerateColumn(Order = 70, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
        [Display(Name = "Description")]
        public String? description { get; set; }
    }

    public class Counter : CommonField2
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int counterid { get; set; } 

        [StringLength(50)]
        [Display(Name = "Counter Name")]
        [Required]
        public String countername { get; set; }

        [StringLength(10)]
        [Display(Name = "Counter Code")]
        public String? countercode { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        public string addr1 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address 2")]
        public string? addr2 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address 3")]
        public string? addr3 { get; set; }

        [StringLength(10)]
        [ValidateNever]
        [Required]
        [Display(Name = "Village")] 
        public String villid { get; set; }
        [ForeignKey("villid")]
        [ValidateNever] 
        public Village Village { get; set; }

        [StringLength(50)]
        [Display(Name = "District")]
        public String? distname { get; set; }

        [StringLength(50)]
        [Display(Name = "City")] 
        public String? cityname { get; set; }

        [StringLength(50)]
        [Display(Name = "Province")]
        public String? provname { get; set; }

        [StringLength(5, ErrorMessage = "Postal Code cannot be longer than 5 characters.")]
        [Display(Name = "Postal Code")]
        public String? postcode { get; set; }

        [StringLength(100)]
        [Display(Name = "Latitude")]
        [Required]
        public String latitude { get; set; }

        [StringLength(100)]
        [Display(Name = "Longitude")]
        [Required]
        public String longitude { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        public String? phone { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone Alt")]
        public String? phonealt { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Display(Name = "Email")]
        public String? email { get; set; }

        [StringLength(50, ErrorMessage = "PIC Name cannot be longer than 50 characters.")]
        [Display(Name = "PIC Name")]
        public String? picname { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "PIC Phone No")]
        public String? picno { get; set; }

        [Display(Name = "City Code")]
        [StringLength(3)] 
        public String? citycode { get; set; }

        [Required(ErrorMessage = "Comission Is Required")]
        [Display(Name = "Comission")]
        [Precision(18, 2)] 
        public decimal comission { get; set; }

        [ValidateNever]
        [Required]
        [Display(Name = "Branch")] 
        public int branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever] 
        public Branch Branch { get; set; }
    }

    public class Agent : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int agentid { get; set; }

        [StringLength(50, ErrorMessage = "Agent Name cannot be longer than 50 characters.")]
        [Display(Name = "Agent Name")]
        public String agentname { get; set; }

        [StringLength(10)]
        [Display(Name = "Agent Code")]
        public String? agentcode { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        public string addr1 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address 2")]
        public string? addr2 { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address 3")]
        public string? addr3 { get; set; }

        [StringLength(10)]
        [ValidateNever]
        [Required]
        [Display(Name = "Village")] 
        public String villid { get; set; }
        [ForeignKey("villid")]
        [ValidateNever] 
        public Village Village { get; set; }

        [StringLength(50)]
        [Display(Name = "District")]
        public String? distname { get; set; }

        [StringLength(50)]
        [Display(Name = "City")]
        public String? cityname { get; set; }

        [StringLength(50)]
        [Display(Name = "Province")]
        public String? provname { get; set; }

        [StringLength(5, ErrorMessage = "Postal Code cannot be longer than 5 characters.")]
        [Display(Name = "Postal Code")]
        public String? postcode { get; set; }

        [StringLength(100)]
        [Display(Name = "Latitude")]
        [Required]
        public String latitude { get; set; }

        [StringLength(100)]
        [Display(Name = "Longitude")]
        [Required]
        public String longitude { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        public String? phone { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone Alt")]
        public String? phonealt { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Display(Name = "Email")]
        [Required]
        public String? email { get; set; }

        [StringLength(50, ErrorMessage = "PIC Name cannot be longer than 50 characters.")]
        [Display(Name = "PIC Name")]
        public String? picname { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "PIC Phone No")]
        public String? picno { get; set; }

        [StringLength(3)]
        [Display(Name = "City Code")] 
        public String? citycode { get; set; }

        [Required(ErrorMessage = "Comission Is Required")]
        [Precision(18, 2)] 
        public decimal comission { get; set; }

        [ValidateNever]
        [Required]
        [Display(Name = "Branch")] 
        public int branchid { get; set; }
        [ForeignKey("branchid")]
        [ValidateNever] 
        public Branch Branch { get; set; }
    }

    public class CostComponent : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [AutoGenerateColumn(Ignore = true)]
        public int id { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Component Name")]
        [AutoGenerateColumn(Order = 10, Cols = 12, Searchable = true, Filterable = true)]
        public string componentname { get; set; }

        [StringLength(6)]
        [Required]
        [Display(Name = "Type")]
        [AutoGenerateColumn(Order = 20, Cols = 12, Filterable = true)]
        public string type { get; set; }

        [StringLength(300, ErrorMessage = "Description cannot be longer than 300 characters.")]
        [Display(Name = "Description")]
        [AutoGenerateColumn(Order = 30, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
        public string? description { get; set; }

        [Required]
        [Display(Name = "System Data")]
        [AutoGenerateColumn(Ignore = true)] 
        public int issystem { get; set; } = 0;
    }

    public class Relation : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [AutoGenerateColumn(Ignore = true)]
        public int id { get; set; }

        [StringLength(50, ErrorMessage = "Relation Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Relation Name")]
        [AutoGenerateColumn(Order = 10, Cols = 12, Searchable = true, Filterable = true)]
        public string relationname { get; set; }

        [StringLength(5, ErrorMessage = "Relation Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Relation Code")]
        [AutoGenerateColumn(Order = 20, Cols = 12, Searchable = true, Filterable = true)]
        public string relationcode { get; set; }

        [StringLength(100, ErrorMessage = "Remarks cannot be longer than 100 characters.")]
        [Display(Name = "Remarks")]
        [AutoGenerateColumn(Order = 30, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
        public string? remarks { get; set; }

    }

    public class ReasonUN : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [AutoGenerateColumn(Ignore = true)]
        public int id { get; set; }

        [StringLength(50, ErrorMessage = "Reason Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Reason Name")]
        [AutoGenerateColumn(Order = 10, Cols = 12, Searchable = true, Filterable = true)]
        public string reasonname { get; set; }

        [StringLength(5, ErrorMessage = "Reason Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Reason Code")]
        [AutoGenerateColumn(Order = 20, Cols = 12, Searchable = true, Filterable = true)]
        public string reasoncode { get; set; }

        [StringLength(100, ErrorMessage = "Remarks cannot be longer than 100 characters.")]
        [Display(Name = "Remarks")]
        [AutoGenerateColumn(Order = 30, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
        public string? remarks { get; set; }

    }

    public class Service : CommonField2
    {
        [Key]
        [StringLength(5, ErrorMessage = "Service Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Service Code")]
        [AutoGenerateColumn(Order = 10, Cols = 12, Searchable = true, Filterable = true)]
        public string servicecode { get; set; }

        [StringLength(30, ErrorMessage = "Service Name cannot be longer than 30 characters.")]
        [Required]
        [Display(Name = "Service Name")]
        [AutoGenerateColumn(Order = 20, Cols = 12, Searchable = true, Filterable = true)]
        public string servicename { get; set; }

        [StringLength(100, ErrorMessage = "Remarks cannot be longer than 100 characters.")]
        [Display(Name = "Remarks")]
        [AutoGenerateColumn(Order = 30, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
        public string? remarks { get; set; }

    }

    public class PackingType: CommonField2
    {
        [Key]
        [StringLength(5, ErrorMessage = "Packing Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Packing Code")]
        [AutoGenerateColumn(Order = 10, Cols = 12, Searchable = true, Filterable = true)]
        public string packingcode { get; set; }

        [StringLength(30, ErrorMessage = "Packing Name cannot be longer than 30 characters.")]
        [Required]
        [Display(Name = "Packing Name")]
        [AutoGenerateColumn(Order = 20, Cols = 12, Searchable = true, Filterable = true)]
        public string packingname { get; set; }

        [StringLength(100, ErrorMessage = "Remarks cannot be longer than 100 characters.")]
        [Display(Name = "Remarks")]
        [AutoGenerateColumn(Order = 30, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
        public string? remarks { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)]
        [AutoGenerateColumn(Ignore = true)]
        public virtual ICollection<PackingPrice> PackingPrices { get; set; } = new List<PackingPrice>();

    }

    public class PackingSize : CommonField3
    {
        [Key]
        [StringLength(5, ErrorMessage = "Size Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Size Code")]
        [AutoGenerateColumn(Order = 10, Cols = 12, Searchable = true, Filterable = true)]
        public string sizecode { get; set; }

        [StringLength(30, ErrorMessage = "Size Name cannot be longer than 30 characters.")]
        [Required]
        [Display(Name = "Size Name")]
        [AutoGenerateColumn(Order = 20, Cols = 12, Searchable = true, Filterable = true)]
        public string sizename { get; set; }

        [StringLength(100, ErrorMessage = "Remarks cannot be longer than 100 characters.")]
        [Display(Name = "Remarks")]
        [AutoGenerateColumn(Order = 30, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
        public string? remarks { get; set; }

        [NotMapped]
        [ScaffoldColumn(false)]
        [AutoGenerateColumn(Ignore = true)]
        public virtual ICollection<PackingPrice> PackingPrices { get; set; } = new List<PackingPrice>();

    }

    [Keyless]
    public class PackingPrice : CommonField1
    {
        [Required]
        [StringLength(5)]
        public string packingcode { get; set; }
        [ForeignKey("packingcode")]
        [NotMapped]
        public PackingType PackingType { get; set; }

        [Required]
        [StringLength(5)]
        public string sizecode { get; set; }
        [ForeignKey("sizecode")]
        [NotMapped]
        public PackingSize PackingSize { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,0)")]
        [Display(Name = "Price")]
        public decimal price { get; set; }




    }

    public class Country : CommonField3
    {
        [Key]
        [StringLength(3, ErrorMessage = "Country Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Country Code")]
        [AutoGenerateColumn(Order = 10, Cols = 6, Searchable = true, Filterable = true)]
        public string countrycode { get; set; }

        [StringLength(50, ErrorMessage = "Country Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Country Name")]
        [AutoGenerateColumn(Order = 20, Cols = 6, Searchable = true, Filterable = true)]
        public string countryname { get; set; }

        [StringLength(3, ErrorMessage = "ISO Alpha3 cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "ISO Alpha3")]
        [AutoGenerateColumn(Order = 30, Cols = 6, Searchable = true, Filterable = true)]
        public string isoalpha3 { get; set; }

        [StringLength(3, ErrorMessage = "Phone Code cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Phone Code")]
        [AutoGenerateColumn(Order = 40, Cols = 6)]
        public string phonecode { get; set; }

    }

    public class CityIntl : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50, ErrorMessage = "City Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "City Name")]
        public string cityname { get; set; }

        [StringLength(5, ErrorMessage = "City Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "City Code")]
        public string citycode { get; set; }

        [StringLength(100, ErrorMessage = "Airport cannot be longer than 100 characters.")]
        [Display(Name = "Airport")]
        public string? airport { get; set; }

        [StringLength(3)]
        [ValidateNever]
        [Required]
        [Display(Name = "Country")]
        public String countrycode { get; set; }
        [ForeignKey("countrycode")]
        [ValidateNever]
        public Country Country { get; set; }

        [StringLength(30, ErrorMessage = "Region be longer than 30 characters.")]
        [Display(Name = "Region")]
        public string? region { get; set; }

        [StringLength(10, ErrorMessage = "Zone 3PL 1 be longer than 10 characters.")]
        [Display(Name = "Zone 3PL 1")]
        public string? zone3pl1 { get; set; }

        [StringLength(10, ErrorMessage = "Zone 3PL 2 be longer than 10 characters.")]
        [Display(Name = "Zone 3PL 2")]
        public string? zone3pl2 { get; set; }

        [StringLength(10, ErrorMessage = "Zone 3PL 3 be longer than 10 characters.")]
        [Display(Name = "Zone 3PL 3")]
        public string? zone3pl3 { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Disc 3PL 1")]
        public decimal? disc3pl1 { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Disc 3PL 2")]
        public decimal? disc3pl2 { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Disc 3PL 3")]
        public decimal? disc3pl3 { get; set; } = 0;
    }

    public class PostCode : CommonField2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(10, ErrorMessage = "Postal Code cannot be longer than 10 characters.")]
        [Required]
        [Display(Name = "Postal Code")]
        public string postcode { get; set; }

        [StringLength(10)]
        [ValidateNever]
        [Required]
        [Display(Name = "Village")]
        public String villid { get; set; }
        [ForeignKey("villid")]
        [ValidateNever]
        public Village Village { get; set; }
    }

    public class Bank : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [AutoGenerateColumn(Ignore = true)]
        public int id { get; set; }

        [StringLength(50, ErrorMessage = "Bank Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Bank Name")]
        [AutoGenerateColumn(Order = 20, Cols = 6, Searchable = true, Filterable = true)]
        public string bankname { get; set; }

        [StringLength(5, ErrorMessage = "Bank Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Bank Code")]
        [AutoGenerateColumn(Order = 10, Cols = 6, Searchable = true, Filterable = true)]
        public string bankcode { get; set; }

        [StringLength(20, ErrorMessage = "Swift Code cannot be longer than 20 characters.")]
        [Required]
        [Display(Name = "Swift Code")]
        [AutoGenerateColumn(Order = 30, Cols = 6, Searchable = true, Filterable = true)]
        public string? swiftcode { get; set; }

    }

    public class NCSBankAccount : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(5, ErrorMessage = "Bank Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Bank Code")]
        [AutoGenerateColumn(Order = 10, Cols = 6, Searchable = true, Filterable = true)]
        public string bankcode { get; set; }

        [StringLength(50, ErrorMessage = "Bank Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Bank Name")]
        [AutoGenerateColumn(Order = 20, Cols = 6, Searchable = true, Filterable = true)]
        public string bankname { get; set; }

        [StringLength(20, ErrorMessage = "Account Number cannot be longer than 20 characters.")]
        [Required]
        [Display(Name = "Account Number")]
        [AutoGenerateColumn(Order = 30, Cols = 6, Searchable = true, Filterable = true)]
        public string accountno { get; set; }

        [StringLength(50, ErrorMessage = "Account Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Account Name")]
        [AutoGenerateColumn(Order = 20, Cols = 6, Searchable = true, Filterable = true)]
        public string accountname { get; set; }

    }

    public class Zone : CommonField2
    {
        [Key]
        [StringLength(5)]
        [Required]
        public string zoneid { get; set; }

        [StringLength(50)]
        [Display(Name = "Zone Name")]
        [Required]
        public string zonename { get; set; }

        [StringLength(50)]
        [Display(Name = "Zone Group")]
        [Required]
        public string zonegroup { get; set; }

    }

    public class CityZone : CommonField1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(5)]
        [Required]
        [Display(Name = "Zone")]
        public String zoneid { get; set; }
        [ForeignKey("zoneid")]
        [ValidateNever]
        public Zone Zone { get; set; }

        [StringLength(4)]
        [Required]
        [Display(Name = "City")]
        public String cityid { get; set; }
        [ForeignKey("cityid")]
        [ValidateNever]
        public City City { get; set; }

    }

    public class ReasonPickup : CommonField3
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [AutoGenerateColumn(Ignore = true)]
        public int id { get; set; }

        [StringLength(100, ErrorMessage = "Reason Name cannot be longer than 50 characters.")]
        [Required]
        [Display(Name = "Reason Name")]
        [AutoGenerateColumn(Order = 10, Cols = 12, Searchable = true, Filterable = true)]
        public string reasonname { get; set; }

        [StringLength(5, ErrorMessage = "Reason Code cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Reason Code")]
        [AutoGenerateColumn(Order = 20, Cols = 12, Searchable = true, Filterable = true)]
        public string reasoncode { get; set; }

        [StringLength(100, ErrorMessage = "Remarks cannot be longer than 100 characters.")]
        [Display(Name = "Remarks")]
        [AutoGenerateColumn(Order = 30, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
        public string? remarks { get; set; }

        [StringLength(15, ErrorMessage = "Reason Group cannot be longer than 5 characters.")]
        [Required]
        [Display(Name = "Reason Group")]
        [AutoGenerateColumn(Order = 40, Cols = 12, Searchable = true, Filterable = true)]
        public string reasongroup { get; set; }

    }
}

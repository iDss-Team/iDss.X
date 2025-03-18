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
        [AutoGenerateColumn(Order = 1, Filterable = true, Searchable = true, GroupName = "General", GroupOrder = 1)]
        public String branchname { get; set; }

        [StringLength(10)] 
        [Display(Name = "Branch Code")]
        [AutoGenerateColumn(Order = 2, Filterable = true, Searchable = true, GroupName = "General", GroupOrder = 1, Cols = 4)]
        public String? branchcode { get; set; }

        [StringLength(10)]
        [AutoGenerateColumn(Order = 5, GroupName = "General", GroupOrder = 1)]
        public String? branchtype { get; set; }

        [StringLength(300, ErrorMessage = "Address cannot be longer than 300 characters.")]
        [Display(Name = "Address")]
        [Required]
        [AutoGenerateColumn(Order = 30, GroupName = "Address", GroupOrder = 2, Cols = 12, ComponentType = typeof(Textarea))]
        public String addr1 { get; set; }

        [StringLength(300)]
        [AutoGenerateColumn(Order = 31, GroupName = "Address", GroupOrder = 2, Cols = 6, Visible = false)]
        public String? addr2 { get; set; }

        [StringLength(300)]
        [AutoGenerateColumn(Order = 32, GroupName = "Address", GroupOrder = 2, Cols = 6, Visible = false)]
        public String? addr3 { get; set; }

        [StringLength(10)]
        [ValidateNever]
        [Required]
        [Display(Name = "Village")]
        [AutoGenerateColumn(Order = 35, GroupName = "Address", GroupOrder = 2, Visible = false, ComponentType = typeof(AutoComplete))]
        public String villid { get; set; }
        [ForeignKey("villid")]
        [ValidateNever]
        [AutoGenerateColumn(Ignore = true)]
        public Village Village { get; set; }

        [StringLength(50)]
        [AutoGenerateColumn(Order = 36, Visible = false, GroupName = "Address", GroupOrder = 2, Readonly = true)]

        public String? distname { get; set; }

        [StringLength(50)]
        [AutoGenerateColumn(Order = 37, Visible = false, GroupName = "Address", GroupOrder = 2, Readonly = true)]
        public String? cityname { get; set; }

        [StringLength(50)]
        [AutoGenerateColumn(Order = 38, Visible = false, GroupName = "Address", GroupOrder = 2, Readonly = true)]
        public String? provname { get; set; }

        [StringLength(5, ErrorMessage = "Postal Code cannot be longer than 5 characters.")]
        [Display(Name = "Postal Code")]
        [AutoGenerateColumn(Order = 39, Visible = false, GroupName = "Address", GroupOrder = 2)]
        public String? postcode { get; set; }

        [StringLength(100)]
        [Required]
        [AutoGenerateColumn(Order = 41, Visible = false, GroupName = "Address", GroupOrder = 2)]
        public String latitude { get; set; }

        [StringLength(100)]
        [Required]
        [AutoGenerateColumn(Order = 42, Visible = false, GroupName = "Address", GroupOrder = 2)]
        public String longitude { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [AutoGenerateColumn(Order= 10, Visible = false, GroupName = "General", GroupOrder = 1)]
        public String? phone { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [AutoGenerateColumn(Order = 11, Visible = false, GroupName = "General", GroupOrder = 1)]
        public String? phonealt { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [EmailAddress]
        [AutoGenerateColumn(Order = 12, Visible = false, GroupName = "General", GroupOrder = 1)]
        public String? email { get; set; }

        [StringLength(50)]
        [Display(Name = "HO Name")]
        [AutoGenerateColumn(Order = 90, Visible = false, GroupName = "General", GroupOrder = 1)]
        public String? honame { get; set; }

        [StringLength(50)]
        [Display(Name = "PIC Name")]
        [AutoGenerateColumn(Order = 15, Visible = false, GroupName = "General", GroupOrder = 1)]
        public String? picname { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "PIC Phone No")]
        [AutoGenerateColumn(Order = 17, Visible = false, GroupName = "General", GroupOrder = 1)]
        public String? picno { get; set; }

        [StringLength(3)]
        [AutoGenerateColumn(Order = 20, Visible = false, GroupName = "General", GroupOrder = 1)]
        public String? citycode { get; set; }
    }

    public class Courier : CommonField2
    {
        [Key]
        [StringLength(30)]
        [Display(Name = "NIP")]
        public String nip { get; set; }

        [StringLength(50, ErrorMessage = "Courier Name cannot be longer than 50 characters.")] 
        public String couriername { get; set; }

        [StringLength(10)]
        [Required]
        public String couriercode { get; set; }

        [StringLength(6)][ValidateNever][Required][Display(Name = "District")] public String distid { get; set; }
        [ForeignKey("distid")][ValidateNever] public District District { get; set; }

        [ValidateNever][Required][Display(Name = "Branch")] public int branchid { get; set; }
        [ForeignKey("branchid")][ValidateNever] public Branch Branch { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Required]
        public String phone { get; set; }

        [Display(Name = "Delivery Frequency")]
        public int? freqdelivery { get; set; }

        [Display(Name = "Fuel Quota")]
        public int? fuelquota { get; set; }

        public int? status { get; set; }

    }

    public class Industry : CommonField3
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int id { get; set; }

        [StringLength(100)]
        [Required]
        [Display(Name = "Industry Name")]
        public String industryname { get; set; }

        public String? description { get; set; }

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

        [ValidateNever][Required][Display(Name = "Industry")] public int industryid { get; set; }
        [ForeignKey("industryid")][ValidateNever] public Industry Industry { get; set; }

        [ValidateNever][Required][Display(Name = "Branch")] public int branchid { get; set; }
        [ForeignKey("branchid")][ValidateNever] public Branch Branch { get; set; }

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

        [StringLength(30)][ValidateNever][Required][Display(Name = "CIF")] public String cif { get; set; }
        [ForeignKey("cif")][ValidateNever] public CIF CIF { get; set; }

        [ValidateNever][Required][Display(Name = "Branch")] public int branchid { get; set; }
        [ForeignKey("branchid")][ValidateNever] public Branch Branch { get; set; }

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

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Credit Limit")]
        public decimal? creditlimit { get; set; }

        [StringLength(30)]
        [Display(Name = "Credit Period")]
        public String? creditperiod { get; set; }

        public int? iscod { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "COD Fee")]
        public decimal? feecod { get; set; }

        public int? isintl { get; set; } = 0;

        public int? isnl { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Discount Rates")]
        public decimal? discrates { get; set; }

        public int? isrev { get; set; } = 0;

        public int? istrace { get; set; } = 0;

    }

    public class AccountAddr : CommonField1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int id { get; set; }

        [StringLength(30)][ValidateNever][Required][Display(Name = "Account")] public String acctno { get; set; }
        [ForeignKey("acctno")][ValidateNever] public Account Account { get; set; }

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

        [StringLength(6)][ValidateNever][Required][Display(Name = "District")] public String distid { get; set; }
        [ForeignKey("distid")][ValidateNever] public District District { get; set; }

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

    }

    [Keyless]
    public class AccountCro : CommonField1
    {
        [StringLength(30)][ValidateNever][Required][Display(Name = "Account")] public String acctno { get; set; }
        [ForeignKey("acctno")][ValidateNever] public Account Account { get; set; }

        [StringLength(10)][ValidateNever][Required][Display(Name = "CRO")] public String crocode { get; set; }
        [ForeignKey("crocode")][ValidateNever] public CRO CRO { get; set; }
    }

    public class Province
    {
        [Key][StringLength(2)]
        [Required]
        public String provid { get; set; }

        [StringLength(50)]
        [Required]
        public String provname { get; set; }

    }

    public class City
    {
        [Key]
        [StringLength(4)]
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


        [StringLength(2)][ValidateNever][Required][Display(Name = "Province")] public String provid { get; set; }
        [ForeignKey("provid")][ValidateNever] public Province Province { get; set; }
    }

    public class District
    {
        [Key]
        [StringLength(6)]
        [Required]
        public String distid { get; set; }

        [StringLength(50, ErrorMessage = "District Name cannot be longer than 50 characters.")]
        [Display(Name = "District Name")]
        [Required]
        public String distname { get; set; }

        [StringLength(4)][ValidateNever][Required][Display(Name = "City")] public String cityid { get; set; }
        [ForeignKey("cityid")][ValidateNever] public City City { get; set; }

    }

    public class Village
    {
        [Key]
        [StringLength(10)]
        [Required]
        public String villid { get; set; }

        [StringLength(50, ErrorMessage = "Village Name cannot be longer than 50 characters.")]
        [Display(Name = "Village Name")]
        public String? villname { get; set; }

        [StringLength(6)][ValidateNever][Required][Display(Name = "District")] public String distid { get; set; }
        [ForeignKey("distid")] [ValidateNever] public District District { get; set; }
    }

    public class Checkpoint : CommonField3
    {
        [Key]
        [StringLength(3)]
        [Required]
        [AutoGenerateColumn(Order = 10, Filterable = true, Searchable = true, Sortable = true, Cols = 5)]
        public string cpcode { get; set; }

        [StringLength(50)]
        [Display(Name = "Checkpoint Name")]
        [Required]
        [AutoGenerateColumn(Order = 20, Filterable = true, Searchable = true, Cols = 7)]
        public string cpname { get; set; }

        [AutoGenerateColumn(Order = 70, Cols = 12, Rows = 2, ComponentType = typeof(Textarea))]
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

        [StringLength(10)][ValidateNever][Required][Display(Name = "Village")] public String villid { get; set; }
        [ForeignKey("villid")][ValidateNever] public Village Village { get; set; }

        [StringLength(50)] public String? distname { get; set; }

        [StringLength(50)] public String? cityname { get; set; }

        [StringLength(50)] public String? provname { get; set; }

        [StringLength(5, ErrorMessage = "Postal Code cannot be longer than 5 characters.")]
        [Display(Name = "Postal Code")]
        public String? postcode { get; set; }

        [StringLength(100)]
        [Required]
        public String latitude { get; set; }

        [StringLength(100)]
        [Required]
        public String longitude { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        public String? phone { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone Alt")]
        public String? phonealt { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Required]
        public String? email { get; set; }

        [StringLength(50, ErrorMessage = "PIC Name cannot be longer than 50 characters.")]
        [Display(Name = "PIC Name")]
        public String? picname { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "PIC Phone No")]
        public String? picno { get; set; }

        [StringLength(3)] public String? citycode { get; set; }

        [Required(ErrorMessage = "Comission Is Required")][Precision(18, 2)] public decimal comission { get; set; }

        [ValidateNever][Required][Display(Name = "Branch")] public int branchid { get; set; }
        [ForeignKey("branchid")][ValidateNever] public Branch Branch { get; set; }
    }

    public class Agent : CommonField2
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int agentid { get; set; }

        [StringLength(50, ErrorMessage = "Agent Name cannot be longer than 50 characters.")]
        [Display(Name = "Agent Name")]
        public String agentname { get; set; }

        [StringLength(10)] public String? agentcode { get; set; }

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

        [StringLength(10)][ValidateNever][Required][Display(Name = "Village")] public String villid { get; set; }
        [ForeignKey("villid")][ValidateNever] public Village Village { get; set; }

        [StringLength(50)] public String? distname { get; set; }

        [StringLength(50)] public String? cityname { get; set; }

        [StringLength(50)] public String? provname { get; set; }

        [StringLength(5, ErrorMessage = "Postal Code cannot be longer than 5 characters.")]
        [Display(Name = "Postal Code")]
        public String? postcode { get; set; }

        [StringLength(100)]
        [Required]
        public String latitude { get; set; }

        [StringLength(100)]
        [Required]
        public String longitude { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        public String? phone { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "Phone Alt")]
        public String? phonealt { get; set; }

        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 characters.")]
        [Required]
        public String? email { get; set; }

        [StringLength(50, ErrorMessage = "PIC Name cannot be longer than 50 characters.")]
        [Display(Name = "PIC Name")]
        public String? picname { get; set; }

        [StringLength(15, ErrorMessage = "Phone cannot be longer than 15 characters.")]
        [Display(Name = "PIC Phone No")]
        public String? picno { get; set; }

        [StringLength(3)] public String? citycode { get; set; }

        [Required(ErrorMessage = "Comission Is Required")][Precision(18, 2)] public decimal comission { get; set; }

        [ValidateNever][Required][Display(Name = "Branch")] public int branchid { get; set; }
        [ForeignKey("branchid")][ValidateNever] public Branch Branch { get; set; }
    }
}

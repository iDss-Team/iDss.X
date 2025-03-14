using BootstrapBlazor.Components;
using System.ComponentModel.DataAnnotations;

namespace iDss.X.Models
{
    public class CommonField1
    {
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [AutoGenerateColumn(Ignore = true)]
        public DateTime createddate { get; set; } = System.DateTime.Now;

        [StringLength(50)]
        [AutoGenerateColumn(Ignore = true)]
        public String createdby { get; set; } = "System";
    }

    public class CommonField2
    {
        [AutoGenerateColumn(Ignore = true)]
        public int flag { get; set; } = 1;

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [AutoGenerateColumn(Ignore = true)]
        public DateTime createddate { get; set; } = System.DateTime.Now;

        [StringLength(50)]
        [AutoGenerateColumn(Ignore = true)]
        public String createdby { get; set; } = "System";

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [AutoGenerateColumn(Ignore = true)]
        public DateTime? modifieddate { get; set; }

        [StringLength(50)]
        [AutoGenerateColumn(Ignore = true)]
        public String? modifier { get; set; }
    }

    public class CommonField3
    {
        [AutoGenerateColumn(Ignore =true)]
        public int flag { get; set; } = 1;

        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}", ApplyFormatInEditMode = true)]
        [AutoGenerateColumn(Ignore = true)]
        public DateTime createddate { get; set; } = System.DateTime.Now;

        [StringLength(50)]
        [AutoGenerateColumn(Ignore = true)]
        public String createdby { get; set; } = "System";
    }
}

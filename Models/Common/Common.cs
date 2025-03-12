namespace iDss.X.Models.Common
{
    public class BasicFilter
    {
        public String? Code { get; set; }
        public String? Name { get; set; }
        public String? AWB { get; set; }
        public String? RefNo { get; set; }
        public DateOnly? Period { get; set; } 
        public DateOnly? DateFrom { get; set; } 
        public DateOnly? DateTo { get; set; }
        public int? Flag { get; set; }

    }
}

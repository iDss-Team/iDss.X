using System.ComponentModel.DataAnnotations;

namespace iDss.X.Models.Dto
{
    public class EntryDataPrimaryDto
    {
        public EntryDataPrimaryDto()
        {
            Shipment = new ShipmentDetail();
            //Shipper = new ShipperDetail();
            Shipper = new ShipperDetail
            {
                branchid = 1
            };
            Consignee = new ConsigneeDetail();
        }

        public ShipmentDetail Shipment { get; set; }
        public ShipperDetail Shipper { get; set; }
        public ConsigneeDetail Consignee { get; set; }
    }

    //public class EntryDataPrimaryDto
    //{
    //    [Required(ErrorMessage = "Data shipment wajib diisi")]
    //    public ShipmentDetail Shipment { get; set; }

    //    [Required(ErrorMessage = "Data shipper wajib diisi")]
    //    public ShipperDetail Shipper { get; set; }

    //    [Required(ErrorMessage = "Data consignee wajib diisi")]
    //    public ConsigneeDetail Consignee { get; set; }
    //}
}
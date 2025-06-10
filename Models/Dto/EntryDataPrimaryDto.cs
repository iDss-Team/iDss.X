using System.ComponentModel.DataAnnotations;
namespace iDss.X.Models.Dto
{
    public class EntryDataPrimaryDto
    {
        [Required(ErrorMessage = "Data shipment wajib diisi")]
        public ShipmentDetail? Shipment { get; set; }

        [Required(ErrorMessage = "Data shipper wajib diisi")]
        public ShipperDetail? Shipper { get; set; }

        [Required(ErrorMessage = "Data consignee wajib diisi")]
        public ConsigneeDetail? Consignee { get; set; }
    }
}
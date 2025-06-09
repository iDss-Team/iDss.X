namespace iDss.X.Models.Dto
{
    public class EntryDataPrimaryDto
    {
        public ShipmentDetail? Shipment { get; set; }
        public ShipperDetail? Shipper { get; set; }
        public ConsigneeDetail? Consignee { get; set; }
    }
}
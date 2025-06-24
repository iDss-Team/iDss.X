using System.ComponentModel.DataAnnotations;

namespace iDss.X.Models.Dto
{
    public class EntryDataPrimaryDto
    {
        public EntryDataPrimaryDto()
        {
            Shipment = new ShipmentDetail
            {
                packingtype = "" // ← inisialisasi di sini!
            };
            Shipper = new ShipperDetail();

            Consignee = new ConsigneeDetail();
        }

        public string? awb { get; set; }
        public ShipmentDetail Shipment { get; set; }
        public ShipperDetail Shipper { get; set; }
        public ConsigneeDetail Consignee { get; set; }
    }

    public class CombinedTransactionDto
    {
        // Data Shipper
        public string? ShipperName { get; set; }
        public string? ShipperAddress { get; set; }

        // Data Consignee
        public string? ConsigneeName { get; set; }
        public string? ConsigneeAddress { get; set; }
        public string? Destination { get; set; }

        // Data Shipment
        public string? AWB { get; set; }
        public string? PickupDate { get; set; }
        public string? ServiceType { get; set; }
        public int? Pieces { get; set; }
        public decimal? ActualWeight { get; set; }
        public decimal? ChargeWeight { get; set; }
        public string? PackingType { get; set; }
        //public string? ReffNo { get; set; }
        //public string? Branch { get; set; }
    }
}
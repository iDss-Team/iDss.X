using System.ComponentModel.DataAnnotations;

namespace iDss.X.Models.Dto
{
    public class EntryDataPrimaryDto
    {
        public EntryDataPrimaryDto()
        {
            Shipment = new ShipmentDetail
            {
                packingtype = "",// ← inisialisasi di sini!
                pickupdate = DateOnly.FromDateTime(DateTime.Today)

            };
            Shipper = new ShipperDetail();
            Consignee = new ConsigneeDetail();
            VolWeight = new VolumeWeight();

        }

        public string? awb { get; set; }
        public ShipmentDetail Shipment { get; set; }
        public ShipperDetail Shipper { get; set; }
        public ConsigneeDetail Consignee { get; set; }
        public VolumeWeight VolWeight { get; set; }

        //display only
        public string? districtName { get; set; }

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

    public class VolumeWeight
    {
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
    }

}
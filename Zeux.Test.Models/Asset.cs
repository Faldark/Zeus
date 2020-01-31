using System.ComponentModel.DataAnnotations;

namespace Zeux.Test.Models
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Percent { get; set; }
        public decimal Sum { get; set; }

        public AssetType Type { get; set; }
        public string AssetTypeName => Type.Name;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Zeux.Test.Models
{
    public class AssetType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
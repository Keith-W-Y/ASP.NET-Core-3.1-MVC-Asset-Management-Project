using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.AssetTrack.Domain
{
    [Table("AssetType")]
    public class AssetType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //navigation property
        public ICollection<Asset> Asset { get; set; }
    }
}


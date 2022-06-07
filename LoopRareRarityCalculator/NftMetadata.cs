using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopRareRarityCalculator
{

    public class NftMetadata
    {
        public string? description { get; set; }
        public string? image { get; set; }
        public string? name { get; set; }
        public int royalty_percentage { get; set; }

        public string? animation_url { get; set; }

        public List<Trait>? attributes { get; set; }
        public decimal totalRarityScore { get; set; }
        public List<Rarity> rarities { get; set; }
    }

    public class Trait
    {
        public string? trait_type { get; set; }
        public string? value { get; set; } //value can be either string or int
    }

}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopRareRarityCalculator
{
    public class Rarity
    {
        [JsonProperty("$1")]
        public int Count { get; set; }
        public string TraitType { get; set; }
        public object TraitValue { get; set; }

        public decimal Score { get; set; }
    }
}

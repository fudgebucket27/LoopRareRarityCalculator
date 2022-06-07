using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopRareRarityCalculator
{
    public class Rankings
    {
        public string name { get; set; }
        public List<Ranking> rankings { get; set; } = new List<Ranking>();
    }

    public class Ranking
    {
        public int Id { get; set; }
        public decimal RarityScore { get; set; }
    }
}

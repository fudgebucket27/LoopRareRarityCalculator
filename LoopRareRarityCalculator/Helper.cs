using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopRareRarityCalculator
{
    public static class Helper
    {
        public static NftMetadata LoadJson(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                NftMetadata nftMetadata = JsonConvert.DeserializeObject<NftMetadata>(json);
                return nftMetadata;
            }
        }
    }
}

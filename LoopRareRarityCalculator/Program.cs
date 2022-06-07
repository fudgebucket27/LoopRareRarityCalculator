// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using LoopRareRarityCalculator;

Rankings rankingsList = new Rankings();
rankingsList.name = "nubs-Ranks";

string[] filePaths = Directory.GetFiles(@"C:\Temp\nubs\json\", "*.json", SearchOption.TopDirectoryOnly);

List<NftMetadata> nftMetadatas = new List<NftMetadata>();

foreach(string filePath in filePaths)
{
    nftMetadatas.Add(Helper.LoadJson(filePath));
}
List<NftMetadata> compareList = nftMetadatas;

Console.WriteLine($"Metadata count: {nftMetadatas.Count}");
int collectionTotal = nftMetadatas.Count;

foreach(NftMetadata nftMetadata in nftMetadatas)
{
    nftMetadata.rarities = new List<Rarity>();
    foreach (var trait in nftMetadata.attributes)
    {
        decimal traitCountDecimal = 0;
        foreach(var nftMetadata2 in compareList)
        {
            foreach(var trait2 in nftMetadata2.attributes)
            {
                if(trait2.trait_type == trait.trait_type && trait2.value==trait.value)
                {
                    traitCountDecimal += 1;
                }
            }        
        }
        decimal collectionTotalDecimal = collectionTotal;
        decimal rarityScore = Math.Round(1M / (traitCountDecimal / collectionTotalDecimal), 2);
        nftMetadata.rarities.Add(new Rarity()
        {
            Score = rarityScore,
        });
    };
    nftMetadata.totalRarityScore = nftMetadata.rarities.Sum(x => x.Score);
    Ranking ranking = new Ranking()
    {
        Id = Int32.Parse(nftMetadata.name.Split('#')[1]),
        RarityScore = nftMetadata.totalRarityScore
    };
    rankingsList.rankings.Add(ranking);
}

rankingsList.rankings = rankingsList.rankings.OrderByDescending(x => x.RarityScore).ToList();
string json = JsonConvert.SerializeObject(rankingsList, Formatting.Indented);
File.WriteAllText($"C:\\temp\\{rankingsList.name}.json", json);


Console.WriteLine("End");

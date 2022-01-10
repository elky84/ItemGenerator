using ItemGenerator.Types;

namespace ItemGenerator.Model
{
    public class Item
    {
        public string? ItemId { get; set; }

        public int Lv { get; set; }

        public GradeType Grade { get; set; }

        public MasterData.Item? MasterData { get; set; }

        public List<ItemOption> Options { get; set; } = new();
    }
}

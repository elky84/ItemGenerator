namespace ItemGenerator.Model
{
    public class ItemEquip : Item
    {
        public ItemEquip(OptionValue defense)
        {
            Defense = defense;
        }

        public OptionValue Defense { get; set; }
    }
}

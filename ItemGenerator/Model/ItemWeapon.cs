namespace ItemGenerator.Model
{
    public class ItemWeapon : Item
    {
        public ItemWeapon(OptionValue damage)
        {
            Damage = damage;
        }

        public OptionValue Damage { get; set; }
    }
}

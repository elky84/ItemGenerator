using EnumExtend;
using ItemGenerator.Types;

namespace ItemGenerator.Model
{
    public class ItemOption
    {

        public ItemOptionType Type { get; set; }

        public float Value { get; set; }

        public override string ToString()
        {
            return $"Type:{Type.Desc()}, Value:{Value}";
        }
    }
}

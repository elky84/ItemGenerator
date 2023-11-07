using ItemGenerator.MasterData;
using ItemGenerator.Types;
using JsonTable;

namespace ItemGenerator.Table
{
    [Table(@"json")]
    public partial class TableItem : BaseDict<string, Item>
    {
    }

    [Table(@"json", "Type")]
    public partial class TableItemByType : BaseMultiDict<ItemType, Item>
    {
    }

    [Table(@"json")]
    public partial class TableItemDrop : BaseList<ItemDrop>
    {
    }

    [Table(@"json")]
    public partial class TableItemDropGrade : BaseList<ItemDropGrade>
    {
#pragma warning disable CS8609 // 반환 형식에 있는 참조 형식 Null 허용 여부가 재정의된 멤버와 일치하지 않습니다.
        protected override List<ItemDropGrade?> OnLoad(List<ItemDropGrade?> list)
#pragma warning restore CS8609 // 반환 형식에 있는 참조 형식 Null 허용 여부가 재정의된 멤버와 일치하지 않습니다.
        {
            return list.OrderByDescending(x => (int)x!.Grade).ToList();
        }
    }


    [Table(@"json")]
    public partial class TableItemOption : BaseList<ItemOption>
    {
    }

    [Table(@"json", "Grade")]
    public partial class TableItemOptionByGrade : BaseMultiDict<GradeType, ItemOption>
    {
#pragma warning disable CS8610 // 매개 변수 형식에 있는 참조 형식 Null 허용 여부가 재정의된 멤버와 일치하지 않습니다.
        protected override Dictionary<GradeType, List<ItemOption>> OnLoad(List<ItemOption?> list)
#pragma warning restore CS8610 // 매개 변수 형식에 있는 참조 형식 Null 허용 여부가 재정의된 멤버와 일치하지 않습니다.
        {
            foreach (var itemOption in list)
            {
                foreach (var grade in Enumerable.Range((int)GradeType.Normal, (int)itemOption!.Grade + 1))
                {
                    Add((GradeType)grade, itemOption);
                }
            }

            return Container;
        }
    }

    [Table(@"json")]
    public partial class TableItemEquip : BaseDict<string, ItemEquip>
    {
    }


    [Table(@"json")]
    public partial class TableItemWeapon : BaseDict<string, ItemWeapon>
    {
    }

    [Table(@"json")]
    public partial class TableItemScroll : BaseDict<string, ItemScroll>
    {
    }

    [Table(@"json")]
    public partial class TableItemPotion : BaseDict<string, ItemPotion>
    {
    }
}

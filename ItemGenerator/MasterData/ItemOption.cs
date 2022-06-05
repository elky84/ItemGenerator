using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;
using ItemGenerator.Types;

namespace ItemGenerator.MasterData
{
	public partial class ItemOption
	{
        [JsonConverter(typeof(JsonEnumConverter<GradeType>))]
        public GradeType Grade { get; set; }

        [JsonConverter(typeof(JsonEnumConverter<ItemOptionType>))]
        public ItemOptionType Option { get; set; }

        public float ValueMin { get; set; }

        public float ValueMax { get; set; }

        public int? Level { get; set; }

        [JsonConverter(typeof(JsonEnumsConverter<ItemSlotType>))]
        public List<ItemSlotType>? SlotLimit { get; set; }

        [JsonConverter(typeof(JsonEnumsConverter<ClassType>))]
        public List<ClassType>? ClassLimit { get; set; }

	}
}

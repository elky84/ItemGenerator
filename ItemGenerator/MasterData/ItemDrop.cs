using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;
using ItemGenerator.Types;

namespace ItemGenerator.MasterData
{
	public partial class ItemDrop
	{
        public string? Id { get; set; }

        [JsonConverter(typeof(JsonEnumConverter<ItemType>))]
        public ItemType Type { get; set; }

        public double Probability { get; set; }

	}
}

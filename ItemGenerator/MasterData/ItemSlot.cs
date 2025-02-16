using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;
using ItemGenerator.Types;

namespace ItemGenerator.MasterData
{
	public partial class ItemSlot
	{
	
		[JsonConverter(typeof(JsonEnumConverter<ItemSlotType>))]
		public ItemSlotType Id { get; set; }
		
		public int Slot { get; set; }
	}
}
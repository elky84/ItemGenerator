using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;
using ItemGenerator.Types;

namespace ItemGenerator.MasterData
{
	public partial class ItemPotion
	{
	
		public string? Id { get; set; }
		
		[JsonConverter(typeof(JsonEnumConverter<ItemPotionType>))]
		public ItemPotionType PotionType { get; set; }
		
		public float Value { get; set; }
		
		public int Time { get; set; }
	}
}
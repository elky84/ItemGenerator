using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;
using ItemGenerator.Types;

namespace ItemGenerator.MasterData
{
	public partial class ItemScroll
	{
	
		public string? Id { get; set; }
		
		[JsonConverter(typeof(JsonEnumConverter<ItemScrollEffectType>))]
		public ItemScrollEffectType EffectType { get; set; }
		
		public int Min { get; set; }
		
		public int Max { get; set; }
	}
}
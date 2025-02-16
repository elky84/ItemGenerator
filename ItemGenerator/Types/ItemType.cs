using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;

namespace ItemGenerator.Types
{
	
	public enum ItemType
	{
	
		[Description("없음")]
		None,
		
		[Description("장비")]
		Equip,
		
		[Description("무기")]
		Weapon,
		
		[Description("골드")]
		Gold,
		
		[Description("포션")]
		Potion,
		
		[Description("두루마리")]
		Scroll,
	}
}
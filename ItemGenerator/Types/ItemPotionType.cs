using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;

namespace ItemGenerator.Types
{
	
	public enum ItemPotionType
	{
	
		[Description("체력회복")]
		HpRecovery,
		
		[Description("마나회복")]
		MpRecovery,
		
		[Description("속도변화")]
		SpeedChange,
		
		[Description("해독")]
		PoisonRecovery,
	}
}
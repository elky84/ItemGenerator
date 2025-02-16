using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;

namespace ItemGenerator.Types
{
	
	public enum ItemScrollEffectType
	{
	
		[Description("효과숨기기")]
		Hidden,
		
		[Description("순간이동")]
		Teleport,
		
		[Description("확인")]
		Identity,
	}
}
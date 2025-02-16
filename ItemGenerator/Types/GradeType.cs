using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;

namespace ItemGenerator.Types
{
	
	public enum GradeType
	{
	
		[Description("일반")]
		Normal,
		
		[Description("고급")]
		Advanced,
		
		[Description("희귀")]
		Rare,
		
		[Description("서사")]
		Epic,
		
		[Description("전설")]
		Legend,
		
		[Description("신화")]
		Mythology,
	}
}
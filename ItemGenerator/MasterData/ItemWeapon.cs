using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using EnumExtend;
using ItemGenerator.Types;

namespace ItemGenerator.MasterData
{
	public partial class ItemWeapon
	{
	
		public string? Id { get; set; }
		
		public int Min { get; set; }
		
		public int Max { get; set; }
		
		public float AttackSpeed { get; set; }
	}
}
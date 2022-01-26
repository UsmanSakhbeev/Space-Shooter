using System;
using UnityEngine;

namespace Assets.Sources.Test
{
	[CreateAssetMenu]
	public class LevelConfig : ScriptableObject
	{
		public UnitsPack[] packsOrder;

		[Serializable]
		public struct UnitsPack
		{
			public string prefab;
			public int count;
		}
	}
}

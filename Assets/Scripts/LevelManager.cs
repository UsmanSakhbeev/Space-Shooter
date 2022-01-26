using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sources.Test
{
	public class LevelManager : MonoBehaviour
	{
		public LevelConfig[] _levels;

		private void Start()
		{
			foreach (var level in _levels)
				foreach (var pack in level.packsOrder)
				{
					Debug.Log($"Prefab {pack.prefab} {pack.count}");
				}
		}
	}
}

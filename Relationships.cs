using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Groups.Utilities
{
	public class Relationships : MonoBehaviour
	{
		public Group[] Allies => GetGroup(allies);
		public Group[] Enemies => GetGroup(enemies);
		public Group[] Neutrals => GetGroup(neutrals);

		[SerializeField, TabGroup("Allies"), ListDrawerSettings(Expanded = true), AssetSelector] private Group[] allies = null;
		[SerializeField, TabGroup("Enemies"), ListDrawerSettings(Expanded = true), AssetSelector] private Group[] enemies = null;
		[SerializeField, TabGroup("Neutrals"), ListDrawerSettings(Expanded = true), AssetSelector] private Group[] neutrals = null;

		private Group[] GetGroup(Group[] group)
		{
			Group[] newGroup = new Group[group.Length];
			group.CopyTo(newGroup, 0);

			return newGroup;
		}
	}
}

using ToolBox.Attributes;
using UnityEngine;

namespace ToolBox.Groups.Utilities
{
	public class Relationships : MonoBehaviour
	{
		public Group[] Allies => GetGroup(allies);
		public Group[] Enemies => GetGroup(enemies);
		public Group[] Neutrals => GetGroup(neutrals);

		[SerializeField, ReorderableList] private Group[] allies = null;
		[SerializeField, ReorderableList] private Group[] enemies = null;
		[SerializeField, ReorderableList] private Group[] neutrals = null;

		private Group[] GetGroup(Group[] group)
		{
			Group[] newGroup = new Group[group.Length];
			group.CopyTo(newGroup, 0);
			return newGroup;
		}
	}
}

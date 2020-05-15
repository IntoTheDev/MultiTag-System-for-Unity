using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Groups
{
	[CreateAssetMenu(menuName = "ToolBox/Groups/Faction")]
	public class Faction : ScriptableObject
	{
		public Group[] Groups => groups;

		[SerializeField,
			ListDrawerSettings(NumberOfItemsPerPage = 10, Expanded = true),
			AssetSelector] private Group[] groups = null;

		public bool IsEntityInFaction(GameObject entity, CheckType checkType) =>
			Group.IsEntityInGroups(entity, groups, checkType);
	}
}

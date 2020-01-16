using UnityEngine;

namespace ToolBox.Groups
{
	public class IncludeSelf : MemberProcessor
	{
		private GameObject cachedObject = null;

		public override void Initialize(Group[] groups, Member member)
		{
			base.Initialize(groups, member);

			cachedObject = member.gameObject;
		}

		public override void OnEnable() =>
			AddToGroups(cachedObject);

		public override void OnDisable() =>
			RemoveFromGroups(cachedObject);

	}
}

using UnityEngine;

namespace ToolBox.Groups
{
	public class IncludeChild : MemberProcessor
	{
		private GameObject[] child = null;

		public override void Initialize(Group[] groups, Member member)
		{
			base.Initialize(groups, member);

			Transform transform = member.transform;
			int childCount = transform.childCount;
			child = new GameObject[childCount];

			for (int i = 0; i < childCount; i++)
				child[i] = transform.GetChild(i).gameObject;
		}

		public override void OnEnable()
		{
			for (int i = 0; i < child.Length; i++)
				AddToGroups(child[i]);
		}

		public override void OnDisable()
		{
			for (int i = 0; i < child.Length; i++)
				RemoveFromGroups(child[i]);
		}
	}
}

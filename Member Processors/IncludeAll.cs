using UnityEngine;

namespace ToolBox.Groups
{
	public class IncludeAll : MemberProcessor
	{
		private GameObject[] entities = null;
		private GameObject cachedObject = null;

		public override void Initialize(Group[] groups, Member member)
		{
			base.Initialize(groups, member);

			Transform transform = member.transform;
			cachedObject = member.gameObject;

			int childCount = transform.childCount;
			int totalCount = childCount + 1;

			entities = new GameObject[totalCount];
			entities[0] = cachedObject;

			for (int i = 0; i < childCount; i++)
			{
				int index = i + 1;
				entities[index] = transform.GetChild(i).gameObject;
			}
		}

		public override void OnEnable()
		{
			for (int i = 0; i < entities.Length; i++)
				AddToGroups(entities[i]);
		}

		public override void OnDisable()
		{
			for (int i = 0; i < entities.Length; i++)
				RemoveFromGroups(entities[i]);
		}
	}
}

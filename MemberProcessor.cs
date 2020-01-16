using UnityEngine;

namespace ToolBox.Groups
{
	public abstract class MemberProcessor
	{
		protected Group[] groups = null;
		protected Member member = null;

		protected void AddToGroups(GameObject entity)
		{
			for (int i = 0; i < groups.Length; i++)
				groups[i].AddMember(entity);
		}

		protected void RemoveFromGroups(GameObject entity)
		{
			for (int i = 0; i < groups.Length; i++)
				groups[i].RemoveMember(entity);
		}

		public virtual void Initialize(Group[] groups, Member member)
		{
			this.groups = groups;
			this.member = member;
		}

		public abstract void OnEnable();

		public abstract void OnDisable();
	}
}

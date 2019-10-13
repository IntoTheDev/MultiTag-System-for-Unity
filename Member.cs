using System.Collections.Generic;
using ToolBox.Attributes;
using UnityEngine;

namespace ToolBox.Groups
{
	[DisallowMultipleComponent]
	public class Member : MonoBehaviour
	{
		[SerializeField, BoxGroup("My Groups")] private List<Group> groups = new List<Group>();
		[SerializeField, ReadOnly, BoxGroup("Debug")] private int groupsCount;

		private GameObject cachedGameObject;

		private void Awake()
		{
			cachedGameObject = gameObject;
			groupsCount = groups.Count;

			if (groupsCount <= 0)
			{
				Debug.LogError(name + " have 0 groups!");
				Destroy(this);
			}
		}

		private void OnValidate()
		{
			if (groups != null && groups.Count > 0)
				groupsCount = groups.Count;

			cachedGameObject = gameObject;
		}

		private void OnEnable()
		{
			for (int i = 0; i < groupsCount; i++)
				groups[i].AddMember(cachedGameObject);

			groupsCount = groups.Count;
		}

		private void OnDisable()
		{
			for (int i = 0; i < groupsCount; i++)
				groups[i].RemoveMember(cachedGameObject);

			groupsCount = 0;
		}

		public void AddGroup(Group group)
		{
			if (!groups.Contains(group))
			{
				groups.Add(group);
				group.AddMember(cachedGameObject);
				groupsCount++;
			}
		}

		public void RemoveGroup(Group group)
		{
			if (groups.Contains(group))
			{
				groups.Remove(group);
				group.RemoveMember(cachedGameObject);
				groupsCount--;
			}
		}

		public void ClearGroups()
		{
			for (int i = 0; i < groupsCount; i++)
				RemoveGroup(groups[i]);

			groups.Clear();
			groupsCount = 0;
		}
	}
}


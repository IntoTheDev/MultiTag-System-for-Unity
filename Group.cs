using UnityEngine;
using System.Collections.Generic;
using ToolBox.Attributes;

[CreateAssetMenu(menuName = "ToolBox/Group")]
public class Group : ScriptableObject
{
	// For returns 
	private List<GameObject> listMembers = new List<GameObject>();

	// For checking
	private HashSet<GameObject> hashMebmers = new HashSet<GameObject>();

	[SerializeField, ReadOnly, BoxGroup("Debug")] private int membersCount = 0;

	/// <summary>
	/// Adds a target to the group
	/// </summary>
	public void AddToGroup(GameObject target)
	{
		if (!hashMebmers.Contains(target))
		{
			listMembers.Add(target);
			hashMebmers.Add(target);

			membersCount++;
		}
	}

	/// <summary>
	/// Removes a target from the group
	/// </summary>
	public void RemoveFromGroup(GameObject target)
	{
		if (hashMebmers.Contains(target))
		{
			listMembers.Remove(target);
			hashMebmers.Remove(target);

			membersCount--;
		}
	}

	/// <summary>
	/// Checks if the target is in a group
	/// </summary>
	public bool IsTargetInGroup(GameObject target)
	{
		return hashMebmers.Contains(target);
	}

	/// <summary>
	/// Returns a random member of the group
	/// </summary>
	public GameObject GetRandomMemberInGroup()
	{
		if (IsGroupEmpty())
			return null;

		int randomIndex = Random.Range(0, membersCount - 1);
		return listMembers[randomIndex];
	}

	/// <summary>
	/// Returns a certain number of group members
	/// </summary>
	public GameObject[] GetRandomMembersInGroup(int count)
	{
		if (IsGroupEmpty())
			return null;

		GameObject[] randomObjects = new GameObject[count];
		int randomIndex = -1;

		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < 10000; j++)
			{
				int newRandomIndex = Random.Range(0, membersCount - 1);

				if (newRandomIndex != randomIndex)
				{
					randomIndex = newRandomIndex;
					randomObjects[i] = listMembers[randomIndex];
					break;
				}
			}
		}

		return randomObjects;
	}

	/// <summary>
	/// Returns all group members
	/// </summary>
	public GameObject[] GetAllMembersInGroup()
	{
		if (IsGroupEmpty())
			return null;

		GameObject[] allMembers = new GameObject[membersCount];
		allMembers = listMembers.ToArray();

		return allMembers;
	}

	/// <summary>
	/// Checks if there is a target in all or one of these groups
	/// </summary>
	public static bool IsTargetInGroups(Group[] groups, GameObject target, CheckType checkType)
	{
		int groupsCount = groups.Length;

		if (checkType == CheckType.AllGroups)
		{
			for (int i = 0; i < groupsCount; i++)
			{
				if (!groups[i].IsTargetInGroup(target))
					return false;
			}

			return true;
		}
		else
		{
			for (int i = 0; i < groupsCount; i++)
			{
				if (groups[i].IsTargetInGroup(target))
					return true;
			}

			return false;
		}
	}

	private bool IsGroupEmpty()
	{
		return membersCount <= 0;
	}
}

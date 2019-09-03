using UnityEngine;
using NaughtyAttributes;

[DisallowMultipleComponent]
public class Member : MonoBehaviour
{
	[SerializeField, ReorderableList, BoxGroup("My Groups")] private Group[] groups;
	[SerializeField, ReadOnly, BoxGroup("Debug")] private int groupsCount;
	private GameObject cachedGameObject;

	private void Awake()
	{
		cachedGameObject = gameObject;
		groupsCount = groups.Length;

		if (groupsCount <= 0)
		{
			Debug.LogError(name + " have 0 groups!");
			Destroy(this);
		}
	}

	private void OnValidate()
	{
		groupsCount = groups.Length;
	}

	private void OnEnable()
	{
		for (int i = 0; i < groupsCount; i++)
		{
			groups[i].AddToGroup(cachedGameObject);
		}
	}

	private void OnDisable()
	{
		for (int i = 0; i < groupsCount; i++)
		{
			groups[i].RemoveFromGroup(cachedGameObject);
		}
	}
}

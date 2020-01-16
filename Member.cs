using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.ObjectModel;
using UnityEngine;

namespace ToolBox.Groups
{
	[DisallowMultipleComponent]
	public class Member : SerializedMonoBehaviour
	{
		[OdinSerialize, TabGroup("Processor")] private MemberProcessor memberProcessor = null;
		[SerializeField, TabGroup("Data"), AssetSelector, ListDrawerSettings(Expanded = true)] private Group[] groups = null;

		private GameObject cachedGameObject = null;

		private void Awake()
		{
			cachedGameObject = gameObject;

			if (groups.Length <= 0 || memberProcessor == null)
			{
				Debug.LogError("Member Error", cachedGameObject);
				enabled = false;
				return;
			}

			memberProcessor.Initialize(groups, this);
		}

		private void OnEnable() =>
			memberProcessor.OnEnable();

		private void OnDisable() =>
			memberProcessor.OnDisable();

#if UNITY_EDITOR
		public ReadOnlyCollection<Group> GetGroups()
		{
			ReadOnlyCollection<Group> groups = Array.AsReadOnly(this.groups);
			return groups;
		}
#endif
	}
}


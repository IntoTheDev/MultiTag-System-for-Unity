using UnityEngine;
using ToolBox.Groups;
using UnityEditor;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class GroupEditor : EditorWindow
{
	private Group group = null;

	private List<Member> scene = null;
	private List<Member> assets = null;

	private int sceneCount = 0;
	private int assetsCount = 0;

	private Vector2 scrollPosition = Vector2.zero;

	[MenuItem("Window/ToolBox/Group")]
	public static void ShowWindow()
	{
		GetWindow<GroupEditor>("Group");
	}

	private void OnGUI()
	{
		scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true);

		MainDraw();
		FindListeners();

		GUILayout.Space(50f);

		GUILayout.Label("Members in Assets", EditorStyles.boldLabel);

		EditorGUI.BeginDisabledGroup(true);
		DrawMembers(assetsCount, assets);
		EditorGUI.EndDisabledGroup();

		GUILayout.Space(50f);

		GUILayout.Label("Members in Scene", EditorStyles.boldLabel);

		EditorGUI.BeginDisabledGroup(true);
		DrawMembers(sceneCount, scene);
		EditorGUI.EndDisabledGroup();

		GUILayout.EndScrollView();
	}

	private void MainDraw()
	{
		GUILayout.Label("Group", EditorStyles.boldLabel);
		group = EditorGUILayout.ObjectField("", group, typeof(Group), true) as Group;
	}

	private void FindListeners()
	{
		if (group == null)
		{
			if (scene != null)
				scene.Clear();

			if (assets != null)
				assets.Clear();

			sceneCount = 0;
			assetsCount = 0;

			return;
		}

		Member[] members = Resources.FindObjectsOfTypeAll<Member>();

		scene = new List<Member>();
		assets = new List<Member>();

		int membersCount = members.Length;

		for (int i = 0; i < membersCount; i++)
		{
			Member member = members[i];
			ReadOnlyCollection<Group> groups = member.GetGroups();
			int count = groups.Count;

			for (int j = 0; j < count; j++)
			{
				Group group = groups[j];

				if (group == this.group)
				{
					if (member.gameObject.scene.IsValid())
						scene.Add(member);
					else
						assets.Add(member);

					break;
				}
			}
		}

		sceneCount = scene.Count;
		assetsCount = assets.Count;
	}

	private void DrawMembers(int count, List<Member> collection)
	{
		for (int i = 0; i < count; i++)
			collection[i] = EditorGUILayout.ObjectField("", collection[i], typeof(Member), true) as Member;
	}
}

using UnityEngine;

namespace ToolBox.Tags
{
	public static class TagExtensions
	{
		public static void AddTag(this GameObject instance, Tag tag) =>
			tag.Add(instance);

		public static void RemoveTag(this GameObject instance, Tag tag) =>
			tag.Remove(instance);

		public static bool HasTag(this GameObject entity, Tag tag) =>
			tag.HasInstance(entity.GetHashCode());

		public static void AddTags(this GameObject instance, Tag[] tags)
		{
			for (int i = 0; i < tags.Length; i++)
				tags[i].Add(instance);
		}

		public static void AddTags(this GameObject instance, TagsContainer container) =>
			container.Add(instance);

		public static void RemoveTags(this GameObject instance, Tag[] tags)
		{
			for (int i = 0; i < tags.Length; i++)
				tags[i].Remove(instance);
		}

		public static void RemoveTags(this GameObject instance, TagsContainer container) =>
			container.Remove(instance);

		public static bool HasTags(this GameObject instance, Tag[] tags, bool allRequired)
		{
			int hash = instance.GetHashCode();

			for (int i = 0; i < tags.Length; i++)
			{
				if (tags[i].HasInstance(hash) == !allRequired)
					return !allRequired;
			}

			return allRequired;
		}

		public static bool HasTags(this GameObject instance, TagsContainer container, bool allRequired) =>
			container.HasInstance(instance, allRequired);
	}
}


using UnityEngine;

namespace ToolBox.Tags
{
	public static class TagExtensions
	{
		public static void AddTag(this GameObject entity, Tag tag)
		{
#if UNITY_EDITOR
			var taggable = entity.GetComponent<Taggable>();

			if (taggable == null)
				taggable = entity.AddComponent<Taggable>();

			taggable.AddTagInEditor(tag);
#endif

			tag.Add(entity.GetHashCode());
		}

		public static void RemoveTag(this GameObject entity, Tag tag)
		{
#if UNITY_EDITOR
			var taggable = entity.GetComponent<Taggable>();

			if (taggable == null)
				taggable = entity.AddComponent<Taggable>();

			taggable.RemoveTagInEditor(tag);
#endif

			tag.Remove(entity.GetHashCode());
		}

		public static bool HasTag(this GameObject entity, Tag tag) =>
			tag.HasEntity(entity.GetHashCode());

		public static void AddTags(this GameObject entity, Tag[] tags)
		{
			int hash = entity.GetHashCode();
#if UNITY_EDITOR
			var taggable = entity.GetComponent<Taggable>();

			if (taggable == null)
				taggable = entity.AddComponent<Taggable>();
#endif

			for (int i = 0; i < tags.Length; i++)
			{
				var tag = tags[i];
				tag.Add(hash);
#if UNITY_EDITOR
				taggable.AddTagInEditor(tag);
#endif
			}
		}

		public static void RemoveTags(this GameObject entity, Tag[] tags)
		{
			int hash = entity.GetHashCode();
#if UNITY_EDITOR
			var taggable = entity.GetComponent<Taggable>();

			if (taggable == null)
				taggable = entity.AddComponent<Taggable>();
#endif

			for (int i = 0; i < tags.Length; i++)
			{
				var tag = tags[i];
				tag.Remove(hash);
#if UNITY_EDITOR
				taggable.RemoveTagInEditor(tag);
#endif
			}
		}

		public static bool HasTags(this GameObject entity, Tag[] tags, bool allRequired)
		{
			int hash = entity.GetHashCode();

			if (allRequired)
			{
				for (int i = 0; i < tags.Length; i++)
				{
					if (!tags[i].HasEntity(hash))
						return false;
				}

				return true;
			}
			else
			{
				for (int i = 0; i < tags.Length; i++)
				{
					if (tags[i].HasEntity(hash))
						return true;
				}

				return false;
			}
		}

		public static bool HasTags(this GameObject entity, TagsContainer tagsContainer, bool allRequired) =>
			tagsContainer.HasEntity(entity, allRequired);
	}
}


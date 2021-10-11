using UnityEngine;

namespace ToolBox.Tags
{
	public static class TagHelper
	{
		public static void AddTag(this GameObject instance, Tag tag)
		{
#if UNITY_EDITOR
			var taggable = GetComponent(instance);
			if (!taggable.Contains(tag))
				taggable.Add(tag);
#endif

			tag.Add(instance, instance.GetHashCode());
		}

		public static void AddTag(this Component instance, Tag tag)
		{
			instance.gameObject.AddTag(tag);
		}

		public static void RemoveTag(this GameObject instance, Tag tag)
		{
#if UNITY_EDITOR
			var taggable = GetComponent(instance);
			if (taggable.Contains(tag))
				taggable.Remove(tag);
#endif

			tag.Remove(instance, instance.GetHashCode());
		}

		public static void RemoveTag(this Component instance, Tag tag)
		{
			instance.gameObject.RemoveTag(tag);
		}

		public static bool HasTag(this GameObject instance, Tag tag)
		{
			return tag.HasInstance(instance.GetHashCode());
		}

		public static bool HasTag(this Component instance, Tag tag)
		{
			return instance.gameObject.HasTag(tag);
		}

		public static void AddTags(this GameObject instance, Tag[] tags)
		{
#if UNITY_EDITOR
			var taggable = GetComponent(instance);
#endif

			int hash = instance.GetHashCode();

			for (int i = 0; i < tags.Length; i++)
			{
				var tag = tags[i];

#if UNITY_EDITOR
				if (!taggable.Contains(tag))
					taggable.Add(tag);
#endif

				tag.Add(instance, hash);
			}
		}

		public static void AddTags(this Component instance, Tag[] tags)
		{
			instance.gameObject.AddTags(tags);
		}

		public static void AddTags(this GameObject instance, CompositeTag composite)
		{
#if UNITY_EDITOR
			var taggable = GetComponent(instance);

			foreach (var tag in composite.Tags)
			{
				if (taggable.Contains(tag))
					continue;

				taggable.Add(tag);
			}
#endif

			composite.Add(instance, instance.GetHashCode());
		}

		public static void AddTags(this Component instance, CompositeTag composite)
		{
			instance.gameObject.AddTags(composite);
		}

		public static void RemoveTags(this GameObject instance, Tag[] tags)
		{
#if UNITY_EDITOR
			var taggable = GetComponent(instance);
#endif

			int hash = instance.GetHashCode();

			for (int i = 0; i < tags.Length; i++)
			{
				var tag = tags[i];

#if UNITY_EDITOR
				if (taggable.Contains(tag))
					taggable.Remove(tag);
#endif

				tag.Remove(instance, hash);
			}
		}

		public static void RemoveTags(this Component instance, Tag[] tags)
		{
			instance.gameObject.RemoveTags(tags);
		}

		public static void RemoveTags(this GameObject instance, CompositeTag composite)
		{
#if UNITY_EDITOR
			var taggable = GetComponent(instance);

			foreach (var tag in composite.Tags)
			{
				if (!taggable.Contains(tag))
					continue;

				taggable.Remove(tag);
			}
#endif
			
			composite.Remove(instance, instance.GetHashCode());
		}

		public static void RemoveTags(this Component instance, CompositeTag composite)
		{
			instance.gameObject.RemoveTags(composite);
		}

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

		public static bool HasTags(this Component instance, Tag[] tags, bool allRequired)
		{
			return instance.gameObject.HasTags(tags, allRequired);
		}

		public static bool HasTags(this GameObject instance, CompositeTag composite, bool allRequired)
		{
			return composite.HasInstance(instance, allRequired);
		}

		public static bool HasTags(this Component instance, CompositeTag composite, bool allRequired)
		{
			return instance.gameObject.HasTags(composite, allRequired);
		}

#if UNITY_EDITOR
		private static Taggable GetComponent(GameObject instance)
		{
			if (!instance.TryGetComponent(out Taggable taggable))
				taggable = instance.AddComponent<Taggable>();

			return taggable;
		}
#endif
	}
}
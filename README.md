# MultiTag System for Unity
This package allows you to Tag Game Objects with ScriptableObjects.

### TODO
- [x] Editor support with custom inspector
- [ ] Add tag code generator to quickly access tags without referencing them in the inspector
- [ ] Add API to get entity's runtime added tags

## Features
- Allows you to put as many Tags on your GameObject as you want
- Add and remove tags via code and inspector
- Work with ScriptableObjects instead of strings
- Faster than Unity's tag system. Keep in mind that such methods as AddTag, AddTags, RemoveTag and RemoveTags are way slower in Editor than in Build because of the Taggable component's updates and Custom Inspector 
- Editor support

## How to Install
### Git Installation (Best way to get latest version)

If you have Git on your computer, you can open Package Manager indside Unity, select "Add package from Git url...", and paste link ```https://github.com/IntoTheDev/MultiTag-System-for-Unity.git```

or

Open the manifest.json file of your Unity project.
Add ```"com.intothedev.multitags": "https://github.com/IntoTheDev/MultiTag-System-for-Unity.git"```

### Manual Installation (Version can be outdated)
Download latest package from the Release section.
Import MultiTags.unitypackage to your Unity Project

## Usage

### How to create a new Tag/CompositeTag
Assets/Create/ToolBox/Tags

### Change Tags in Editor
If you want to change tags only in Runtime via code then ```Taggable``` component is unnecessary.

![](https://i.imgur.com/4IMUydj.png)

### Runtime Operations (HasTag, HasTags, AddTag, RemoveTag, GetInstances, etc)
<details><summary>Code</summary>	
<p>	
	
```csharp
using ToolBox.Tags;
	
public class Test : MonoBehaviour
{
	[SerializeField] private GameObject _enemy = null;
	[SerializeField] private Tag _zombieTag = null;
	[SerializeField] private CompositeTag _allEnemiesTags = null;
 
	private void Awake()
	{
		// Check for Tag
		if (_enemy.HasTag(_zombieTag))
		{
		
		}
		
		// Check for Multiple Tags
		// You can also pass in simple array of tags
		if (_enemy.HasTags(_allEnemiesTags, allRequired: false))
		{
		
		}
		
		// Add Tag
		// Be careful, if you create a copy of an existing object with added/removed tags via API (AddTag, RemoveTag, etc). 
		// These tags will not be copied to the new object. 
		// But I'll implement a way to copy tags in the future.
		_enemy.AddTag(_zombieTag);
		
		// Remove Tag
		_enemy.RemoveTag(_zombieTag);
		
		
		// Get all objects with tag
		var zombies = _zombieTag.GetInstances();
		
		foreach (var zombie in zombies)
		{
			// Do something
		}
	
		// Instead of gameObject you can use any class that inherits from Component (transform, collider, etc)
		// Example:
		_enemy.transform.AddTag(_zombieTag);
	}
}
```	

</p>
</details>

### CompositeTag Usage
CompositeTag allows you to combine tags into single asset and use API with that asset (AddTags, RemoveTags, HasTags)

Example: 

![](https://i.imgur.com/nnxY4kj.png)


### Performance Test
<details><summary>Code</summary>
<p>

```csharp
using Sirenix.OdinInspector;
using System.Diagnostics;
using ToolBox.Tags;
using UnityEngine;

namespace ToolBox.Test
{
	[DefaultExecutionOrder(-100)]
	public class Tester : MonoBehaviour
	{
		[SerializeField] private Tag _myTag = null;
		[SerializeField] private string _unityTag = null;
		[SerializeField] private GameObject _object = null;

		private const int ITERATIONS = 100000;

		[Button]
		private void MyTagTest()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			for (int j = 0; j < ITERATIONS; j++)
			{
				_object.HasTag(_myTag);
			}

			stopwatch.Stop();
			UnityEngine.Debug.Log($"Scriptable Object Tag Comparer: {stopwatch.ElapsedMilliseconds} milliseconds");
		}

		[Button]
		private void UnityTagTest()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			for (int j = 0; j < ITERATIONS; j++)
			{
				_object.CompareTag(_unityTag);
			}

			stopwatch.Stop();
			UnityEngine.Debug.Log($"Unity Tag Comparer: {stopwatch.ElapsedMilliseconds} milliseconds");
		}
	}
}

```
</p>
</details>

<details><summary>Test Result</summary>	
<p>
	
![Result](https://imgur.com/c8rnKdo.png)

</p>
</details>






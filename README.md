# MultiTag System for Unity
This package allows you to Tag your Game Objects with ScriptableObjects.

## Features:
- Allows to put as many Tags on your object as you want
- Adding and Removing Tags via Inspector and Code (Works faster in Build than in Editor because Inspector updating when tag added/removed from object)
- Work with SO Assets instead of strings
- Works few times faster than Unity Tag Comparer

## Examples:

### Creating new Tag/Container:
Assets/Create/ToolBox/MultiTags

### Change Tags in Editor:
![](https://imgur.com/EPxkbza.png)

### Runtime Operations:
<details><summary>Code</summary>	
<p>
	
```csharp
public class Test : MonoBehaviour
{
	[SerializeField] private GameObject _enemy = null;
	[SerializeField] private Tag _zombieTag = null;
	[SerializeField] private TagsContainer _allEnemiesTags = null;
 
	private void Awake()
	{
		// Check for Tag
		if (_enemy.HasTag(_zombieTag))
		{
		
		}
		
		// Check for Multiple Tags
		if (_enemy.HasTags(_allEnemiesTags, allRequired: false))
		{
		
		}
		
		// Adding Tag
		_enemy.AddTag(_zombieTag);
		
		// Removing Tag
		_enemy.RemoveTag(_zombieTag);
	}
}
```	

</p>
</details>

### Tags Container Usage:
Tags Container allows you to group tags in a single asset, which allows you to check a single object for multiple tags at once. In my games, I use containers most often for a system of relationships between entities.

![](https://imgur.com/XTM5YOU.png)


### Performance Test:
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

<details><summary>Scene and Objects Setup</summary>	
<p>
	
![Scene Setup](https://imgur.com/IgSjjpz.png)

![A Object Setup](https://imgur.com/0kkITFa.png)

![B Object Setup](https://imgur.com/4DVS3XP.png)
</p>
</details>

<details><summary>Test Result</summary>	
<p>
	
![Result](https://imgur.com/c8rnKdo.png)

</p>
</details>






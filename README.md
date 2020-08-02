# MultiTag System for Unity
This package allows you to Tag your Game Objects with ScriptableObjects.

## Features:
- Allows to put as many Tags on your object as you want
- Adding and Removing Tags via Inspector and Code (Works faster in Build than in Editor because of the Inspector updating when adding and removing tags)
- Work with SO Assets instead of strings
- Works few times faster than Unity Tag Comparer

## Examples:

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
using ToolBox.Pools;
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

		[SerializeField, ReadOnly] private float _myMS = 0;
		[SerializeField, ReadOnly] private float _unityMS = 0;

		[SerializeField, ReadOnly] private bool _hasMyTag = false;
		[SerializeField, ReadOnly] private bool _hasUnityTag = false;

		private const int ITERATIONS = 10;

		[Button]
		private void MyTagTest()
		{
			_myMS = 0f;

			for (int i = 0; i < ITERATIONS; i++)
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();

				for (int j = 0; j < 100000; j++)
				{
					_hasMyTag = _object.HasTag(_myTag);
				}

				stopwatch.Stop();
				_myMS += stopwatch.ElapsedMilliseconds;
			}

			_myMS /= ITERATIONS;
		}

		[Button]
		private void UnityTagTest()
		{
			_unityMS = 0;

			for (int i = 0; i < ITERATIONS; i++)
			{
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();

				for (int j = 0; j < 100000; j++)
				{
					_hasUnityTag = _object.CompareTag(_unityTag);
				}

				stopwatch.Stop();
				_unityMS += stopwatch.ElapsedMilliseconds;
			}

			_unityMS /= ITERATIONS;
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
	
![Result](https://imgur.com/YedN04E.png)

</p>
</details>






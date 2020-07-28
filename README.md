# MultiTag System for Unity
This package allows you to Tag your Game Objects with ScriptableObjects

## Features:
- Allows to put as many Tags on your object as you want
- Runtime Tag add/remove
- Work with SO Assets instead of strings
- Works few times faster than Unity Tag Comparer

## Examples:

### Adding Tags in Editor:
![](https://imgur.com/EPxkbza.png)

### Runtime Operations:
```csharp
public class Test : MonoBehaviour
{
	[SerializeField] private GameObject _enemy = null;
	[SerializeField] private Tag _zombieTag = null;
	[SerializeField] private TagsContainer = _allEnemiesTags = null;
 
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

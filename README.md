# Group-System-for-Unity

This system will allow you to add your object to a group of similar objects, you can think of it as a multi-tag. Also, this system allows you to get from any group random objects or even get the whole group and put in an list.

## Requirements
[NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes) for some attributes (not necessary, you can just remove the extra attributes).

Patience to read my bad English

## Usage
Throw scripts from this repository into your project

### Group creation
You can create a group through the context menu in the project folder. This will create a ScriptableObject in your folder.

![Group Creation](https://i.gyazo.com/14ecd854f94ccaeba75405147aa10850.png)

### Attach an object to a group/groups

Simply attach the "Member" script to the object you want to add to the desired groups.

![MemberScript](https://i.gyazo.com/10a39a8cdd0050065923af66082fb111.png)

### Examples

#### Example of checking an entity for membership in one of the groups. (Like CompareTag, but 2 times faster, with more functionality and no need to work with strings)

```csharp
using UnityEngine;

public class GroupExample : MonoBehaviour
{
	[SerializeField] private Group enemies = null;
	[SerializeField] private GameObject target = null;

	private void Update()
	{
		if (enemies.HasMember(target))
		{
			// Do something
		}
	}
}
```

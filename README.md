# Group-System-for-Unity
This system will allow you to place your objects in groups and access them

This system will allow you to add your object to a group of similar objects, you can think of it as a multi "Tag". Also, this system allows you to get from any group random objects or even get the whole group and put in an array.

## Requirements
[NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes) for some attributes.

## Usage
Throw scripts from this repository into your project

### Group creation
You can create a group through the context menu in the project folder. This will create a ScriptableObject in your folder.

![Group Creation](https://i.gyazo.com/14ecd854f94ccaeba75405147aa10850.png)

### Attach an object to a group/groups

Simply attach the "Member" script to the object you want to add to the desired groups and add the desired groups using the inspector.

![MemberScript](https://i.gyazo.com/10a39a8cdd0050065923af66082fb111.png)

### Examples

#### Example with getting all objects from the group.

Let's say you have in the game merchants of different races and you want to give the item called "Goblin dagger" only to merchants of Goblin race. 

We have such groups in the game and adding a dagger to Goblin merchants is very simple.

![Example00](https://i.gyazo.com/d66e91d567f7bc5d9ac2bd7a9f7e2043.png)

Add a "GiveItem" script to Goblin merchants.

![Example01](https://i.gyazo.com/49d96516a3f53a6fde6e695c3a1dad07.png)

And write some code

```csharp
using UnityEngine;

public class GiveItem : MonoBehaviour
{
	[SerializeField] private Group goblinMerchants;
	[SerializeField] private GameObject[] goblins;

	private void Start()
	{
		goblins = goblinMerchants.GetAllMembersInGroup();
		GiveItemToGoblinMerchants();
	}

	private void GiveItemToGoblinMerchants()
	{
		for (int i = 0; i < goblins.Length; i++)
		{
			// Give item to goblins
		}
	}
}

```

### Example with checking if the desired goal is in the right groups.

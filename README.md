# Group-System-for-Unity

This system will allow you to add your object to a group of similar objects, you can think of it as a multi-tag. Also, this system allows you to get from any group random objects or even get the whole group and put in an list.

## Requirements
[NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes) for some attributes (not necessary, you can just remove the extra attributes).

Patience to read my bad English

## Performance
I have 5000 objects, 2500 with the tag "Human" and 2500 with the tag "Zombie". My task is to find all the zombies and destroy them.

Classic way:
```csharp
zombies = GameObject.FindGameObjectsWithTag("Zombie");
```
It cost me: 19.6 KB GC Alloc & 0.5 Self ms

Group way:
```csharp
zombies = new List<GameObject>(zombiesGroup.GetAllMembers());
```

It cost me: 19.6 KB GC Alloc & 0 Self ms

Almost nothing has changed, but let's look further.

The same number of objects, but now our goal is to set ignite to all the characters who have a component "Ignitable". Imagine that we used the global ability on the entire map and got an array of all the characters that need to be set on ignite.

Classic way:
```csharp
Collider2D[] colliders = Physics2D.OverlapCircleAll(cachedTransform, radius, layerMask);

for (int i = 0; i < colliders.Length; i++)
{
	GameObject character = colliders[i].gameObject;

	if (character.GetComponent<Ignitable>())
	{
		// Start ignite
	}
} 
```
It cost me: 1.4 MB GC Alloc & 22.38 Self ms

Group way:
```csharp
Collider2D[] colliders = Physics2D.OverlapCircleAll(cachedTransform, radius, layerMask);

for (int i = 0; i < colliders.Length; i++)
{
	GameObject character = colliders[i].gameObject;

	if (ignitableGroup.HasMember(character))
	{
		if (character.GetComponent<Ignitable>() != null)
		{
			// Start ignite
		}
	}
} 
```

It cost me: 0 KB GC Alloc & 1.8 Self ms

## Usage
Throw scripts from this repository into your project

### Group creation
You can create a group through the context menu in the project folder. This will create a ScriptableObject in your folder.

![Group Creation](https://i.gyazo.com/14ecd854f94ccaeba75405147aa10850.png)

### Attach an object to a group/groups

Simply attach the "Member" script to the object you want to add to the desired groups.

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
using System.Collections.Generic;

public class GiveItem : MonoBehaviour
{
	[SerializeField] private Group goblinMerchants;
	[SerializeField] private List<GameObjects> goblins = new List<GameObjects>();

	private void Start()
	{
		goblins = new List<GameObject>(goblinMerchants.GetAllMembers());
		GiveItemToGoblinMerchants();
	}

	private void GiveItemToGoblinMerchants()
	{
		for (int i = 0; i < goblins.Count; i++)
		{
			// Give item to goblins
		}
	}
}

```

### Example with checking if the desired target is in the right groups.

Imagine that we have a bullet that can set ignite to enemies who are not immune to ignite. Instead of adding to our enemy components of immunity, such as immunity to ignite, cold and others. We can add this enemy in a group with the name "ImmuteToIgnite"

```csharp
using UnityEngine;

public class BurningBullet : MonoBehaviour
{
	[SerializeField] private Vector3 bulletSpeed;
	[SerializeField] private Group immuneEnemies;

	private Transform myTransform;

	private void Update()
	{
		myTransform.position += bulletSpeed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider enemy)
	{
		// 2x Faster
		if (!immuneEnemies.HasMember(enemy.gameObject))
		{
			// Burn enemy
		}

		// 2x slower
		if (!enemy.GetComponent<ImmuneToIgnite>())
		{
			// Burn enemy
		}
	}
}

```

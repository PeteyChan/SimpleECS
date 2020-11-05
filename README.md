# SimpleECS
A Simple and easy to use C# Entity Component System


## Entities and Components
Creating Entities and Components can't get any easier.
```C#
var entity = new Entity();    // creates a new entity

class Component    // components are just any regular class or struct
{
  public int value;
}
```

Adding, retrieving and removing components is also dead simple
```C#
var entity = new Entity(new Component{value = 3}, 4, "Hello");    // you can add components during entity creation

entity.Set(new Component(value = 4));    // or afterwards with Set

//Set functions as both an add component or replace component depending if the entity already has the component

if (entity.TryGet(out Component c, out int i))    // you can retrieve components with TryGet
{
    c.value++;
    i++;
    entity.Set(s);  // structs will need to be set afterwards
}

entity.Remove<int>(); // you remove components with Remove

entity.RemoveAll(); // or all components at once with RemoveAll
                    // this effectively 'deletes' the entity for the gc to handle
                    // unless another component is set

if (entity.Has<int>() && entity.Not<string>())
{
  // you can also do basic querying of components with has and not  
}

entity.GetAllComponents();       // returns all components currently on the entity
```
## Systems

My belief is that systems are best tailored to the specific application your building.
So keeping that in mind, Simple ECS's Systems can't get any simpler because there isn't any.
Instead there are Queries.

## Queries

Queries let you iterate over entities based on specified components you
include or exclude. Queries are very straight forward to create and use.

```C#
// you can chain as many includes and excludes as you want
// but adding too many can decrease performance

var query = new Entity.Query().Include<int, string>() // included components
                              .Exclude<float>();      // excluded components

foreach (var entity in query) // you then iterate with foreach
{
    if (entity.TryGet(out string str, out int i))
    {
      // do something
    }
}
```

You can also do simple multithreading if you are expecting a large query
```C#
if (query.QueryCount > 10000) 
{                             
    query.ForeachParallel(entity =>     // structural changes such as adding and removing components or entities
    {                                   // is not safe. Only the modification of components and only 
        if (entity.TryGet(out int i))   // if they are not shared elsewhere is safe to do
        {                               
            // do something
        }
    });
}
```
If you just need to iterate over a single component, you can do so directly
```C#
foreach(var entity in Entity.AllWith<Component>())  // iteration is faster since there is no filtering
{
    // iterate over all entities that have component
}

foreach(var component in Entity.AllComponents<Component>()) // fastest way to iterate over components
{
    // great if you don't need a reference to an entity
}

foreach(var entity in Entity.All)
{
    // iterates over all entities that contain atleast one component
}
```

## Events
Finally there are a couple Event callbacks which are useful if you want to make reactive systems

```C#
// is called at the end of Set if the component was added
// calling entity.Has<Component>() at this point will return true
Entity.Events<Component>.OnAdd += (Entity entity, Component addedComponent) => 
{ 
    // do something when the component is added
};

// is called at the end of Remove if the component was removed
// calling entity.Has<Component>() at this point will return false
Entity.Events<Component>.OnRemove += (Entity entity, Component removedComponent) =>
{
    // do something when the component is removed
};
```

## Tips

Queries use the first include to peform their search over, so always try to 
include the most specific component with the least entities first to increase performance
```C#
var query = new Entity.Query().Include<Transform, Player>(); // instead of this
var query = new Entity.Query().Include<Player, Transfrom>(); // do this
```

entity.Set() and entity.SetComponents() work slightly differently. 
Choose which one works best for your situation 
```C#
class Component: IInterface
{}

IInterface component = new Component();

entity.Set(component);           // set adds the component as the current type
                                 // which in this case will set IInterface as the 
                                 // component to the entity
                                  
entity.SetComponents(component); // while set components adds objects by it's type
                                 // which in this case is Component

new Entity(component);           // coincidentally this is equivilant to new Entity().SetComponents(component)
```

Lastly, when removing large amounts of components, the backing arrays may be larger than they need to be.
To free up space, especially if your changing scenes in a game engine you can resize them simply by calling
```C#
// resizes all backing arrays to the minimum power of 2 needed to contain all components
Entity.ResizeBackingArrays();
```

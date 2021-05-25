# SimpleECS
A Simple and easy to use C# Entity Component System.
Min C# Framework 4.7

### Features:
* No Dependencies, just build and drop in however you want
* No setup or boilerplate like marking components or code generators
* Archetype based = fast component iteration
* Very simple and easy to use queries

## Entities
To create an entity use Entity.Create() with the components as arguments. 
Anything that can be put into a list can be a component.
The function can take up to 64 components, but entities themselves have 
no component limit.
```C#
Entity.Create("my entity", 3, 5f);    // creates a new entity with components
```

Manipulating entities is pretty simple
```C#
if(entity)              // returns false if entity is destroyed or invalid
{}

entity.Get<int>() += 4; // gets the entity's component by ref value.
                        // throws an exception if the entity is invalid or
                        // the entity does not have the component
                        // since they are returned by ref, you can assign values directly

entity.Set(3)             // sets the entity's components to values.
      .Set("my entity");  // can be chained for easier use.
                          // component is added if entity does not already contain one 

if (enity.Has<int>())     // returns true if entity has component
{
  // do something
}

if (entity.TryGet<int>(out var value)) // gets the component's value on entity, returns false if not found
{
    entity.Set(value + 4);             // Value types need to be set afterwards for changes to take place
}

entity.Remove<T>();   // removes the component on entity if found.
                    
entity.Destroy();     // destroys the entity leaving it invalid

```

### Component Callbacks
There are 2 callbacks which components can implement. IOnSetCallback and IOnRemoveCallback.
Although most sources say ECS components should be plain data, these callbacks make it easier to use 
SimpleECS with game engines such as Unity.
```C#
class MyComponent: IOnSetCallback, IOnRemoveCallback
{
  void IOnSetCallback.OnSetBy(Entity entity)  // called whenever entity sets the component with OnSet()
  {                                           // or during entity creation
    Console.WriteLine($"{entity} set MyComponent");    
  }
  
  void IOnRemoveCallback.OnRemoveBy(Entity entity)        // called when the entity removes the component or
  {                                                       // if the entity was destroyed. If entity was destroyed
    Console.WriteLine($"{entity} removed MyComponent");   // if(entity) will return false
  }
}
```

## Queries

Queries let you iterate over entities based on specified components.
You can specify up to 16 components to iterate over.
Queries cache their results and only update when new archetypes are created.

```C#
var query = new Query().Has<int>().Has<float>()       // Has() filters entities to those with components
                       .Not<string>().Not<double>();  // Not() filters for those that do not
                                                      // there's no limit to the amount of filters you can add
                                                      // infact the more specific the better

query.Foreach( (ref int int_value, ref float float_value) =>  // you then use the foreach function to update your components
{                                                             // components must be prefaced with the ref modifier
    int_value ++;                                             // you can use up to 16 components as parameters
    float_value = int_value * 100;                            // queries operate only on entities that match both the query 
}));                                                          // filter and contains all the foreach parameters


query.Foreach( (Entity entity, ref int value ) =>         // you can access the owner entity by putting it in the first position
{                                                         // without modifiers. You can then add any components you want to use
  Console.WriteLine($"{entity} value is {value}");        // afterwards
});

var all_entities = new Query();                       // a simple way to match against all entities is to make a query with no filters
all_entities.Foreach( entity => entity.Destroy());    // a simple way to delete all entities
```

Queries are already very fast, but for maximum performance or control
over iteration order, manual iteration is possible.
```C#
for(int i = 0;i < query.MatchingArchetypes.Count; ++ i) // getting the matching archetype count will 
{                                                       // keep the query up-to-date
  var archetype = query.MatchingArchetypes[i];
    if (archetype.Entities.Count > 0 && archetype.TryGetArray<int>(out var int_pool))
      for(int index = 0; index < archetype.Entities.Count; ++ index)
        int_pool[index]++;
}
```

During Foreach structural changes made using Set(), Remove() and Destroy() are
cached and applied after iteration is complete. This is to prevent iterator
invalidation. You can still create entities during foreach loops though as these
do not affect archetype structures.

```C#
var entity = Entity.Create("my entity", 3);
entity.Remove<string>();
entity.Has<string>();       // this will return false

query.Foreach((Entity entity, ref int int_val) =>
{
  entity.Remove<int>();     // since this is a structural change and we are in 
                            // the middle of iterating, this operation will be cached
  
  entity.Has<int>();        // since Remove() was cached, this will still return true
  
  entity.Set("my entity");  // Since this was removed before the query, this is a 
                            // structural operation and will also be cached
  
  entity.Has<string>();     // so this will still false
});
// now all structural changes are applied since we are done iterating entities

entity.Has<string>();   // this will now return true
entity.Has<int>();      // and this will now return false
```

## Systems

Since queries are so flexible there was little point in adding dedicated systems. 
Rather if you are using an existing game engine, it's pretty simple to just use their systems.
A small Unity Example.

```C#
class Player : MonoBehaviour , IOnRemoveCallback // player gameobject
{
  void Awake()
  {
    Entity.Create(this, GetComponent<Animator>(), GetComponent<Rigidbody>()); //...etc
  }
  
  void IOnRemoveCallback.OnRemoveBy(Entity entity)
  {
    Destroy(gameobject);  // Sync gameobject destruction with entity destruction
  }
}

// some other file

class PlayerSystem: MonoBehaviour
{
  Query player_query = new Query().Has<Player>();

  void Update()
  {
    player_query.Foreach((ref Rigidbody rb, ref Animator animator) =>
    {
      // etc...
    });
  }
}
```
## World
The world static class is what manages all the underlying archetypes and their entities. 
Normally you won't need to do much with this class but there are a couple of useful features.
```C#
World.AllowStructuralChanges = true;  // set to false to start caching structural changes
                                      // changes will be appiled when set back to true.
                                      // query.Foreach() internally sets this to false before starting
                                      // the query and true once complete
                                      
World.Resize();   // if a large amount of entities and components were recently deleted, 
                  // use this to resize the archetype backing arrays. This can be
                  // followed up with System.GC.Collect() to reclaim memory.
```

## Generators
if for some reason 64 components is not enough for entity creation or
you want more than 16 components in the foreach function. You can use
the Generator class to increase that limit. Simply call the functions
with the amount of components you want, then recompile.

```C#
using SimpleECS.Internal;
class Program
{
  static void Main(string[] args)
  {
    // generates Query.Foreach() functions for up to 24 components
    Generator.ForeachFunctions("path to foreach functions file.cs", 24); 

    // generates Entity.Create() functions for up to 100 components
    Generator.EntityCreateFunctions("path to entity create functions file.cs", 100); 
  }
}
```

# SimpleECS
A Simple and easy to use C# Entity Component System.
Min C# Framework 4.7

### Features:
* No Dependencies, just build or drop in however you want
* No setup or boilerplate like marking components or code generators
* Archetype based = fast component iteration
* Very simple and easy to use queries

> **Warning** - This project is a very much a hobby project to learn more about ECS.
>   Because of this, breaking API changes may occur as I tinker on the framework.


## Entities
An Entity is simply an ID that associates a group of components together.
To create an entity you first need to create a new world,
then using that world create your entity with it's components as arguments.
```C#
var world = World.Create("My World");    // naming the world is optional
var entity = world.CreateEntity("my entity", 3, 5f);    
                                      // creates a new entity with components
                                      // components added this way will trigger
                                      // callbacks registered with world.OnSet()
                                      // setting the entity's string component
                                      // will change the entity's ToString() value

world.Destroy();  // when your done with a world, destroy it to free up it's resourcess
                  // This will automatically destroy all entities in that world
```
Anything that can be put into a list can be a component.
Only one component of each type can be associated with an entity, 
however there's nothing stopping you having a List or array as a component.
Setting more than one component of the same type will simply overwrite the old one.
The function can take up to 32 components, but entities themselves have 
no component limit.
Due to how entities are structured, it's more efficient to set all components upfront
during creation than adding them one at a time with entity.Set().

Manipulating entities is pretty simple
```C#
if(entity)              // returns false if entity is destroyed or invalid
{}                      // shorthand for entity.IsValid()

entity.Get<int>() += 4; // gets the entity's component by ref value.
                        // throws an exception if the entity is invalid or
                        // the entity does not have the component
                        // since they are returned by ref, you can assign values directly

entity.Set(3)             // sets the entity's components to values.
      .Set("my entity");  // can be chained to set multiple components at once.
                          // if entity does not already contain the component it will be added
                          // setting a component will trigger any callbacks registered
                          // with world.OnSet() 

if (entity.Has<int>())     // returns true if entity has component
{
  // do something
}

if (entity.TryGet(out int value)) // gets the component's value on entity, returns false if not found
{
    entity.Set(value + 4);        // Value types need to be set afterwards for changes to take place
}

entity.Remove<T>();   // removes the component on entity if found.
                      // if component was removed, will trigger any callbacks registered  with world.OnRemove()
                    
entity.Destroy();     // destroys the entity leaving it invalid
                      // all components on the entity will trigger their respective world.OnRemove() callbacks

var newWorld = World.Create("new World");
entity.Transfer(new_world);   // transfer moves entity to the specified world

entity.GetAllComponents(); // returns a copy of all the components assigned to the entity

entity.GetAllComponentTypes(); // returns a copy of all the component types assigned to the entity
```
## Component Callbacks
There are 2 component callbacks in SimpleECS, world.OnSet() and world.OnRemove().

### OnSet
OnSet is invoked anytime a valid entity uses entity.Set(value).
OnSet is also invoked on all components added during entity creation with world.CreateEntity().
OnSet is not invoked on the defaulted components created during archetype.CreateEntity().
On set has 3 overloads depending on how much information you need during the callback.
```C#
// whenever an entity in the world sets an int, it'll invoke this callback
world.OnSet((ref int new_value) =>
    Console.WriteLine($"an entity set an int to {new_value}"));

// if you need the invoking entity, put it as the first parameter
world.OnSet((Entity entity, ref int new_value) => 
    Console.WriteLine($"{entity} set int to {new_value}"));

// if you need the previous value, simply put it between the entity
// and the new value without any modifiers.
// if the component did not have an old component, it'll be set to default
world.OnSet((Entity entity, int old_value, ref int new_value) => 
    Console.WriteLine($"{entity} set int {old_value} to {new_value}"));

// you can also name your callback
void IntSetCallback(ref int value)
{
    // do something
}

world.OnSet<int>(IntSetCallback); // then register it
world.OnSet<int>(IntSetCallback, false); // and later unregister by adding false as the second parameter
```

### OnRemove
OnRemove is invoked anytime a valid entity removes that component.
OnRemove is also invoked when an entity with that component is destroyed.
OnRemove has 2 overloads depending on how much information you need during the callback.
```C#
// the callback is invoked whenever an entity in the world with the component removes the component or is destroyed
world.OnRemove((int val) => 
    Console.WriteLine($"an entity removed int {val}"));

// put the entity as the first paramter to get the invoking entity
world.OnRemove((Entity e, int val) => 
    Console.WriteLine($"{e} removed int {val}");
    
// like OnSet, OnRemove can be named and registered and unregistered
void IntRemoveCallback(int value)
{
    // do something
}

world.OnRemove<int>(IntRemoveCallback);
world.OnRemove<int>(IntRemoveCallback, false);
```

## Queries

Queries let you iterate over entities based on specified components.
You can specify up to 12 components to iterate over.
Queries cache their results and only update when new archetypes are created or destroyed or their filter changes.
```C#
var query = world.CreateQuery()                     // Queries operate on the world they are created with
                 .Has<int>()                        // your free to mix an match any filter overload
                 .Has(typeof(float), typeof(short)) // Has() filters entities to those with components
                 .Not<string>()                     // Not() filters for those that do not
                 .Not(typeof(ushort));              // there's no limit to the amount of filters you can add
                                                    // infact the more specific the better

query.Foreach( (ref int int_value, ref float float_value) =>  // you then use the foreach function to update your components
{                                                             // components must be prefaced with the ref modifier
    int_value ++;                                             // you can use up to 12 components as parameters
    float_value = int_value * 100;                            // queries operate only on entities that match both the query 
}));                                                          // filter and contains all the foreach parameters

query.Foreach( (Entity entity, ref int value ) =>         // you can access the current entity by putting it before the components
{                                                         // without modifiers. 
  Console.WriteLine($"{entity} value is {value}");        
});

foreach ((Entity entity, int value) in query.Foreach<int>()) // foreach makes so you can use continue and break
{
    if (value > 0)
    {
        continue;
    }

    if (value < 0)
    {
        break;
    }

    Console.WriteLine($"{entity} value is {value}"); 
}

// having more then 5 components makes so you have to put double parenthesis.
// the reason is that a tuple only can hold in 8 values, so you create a second tuple in the tuple
foreach ((Entity entity, A aa, B bb, C cc, D dd, E ee, (F ff, G gg, H hh, I ii, J jj)) in query.Foreach<A, B, C, D, E, F, G, H, I, J>())   
{                     
    Console.WriteLine($"value x is {aa.x} value y is {aa.y}");
}

var all_entities = world.CreateQuery();   // a simple way to match against all entities is to make a query with no filters

query.GetEntities();    // returns a copy of all entities currently matching the query

query.GetArchetypes();  // returns a copy of all archetypes currently matching the query

query.Clear();          // clears query filters, since the query has no filters it'll match against all entities

query.GetHasFilterTypes(); // returns all types in the Has() filter

query.GetNotFilterTypes(); // returns all types in the Not() filter

query.DestroyMatching();   // destroys all archtypes and their entities matching the query
```

During query.Foreach, functions that cause structural changes to the ECS are cached 
and applied after iteration is complete. This is to prevent iterator invalidation. 
Some functions that cause structural changes are:
  * entity.Set()
  * entity.Remove()
  * entity.Transfer()
  * entity.Destroy()
  * archetype.CreateEntity()
  * archetype.Destroy()
  * world.CreateEntity()
  * world.Destroy()
  
Entities created during query.Foreach() will be invalid during the function.
However you can still set or remove components on that entity, 
they will simply be applied when the Foreach function completes.

```C#
var entity = world.Create("my entity", 3);
entity.Remove<string>();
entity.Has<string>();       // this will return false

query.Foreach((Entity entity, ref int int_val) =>
{
  entity.Remove<int>();     // since this is a structural change and we are in 
                            // the middle of iterating, this operation will be cached
  
  entity.Has<int>();        // since Remove() was cached, this will still return true
  
  entity.Set("my entity");  // set is regarded as a structural event so will 
                            // be cached regardless if the entity has the
                            // component or not
  
  entity.Has<string>();     // so this will still return false
});
// now all structural changes are applied since we are done iterating entities

entity.Has<string>();   // this will now return true
entity.Has<int>();      // and this will now return false
```

For maximum control over query iteration or a small performance boost, manual iteration is possible.
When iterating manually though, make sure not to do any structural changes as
this may invalidate iterators.
```C#
// you can manually iterate over a query using foreach
// however during manual iteration you should not do any structural changes
// as this many invalidate internal iterators
foreach(var archetype in query)
{
    if (archetype.TryGetEntityBuffer(out Entity[] entity_buffer) &&
        archetype.TryGetComponentBuffer(out int[] int_buffer))
    {
        for(int i = 0; i < archetype.EntityCount; ++ i) // use the entity count not buffer length
            System.Console.WriteLine($"{entity_buffer[i]} {int_buffer[i]}");
    }
}
```

## Archetype
Entites are stored in archetypes. Archetypes are simply a container of arrays that
store entities and their components. All arrays are contiguous and of a single type.
i.e all entities are stored together, each component type is stored together.
The entity in index 1 of the entity array owns the components in index 1 of each component
array. Queries don't match against single entities but archetypes since all
entities within an archetype has the same component types by definition.
```C#
if (!world.TryGetArchetype(out var archetype, typeof(int), typeof(float))) // gets an archetype with components
  return;                                                                  // returns false if world is invalid

var entity = world.Create(3);
var entity _archetype = entity.archetype;   // you can also get the archetype from valid entities
                                            // if entity is invalid, the archtype will also be invalid
                                            // an entity's archetype changes when the component types it
                                            // holds changes
  
if (archetype)  // use to check if archetype is valid
{               // valid entities will always have valid archetypes
  //...         // shorthand for archetype.IsValid()
}

var new_entity = archetype.CreateEntity();  // creates an entity using the archetype
                                            // the entity created will have all the components of the archetype set to default values
                                            // this is the most performant way to create entities
                                            // world.OnSet() is not invoked for the defaulted components

archetype.GetTypes();       // returns a copy of what components in the archetype
  
archetype.GetEntities();    // returns a copy of all entities in the archetype

archetype.ResizeBackingArrays(); // resizes the internal component and entity buffers to the minimum power of 2 needed to store them
                                 // may be useful if a large amount of entities were recently destroyed

if (archetype.TryGetEntityBuffer(out Entity[] entity_buffer))  // tries to get the raw entity storage buffer from
{                                                         // the archetype. Should be treated as readonly as
    for (int i = 0; i < archetype.EntityCount; ++ i)      // changing their values will break the ecs.
        Console.WriteLine(entity_buffer[i]);              // Valid indexes are only up to archetype.EntityCount
}                                                         // not entities.Length
                                                          // while iterating over raw buffers, structural changes should not be performed
                                                          // as this will possibly invalidate iterators

if (archetype.TryGetComponentBuffer(out int[] int_buffer))  // tries to get the raw component storage buffer
{                                                           // from the archetype. returns false if the archetype
    for(int i = 0; i < archetype.EntityCount; ++ i)         // is invalid or does not store the component
        int_buffer[i]++;                                    // entities in the entity buffer own the components in 
}                                                           // the component buffer that share the same index
                                                            // like the entity buffer, valid indexes are only up
                                                            // to archetype.EntityCount
                                                            
archetype.Destroy();    // destroys the archetype along with any entities it owns
                        // destroying the archetype is more efficient than destroying entities
                        // one by one
```
## World Data
Instead of singletons, shared components or singleton components, Simple Ecs uses the concept of World Data.
World data are basically components belonging to the world instead of an entity. 

```C#
world.SetData(3)            // sets the world data to value
     .SetData("My Value");  // can be chained
     
world.GetData<float>() = delta_time;    // alternately you can use GetData
                                        // to get a reference and change it directly
                                        // throws an exception if the world is invalid
                                        // if data was not set before hand, get data will create and return defaulted data

query.Foreach((in float delta_time, Entity entity, ref Vector3 velocity) => 
{                                                     // you can access world data directly in queries using
    velocity += delta_time * new Vector3(1, 0, 0);    // the 'in' modifier before any entity
});                                                   // or component parameters
                                                      // you can add up to 4 world data in queries

world.GetAllWorldData(); // gets all WorldData created with SetData() or GetData()

world.GetAllWorldDataTypes(); // returns all the types of GetAllWorldData()
```

## World
The world class is what manages all the underlying archetypes and their entities.

```C#
World.GetAll();                         // returns a copy of all the currently valid worlds

var world = World.Create("My World");   

var count = world.EntityCount;          // returns how many entities are in the world

world.GetEntities();                    // returns a copy of all the entities in the world

world.GetArchtypes();                   // returns a copy of all the archetypes in the world

world.ResizeBackingArrays();            // resizes all archetype backing arrays to the minimum power 
                                        // of 2 needed to store their data
                                        
world.DestroyEmptyArchetypes();         // destroys all archetypes that have no entities
                                        // this can potentially speed up queries since they no longer
                                        // have to iterate over those archetypes
                                        
world.CacheStructuralEvents(true);      // manually sets the world to cache structural events like when executing queries
                                        // set to false to apply all cached structural events
                                        
world.IsCachingStructuralEvents();      // returns true if the world is currently caching structural events
```

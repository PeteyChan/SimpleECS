# SimpleECS
A Simple and easy to use C# Entity Component System.
Min C# Framework 4.7

### Features:
* No Dependencies, just build and drop in however you want
* No setup or boilerplate like marking components or code generators
* Archetype based = fast component iteration
* Very simple and easy to use queries

> **Warning** - This project is a very much a hobby project to learn more about ECS. Although it's quite usuable in it's current state, the API is still very much in flux and breaking changes can occur in the future. 


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
entity.TransferTo(new_world);   // transfer moves entity to the specified world
                                // since the entity was moved, it's old value is now invalid
```
## Component Callbacks
There are 2 component callbacks in SimpleECS, world.OnSet() and world.OnRemove().
```C#
world.OnSet((Entity entity, ref int value) =>     // use world.OnSet to set a callback to invoke
  Console.WriteLine($"{entity} added {value}"));  // whenever an entity sets that component in that world

world.OnRemove((Entity entity, ref int value) =>  // use world.OnRemove to set a callback  to invoke
  Console.WriteLine($"{entity} removed {value}"));// whenever an entity removes a component in that world
                                                  // If the entity was destroyed, entity.IsValid() will
                                                  // be false during the callback

void MyCallback(Entity entity, ref int value)     // additionally you can name your callbacks
{
  Console.WriteLine($"{entity} added int {value}");
}

world.OnSet<int>(MyCallback);         // then register the callback
// do stuff...
world.OnSet<int>(MyCallback, false);  // and by passing false as the second parameter you can later unregister the callback
  
```

## Queries

Queries let you iterate over entities based on specified components.
You can specify up to 16 components to iterate over.
Queries cache their results and only update when new archetypes are created.

```C#
var query = world.CreateQuery()                 // Queries operate on the world they are created with
                 .Has<int>().Has<float>()       // Has() filters entities to those with components
                 .Not<string>().Not<double>();  // Not() filters for those that do not
                                                // there's no limit to the amount of filters you can add
                                                // infact the more specific the better

query.Foreach( (ref int int_value, ref float float_value) =>  // you then use the foreach function to update your components
{                                                             // components must be prefaced with the ref modifier
    int_value ++;                                             // you can use up to 12 components as parameters
    float_value = int_value * 100;                            // queries operate only on entities that match both the query 
}));                                                          // filter and contains all the foreach parameters


query.Foreach( (Entity entity, ref int value ) =>         // you can access the owner entity by putting it before the components
{                                                         // without modifiers. 
  Console.WriteLine($"{entity} value is {value}");        
});

var all_entities = world.CreateQuery();               // a simple way to match against all entities is to make a query with no filters

query.DestroyMatching();          // destroys all archtypes and their entities matching the query
                                  // its the most efficient way to destroy entities
```

For maximum control over query iteration, manual iteration is possible.
```C#
foreach(var archetype in query.GetArchetypes())
{
    if (archetype.TryGetEntityBuffer(out Entity[] entity_buffer) &&
        archetype.TryGetComponentBuffer(out int[] int_buffer))
    {
        for(int i = 0; i < archetype.EntityCount; ++ i)
            System.Console.WriteLine($"{entity_buffer[i]} {int_buffer[i]}");
    }
}
```

During query.Foreach structural changes are cached and applied after iteration is complete. 
This is to prevent iterator invalidation. Functions that cause structural changes are:
  * entity.Set()
  * entity.Remove()
  * entity.Transfer()
  * entity.Destroy()
  * archetype.CreateEntity()
  * archetype.Destroy()
  * world.CreateEntity()
  * world.Destroy()
  
Entities created during query.Foreach() will be invalid during the function, but you can
still use all entity functions on that entity, it will simply be applied when the 
Foreach function completes.

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

## Archetype
Entites are stored in archetypes. Archetypes are simply a container of arrays that
store entities and their components. All arrays are contiguous and of a single type.
i.e all entities are stored together, each component type is stored together.
The entity in index 1 of the entity array owns the components in index 1 of each component
array. Queries don't match against single entities but archetypes since all
entities within an archetype has the same component types by definition.
```C#
var entity = world.Create(3);

var archetype = entity.archetype;     // gets archetype that the entity belongs
                                      // if entity is invalid, the archtype will also be invalid
                                      // an entity's archetype changes when the component types it
                                      // holds changes
  
if (archetype)  // use to check if archetype is valid
{               // valid entities will always have valid archetypes
  //...         // shorthand for archetype.IsValid()
}
                                                  
foreach(var entity in archetype.Entities) // you can get the entities in an archetype
{                                         // with the Entities property
    Console.WriteLine(entity);
}

archetype.GetTypeSignature();   // returns a copy of the archetype's type signature
  
archetype.GetEntities();    // returns a copy of all entities in the archetype

if (archetype.TryGetEntityBuffer(out Entity[] entity_buffer))  // tries to get the raw entity storage buffer from
{                                                         // the archetype. Should be treated as readonly as
    for (int i = 0; i < archetype.EntityCount; ++ i)      // changing their values will break the ecs.
        Console.WriteLine(entity_buffer[i]);              // Valid indexes are only up to archetype.EntityCount
}                                                         // not entities.Length

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
World data is simply data stored in the world.
```C#
world.SetData(3)            // sets the world data to value
     .SetData("My Value");  // can be chained
     
world.GetData<float>() = delta_time;    // alternately you can use GetData
                                        // to get a reference and change it directly

query.Foreach((in float delta_time, Entity entity, ref Vector3 velocity) => 
{                                                     // you can access world data directly in queries using
    velocity += delta_time * new Vector3(1, 0, 0);    // the 'in' modifier before any entity
});                                                   // or component parameters
                                                      // you can add up to 4 world data in queries
```



## World
The world class is what manages all the underlying archetypes and their entities.

```C#
World.GetAll();                         // returns a copy of all the current worlds

var world = World.Create("My World");   

var count = world.EntityCount;          // how many current entities in the world

world.GetEntities();                    // returns a copy of all the entities currently in the world

world.GetArchtypes();                   // returns a copy of all the current archetypes in the world

world.ResizeBackingArrays();            // resizes all archetype backing arrays to the minimum power 
                                        // of 2 needed to store their data
world.DestroyEmptyArchetypes();         // destroys all archetypes that have no entities
                                        // this can potentially speed up queries since they no longer
                                        // have to iterate over those archetypes
                                        
world.Destroy();                        // destroys the world along with all the entities and
                                        // archetypes associated with it
```

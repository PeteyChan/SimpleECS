# SimpleECS
A Simple and easy to use C# Entity Component System.
Min C# Framework 4.7

### Features:
* No Dependencies, just build and drop in however you want
* No setup or boilerplate like marking components or code generators
* Archetype based = fast component iteration
* Very simple and easy to use queries

## Entities
An Entity is simply an ID that associates a group of components together.
To create an entity you first need to create a new world,
then using that world create your entity with it's components as arguments.
```C#
var world = new World("My World");    // naming the world is optional
var entity = world.CreateEntity("my entity", 3, 5f);    
                                      // creates a new entity with components
                                      // components added this way will trigger
                                      // callbacks registered with world.OnSet()
                                      // setting the entity's string component
                                      // will change the entity's ToString() value
```
Anything that can be put into a list can be a component.
Only one component of each type can be associated with an entity, 
however there's nothing stopping you having a List or array a component.
Setting more than one component of the same type will simply overwrite the old one.
The function can take up to 64 components, but entities themselves have 
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

if (enity.Has<int>())     // returns true if entity has component
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

var newWorld = new World("new World");
Entity newWorldEntity = entity.Transfer(new_world); // transfer moves entity to the specified woorld and
                                                    // returns the entity's new value
                                                    // the transfered entity will be invalid in the old world
                                                    // after the move
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
  Console.WriteLine($"{} added int {value}");
}

world.OnSet<int>(MyCallback);         // then register the callback
// do stuff...
world.OnSet<int>(MyCallback, false);  // and by passing false as the second parameter you can later unregister the callback
  
```

## Queries

Queries let you iterate over entities based on specified components.
You can specify up to 12 components to iterate over.
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


query.Foreach( (Entity entity, ref int value ) =>         // you can access the owner entity by putting it in the first position
{                                                         // without modifiers. You can then add any components you want to use
  Console.WriteLine($"{entity} value is {value}");        // afterwards
});

var all_entities = world.CreateQuery();               // a simple way to match against all entities is to make a query with no filters
all_entities.Foreach( entity => entity.Destroy());    // a simple way to delete all entities
```

Queries are already very fast, but for maximum performance or control
over iteration order, manual iteration is possible.
```C#
for(int i = 0; i < query.MatchingArchetypes.Count; ++ i) // getting the matching archetypes count will 
{                                                        // keep the query up-to-date
  var archetype = query.MatchingArchetypes[i];
    if (archetype.Entities.Count > 0 && archetype.TryGetArray(out int[] int_pool))  // try get array gets the raw component backing array
      for(int index = 0; index < archetype.Entities.Count; ++ index)    // int pool's count is the same as the entity count NOT the pool's length
        int_pool[index]++;
}
```

During Foreach structural changes are cached and applied after iteration is complete. 
This is to prevent iterator invalidation. Functions that cause structural changes are:
entity.Set(), entity.Remove(), entity.Transfer(), entity.Destroy() and world.CreateEntity();
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
  
  entity.Set("my entity");  // Since this was removed before the query, this is a 
                            // structural operation and will also be cached
  
  entity.Has<string>();     // so this will still return false
});
// now all structural changes are applied since we are done iterating entities

entity.Has<string>();   // this will now return true
entity.Has<int>();      // and this will now return false
```
## Singletons
Instead of a singleton component or singleton entity, the way SimpleECS deals with
singleton data is with a concept called World Data. World Data is just data belonging to the world.
Each world stores it's own world data.

```C#
float deltaTime = Time.time;

world.GetData<float>() = deltaTime; // you can get and assign world Data with world.GetData()
                                    // GetData() returns a ref so you can assign or add to it directly

world.SetData(deltaTime);   // you can also use SetData(), just like entity.Set() SetData() is chainable

query.Foreach((Entity entity, in float deltaTime, ref float comp_time) => 
{                           // you can get world data in foreach loops using the in modifier 
  comp_time += deltaTime;   // world data goes after entity and before components
  if (comp_time > 5f)       // you can add up to 8 world data
    entity.Destroy();
});
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

if (entity.TryGetArchetype(out var archetype))  // gets archetype that the entity belongs to
{                                               // will return false if entity is invalid
                                                // an entity's archetype can change when a new 
                                                // component is set or when a component is removed
  
  if (archetype)  // use to check if archetype is valid
  {               // valid entities will always have valid archetypes
    //...         // shorthand for archetype.IsValid()
  }
                                                  
  foreach(var entity in archetype.Entities) // you can get the entities in an archetype
  {                                         // with the Entities property
    Console.WriteLine(entity);
  }
                                                  
  if (archetype.TryGetArray(out int[] int_values))      // you can get the raw component arrays using TryGetArray()
  {                                                     // returns false if entities don't have component
    for(int i = 0; i < archetype.Entities.Count; ++ i)  // the component count is not the array's length
    {                                                   // but the archetype's entity count. Be sure not to
      int_values[i] ++;                                 // use the wrong count
    }
  }
}

```

## World
The world class is what manages all the underlying archetypes and their entities.
Apart from making entities and queries there are a couple other useful features of this class.

```C#
world.AllowStructuralChanges = true;  // this field controls entity caching behaviour
                                      // set to false to start caching structural changes
                                      // changes will be appiled when set back to true.
                                      // query.Foreach() internally sets this to false before starting
                                      // the query and true once complete
                                      
world.DestroyEmptyArchetypes();       // Use to remove archetypes that have no entities. Useful when
                                      // changing scenes in game engines.
                                      // Any archetypes destroyed in this process will become invalid

world.ResizeBackingArrays();          // if a large amount of entities and components were recently deleted, 
                                      // use this to resize the archetype backing arrays. This can be
                                      // followed up with System.GC.Collect() to reclaim memory.

var archetypes = world.Archetypes;    // returns a list of all currently active archetypes

world.CreateEntityWithArchetype(archetypes[0]);
                                      // creates an entity using the supplied archetype
                                      // will throw an exception if archetype is null or destroyed
                                      // entities created this way will have the same components
                                      // as those in the archetype with defaulted values
                                      // i.e null for classes and 0 for structs
                                      // world.OnSet() will not invoke registered callbacks since 
                                      // they were not explicitly set. 
                                      // This is the most performant way to create entities
```

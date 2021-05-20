# SimpleECS
A Simple and easy to use C# Entity Component System.
Min C# Framework 4.7

### Features:
* No setup or boilerplate like marking components or code generators to get started
* Archetype based = fast component iteration
* Very simple query system

## Entities
To create an entity use Entity.Create() with the components as arguments. 
Anything that can be put into a list can be a component.
You can add up to 50 components.
```C#
Entity.Create("my entity", 3, 5f);    // creates a new entity with components
```

Manipulating entities is pretty simple
```C#
ref int value = ref entity.Get<int>();  // gets the entity's int component by ref value. 
                                        // throws an exception if the entity is invalid or
                                        // the entity does not have the component

entity.Get<int>() += 4;           // since they are returned by ref, you can assign values directly

entity.Set(3).Set("my entitiy");  // sets the entity's components to values. Component is added if not already on entity.
                                  // if a component implements ISetCallback, it will be called if it
                                  // was sucessfully set on the entity

if (enity.Has<int>())             // returns true if entity has component
{
  // do something
}

if (entity.TryGet<int>(out var value)) // gets the component's value on entity, returns false if not found
{
    entity.Set(value + 4); // Value types need to be set afterwards for changes to take place
}

entity.Remove<T>();   // removes the component on entity if found.
                      // if component implements IRemoveCallback, it'll
                      // be called when it's removed
                    
entity.Destroy();     // destroys the entity leaving it invalid
                      // all components implmenting IRemoveCallback will
                      // also be called

if (entity.IsValid)   // returns false if entity is destroyed or invalid
{}

if(entity)            // same as entity.IsValid
{}
```
## Systems

There are no systems in simpleECS, instead it just uses simple queries to manage entities.


## Queries

Queries let you iterate over entities based on specified components.
You can specify up to 12 components to iterate over.
Queries cache their results and only update when new archetypes are created.

```C#
var query = new Query().Has<int>().Has<float>()       // Has() filters entities to those with components
                       .Not<string>().Not<double>();  // Not() filters for those that do not
                                                      // there's no limit to the amount of filters you can add
                                                      // infact the more specific the better

var all_entities = new Query();               // a simple way to match against all entities is to make a query with no filters

query.Foreach( (ref int int_value, ref float float_value) =>  // you then use the foreach function to update your components
{                                                             // you can use up to 12 components in the query
    int_value ++; // can manipulate components                // queries operate only on entities that match both the query and 
    float_value = int_value * 100;                            // contains all the components in the foreach function
}));

query.Foreach( (in Entity entity, ref int value ) =>         // you can access the owner entity by putting it in the first position
{                                                            // with the in keyword followed by any components you want to use
  Console.WriteLine($"{entity} value is {value}");                  
});
```

Queries are already very fast, but for maximum performance manual iteration is possible
```C#
query.Refresh();           // if not using Foreach() this must be called manually to keep the query up-to-date
for(int i = 0;i < query.MatchingArchetypes.Count; ++ i)
{
  var archetype = query.MatchingArchetypes[i];
    if (archetype.entity_count > 0 && archetype.TryGetPool<int>(out var int_pool))
      for(int index = 0; index <= archetype.entity_count; ++ index)
        int_pool.Values[index]++;
}
```

During Foreach structural changes made using Set(), Remove() and Destroy() are
cached and applied after iteration is complete. This is to prevent iterator
invalidation. You can still create entities during foreach loops though as these
do not change archetype structures.

```C#
var entity = Entity.Create("my entity", 3);
entity.Remove<string>();
entity.Has<string>(); // this will return false

query.Foreach((in Entity entity, ref int int_val) =>
{
  entity.Remove<int>(); // since this is a structural change and we are in 
                        // the middle of interating, this will be cached
  
  entity.Has<int>();    // since Remove() was cached, this will return true
  
  entity.Set("my entity");// Since this is structural this will also be cached
  entity.Has<string>();   // so likewise this will return false
});
// now all structural changes are applied since we are done iterating entities
entity.Has<string>();   // this will now return true
entity.Has<int>();      // and this will now return false
```

To manually start caching structrual changes use
```
World.AllowStructuralChanges = false;
```
All structural changes will be applied when
World.AllowStructuralChanges is set back to true

## Generators
if for some reason 50 components is not enough when creating an entity, or
you want more than 12 components in the foreach function. You can use
the Generator class to increase the limit. Simply call the functions
with the amount of components you want, then recompile.

```
using SimpleECS.Internal;
class Program
{
  static void Main(string[] args)
  {
    // generates Query.Foreach() functions for up to 24 components
    Generator.ForeachFunctions("path to foreach functions file.cs", 24); 

    // generates Entity.Create() functions for up to 100 components
    Generator.EntityCreateFunctions("path to create entity functions file.cs", 100); 
  }
}
```

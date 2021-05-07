# SimpleECS
A Simple and easy to use C# Entity Component System.
Min C# Framework 4.7

### Features:
* 1 File, just copy paste
* No setup or boilerplate like marking components or code generators
* Archetype based = fast component iteration
* Very simple query system
* Optional multiple entity worlds

## Entities
To create an entity use new with the components as parameters.
Components are stored as what their GetType() returns.
Components can be anything that can be put into an array.
```C#
var entity = new Entity("my entity", 3, 5f);    // creates a new entity with components
```

Manipulating entities is also pretty simple
```C#
ref int value = ref entity.Get<int>();  // gets the entity's int component by ref value. 
                                        // throws an exception if component is not found.

entity.Get<int>() += 4;           // since they are returned by ref, you can assign values directly

entity.Set(3).Set("my entitiy");  // sets the entity's components to values. Component is added if not already on entity.
                                  // using set it's possible to add delegates, interfaces or abstract classes
                                  // as components. Additonally setting a string component changes the entity's ToString() function.

if (enity.Has<int>())             // returns true if entity has component
{
  // do something
}

if (entity.TryGet<int>(out var value)) // gets the component's value on entity, returns false if not found
{
    entity.Set(value + 4); // Value types need to be set afterwards for changes to take place
}

entity.Remove<T>();   // removes the component on entity if found.
                      // if component implements System.IDisposable, Dispose() is called when component is removed
                    
entity.Destroy();     // destroys the entity leaving it invalid
                      // Dispose() is called on all removed components that implement System.IDisposable
                      // entity is invalid during the dispose call

if (entity.IsValid)   // returns false if entity is destroyed or invalid
{}

if(entity)            // same as entity.IsValid
{}

// you can iterate over all the components on an entity using foreach
foreach(var component in entity)
{
  Console.WriteLine(component.GetType().Name);
}

```
## Blueprints
To make creating entities simpler there is the blueprint class
```C#

class MyComponent // example component
{
  public MyComponent(int value)
  {
    this.value = value;
  }
  int value;
}

// Creates the blueprint
Blueprint my_blueprint = new Blueprint().Set<float>()  // use to set a component with default values
                                        .Set(3)     // use to set component with value. If value is a class, it'll be shared
                                                       // by all entities made by this blueprint
                                        .Set( () => new MyComponentA()) 
                                                       // uses a function to generate a component and set it on the entity
                                        .Set( entity => new MyComponentB(entity.Get<int>())
                                                       // use the entity function to retrieve previously added components     
                                        .OnComplete( entity => Console.WriteLine($"{entity} spawned"); 
                                                       // OnComplete() is called after all components have been added
                                                       
                                                       // None of these functions are mandatory, infact you can spawn
                                                       // entities with no components using an empty blueprint

var entity = my_blueprint.CreateEntity();              // creates an entity with components set by blueprint

var entities = my_blueprint.CreateEntities(1000);      // creates 1000 entities with components set by blueprint
```
## Systems

There are no systems in simpleECS, instead it just uses simple queries to manage entities.


## Queries

Queries let you iterate over entities based on specified components.
Queries cache their results and only update when the world they observe changes.

```C#
var query = new Query().Has<int>().Has<float>()       // Has() filters entities to those with components
                       .Not<string>().Not<double>();  // Not() filters for those that do not
                                                      // there's no limit to the amount of filters you can add
                                                      // infact the more specific the better

var all_entities = new Query();               // a simple way to match against all entities is to make a query with no filters

query.Foreach( (ref int int_value, ref float float_value) =>  // you then use the foreach function to update your components
{                                                             // you can use up to 8 components in the query
    int_value ++; // can manipulate components                // queries operate only on entities that match both the query and 
    float_value = int_value * 100;                            // contains all the components in the foreach function
}));

query.Foreach( (in Entity entity, ref int value ) =>  // you can access the owner entity by putting it in the first position
{                                                            // with the in keyword followed by any components you want to use
  Console.WriteLine($"{entity} value is {value}");                  
});
```
Queries are already very fast, but for maximum performance manual iteration is possible
```C#
query.Refresh();           // if not using Foreach() this must be called manually to keep the query up-to-date
foreach(var archetype in query)
{
  if (archetype.Count > 0)
    if (archetype.TryGetPool<int>(out var pool))
      for(int i = archetype.entity_count - 1; i >= 0; --i)   // iterate backwards to prevent iterator invalidation if 
      {                                               // performing structural changes on entities
          var value = pool.Values[i]++;
          if (value > 20)
            archetype.entity_pool.Values[i].Destroy();
      }  
}
```


Do not call Set(), Remove() or Destroy() on entities other than the owner as they can
change the structure of the archetypes and potentially invalidate query iterators.
```C#
class MyComponent
{
  public Entity other_entity;
}

List<Entity> ToDestroy = new List<Entity>();

query.Foreach((in Entity entity, ref MyComponent comp) =>
{
    entity.Set(3);                    // these functions are structural functions that can potentially change
    entity.Remove<float>()            // the entity's archetype. The owner entity supports
    entity.Destroy();                 // structural operations so is fine to call them
    
    // BE CAREFUL
    comp.other_entity.Remove<int>();  // however since entity fields from components can potentially be anything,
    comp.other_entity.Set(4.5f);      // calling these functions can possibly invalidate the query's 
    comp.other_entity.Destroy();      // iterators and lead to undefined behaviour.
                                      // Only use them when you know for certain that the query archetypes 
                                      // and the entity's archetype that your changing do not overlap
    // INSTEAD
    if (comp.other_entity.TryGet(out int value)) // instead get information from it with TryGet() first
    {
      if (value > 20)                            // then add entities you want to change to a list
        ToDestroy.Add(comp.other_entity);
      else
        comp.other_entity.Set(value++);          // once you know the component exists, it's safe to call set
        
      if (value == 5)               // making new entities in queries should be safe,so long as they
        blueprint.CreateEntity();   // don't modify the structure of existing entities in the process
    }
});

foreach (var entity in ToDestroy) // when the query is complete, it's safe to do to the entities what you wish
  entity.Destroy();
```

## Worlds

Worlds store all entities and archetype information. 
By default all entities, blueprints and queries operate in Wolrd.Default. 
Worlds are completely independent of each other so should be safe to use in different threads.
Using worlds is really simple

```C#
var world = new World();  // creates a new World

World.Default = world;    // Changes the default world, all blueprints, queries and new entities will now operate in this world.
                          // All previously created entities however will remain in their old world.

blueprint.world = world;  // By setting the world of a blueprint or query, they will only operate in that world.
query.world = world;      // If you want them to return to their default behaviour, change their world value to null.
new Entity(world, 3f, 2); // You can specify which world to spawn an entity in by passing it as the first parameter.

var new_entity = old_entity.MoveTo(world);  // moves entity from it's current world to it's new world and returns the  
                                            // entity's entity in that world. The original entity is now invalid.
                                            // This operation is not thread safe, so all worlds should be synced to the main thread beforehand

World.Default.Compact();  // after deleting or moving large amount of entities or components, you can call Compact() to resize the world's backing arrays
```

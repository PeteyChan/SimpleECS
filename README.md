# SimpleECS
A Simple and easy to use C# Entity Component System.
Min C# Framework 4.7

### Features:
* 1 File, just copy paste
* Uses generics so no code generation or any real setup required
* Archetype based ECS = fast component iteration speeds
* Very simple query system
* Multiple worlds

## Entities
To create an entity use new with the components as parameters.
Components can be any class or struct except entity.
Components are stored as their GetType().
```C#
var entity = new Entity("my entity", 3, 5f);    // creates a new entity with components
```

Manipulating entities is also pretty simple
```C#
ref int value = ref entity.Get<int>();  // gets the entity's int component by ref value. 
                                        // int is automatically added with default values if not found.

entity.Get<int>() += 4;           // since they are returned by ref, you can assign values directly

entity.Set(3).Set("my entitiy");  // sets the entity's components to values. Component is added if not already on entity
                                  // additonally setting an entity's string component sets it's ToString() function

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
                                        .Set( () => 5) // uses a function that generates a component and sets it on the entity
                                        .Set( entity => new MyComponent(entity.Get<int>()) // use the entity function to retrieve previously added components
                                        .OnComplete( entity => Console.WriteLine($"{entity} spawned"); // complete is called after all components have been added

var entity = my_blueprint.CreateEntity();         // creates an entity with components set by blueprint

var entities = my_blueprint.CreateEntities(1000); // creates 1000 entities with components set by blueprint
```
## Systems

There are no systems in simpleECS, instead it uses simple queries to manage entities


## Queries

Queries let you iterate over entities based on specified components.
Queries cache their results and only update their queries when the world changes,
so make sure to reuse them and not create them every frame.

```C#
var query = new Query().Has<int>().Has<float>()       // Has() filters entities to those with components
                       .Not<string>().Not<double>();  // Not() filters for those that do not
                                                      // there's no limit to the amount of filters you can add
                                                      // infact the more specific the better

query.Foreach( (ref int int_value, ref float float_value) =>  // you then use the foreach function to update your components
{                                                             // you can use up to 8 components in the query
    int_value ++; // can manipulate components                // queries operate only on entities that match both the query and 
    float_value = int_value * 100;                            // contains all the components in the foreach function
}));

var all_entities = new Query();               // a simple way to match all entities is to make a query with no filters

all_entities.Foreach( (ref Entity entity) =>  // all entities have themselves as components which can be accessed in queries
{                                             // just like a regular component. It's for this reason you should not Set(),
  Console.WriteLine(entity);                  // Remove() or otherwise alter an entity's entity component
});
```

Manual iteration is possible if needed
```C#
foreach(var archetype in query)
{
    if (archetype.TryGetPool<int>(out var int_pool) &&
        archetype.TryGetPool<Entity>(out var entity_pool)))
    {
      for(int i = int_pool.Count-1; i >= 0; --i) // if you plan to use get, set, remove, destroy or make new entities
      {                                          // iterate backwards so the iterators don't become invalidated
        var count = int_pool.Values[i] ++;
        if (count > 1000)
          entity_pool.Values[i].Destroy();
      }   
    }
}
```

Do not call Get(), Set(), Remove() or Destroy() on entities other than the entity supplied by the query 
otherwise iterators can potentially become invalidated.
```C#
class MyComponent
{
  public Entity other_entity;
}

List<Entity> ToDestroy = new List<Entity>();

query.Foreach((ref Entity entity, ref MyComponent comp) =>
{
    entity.Get<float>() = 3f; // these functions are structure calls that can potentially change
    entity.Set(3);            // the entity's archetype. The entity ref provided by the query supports
    entity.Remove<float>()    // structural operations so is fine to call them
    entity.Destroy();
    
    
    // DO NOT DO
    comp.other_entity.Get<int>() = 3; // however since entitiy fields from components can potentially be anything,
    comp.other_entity.Set(4.5f);      // calling these functions can possibly invalidate the query's 
    comp.other_entity.Remove<int>();  // iterators and lead to undefined behaviour.
    comp.other_entity.Destroy();      // Only use them when you know for certain that the query archetypes 
                                      // and the component's entity archetype do not overlap
    
    // INSTEAD
    if (comp.other_entity.TryGet(out int value)) // instead get information from it with try get first
    {
      if (value > 20)                            // then add entities you want to change to a list
        ToDestroy.Add(comp.other_entity);
      else
        comp.other_entity.Set(value++);          // once you know the component exists, it's safe to call set or get
        
      if (value == 5)               // making new entities in queries should be safe,so long as they
        blueprint.CreateEntity();   // don't modify the structure of existing entities in the process
    }
});

foreach (var entity in ToDestroy) // when the query is complete, it's safe to do to the entities what you wish
  entity.Destroy();
```

## Worlds

Worlds store all entities and archetype information.
All entities, Blueprints and Queries use static field World.Default by default.
Worlds are completely independent of each other so should be safe to use in different threads.
Using worlds is really simple
```C#
var world = new World(); // creates a new World

blueprint.world = world; // changes the world the blueprint creates entities in
query.world = world;     // changes the world the query operates on

var new_entity = entity.MoveTo(world); // moves entity from it's current world to it's new world and returns the entity's new value in that world
                                       // the original entity is now invalid
                                       // this operation is not thread safe, so all worlds should be synced to the main thread before hand
                                       
World.Default = world; // changes the default world, all new blueprints, new queries and new entities will use this world instead

World.Default.Compact();  // after deleting a large amount of entities or components, you can call Compact() to resize the backing arrays
```

# Welcome to SimpleECS

### Motivation

Ever since I first came across Entity Component Systems I thought it was a great Idea. Separating data from the logic is genius, no more questioning "should this belong to this class?" nonsense. To me the less thinking I need to do when to make my game work the better. I searched for a bit for other Entity Systems but thier workflows often involved manual setup of entities and/or components to tie the systems to Unity which meant that creating prefabs was much more involved. The biggest reason I wanted an ECS was to simplify my workflow and also, I'm quite fond of Unity's simple drag and drop way of creating prefabs. It didn't look too hard to roll my own so I thought I'd give it a go and this is the result.

## Features
- Enable and disable Entity Systems during runtime
- Instantiate and Destroy Systems during runtime
- Enable and disable entity components during runtime (disabled components are not updated by systems) 
- Use unity's existing prefab system
- Simple type-safe entity driven event system

## Wiki
Check out the wiki for more information.

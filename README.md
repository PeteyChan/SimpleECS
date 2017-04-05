# Welcome to SimpleECS

### Motivation

Ever since I first came across Entity Component Systems I thought it was a great Idea. Separating data from the logic is genius, no more questioning "should this belong to this class?" nonsense. To me the less thinking I need to do when to make my game the better. I searched for a bit for other Entity Systems but thier workflows often involved too much manual setup of entities and/or components to tie the systems to Unity for my liking. I just make games for a hobby and I'm also quite fond of Unity's simple drag and drop method of creating prefabs. It didn't look too hard to roll my own so I thought I'd give it a go and this is the result.

## Features
- Freely enable and disable Entity Systems during runtime
- Freely instantiate and destroy Systems during runtime
- Enable and disable entity components during runtime (disabled components are not updated by systems) 
- Use unity's existing prefab system
- Simple type-safe entity driven event system

## Wiki
Check out the [wiki](https://github.com/PeteyChan/SimpleECS/wiki) for more information.

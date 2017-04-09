using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SimpleECS.Internal
{
	public class Group<C1, C2>: Group 
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
	{
		static Group<C1,C2> _i;
		public static Group<C1,C2> instance	// Yes this is singleton pattern. Fastest way I could find to get Component IDs
		{
			get 
			{
				if (_i == null && EntityManager.loaded)										// if null and there is an Entity Manager, get set the instance value
				{
					_i = EntityManager.instance.GetGroup<C1,C2>();							// Instances are actually created by Entity Manager and hopefully dies with it

					_i.AddEntities(Group<C1>.instance.GetEntities());						// On Instantiate Initialize processor list
					_i.AddEntities(Group<C2>.instance.GetEntities());

					Group<C1>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;	// Subscribe to enable and disable callbacks to keep group up-to-date
					Group<C2>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;

					Group<C1>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
					Group<C2>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
				}
				return _i;
			}
		}

		Dictionary<int, int> entityLookup = new Dictionary<int, int>(); 	// lookups for entity array positions
		public Processor<C1,C2>[] processors = new Processor<C1, C2>[8];	// current list of all enabled components of type
		public int processorCount = 0;
		Processor<C1,C2> newProcessor;

		public Action<C1, C2> AddGroupCallback;
		public Action<C1, C2> RemoveGroupCallback;

		public void OnEnableComponent(Entity e)	// Called by the component when enabled
		{
			if (entityLookup.ContainsKey(e.ID)) 				// early out if component is already added
				return;

			if (!(e.TryGetEnabled<C1>(out newProcessor.c1) 
				&& e.TryGetEnabled<C2>(out newProcessor.c2))) 	// early out if not all components are enabled
				return;

			if (processorCount == processors.Length)			// resize the array if full
			{
				Array.Resize( ref processors, processors.Length*2);
			}

			newProcessor.id = e.ID;								// assign new processor id
			processors[processorCount] = newProcessor; 			// add processor to the end of array
			entityLookup.Add(e.ID, processorCount); 			// add processor position to dictionary lookups
			++ processorCount;									// increaese amount of components

			if (AddGroupCallback != null)						// signal systems that group has been added
				AddGroupCallback(newProcessor.c1, newProcessor.c2);
		}

		public void OnDisableComponent(Entity e)
		{
			int arrayPos;
			if (!entityLookup.TryGetValue(e.ID, out arrayPos)) 		// try get array position, early out if none
				return;
			var lastProcessor = processors[processorCount -1];		// get last processor
			processors[arrayPos] = lastProcessor;					// move the last processor to removed processor's position, keeps array contiguous
			entityLookup[lastProcessor.id] = arrayPos;				// update position of swapped processor
			-- processorCount;										// reduce the amount of processors in list
			entityLookup.Remove(e.ID);								// remove entity from lookup

			if (RemoveGroupCallback != null)						// signal system that group has been removed
				RemoveGroupCallback(e.Get<C1>(), e.Get<C2>());
		}

		void AddEntities(List<Entity> e)							// Adds a list of entities to system
		{
			for(int i = 0; i < e.Count; ++i)
			{
				OnEnableComponent(e[i]);	
			}
		}

		public override void Destroy ()		// clears singleton when destroyed, probably doesn't need it but just to be safe
		{
			_i = null;
		}

		public override int Count {
			get {
				return processorCount;
			}
		}
	}
		
	public struct Processor<C1, C2>	// struct to keep track of processor components
	{
		public int id;
		public C1 c1;
		public C2 c2;
	}
}
	
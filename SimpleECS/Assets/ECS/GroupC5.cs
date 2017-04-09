using UnityEngine;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SimpleECS.Internal
{
	public delegate void Action<C1,C2,C3,C4,C5>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5);

	public class Group<C1, C2, C3, C4, C5>: Group 
		where C1 : EntityComponent<C1>
		where C2 : EntityComponent<C2>
		where C3 : EntityComponent<C3>
		where C4 : EntityComponent<C4>
		where C5 : EntityComponent<C5>
	{
		static Group<C1,C2, C3, C4, C5> _i;
		public static Group<C1,C2,C3,C4, C5> instance	// Yes this is singleton pattern. Fastest way I could find to get Component IDs
		{
			get 
			{
				if (_i == null && EntityManager.instance != null)							// if null and there is an Entity Manager, get set the instance value
				{
					_i = EntityManager.instance.GetGroup<C1,C2,C3,C4,C5>();					// Instances are actually created by Entity Manager and hopefully dies with it

					_i.AddEntities(Group<C1>.instance.GetEntities());						// On Instantiate Initialize processor list
					_i.AddEntities(Group<C2>.instance.GetEntities());
					_i.AddEntities(Group<C3>.instance.GetEntities());
					_i.AddEntities(Group<C4>.instance.GetEntities());
					_i.AddEntities(Group<C5>.instance.GetEntities());

					Group<C1>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;	// Subscribe to enable and disable callbacks to keep group up-to-date
					Group<C2>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;
					Group<C3>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;
					Group<C4>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;
					Group<C5>.instance.EnabledComponentEntityCallback += _i.OnEnableComponent;

					Group<C1>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
					Group<C2>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
					Group<C3>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
					Group<C4>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
					Group<C5>.instance.DisabledComponentEntityCallback += _i.OnDisableComponent;
				}
				return _i;
			}
		}

		Dictionary<int, int> entityLookup = new Dictionary<int, int>(); 	// lookups for entity array positions
		public Processor<C1,C2,C3,C4,C5>[] processors = new Processor<C1,C2,C3,C4,C5>[8];	// current list of all enabled components of type
		public int processorCount = 0;

		Processor<C1,C2,C3,C4,C5> newProcessor;

		public Action<C1, C2, C3, C4, C5> AddGroupCallback;
		public Action<C1, C2, C3, C4, C5> RemoveGroupCallback;

		public void OnEnableComponent(Entity e)	// Called by the component when enabled
		{
			if (entityLookup.ContainsKey(e.ID)) 				// early out if component is already added
				return;

			if (! (e.TryGetEnabled<C1>(out newProcessor.c1) 
				&& e.TryGetEnabled<C2>(out newProcessor.c2) 
				&& e.TryGetEnabled<C3>(out newProcessor.c3) 
				&& e.TryGetEnabled<C4>(out newProcessor.c4) 
				&& e.TryGetEnabled<C5>(out newProcessor.c5))) 	// early out if not all components are enabled
				return;

			if (processorCount == processors.Length)			// resize the array if full
			{
				Array.Resize( ref processors, processors.Length*2);
			}

			newProcessor.id = e.ID;

			processors[processorCount] = newProcessor; 			// add component to the end of array
			entityLookup.Add(e.ID, processorCount); 			// add component position to dictionary lookups
			++ processorCount;									// increaese amount of components

			if (AddGroupCallback != null)
				AddGroupCallback(newProcessor.c1, newProcessor.c2, newProcessor.c3, newProcessor.c4, newProcessor.c5);
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

			if (RemoveGroupCallback != null)
			{
				RemoveGroupCallback(e.Get<C1>(), e.Get<C2>(), e.Get<C3>(), e.Get<C4>(), e.Get<C5>());
			}
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
		
	public struct Processor<C1, C2, C3, C4, C5>	// struct to keep track of processor components
	{
		public int id;
		public C1 c1;
		public C2 c2;
		public C3 c3;
		public C4 c4;
		public C5 c5;
	}
}
	
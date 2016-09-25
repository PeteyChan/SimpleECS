using UnityEngine;
using System.Collections.Generic;
using ECS.Internal;

public interface IEvent{}

public static class CustomEvent
{
	private static Dictionary <System.Type, EventHolder> CallDelegates = new Dictionary<System.Type, EventHolder>();	// Dicitonary containing a list of delegates you can call		

	/// <summary>
	/// Add event listener.
	/// </summary>
	public static void AddListener<T>(EventDelegate<T> eventDelegate) where T : IEvent
	{
		EventHolder newDel;
		if (CallDelegates.TryGetValue(typeof(T), out newDel))
		{
			((EventHolder<T>)newDel).eventDelegate += eventDelegate;
			return;
		}
		else
		{
			newDel = new EventHolder<T>();
			((EventHolder<T>)newDel).eventDelegate = eventDelegate;
			CallDelegates.Add(typeof(T), newDel);
		}
	}
		
	public static void RemoveListener<T>(EventDelegate<T> eventDelegate) where T : IEvent
	{
		EventHolder newDel;
		if (CallDelegates.TryGetValue(typeof(T), out newDel))
		{
			((EventHolder<T>)newDel).eventDelegate -= eventDelegate;
			return;
		}
	}
		
	public static void Invoke(IEvent e)
	{
		EventHolder holder;
		if(CallDelegates.TryGetValue(e.GetType(), out holder))
		{
			holder.Invoke(e);
		}
	}

	public static void Invoke<T>(IEvent e)
	{
		Invoke(e);
	}

	public static void ClearAllEvents()
	{
		CallDelegates.Clear();
	}
}

namespace ECS.Internal
{
	public delegate void EventDelegate<T>(T e) where T : IEvent;	// delegate which takes a generic arguement that implements IEvent

	public class EventHolder
	{
		public virtual void Invoke(IEvent e)
		{}
	}

	public class EventHolder<T> : EventHolder where T : IEvent
	{
		public EventDelegate<T> eventDelegate;

		public override void Invoke (IEvent e)
		{
			if (eventDelegate != null)
				eventDelegate((T)e);
		}
	}

}
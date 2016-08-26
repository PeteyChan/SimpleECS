using UnityEngine;
using System.Collections.Generic;

public interface IEvent{}

public static class CustomEvent
{
	public delegate void GenericEventDelegate<T>(T e) where T : IEvent;	// delegate which takes a generic arguement that implements IEvent
	public delegate void EventDelegate(IEvent e);					// delegate that takes an arument of type IEvent

	private static Dictionary <System.Type, EventDelegate> CallDelegates = new Dictionary<System.Type, EventDelegate>();	// Dicitonary containing a list of delegates you can call		

	public static void AddListener<T>(GenericEventDelegate<T> del) where T : IEvent
	{
		EventDelegate newEvent = (e) => del((T)e);					// get a new delegate of type T, this is the one we invoke
		EventDelegate tempEvent;									// dicitonary output
		if(CallDelegates.TryGetValue(typeof(T), out tempEvent))
		{
			CallDelegates[typeof(T)] += newEvent;					// if value found add event to dictionary
		}
		else
		{
			CallDelegates[typeof(T)] = newEvent;					// add new entry to dictionary
		}
	}
		
	public static void RemoveListener<T>(GenericEventDelegate<T> del) where T : IEvent
	{
		EventDelegate newEvent = (e) => del((T)e);
		EventDelegate tempEvent;
		if(CallDelegates.TryGetValue(typeof(T), out tempEvent))
		{
			if (tempEvent == null) return;		// should I keep or remove? Keep reference for now, better if need to re-reference
			tempEvent -= newEvent;
		}
	}

	public static void ClearAllEvents()
	{
		CallDelegates.Clear();
	}

	public static void Invoke(IEvent e)
	{
		EventDelegate tempEvent;
		if(CallDelegates.TryGetValue(e.GetType(), out tempEvent))
		{
			if (tempEvent != null)
				tempEvent.Invoke(e);	
		}
	}

	public static void Invoke<T>(IEvent e)
	{
		Invoke(e);
	}
}
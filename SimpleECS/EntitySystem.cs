using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using ECS.Internal;
using System;

namespace ECS
{
	public interface IUpdate{}	// Update EveryFrame
	public interface IFixedUpdate{}

	[System.Serializable]
	public class EntitySystem
	{
		bool _enabled = false;
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="ECS.EntitySystem"/> is enabled.
		/// </summary>
		public bool enabled
		{
			get {return _enabled;}
			set
			{
				if (_enabled)
				{
					if (value == false)
						OnDisable();
				}
				else
				{
					if (value == true)
						OnEnable();
				}
				_enabled = value;
			}
		}

		/// <summary>
		/// Gets called once when system is created regardless if enabled or not.
		/// Gets called before OnEnable()
		/// </summary>
		public virtual void SetGroups(){}

		/// <summary>
		/// Process Update Systems.
		/// System must implement IUpdate interface to use.
		/// </summary>
		public virtual void Update(){}

		/// <summary>
		/// Process Fixed update Systems
		/// System must implement IFixedUpdate to use
		/// </summary>
		public virtual void FixedUpdate(){}

		/// <summary>
		/// Gets called when system is enabled
		/// </summary>
		public virtual void OnEnable(){}

		/// <summary>
		/// gets called when system is disabled
		/// </summary>
		public virtual void OnDisable(){}
	}
}


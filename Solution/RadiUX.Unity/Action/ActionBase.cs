﻿using System;
using RadiUX.Unity.Elements;
using RadiUX.Unity.Util;
using UnityEngine;

namespace RadiUX.Unity.Action {

	/*================================================================================================*/
	public class ActionBase : MonoBehaviour {

		public enum EventType {
			Enter,
			Exit,
			Press,
			Release,
			Select,
			Deselect
		}

		public EventType Event = EventType.Release;

		public ISphereSegment Segment { get; private set; }
		public ISphereContainer Container { get; private set; }


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public ActionBase() {
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Start() {
			FindElement();
		}

		/*--------------------------------------------------------------------------------------------*/
		private void FindElement() {
			if ( Application.isPlaying && (Segment != null || Container != null) ) {
				return;
			}

			Segment = UnityUtil.FindSiblingComponent<ISphereSegment>(gameObject);
			Container = UnityUtil.FindSiblingComponent<ISphereContainer>(gameObject);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void Update() {
			FindElement();
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnMouseEnter() {
			HandleEvent(EventType.Enter);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnMouseExit() {
			HandleEvent(EventType.Exit);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnMouseDown() {
			HandleEvent(EventType.Press);
		}

		/*--------------------------------------------------------------------------------------------*/
		public virtual void OnMouseUp() {
			HandleEvent(EventType.Release);
		}


		////////////////////////////////////////////////////////////////////////////////////////////////
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void HandleEvent(EventType pEvent) {
			if ( Segment == null && Container == null ) {
				throw new Exception("GameObjects with an Action must also have a "+
					"Segment or Container component.");
			}

			if ( pEvent != Event ) {
				return;
			}

			HandleActiveEvent();
		}
		
		/*--------------------------------------------------------------------------------------------*/
		protected virtual void HandleActiveEvent() {
		}

	}

}

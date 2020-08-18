using System;
using System.Collections.Generic;
using System.Text;

namespace UnityEngine {
	class GameObject : Object {
		public List<Component> Components;

		public Transform transform { get; }

		public GameObject() {
			transform = new Transform();
			Components = new List<Component>();
			Components.Add(transform);
		}

		public Component GetComponent(Type type) {
			foreach(var component in Components) {
				if(component.GetType() == type)
					return component;
			}

			return null;
		}

		public T GetComponent<T>() where T : Component {
			T result = null;

			foreach(var component in Components) {
				result = component as T;

				if(result != null)
					break;
			}

			return result;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace UnityEngine {
	class GameObject {
		private List<Component> _components;

		public Transform transform {get; }

		public GameObject(){
			transform = new Transform();
			_components = new List<Component>();
			_components.Add(transform);
		}
	}
}

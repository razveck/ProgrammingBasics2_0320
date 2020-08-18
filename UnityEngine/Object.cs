using System;
using System.Collections.Generic;
using System.Text;

namespace UnityEngine {
	class Object {
		
		public static Object[] FindObjectsOfType(Type type){
			List<Object> result = new List<Object>();

			foreach(var gameObject in Program.MainScene.GameObjects) {
				foreach(var component in gameObject.Components) {
					if(component.GetType() == type){
						result.Add(component);
					}
				}
			}

			return result.ToArray();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace UnityEngine {
	class Transform : Component {

		public Vector3 position;

		public Transform(){
			position = new Vector3(0, 0, 0);
		}
	}
}

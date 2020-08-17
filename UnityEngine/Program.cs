using System;

namespace UnityEngine {
	class Program {
		static void Main(string[] args) {
			Scene mainScene = new Scene();

			Random rand = new Random();
			
			for(int i = 0; i < 10; i++) {
				GameObject obj = new GameObject();
				mainScene.GameObjects.Add(obj);
				obj.transform.position = new Vector3(rand.Next(-100, 100), rand.Next(-100, 100), rand.Next(-100, 100));
			}

			Console.ReadKey();
		}
	}
}

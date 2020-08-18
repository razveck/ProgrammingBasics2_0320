using System;
using System.IO;
using Newtonsoft.Json;

namespace UnityEngine {
	class Program {
		public static Scene MainScene = new Scene();

		private const string _filePath = "MainScene.unity";

		static void Main(string[] args) {
			//Serialization: SAVING data from memory to disk
			//Deserialization: LOADING data from disk to memory

			//JSON - JavaScript Object Notation. It's a universal text format

			//check if file exists
			if(File.Exists(_filePath)) {
				//load the text of the file into a string
				string input = File.ReadAllText(_filePath);
				//convert that (JSON) text into a Scene object
				MainScene = JsonConvert.DeserializeObject<Scene>(input);
			} else {
				//populate the scene with default objects
				Random rand = new Random();

				for(int i = 0; i < 10; i++) {
					GameObject obj = new GameObject();
					MainScene.GameObjects.Add(obj);
					obj.transform.position = new Vector3(rand.Next(-100, 100), rand.Next(-100, 100), rand.Next(-100, 100));
				}

				Object[] objects = Object.FindObjectsOfType(typeof(Transform));

				var transform = MainScene.GameObjects[0].GetComponent<Transform>();

				//this is not allowed, because the generic type doesn't match the constraint
				//var invalidType = MainScene.GameObjects[0].GetComponent<Scene>();
			}

			string output = JsonConvert.SerializeObject(MainScene, Formatting.Indented);
			File.WriteAllText(_filePath, output);

			Console.ReadKey();
		}
	}
}

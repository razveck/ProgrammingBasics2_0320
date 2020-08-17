using System;

namespace ReferenceParameters {

	class ReferenceType {
		public string Name;
	}

	struct ValueType {
		public string Name;
	}

	class Program {
		static void Main(string[] args) {
			Add(3, 5);
			int health = 100;
			DealDamage(health, 12);

			int attackPower = 20;
			DealDamageRef(ref health, ref attackPower);

			DealDamageOut(out health, attackPower);

			DealDamageIn(in health, attackPower);


			ReferenceType somePerson = new ReferenceType();
			ChangeClass(somePerson);

			ChangeClassRef(ref somePerson);

			ChangeClassOut(out somePerson);

			ChangeClassIn(in somePerson);

			ValueType anotherPerson = new ValueType();
			ChangeStructIn(in anotherPerson);


			RaycastHit hit;
			if(Raycast(out hit)){
				//do my stuff
			}else{
				//don't do the stuff
				//or do some other stuff
			}

		}

		private static void Add(int a, int b) {
			int result = a + b;
		}

		private static void DealDamage(int health, int attack) {
			health -= attack;
		}

		//you can do whatever you want
		//this changes the original
		private static void DealDamageRef(ref int health, ref int attack) {
			health -= attack;
		}

		//out parameters MUST be assigned/initialized in the function
		//changes the original
		private static void DealDamageOut(out int health, int attack) {
			//this does not work
			//health -= attack;

			health = 50 - attack;
		}

		//in paramaters MAY NOT be changed in the function (exact opposite of out)
		//doesn't (is not allowed to) change the original
		private static void DealDamageIn(in int health, int attack) {
			//not allowed
			//health = 100;

			Console.WriteLine(health);
			int a = health;
		}

		private static void ChangeClass(ReferenceType myClass) {
			//changes the original
			myClass.Name = "Bob";

			//create a NEW object and point myClass to it
			myClass = new ReferenceType();
			//change the Name of that NEW object (not the original)
			myClass.Name = "Marley";
		}

		private static void ChangeClassRef(ref ReferenceType myClass) {
			//changes the original
			myClass.Name = "Susan";

			//changes the original
			myClass = new ReferenceType();
			//changes the original
			myClass.Name = "Kelly";
		}

		//out parameters MUST be assigned/initialized in the function
		//changes the original
		private static void ChangeClassOut(out ReferenceType myClass) {
			//not allowed, myClass must be initialized
			//myClass.Name = "Karen";

			//this changes the original
			myClass = new ReferenceType();
			myClass.Name = "Karen";
		}

		private static void ChangeClassIn(in ReferenceType myClass) {
			//not allowed, myClass is readonly
			//myClass = new ReferenceType();

			//I can use it
			ReferenceType anotherPerson = myClass;

			//the next line is allowed, however
			//we don't change the reference itself, we change the data
			//PLEASE DON'T DO THIS
			myClass.Name = "Goku";
		}

		private static void ChangeStructIn(in ValueType myStruct) {
			//with a struct, this is not allowed, because a struct is a VALUE type
			//that means Name is part of myStruct (it's not somewhere else in memory)
			//myStruct.Name = "Vegeta";
		}

		private static bool Attack(ref int health, int attackPower) {
			//change the original value of health
			health -= attackPower;

			//also return true if the character died
			if(health <= 0)
				return true;
			else
				return false;
		}



		//---EXAMPLES---

		struct RaycastHit {

		}

		private static bool Raycast(out RaycastHit hit) {
			//check if there are object
			//...insert engine code here...

			//if there are any results, store that here
			if(true) {
				hit = new RaycastHit();
				//hit.hhhhhd = dsjdfjj;
				return true;
			} else {
				//if there are no results
				return false;
			}
		}

		class GameObject{ }

		private static int GenerateObjects(ref GameObject[] list){
			list = new GameObject[10000];
			//generate the map
			//...do stuff here...

			int amountOfBlocks = 5000;
			return amountOfBlocks;
		}

		private static GameObject[] GenerateObjects(ref int amountOfBlocks){
			GameObject[] list = new GameObject[10000];
			//generate the map
			//...do stuff here...

			amountOfBlocks = 5000;
			return list;
		}

	}
}

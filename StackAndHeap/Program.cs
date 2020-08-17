using System;

namespace StackAndHeap {

	class ReferenceType {
		public int Number;
		public float Speed;
		public bool IsActive;
	}

	struct ValueType {
		public int Number;
		public float Speed;
		public bool IsActive;
	}

	class Program {
		static void Main(string[] args) {
			//stack (local variable)
			float someFloat = 100f;

			//stack (local variable)
			char letterA = 'a';

			//name is on the stack, pointing to a string on the heap
			string name = "Joao";

			//stack (local variable)
			ReferenceType myClass = null;

			//throws a NullRef because myClass doesn't point at anything
			//myClass.Number = 10;

			//stack (local variable)
			ValueType myStruct;

			myStruct.Number = 10;

			//on the stack, we simply overwrite the current values of myStruct
			myStruct = new ValueType();

			//on the heap, we create a new object every time
			myClass = new ReferenceType();
			myClass = new ReferenceType();

			//stack (local variable)
			int[] numberArray;

			//create a collection of 10 ints ON THE HEAP
			//numberArray is a pointer of size 32bits/64bits
			//the actual array has a size of 32bits * 10
			numberArray = new int[10];

			//1. call a function. A new stack frame is created and the stack pointer is moved to the new stack frame
			//2. when the function ends, the stack frame is removed and the stack pointer moves back to Main
			BasicFunction();

			//1. call a function. A new stack frame is created and the stack pointer is moved to the new stack frame
			//2. allocate an int = 1 on the stack
			//3. allocate a string = "blabla" on the heap
			//4. when the function ends, the stack frame is removed and the stack pointer moves back to Main
			FunctionWithParameters(1, "blabla");

			//1. call a function. A new stack frame is created and the stack pointer is moved to the new stack frame
			//2. when the function ends, the stack frame is removed and the stack pointer moves back to Main
			//3. allocate a ValueType object with the data returned by the function
			ValueType myValueType = CreateValueType();

			//1. call a function. A new stack frame is created and the stack pointer is moved to the new stack frame
			//2. when the function ends, the stack frame is removed and the stack pointer moves back to Main
			//3. allocate a pointer/reference to a ReferenceType on the STACK and assign it the data returned from the function
			ReferenceType myReferenceType = CreateReferenceType();

			Console.ReadKey();
		}

		private static void BasicFunction() {
			Console.WriteLine("This is a basic function!");
		}

		private static void FunctionWithParameters(int a, string name) {
			//a is on the stack
			//name is on the stack
			//paramaters ALWAYS exist on the stack
		}

		private static ValueType CreateValueType() {
			//allocates a ValueType object on the stack
			ValueType result = new ValueType();
			//create a copy of result and passes it to the previous stack frame
			return result;
		}

		private static ReferenceType CreateReferenceType() {
			//allocate a pointer/reference on the stack
			ReferenceType result;
			//allocate a ReferenceType object on the heap and point result to it
			result = new ReferenceType();

			//create a copy of result and passes it to the previous stack frame
			return result;
		}
	}
}

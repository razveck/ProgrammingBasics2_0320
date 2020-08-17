using System;

namespace Delegates {
	public class Program {

		//1. declare a delegate TYPE
		public delegate void VoidDelegate();

		//2. declare a VARIABLE of that type
		static VoidDelegate A;

		public delegate int Numbers(int a, int b);

		static Numbers B;

		static Action thisIsAVoidWithNoParameters;
		static Action<string> thisIsAVoidWithAStringParameter;
		static Action<string, int, float, bool, Numbers> thisIsAVoidWithManyParameters;

		static Func<int, int, int> thisIsAnIntWithTwoIntParameters;

		static void Main(string[] args) {
			//error, the type VoidDelegate doesn't match the signature of the Add function
			//A = Add;
			thisIsAnIntWithTwoIntParameters = Add;
			//to store Add in a variable we need to create a new delegate that matches the signature of Add
			B = Add;
			Console.WriteLine(B(1, 2));

			B = Multiply;
			Console.WriteLine(B(3, 2));



			//3. assign a VALUE to the variable
			A = PrintName;



			while(true) {
				ConsoleKeyInfo key = Console.ReadKey(true);

				switch(key.Key) {
					case ConsoleKey.D1:
						A = PrintName;
						break;

					case ConsoleKey.D2:
						A = PrintDate;
						break;

					case ConsoleKey.D3:
						A = PrintNumber;
						break;

					case ConsoleKey.Spacebar:
						//pass the delegate as a parameter
						ExecuteDelegate(A);
						break;
				}
			}



			Console.ReadLine();
		}

		public static void PrintName() {
			Console.WriteLine("João");
		}

		public static void PrintName(string name ) {
			Console.WriteLine(name);
		}

		public static void PrintDate() {
			Console.WriteLine(DateTime.Now);
		}

		public static void PrintNumber() {
			Random r = new Random();
			Console.WriteLine(r.Next());
		}

		public static void ExecuteDelegate(VoidDelegate del) {
			del();
		}

		public static int Add(int a, int b) {
			return a + b;
		}

		public static int Multiply(int a, int b) {
			return a * b;
		}
	}
}

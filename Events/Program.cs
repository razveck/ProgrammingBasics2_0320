using System;
using System.Collections.Generic;

namespace Events {
	class Program {

		static List<Action> DelegateList;

		public static event Action MyEvent;

		static void Main(string[] args) {
			//DelegateList = new List<Action>();

			//DelegateList.Add(PrintName);
			//DelegateList.Add(PrintDate);
			//DelegateList.Add(PrintNumber);

			//foreach(Action action in DelegateList) {
			//	action();
			//}

			//--------------------------------------------------------

			Person p = new Person();

			//this does the same as the above
			MyEvent += PrintName;
			MyEvent += PrintDate;
			MyEvent += PrintNumber;

			MyEvent();
		}

		public static void PrintName() {
			Console.WriteLine("João");
		}

		public static void PrintDate() {
			Console.WriteLine(DateTime.Now);
		}

		public static void PrintNumber() {
			Random r = new Random();
			Console.WriteLine(r.Next());
		}
	}
}

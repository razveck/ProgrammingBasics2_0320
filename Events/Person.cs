using System;
using System.Collections.Generic;
using System.Text;

namespace Events {
	class Person {

		public Person(){
			Console.WriteLine("Person was created");
			//subscribe to the MyEvent event
			Program.MyEvent += PrintSomething;
		}


		public void PrintSomething(){
			Console.WriteLine("This is something");
		}
	}
}

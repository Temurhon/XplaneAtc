using System;

namespace XPlaneAtc
{
	public class MainClass	
	{
		//functions
		public static void createFlightPln (string strtAirport, string endAirport)
		{
			Console.WriteLine ("Not implemetented!");
			Environment.Exit (0);
		}

		public static void Wait (int time) 
		{
			System.Threading.Thread.Sleep(time);
		}


		//public variables
		public static string[] airports = new string[2];
		public static string callSign;
		public static string startAirport;
		public static string currentPosition;
		public static string currentAirport;


		//main functions
		public static void Main ()
		{
			//temp airport list
			airports[0] = "KSMD";
			airports[1] = "KFWA";

			//get init variables from user
			Console.WriteLine ("Enter callsign. Ex: N1865");

			callSign = Console.ReadLine ();
			if (callSign != "") { 
				Console.WriteLine ("Callsign is: " + callSign);
			} else {
				Console.WriteLine ("Incorrect callsign!");			
				Environment.Exit (0);
			}		
			Console.WriteLine ("Enter starting airport ICAO. ex:KSFO");
			startAirport = Console.ReadLine ();
			if (startAirport == "") {
				Console.WriteLine ("Incorrect airport ICAO!!");		
				Environment.Exit (0);
			}
			Console.WriteLine ("Starting airport is: " + startAirport);
			Wait (1000);

			//Ask user if they want to file a flightplan or go on
			Console.WriteLine ("What would you like to do?");
			Console.WriteLine ("a.File a flightplan");
			Console.WriteLine ("b.Skip");
			string answer = Console.ReadLine ();
			if (answer == "a") {
				createFlightPln (startAirport, "ksmd");
			} else if (answer == "b") {
				//do nothing
			} else {
				Console.WriteLine("Incorrect command!");
				Environment.Exit (0);
			}
			//init for mainloop
			currentPosition = "ground";
			currentAirport = startAirport;	
			MainLoop(startAirport, false, currentAirport, currentPosition, callSign);
		}	

		public static void MainLoop (string startAirport, bool fltPlanFiled, string currentAirport, string currentPosition, string callSign)
		{
			Console.Clear ();
			while (true) {
				if (currentPosition == "ground") {
					if (currentAirport == startAirport) {
						AtcGround (currentAirport, callSign);
					}
				}
			}
		}
		//atc functions
		public static void declarTaxi (string airport, string callSign, string runway) {
			Console.WriteLine(airport + " traffic, " + callSign + " Taxiing to runway " + runway + "" + airport);
		}

		public static void AtcGround (string airport, string callSign){

			//display action menu
			Console.WriteLine("Currently at: " + airport + "callsign: " + callSign);
			Console.WriteLine("a. Declar taxi intentions");
			Console.WriteLine("b. Declar departing");
			string answer = Console.ReadLine();
			declarTaxi(airport, callSign, "24");


		}

	}

}

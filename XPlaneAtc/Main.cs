using System;
using System.Collections;Sorcus


namespace XPlaneAtc
{
	public class MainClass	
	{
		//public variables
		public static string[] airports = new string[2];
		public static string callSign;
		public static string startAirport;
		public static string currentPosition; //the currentposition and or state. ex currently taxing or init stage.
		public static string currentAirport;


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

		//init
		public static void Main ()
		{
			//temp airport list
			airports[0] = "KSMD";
			airports[1] = "KFWA";


			//set variables
			currentPosition = "init"; 

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
		//public static void
		public static void MainLoop (string startAirport, bool fltPlanFiled, string currentAirport, string currentPosition, string callSign)
		{
			Console.Clear ();
			while (true) {
				Wait (5000);
				if (currentPosition == "ground") {
					if (currentAirport == startAirport) {
						System.Threading.Tasks.Task.Factory.StartNew(() => AtcGround(currentAirport, callSign));
						//AtcGround (currentAirport, callSign);0
					}
				}
			}
		}

			/*
			NOTE:
			Most of the code in the AtcGround function is just for testing. My goal is to have it check the airport database, get all the runways,
			display them, then ask the user which runway. check the answer to see if it matches then call declarTaxi. 
			Towerd controll airports may have a seperate function.			
			*/
		 

		//atc functions
		public static void declarTaxi (string runway) 
		{
			Console.WriteLine(currentAirport + " traffic, " + callSign + " Taxiing to runway " + runway + "" + currentAirport);
		}

		public static void AtcGround (string airport, string callSign)
		{
			Console.WriteLine ("Currently at: " + airport + "callsign: " + callSign);
			Console.WriteLine ("a. Declar taxi intentions");
			string answer = Console.ReadLine ();
			if (answer == "a") {
				Console.WriteLine ("What runway?");
				//current runway list is for testing
				Console.WriteLine ("a.Runway 28");
				answer = Console.ReadLine ();
				if (answer == "a") {
					declarTaxi ("28");
				} else if (answer != "a") {
					Console.WriteLine ("Incorrect option");
					Environment.Exit (0);
				}
			} else if (answer != "a") {
				Console.WriteLine("Incorrect option");
				Environment.Exit (0);
			}
		}
	}
}

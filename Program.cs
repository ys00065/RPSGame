/**
 * This program allows user to play ROCK, PAPER AND SCISSOR game vs Computer
 * @author yam shrestha
 */
using System;
using System.Collections.Generic;

namespace RPSGame
{
	class MainClass
	{
		//This field will store how many times the specific move has been used by computer
		private Dictionary<string,int> computerDic = new Dictionary<string, int> ();

		//This field will store how many times the specific move has been used by computer
		private Dictionary<string,int> humanDic = new Dictionary<string, int> ();

		//This field will store how many times computer has won
		private static int computerWon = 0;

		//This field will store how many times human has won
		private static int humanWon = 0;

		//This field will store how many times game was draw
		private static int drawGame = 0;

		public MainClass ()
		{
			computerDic.Add ("ROCK", 0);
			computerDic.Add ("PAPER", 0);
			computerDic.Add ("SCISSOR", 0);

			humanDic.Add ("ROCK", 0);
			humanDic.Add ("PAPER", 0);
			humanDic.Add ("SCISSOR", 0);
		}

		/**
		 * This method prints out the result
		 * how many times the game has been played
		 * how many times computer has won
		 * how many times human has won
		 * how many times the match has draw
		 */
		public void printOutput ()
		{
			int maxComputerMove = -1000;
			string move = "";
			foreach (KeyValuePair<string, int> pair in computerDic) {
				if (pair.Value > maxComputerMove) {
					maxComputerMove = pair.Value;
					move = pair.Key;
				}
			}

			int maxHumanMove = -1000;
			string moveHuman = "";
			foreach (KeyValuePair<string, int> pair in humanDic) {
				if (pair.Value > maxHumanMove) {
					maxHumanMove = pair.Value;
					moveHuman = pair.Key;
				}
			}

			Console.WriteLine ("Number of times game played:" + (drawGame + humanWon + computerWon));
			Console.WriteLine ("Number of times game draw:" + drawGame);
			Console.WriteLine ("Number of times game won by human:" + humanWon);
			Console.WriteLine ("Number of times game won by computer:" + computerWon);

			Console.WriteLine ("Most move made by computer during the game:");
			foreach (KeyValuePair<string, int> pair in computerDic) {
				if (pair.Value == maxComputerMove) {
					Console.Write (pair.Key + ", ");
				}
			}

			Console.WriteLine ();
			Console.WriteLine ("Most move made by human during the game:");
			foreach (KeyValuePair<string, int> pair in humanDic) {

				if (pair.Value == maxHumanMove) {
					Console.Write (pair.Key + ", ");
				}
			}
		}

		/**
		 * 
		 * This method takes the entered input and compare with computer randomly generated move
		 * The computer move has been generated randomly using date and time 
		 */ 
		public void playGame (String userSelection)
		{
			int userSelectionNumber = 0;
			int count = 0;
			switch (userSelection) {
			case "ROCK":
				count = humanDic ["ROCK"];
				count++;
				humanDic ["ROCK"] = count;
				userSelectionNumber = 0;
				break;
			case "SCISSOR":
				count = humanDic ["SCISSOR"];
				count++;
				humanDic ["SCISSOR"] = count;
				userSelectionNumber = 1;
				break;
			case "PAPER":
				count = humanDic ["PAPER"];
				count++;
				humanDic ["PAPER"] = count;
				userSelectionNumber = 2;
				break;
			}

			Random rnd = new Random (DateTime.Now.Millisecond);

			int computerSelection = rnd.Next (3);
			//computerSelection=0 ROCK
			//computerSelection=1 SCISSOR
			//computerSelection=2 PAPER
			int countComputer = 0;
			switch (computerSelection) {
			case 0:
				countComputer = computerDic ["ROCK"];
				countComputer++;
				computerDic ["ROCK"] = countComputer;
				if (userSelectionNumber == 0) {
					drawGame++;
					Console.WriteLine ("Computer selected ROCK, DRAW");
				} else if (userSelectionNumber == 1) {
					computerWon++;
					Console.WriteLine ("Computer selected ROCK, Computer WIN");
				} else if (userSelectionNumber == 2) {
					humanWon++;
					Console.WriteLine ("Computer selected ROCK, User WIN");
				}
				break;
			case 1:
				countComputer = computerDic ["SCISSOR"];
				countComputer++;
				computerDic ["SCISSOR"] = countComputer;
				if (userSelectionNumber == 0) {
					humanWon++;
					Console.WriteLine ("Computer selected SCISSOR, User WIN");
				} else if (userSelectionNumber == 1) {
					drawGame++;
					Console.WriteLine ("Computer selected SCISSOR, DRAW");
				} else if (userSelectionNumber == 2) {
					computerWon++;
					Console.WriteLine ("Computer selected SCISSOR, Computer WIN");
				}
				break;
			case 2:
				countComputer = computerDic ["PAPER"];
				countComputer++;
				computerDic ["PAPER"] = countComputer;
				if (userSelectionNumber == 0) {
					computerWon++;
					Console.WriteLine ("Computer selected PAPER, Computer WIN");
				} else if (userSelectionNumber == 1) {
					humanWon++;
					Console.WriteLine ("Computer selected PAPER, User Win");
				} else if (userSelectionNumber == 2) {
					drawGame++;
					Console.WriteLine ("Computer selected PAPER, DRAW");
				}
				break;
			}
			Console.WriteLine ();

		}

		/**
		 * 
		 * This main method ask user to enter appropriate move. 
		 * A User also asked to continue game or not
		 */ 
		public static void Main (string[] args)
		{
			MainClass main = new MainClass ();
			Console.WriteLine ("Play Game of ROCK, PAPER and SCISSOR");
			bool continueGame = true;
			while (continueGame) {
				Console.WriteLine ("Please type either ROCK, PAPER OR SCISSOR");
				string userSelection = (Console.ReadLine ()).ToUpper ();

				while (!(userSelection.Equals ("ROCK") || userSelection.Equals ("PAPER") || userSelection.Equals ("SCISSOR"))) {
					Console.WriteLine ("Please type either ROCK, PAPER OR SCISSOR");
					userSelection = (Console.ReadLine ()).ToUpper ();
				}

				main.playGame (userSelection);

				Console.WriteLine ();
				Console.WriteLine ("Would you like to continue, type Y or N");
				char playAgain = (char)Console.Read ();

				while (!(playAgain.Equals ('Y') || playAgain.Equals ('y') || playAgain.Equals ('n') || playAgain.Equals ('N'))) {
					Console.WriteLine ("Please type Y or N");
					Console.WriteLine ();
					playAgain = (char)Console.Read ();
				}
				if (playAgain.Equals ('N') || playAgain.Equals ('n')) {
					continueGame = false;
				}
				Console.WriteLine ();
			}

			main.printOutput ();

		}
	}
}

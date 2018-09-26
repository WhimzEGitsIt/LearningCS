using UnityEngine;

public class Hacker : MonoBehaviour {

	// Game configuration data
	string[] level1Passwords = {"marker", "teacher", "math", "football", "hall pass"};
	string[] level2Passwords = {"particle", "laser", "cell", "organism", "research"};
	string[] level3Passwords = {"Warthog", "Pelican", "Spartan", "Battle Rifle", "John"};
	
	const string menuHint = "You may type menu at any time.";
	
	
	int level;
	enum Screen {MainMenu, Password, Win};
	Screen currentScreen;
	string password;
	
	
	void Start ()
	{
		ShowMainMenu();
	}
	
	void ShowMainMenu()
	{
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		Terminal.WriteLine("Which would you like to hack into?");
		Terminal.WriteLine("Press 1 for Local High School");
		Terminal.WriteLine("Press 2 for Science Lab");
		Terminal.WriteLine("Press 3 for UNSC HQ");
		Terminal.WriteLine("Enter your selection here: ");
	}
	
	void OnUserInput(string input)
	{
		if (input == "menu")
		{
			level = 0;
			ShowMainMenu();
		}
		else if (currentScreen == Screen.MainMenu)
		{
			RunMainMenu(input);
		}
		else if (currentScreen == Screen.Password)
		{
			EnterPassword(input);
		}
	}

	void RunMainMenu(string input)
	{
		bool isValidLevel = (input == "1" || input == "2" || input == "3");
		
		if (isValidLevel)
		{
			level = int.Parse(input);
			AskForPassword();
		}
		else if (input == "117") // easter egg
		{
			Terminal.WriteLine("Nice try, Master Chief");
		}
		else
		{
			Terminal.WriteLine("Your entry is invalid.");
			Terminal.WriteLine(menuHint);
		}
	}
	void AskForPassword ()
	{
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		SetRandomPassword();
		Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
		Terminal.WriteLine(menuHint);
	}

	void SetRandomPassword()
	{
		switch (level)
		{
			case 1:
				password = level1Passwords[Random.Range(0, level1Passwords.Length)];
				break;
			case 2:
				password = level2Passwords[Random.Range(0, level2Passwords.Length)];
				break;
			case 3:
				password = level3Passwords[Random.Range(0, level3Passwords.Length)];
				break;
			default:
				Debug.LogError("Invalid level number");
				break;
		}
	}

	void EnterPassword(string input)
	{
		if (input == password)
		{
			DisplayWinScreen();
		}
		else
		{
			AskForPassword();
		}
	}

	void DisplayWinScreen()
	{
		currentScreen = Screen.Win;
		Terminal.ClearScreen();
		ShowLevelReward();
		Terminal.WriteLine(menuHint);
	}

	void ShowLevelReward()
	{
		switch (level)
		{
				case 1:
					Terminal.WriteLine("You win! Have a book...");
					Terminal.WriteLine(@"

    ________
   /       //
  /       //
 /______ //
(_______(/
"
					);
					break;
				case 2:
					Terminal.WriteLine("You win! You got the vial!");
					Terminal.WriteLine(@"
......
:.  .:
.'  '.
|    |
|    |
`----'
"
					);
					break;
				case 3:
					Terminal.WriteLine("You win! Long live the Chief <3");
					Terminal.WriteLine(@"
   __  _____    __    ____ 
   / / / /   |  / /   / __ \
  / /_/ / /| | / /   / / / /
 / __  / ___ |/ /___/ /_/ / 
/_/ /_/_/  |_/_____/\____/ 
");
					break;
				default:
					Debug.LogError("Invalid level reached");
					break;
				
		}
		
	}
}

using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configurations. whatever that means
    string menuHint = "You may type menu at anytime";
    string[] level1Passwords = {"notes", "books", "classes", "locker", "teacher"};
    string[] level2Passwords = {"patients", "emergency", "surgery", "nursing", "scapal", "masks"};
    string[] level3Passwords = {"executive", "presidential", "Washington", "government", "administration", "Obama", "Trump", "Biden", "commander"};
    //Game State
    int level;
    string password;
    enum Screen { MainMenu, Password, Win }; //State dictates the flow of the game
                                            //and inputs 
    Screen currentScreen = Screen.MainMenu; 
    
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu() 
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Where do you want to hack into?");
        Terminal.WriteLine("\nPress 1 for Malden High School");
        Terminal.WriteLine("Press 2 for the Cambridge Hospital");
        Terminal.WriteLine("Press 3 for the White House");
        Terminal.WriteLine("Please enter in the number you desire:");
    }

    void OnUserInput(string input) 
    {
        if(input == "menu") { // we can always go to direct to main menu
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu) {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win) {
            Terminal.WriteLine(menuHint);
        }
    }

    void RunMainMenu(string input) {
        bool isValidLevelNumber = input == "1" || input == "2" || input == "3";
        if(isValidLevelNumber) {
            level = int.Parse(input);
            AskForPassword();
        }
        else if(input == "007") {
            Terminal.WriteLine("Please choose a level Mr. Bond:");//easter egg
        }
        else {
            Terminal.WriteLine("Please enter in a valid level");
        }
    }

    void AskForPassword() {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
    }

    void CheckPassword(string input) {
        if (input == password) {
            Terminal.WriteLine("Well done!");
            ShowWinScreen();
        }
        else {
            AskForPassword();
        }
    }

    void SetRandomPassword() {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0,level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0,level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0,level3Passwords.Length);
                password = level3Passwords[index3];
                break;    
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }


    void ShowWinScreen() {
        currentScreen = Screen.Win;
        switch(level) {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    ________
   /_____ //
  /_____ //
 /_____ //
(______(/
                    ");
                break;
            case 2:
                Terminal.WriteLine(@".----. 
       ===(_)==
      // 6  6 \\ HI, IM
      (    7   ) DR .COLLINS, THIS
       \ '--' / WON'T HURT A BIT
        \_ ._/
       __)  (__
    ""`/`\`V/`\`\
   /   \  `Y _/_ \
  / [DR]\_ |/ / /\
  |     ( \/ / / /
");
                break;
            case 3:
                Terminal.WriteLine("");
                Terminal.WriteLine(@"
(_ _)
 | |____....----....______________ 
 | |\ ***********|__USA !_________|
 | | |***********|__WELCOME TO ___|
 | | |***********|______THE_______|
 | | |***********|__WHITE HOUSE___|
 | | |____________________________|
 | | |____________________________|
 | | |____________________________|
 | | |____________________________|
 | |/:::''''~~~~''''::::::::::::''~
 | |");
                break;
        }
        Terminal.WriteLine("Click enter to continue...");
    }
}

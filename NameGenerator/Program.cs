using System;
using System.Collections.Generic;
using System.IO;

/* Name Generator
 * CSC205 Final Individual Project
 * Joe Dorsey
 * 
 * Program asks if you want an English name from Earth or a name from the fictional Star Wars universe.
 * 
 * (on a side note, I'm a huge fan of Star Wars and I would highly recommend watching the series if you haven't
 * seen it.)
 * 
 * If you choose earth, you are asked whether you want your name to be male or female
 *      -Whether you choose male or female, it prints out the corresponding name and asks if you like it or not
 *      -If you do, program ends
 *      -If you don't, program restarts
 * If you choose star wars, you are asked whether you want your name to be male or female
 *      -Whether you choose male or female, it prints out the corresponding name and asks if you like it or not
 *      -If you do, program ends
 *      -If you don't, program restarts
 *      
 *      -Error-capturing work is prevalent throughout the program; the proper input that the program is looking
 *      for will be displayed in the user makes a mistake
 *      
 *      -There was a function that I was not able to figure out how to add in; whenever the program generates
 *      you a name and asks if you're satisfied with it, if you select "N" or no, then I wanted it to ask you
 *      whether you wanted it to continue generating names from the criteria that you've already specified or
 *      to start over from the beginning completely. I couldn't get this to work completely as I wanted, so
 *      I left it as is. It's not perfect, but it works.
 */

namespace NameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>(100); // List of Earth male first names
            List<string> names2 = new List<string>(100); // List of Earth female first names
            List<string> names3 = new List<string>(100); // List of Earth surnames
            List<string> names4 = new List<string>(191); // List of SW male first names
            List<string> names5 = new List<string>(78); // List of SW female first names
            List<string> names6 = new List<string>(185); // List of SW surnames
            string choice = ""; //I set this variable to a blank string since it will be used throughout the program for user input

            Console.WriteLine("Welcome to Name Generator!\n");
            Console.WriteLine("I can generate a new name for you, but first let me ask you a few questions.\n");

            do
            {
                ConsoleColor originalColor = Console.ForegroundColor;
                Console.Write("\nWould you like for your new name to be from: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("(1) Earth  ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("(2) A galaxy far, far away.");
                Console.ForegroundColor = originalColor;
                choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1") // User selects "1" for the program to generate a name from Earth
                {
                    Console.Write("You've selected ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Earth.\n");
                    Console.ForegroundColor = originalColor;
                    tryAgain: // I used a goto statement to return to this portion of the loop from line 112 due to an error
                    Console.Write("Please select a gender for your ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Earth ");
                    Console.ForegroundColor = originalColor;
                    Console.WriteLine("name: (1) Male  (2) Female");
                    choice = Console.ReadLine();
                    Console.Clear();

                    if (choice == "1") // User selects "1" for a male name from Earth
                    {
                        Console.WriteLine("You've selected male.\n");
                        names = NewName.processFile(@"C:\Users\jbd11\OneDrive\Documents\MSSA_CAD\CSC_205\MaleFirstNames.txt");
                        names3 = NewName.processFile(@"C:\Users\jbd11\OneDrive\Documents\MSSA_CAD\CSC_205\LastNames.txt");
                        string randomName = NewName.GetRandomName(names);
                        string lastName = NewName.GetRandomName(names3);
                        Console.Write("Your new name is: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(randomName + " " + lastName);
                        Console.ForegroundColor = originalColor;
                    }
                    else if (choice == "2") // User selects "2" for a female name from Earth
                    {
                        Console.WriteLine("You've selected female.\n");
                        names2 = NewName.processFile(@"C:\Users\jbd11\OneDrive\Documents\MSSA_CAD\CSC_205\FemaleFirstNames.txt");
                        names3 = NewName.processFile(@"C:\Users\jbd11\OneDrive\Documents\MSSA_CAD\CSC_205\LastNames.txt");
                        string randomName2 = NewName.GetRandomName(names2);
                        string lastName = NewName.GetRandomName(names3);
                        Console.Write("Your new name is: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(randomName2 + " " + lastName);
                        Console.ForegroundColor = originalColor;
                    }
                    else // I used lots of loops in order to catch the various errors that could possibly occur in the console
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Invalid input.\n");
                        Console.WriteLine("Please select (1) for Male or (2) for female.\n");
                        Console.ForegroundColor = originalColor;
                        choice = "N";
                        goto tryAgain; // goto statment jumps to line 72 due to an error
                    }

                    do
                    {
                        Console.WriteLine("\nAre you satisfied with this name?");
                        Console.WriteLine("(Y) for Yes");
                        Console.WriteLine("(N) for No");
                        choice = Console.ReadLine();
                        choice = choice.ToUpper(); //I added this section for useability; whether user puts upper or lower case answer, it will still take it since it'll convert it to upper case
                        if (choice == "Y" || choice == "N") break; // This was chosen to exit the loop and move to the outer do-while loop
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nError, must include Y or N");
                        Console.ForegroundColor = originalColor;
                    } while (choice != "Y");
                }
                
                else if (choice == "2") // The user selects "2" to generate a name from the Star Wars universe
                {
                    Console.Write("You've chosen wisely. Your name will come from ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("a galaxy far, far away.\n");
                    Console.ForegroundColor = originalColor;
                    tryAgain1: // I used a goto statement to return to this portion of the loop from line 175 due to an error
                    Console.Write("Please select a gender for a name from ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("a galaxy far, far away");
                    Console.ForegroundColor = originalColor;
                    Console.WriteLine(": (1) Male  (2) Female");
                    choice = Console.ReadLine();
                    Console.Clear();

                    if (choice == "1")
                    {
                        Console.WriteLine("You've selected male.\n");
                        names4 = NewName.processFile(@"C:\Users\jbd11\OneDrive\Documents\MSSA_CAD\CSC_205\SWMaleNames.txt");
                        names6 = NewName.processFile(@"C:\Users\jbd11\OneDrive\Documents\MSSA_CAD\CSC_205\SWLastNames.txt");
                        string randomname3 = NewName.GetRandomName(names4);
                        string swLastName = NewName.GetRandomName(names6);
                        Console.Write("Your new name is: ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(randomname3 + " " + swLastName);
                        Console.ForegroundColor = originalColor;
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("You've selected female.\n");
                        names5 = NewName.processFile(@"C:\Users\jbd11\OneDrive\Documents\MSSA_CAD\CSC_205\SWFemaleNames.txt");
                        names6 = NewName.processFile(@"C:\Users\jbd11\OneDrive\Documents\MSSA_CAD\CSC_205\SWLastNames.txt");
                        string randomname4 = NewName.GetRandomName(names5);
                        string swLastName = NewName.GetRandomName(names6);
                        Console.Write("Your new name is: ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(randomname4 + " " + swLastName);
                        Console.ForegroundColor = originalColor;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Invalid input.\n");
                        Console.WriteLine("Please select (1) for Male or (2) for female.\n");
                        Console.ForegroundColor = originalColor;
                        choice = "N";
                        goto tryAgain1; // goto statment jumps to line 135 due to an error
                    }

                    do
                    {
                        Console.WriteLine("\nAre you satisfied with this name?");
                        Console.WriteLine("(Y) for Yes");
                        Console.WriteLine("(N) for No");
                        choice = Console.ReadLine();
                        choice = choice.ToUpper(); //I added this section for useability; whether user puts upper or lower case answer, it will still take it since it'll convert it to upper case
                        if (choice == "Y" || choice == "N") break; // This was chosen to exit the loop and move to the outer do-while loop
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nError, must include Y or N");
                        Console.ForegroundColor = originalColor;
                    } while (choice != "Y"); // This was chosen so that this loop is repeated until the user inputs a correct response
                }
                else //The user types in an invalid input; an error message is displayed that asks for the correct input
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid input.\n");
                    Console.WriteLine("Please select either 1 or 2.\n");
                    Console.ForegroundColor = originalColor;
                    continue;
                }
            } while (choice != "Y"); // After proper selection is made, this portion determines whether the program ends or starts over dependning on the user input
            
            Console.WriteLine("\nEnjoy your new name! If you are from a galaxy far, far away, then may the force be with you!\n");
        }
    }
}

/*
 * My initial intentions for this project was to be able to generate a name for multiple different fictional universes
 * in addition to English names from Earth. Possibly even popular names from historical cutlures as well as other
 * countries from Earth. But there were time limitations for this project, and it took alot of time to properly locate
 * and compile the data that I wanted to use and to be able to edit it in a way that I could use it within my capabilities.
 * 
 * I also wanted to create more classes and have more of the work occur outside of the Main method, possibly with class
 * inheritance, but I felt as though it would take a larger overhaul than my timeline allowed.
 * 
 * In my opinion, this is just the beginning of this project. I know it may seem silly but it's something that excited me when
 * I finally was able to get it functional. I am aware that better ways to accomplish this task without using a labyrinth of
 * loops and nested loops probably exists, but this is the only way that I was able to get it done. I also understand that the
 * contents of this project may not include all of the criteria that was listed on the Moodle page for this project, but I am
 * confident that the amount of work I put into this project will at least garner a decent grade.
 */
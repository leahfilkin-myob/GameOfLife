# Conway's Game of Life Kata
The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970.

The "game" is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input. One interacts with the Game of Life by creating an initial configuration and observing how it evolves.

## How to run the program
The program begins in Program.cs with the Main function, so you can use your IDE to run the program, or you can use your terminal using the dotnet run. Program.cs is located the GameOfLifeConsole folder in the GameOfLife project

## Solution structure
The solution is broken up into two different projects - one for the application (GameOfLife) and one for the tests (GameOfLifeTests).
### GameOfLife
Inside this project there are two folders - GameOfLifeConsole and GameOfLifeLogic. GameOfLifeConsole has all input and output related classes, and anything to do with printing to the Console. The GameOfLifeLogic folder has all business-logic-related classes. Inside GameOfLifeConsole there is a folder called InputHandlers. This is where you will find the input handlers responsibie for receiving console and file input, and the interface they inherit from.
### GameOfLifeTests
This is where all the tests are saved. They are seperated in a way that mirrors the GameOfLife project. There is also a folder called TestInputFiles which you can use to run the program yourself, and they are used in some of the tests.

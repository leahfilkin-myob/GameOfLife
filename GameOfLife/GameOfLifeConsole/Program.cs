using System;
using System.IO;
using GameOfLife.GameOfLifeConsole.InputHandlers;
using GameOfLife.GameOfLifeLogic;

namespace GameOfLife.GameOfLifeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IInputHandler inputHandler;
            while (true)
            {
                try
                {
                    var inputChoice = UserInterface.GetMethodOfInput().ToUpper();
                    inputHandler = InputValidator.ParseInputChoiceTypeToInputHandler(inputChoice);
                    break;
                }
                catch (ArgumentOutOfRangeException ie)
                {
                    Console.WriteLine(ie.Message);
                }
            }

            Grid grid;
            while (true)
            {
                try
                {
                    var input = inputHandler.GetInput();
                    grid = InputValidator.ParseInputToGrid(input);
                    break;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (FileNotFoundException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
            new Game(new World(grid)).RunGenerations();
        }
    }
}
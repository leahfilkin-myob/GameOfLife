using System;
using System.IO;
using GameOfLife.GameOfLifeConsole.InputHandlers;
using GameOfLife.GameOfLifeLogic;

namespace GameOfLife.GameOfLifeConsole
{
    public static class InitialStateGenerator
    {
        public static IInputHandler GenerateInputHandler()
        {
            while (true)
            {
                try
                {
                    var inputChoice = IInputHandler.GetMethodOfInput().ToUpper();
                    return InputValidator.ParseInputChoiceTypeToInputHandler(inputChoice);
                }
                catch (ArgumentOutOfRangeException ie)
                {
                    Console.WriteLine(ie.Message);
                }
            }
        }

        public static Grid GenerateInputGrid(IInputHandler inputHandler)
        {
            while (true)
            {
                try
                {
                    var input = inputHandler.GetInput();
                    return InputValidator.ParseInputToGrid(input);
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
        }
    }
}
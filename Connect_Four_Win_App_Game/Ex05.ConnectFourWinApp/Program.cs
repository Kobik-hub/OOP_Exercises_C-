﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConnectFourWinApp
{
    public class Program
    {
        public static void Main()
        {
            Run();
        }
        public static void Run()
        {
            FormGame formGame = new FormGame();
            formGame.ShowDialog();
        }
    }
}

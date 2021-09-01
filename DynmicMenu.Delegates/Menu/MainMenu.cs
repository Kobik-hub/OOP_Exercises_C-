using System;
using System.Collections.Generic;
using System.Text;

namespace Menu
{
    public class MainMenu
    {
        private List<MenuItem> m_MenuItems;
        private Stack<MenuItem> m_CurrentMenuStack;
        public MainMenu()
        {
            m_MenuItems = new List<MenuItem>();
            m_CurrentMenuStack = new Stack<MenuItem>();
        }
        public void AddMenuItem(MenuItem i_MenuItem)
        {
            m_MenuItems.Add(i_MenuItem);
            if (m_CurrentMenuStack.Count == 0)
            {
                m_CurrentMenuStack.Push(i_MenuItem);
            }
        }
        private void showSubMenu()
        {
            MenuItem currentMenu = m_CurrentMenuStack.Peek();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(currentMenu.Title);
            for (int i = 0; i < currentMenu.m_MenuItems.Count; i++)
            {
                sb.AppendLine(string.Format("{0} - {1}", i + 1, currentMenu.m_MenuItems[i].Title));
            }
            if (m_CurrentMenuStack.Count == 1)
            {
                sb.AppendLine("0 - Exit");
            }
            else
            {
                sb.AppendLine("0 - Back");
            }
            Console.WriteLine(sb.ToString());
        }
        private void getValidChoiceFromUser(out int o_UserChoice)
        {
            o_UserChoice = -1;
            int numberOfItemsInSubMenu = m_CurrentMenuStack.Peek().m_MenuItems.Count;
            bool validChoice = false;
            Console.WriteLine("Please select option");
            while (validChoice != true)
            {
                // Console.WriteLine("Please enter a valid choice number between 0 - {0}",numberOfItemsInSubMenu);
                bool isNumber = int.TryParse(Console.ReadLine(), out o_UserChoice);
                if (isNumber == true)
                {
                    if (o_UserChoice >= 0 && o_UserChoice <= numberOfItemsInSubMenu)
                    {
                        break;
                    }
                }
                Console.WriteLine("Invalid input");
            }
        }
        public void Show()
        {
            int userChoice;
            while (true)
            {
                if (m_CurrentMenuStack.Count == 0)
                {
                    break;
                }
                showSubMenu();
                userChoice = -1;
                getValidChoiceFromUser(out userChoice);
                if (userChoice == 0)
                {
                    m_CurrentMenuStack.Pop();
                    Console.Clear();
                    continue;
                }
                if (m_CurrentMenuStack.Peek().m_MenuItems[userChoice - 1].m_MenuItems == null)
                {
                    Console.Clear();
                    m_CurrentMenuStack.Peek().m_MenuItems[userChoice - 1].OnClick();
                    Console.WriteLine("Please press enter to go menu.");
                    Console.ReadLine();
                }
                else if (m_CurrentMenuStack.Peek().m_MenuItems[userChoice - 1].m_MenuItems.Count > 1)
                {
                    m_CurrentMenuStack.Push(m_CurrentMenuStack.Peek().m_MenuItems[userChoice - 1]);
                }
                Console.Clear();
            }
        }
    }
}

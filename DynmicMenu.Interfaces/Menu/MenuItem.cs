using System;
using System.Collections.Generic;
using System.Text;

namespace Menu
{
    public class MenuItem
    {
        internal List<MenuItem> m_MenuItems;
        internal IMenuItemObserver m_ChoseObserver = null;
        private MenuItem(string i_Title, params MenuItem[] i_MenuItems)
        {
            Title = i_Title;
            m_MenuItems = new List<MenuItem>(i_MenuItems);
        }
        private MenuItem(string i_Title, IMenuItemObserver i_ItemChosen)
        {
            m_MenuItems = null;
            Title = i_Title;
            m_ChoseObserver = i_ItemChosen;
        }
        public void OnClick()
        {
            m_ChoseObserver.ItemChosen();
        }
        public static MenuItem CreateMenuItem(string i_Title, IMenuItemObserver i_ItemChosen)
        {
            return new MenuItem(i_Title, i_ItemChosen);
        }
        public static MenuItem CrateSubMenuItem(string i_Title, params MenuItem[] i_MenuItems)
        {
            return new MenuItem(i_Title, i_MenuItems);
        }
        public string Title { get; }
    }
}

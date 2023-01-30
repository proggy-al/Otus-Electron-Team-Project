using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGS.Gui.Console
{
    /// <summary>
    /// Консольный интерфейс пользователя
    /// </summary>
    public class Gui
    {
        private const string START = "START";
        private const string EXIT = "EXIT";
        private const string NEXT = "NEXT";
        private bool executing;

        private readonly List<Action> _actions;

        public Gui(List<Action> actions)
        {
            _actions=actions;
            executing = true;
        }

        public void Sart()
        {
            foreach (var action in _actions)
            {
                if(!executing) break;
                action.Invoke();
            }
        }
    }
}

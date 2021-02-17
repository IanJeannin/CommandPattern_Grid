using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand
{
    public abstract class Command : ICommand
    {
        public string CommandName;

        public Command()
        {
            this.CommandName = "Base Command";
        }
        
        public virtual void Execute(GameObject go)
        {
            this.Log();
        }

        protected virtual void Log()
        {
            Debug.Log(string.Format("{0} executed.", CommandName));
        }
    }
}


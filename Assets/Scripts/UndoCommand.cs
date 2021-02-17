using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand
{
    public class UndoCommand : Command
    {
        public UndoCommand(CommandWithUndo command)
        {
            this.CommandName = "Undo " + command.CommandName;
        }
    }
}
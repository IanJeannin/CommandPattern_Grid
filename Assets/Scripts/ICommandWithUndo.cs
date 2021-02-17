using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand
{ 
    /// <summary>
    /// Undo is a ICommand With and UndoCommand
    /// </summary>
    public interface ICommandWithUndo : ICommand
    {
        UndoCommand UndoCommand { get; set; }
    }
}


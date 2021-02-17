using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand
{
    public class CommandWithUndo : Command, ICommandWithUndo
    {
        GameObject go; 
        public UndoCommand UndoCommand { get; set; }

        public CommandWithUndo() : base()
        {

        }

        public override void Execute(GameObject go)
        {
            this.go = go;   //Hold a refernce to the game componet this command was excuted on
            base.Execute(go);
        }
        public void UnExecute()
        {
            this.UndoCommand.Execute(go);
        }
    }
}
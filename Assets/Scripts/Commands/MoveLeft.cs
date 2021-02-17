using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand.Commands
{
    public class MoveLeft : CommandWithUndo
    {
        public MoveLeft() : base()
        {
            this.CommandName = "Move Up";
            this.UndoCommand = new UndoMoveLeftCommand(this);
        }

        public override void Execute(GameObject go)
        {
            //Different Game Components may move differently check if the go is a CommandPacMan
            var target = go.GetComponent<GridMovement>();
            if (target is GridMovement)
            {
                target.MoveLeft();
            }
            base.Execute(go);
        }
    }

    public class UndoMoveLeftCommand : UndoCommand
    {

        public UndoMoveLeftCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameObject go)
        {
            //Different Game Components may move differently check if the go is a CommandPacMan
            var target = go.GetComponent<GridMovement>();
            if (target is GridMovement)
            {
                target.MoveRight();
            }
            base.Execute(go);
        }
    }
}
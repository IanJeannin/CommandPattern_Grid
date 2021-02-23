using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand.Commands
{
    public class MoveUp : CommandWithUndo
    {
        public MoveUp() : base()
        {
            this.CommandName = "Move Up";
            this.UndoCommand = new UndoMoveUpCommand(this);
        }

        public override void Execute(GameObject go)
        {
            //Different Game Components may move differently check if the go is a CommandPacMan
            var target = go.GetComponent<GridMovement>();
            if (target is GridMovement)
            {
                if (target.MoveUp())
                {
                    base.Execute(go);
                }
                else
                {
                    base.Execute(go);
                    base.UnExecute();
                }
            }
            base.Execute(go);
        }
    }

    public class UndoMoveUpCommand : UndoCommand
    {

        public UndoMoveUpCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameObject go)
        {
            //Different Game Components may move differently check if the go is a CommandPacMan
            var target = go.GetComponent<GridMovement>();
            if (target is GridMovement)
            {
                target.UndoMoveUp();
            }
            base.Execute(go);
        }
    }
}
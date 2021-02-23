using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand.Commands
{
    public class MoveRight : CommandWithUndo
    {
        public MoveRight() : base()
        {
            this.CommandName = "Move Right";
            this.UndoCommand = new UndoMoveRightCommand(this);
        }

        public override void Execute(GameObject go)
        {
            //Different Game Components may move differently check if the go is a CommandPacMan
            var target = go.GetComponent<GridMovement>();
            if (target is GridMovement)
            {
                if(target.MoveRight())
                {
                    base.Execute(go);
                }
                else
                {
                    base.Execute(go);
                    base.UnExecute();
                }
            }
            //base.Execute(go);
        }
    }

    public class UndoMoveRightCommand : UndoCommand
    {

        public UndoMoveRightCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameObject go)
        {
            //Different Game Components may move differently check if the go is a CommandPacMan
            var target = go.GetComponent<GridMovement>();
            if (target is GridMovement)
            {
                target.UndoMoveRight();
            }
            base.Execute(go);
        }
    }
}
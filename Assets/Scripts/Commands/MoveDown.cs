using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand.Commands
{
    public class MoveDown : CommandWithUndo
    {
        public MoveDown() : base()
        {
            this.CommandName = "Move Down";
            this.UndoCommand = new UndoMoveDownCommand(this);
        }

        public override void Execute(GameObject go)
        {
            //Different Game Components may move differently check if the go is a CommandPacMan
            var target = go.GetComponent<GridMovement>();
            if (target is GridMovement)
            {
                if (target.MoveDown())
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

    public class UndoMoveDownCommand : UndoCommand
    {

        public UndoMoveDownCommand(CommandWithUndo command) : base(command)
        {

        }

        public override void Execute(GameObject go)
        {
            //Different Game Components may move differently check if the go is a CommandPacMan
            var target = go.GetComponent<GridMovement>();
            if (target is GridMovement)
            {
                target.UndoMoveDown();
            }
            base.Execute(go);
        }
    }
}
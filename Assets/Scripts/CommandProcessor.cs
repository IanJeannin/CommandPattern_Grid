using ConsoleCommand;
using ConsoleCommand.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand
{

    public class CommandProcessor : MonoBehaviour
    {
        InputManager keyMap;

        //List of previously processed commands
        Stack<ICommand> Commands = new Stack<ICommand>();

        //public Dictionary<string, GameObject> componentMap;
        public GameObject MoveCommandTarget;

        public object CommandWUndo { get; private set; }

        public CommandProcessor() : base()
        {

            keyMap = new InputManager();

        }

        public void Update()
        {
            //Check keys in keymap
            //Has Released Keys
            foreach (var item in keyMap.OnReleasedKeyMap)
            {
                if (Input.GetKeyUp(item.Key))
                {
                    Debug.Log(string.Format("onReleasedKeyMap Key released {0}", item.Value.ToString())); //Log key to console
                    Command command = null;
                    switch (item.Value)
                    {
                        case "Move Up":
                            //trigger Move Up command
                            command = new MoveUp();
                            break;
                        case "Move Down":
                            //trigger Move Down command
                            command = new MoveDown();
                            break;
                        case "Move Left":
                            //trigger Move Left command
                            command = new MoveLeft();
                            break;
                        case "Move Right":
                            //trigger Move Down command
                            command = new MoveRight();
                            break;
                        case "Undo":
                            if (Commands.Count > 0)
                            {
                                command = (Command)Commands.Pop();
                                if (command is ICommandWithUndo) //if the popped command has an undo command use it
                                {
                                    command = ((ICommandWithUndo)command).UndoCommand;
                                }
                            }
                            break;
                    }
                    if (command != null)
                    {
                        if (command is ICommandWithUndo)
                        {
                            Commands.Push((ICommandWithUndo)command); //only push commands with undo to the stack
                        }
                        command.Execute(MoveCommandTarget);
                    }

                }
            }
        }
    }
}

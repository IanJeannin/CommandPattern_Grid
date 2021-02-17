using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConsoleCommand
{
    public interface ICommand
    {
        void Execute(GameObject go);
    }
}

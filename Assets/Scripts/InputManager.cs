using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Dictionary<KeyCode, string> OnReleasedKeyMap, OnKeyDownMap;

    public InputManager() : base()
    {
        OnReleasedKeyMap = new Dictionary<KeyCode, string>();
        OnKeyDownMap = new Dictionary<KeyCode, string>();
        this.Initalize();
    }

    public virtual void Initalize()
    {

        //Released keys Map May load from text file
        OnReleasedKeyMap.Add(KeyCode.W, "Move Up");
        OnReleasedKeyMap.Add(KeyCode.UpArrow, "Move Up");
        OnReleasedKeyMap.Add(KeyCode.S, "Move Down");
        OnReleasedKeyMap.Add(KeyCode.DownArrow, "Move Down");
        OnReleasedKeyMap.Add(KeyCode.A, "Move Left");
        OnReleasedKeyMap.Add(KeyCode.LeftArrow, "Move Left");
        OnReleasedKeyMap.Add(KeyCode.D, "Move Right");
        OnReleasedKeyMap.Add(KeyCode.RightArrow, "Move Right");
        OnReleasedKeyMap.Add(KeyCode.Z, "Undo");
    }
}

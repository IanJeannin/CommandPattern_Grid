using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private Vector3 originPos;
    private Vector3 targetPos;
    [SerializeField]
    private float distance =0.1f;
    [SerializeField]
    private float moveCooldown;
    [SerializeField]
    private GameObject usedTileSprite;

    //Stores the tiles that have already been moved on
    private Stack<Vector3> UsedTiles = new Stack<Vector3>();
    private Stack<GameObject> UsedTileSprites = new Stack<GameObject>();

    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.W)&&!isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }
        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }*/
    }

    /*private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        originPos = this.gameObject.transform.position;
        targetPos = originPos + (direction*distance);
        if(!UsedTiles.Contains(targetPos))
        {
            UsedTiles.Push(targetPos);
            transform.position = targetPos;
            yield return new WaitForSeconds(moveCooldown);
            isMoving = false;
        }
        else
        {
        }
    }*/

    private bool MovePlayer(Vector3 direction)
    {
        originPos = this.gameObject.transform.position;
        targetPos = originPos + (direction * distance);
        UsedTiles.Push(originPos);
        UsedTileSprites.Push(Instantiate(usedTileSprite, originPos, Quaternion.identity));
        transform.position = targetPos;
        //If false, the command will be unexecuted
        if (!UsedTiles.Contains(targetPos))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UndoMovePlayer(Vector3 direction)
    {
        originPos = this.gameObject.transform.position;
        targetPos = originPos + (direction * distance);
        transform.position = targetPos;
        UsedTiles.Pop();
        Destroy(UsedTileSprites.Pop());
    }

    public bool MoveDown()
    {
        return MovePlayer(Vector3.down);
    }

    public bool MoveUp()
    {
        return MovePlayer(Vector3.up);
    }

    public bool MoveLeft()
    {
        return MovePlayer(Vector3.left);
    }

    public bool MoveRight()
    {
        return MovePlayer(Vector3.right);
    }

    public void UndoMoveUp()
    {
        UndoMovePlayer(Vector3.down);
    }

    public void UndoMoveDown()
    {
        UndoMovePlayer(Vector3.up);
    }

    public void UndoMoveLeft()
    {
        UndoMovePlayer(Vector3.right);
    }

    public void UndoMoveRight()
    {
        UndoMovePlayer(Vector3.left);
    }
}

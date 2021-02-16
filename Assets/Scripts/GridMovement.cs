using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving=false;
    private Vector3 originPos;
    private Vector3 targetPos;
    [SerializeField]
    private float distance =0.1f;
    [SerializeField]
    private float moveCooldown;

    // Update is called once per frame
    void Update()
    {
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
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;
        originPos = this.gameObject.transform.position;
        targetPos = originPos + (direction*distance);
        transform.position = targetPos;
        yield return new WaitForSeconds(moveCooldown);
        isMoving = false;
    }
}

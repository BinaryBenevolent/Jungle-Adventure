using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float moveDirection = 0.1f;
    [SerializeField, Range(0, 1)] private float jumpHeight = 0.5f;

    private void Update()
    {
        if (DOTween.IsTweening(transform))
            return;

        Vector3 direction = Vector3.zero;

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction += Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction += Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
        }

        if(direction == Vector3.zero)
        {
            return;
        }

        Move(direction);
    }

    private void Move(Vector3 direction)
    {
        transform.DOJump(
            transform.position + direction,
            jumpHeight,
            1,
            moveDirection);

        transform.forward = direction;
    }
}

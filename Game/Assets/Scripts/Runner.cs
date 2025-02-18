using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RoadLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}
public class Runner : MonoBehaviour
{
    [SerializeField] float positionX = 4.0f;
    [SerializeField] RoadLine roadLine;
    private float playerXPos;
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Animator animator;

    private void Start()
    {
        roadLine = RoadLine.MIDDLE;

        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Update()
    {
        OnKeyUpdate();
    }
    public void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RoadLine.LEFT)
            {
                roadLine--;
                animator.Play("LeftAvoid");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RoadLine.RIGHT)
            {
                roadLine++;
                animator.Play("RightAvoid");
            }
        }
    }
    public void Move()
    {
        rigidBody.position = new Vector3(positionX * (int)roadLine, 0, 0);
    }
}

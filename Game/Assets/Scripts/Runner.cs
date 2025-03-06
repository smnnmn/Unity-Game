using System;
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
    [SerializeField] float speed = 25.0f;

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
    private void OnEnable()
    {
        InputManager.Instance.action += OnKeyUpdate;
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.State == false) return;
            Move();
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
        // ���� ������
        // ������ �� ���� �־����� �� �� ���̿� ��ġ�� ���� �����ϱ�
        // ���Ͽ� ���� �Ÿ��� ���� ���������� ����ϴ� ����Դϴ�.

        rigidBody.position = Vector3.Lerp
        (
            transform.position,
            new Vector3(positionX * (int)roadLine, 0, 0),
            Time.deltaTime * speed 
        );


    }
    public void Die()
    {
        GameManager.Instance.Finish();
        animator.Play("Die");
    }
    private void OnDisable()
    {
        InputManager.Instance.action -= OnKeyUpdate;
    }
    private void OnTriggerEnter(Collider other)
    {
        Obstacle obstacle = other.GetComponent<Obstacle>();

        if(obstacle != null)
        {
            Die();
        }
    }
    public void Synchoronization()
    {
        animator.speed = SpeedManager.Speed / 20;
    }
}

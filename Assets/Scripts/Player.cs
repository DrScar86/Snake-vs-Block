using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float Speed;
    public Game Game;
    public Transform SnakeHead;
    public int value;
    public int Health = 1;
    private Rigidbody componentRigidbody;
    Vector3 tempVect = new Vector3(0, 0, 1);
    private Vector3 _previousMousePosition;
    public TextMeshPro PointsText;
    public int Length = 1;
    private SnakeTail componentSnakeTail;

    void Start()
    {
        componentRigidbody = GetComponent<Rigidbody>();
        PointsText.SetText(Health.ToString());
        componentSnakeTail = GetComponent<SnakeTail>();
    }

    void Update()
    {
        tempVect = tempVect.normalized * Speed * Time.deltaTime;
        componentRigidbody.MovePosition(transform.position + tempVect);

        if (Input.GetMouseButton(0))
        {

            Vector3 delta = Input.mousePosition - _previousMousePosition;
            delta = delta.normalized * Speed * Time.deltaTime;
            Vector3 newPosition = new Vector3(transform.position.x + delta.x, transform.position.y, transform.position.z + tempVect.z);
            componentRigidbody.MovePosition(newPosition);
        }
        _previousMousePosition = Input.mousePosition;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            value = collision.gameObject.GetComponent<Food>().Value;
            Health += value;
            PointsText.SetText(Health.ToString());
            Destroy(collision.gameObject);

            for (int i = 0; i < value; i++)
            {
                Length++;
                componentSnakeTail.AddCircle();
            }
        }
        else if (collision.gameObject.tag == "Block")
        {
            value = collision.gameObject.GetComponent<Block>().Value;
            if (value >= Health)
            {
                Game.OnPlayerDied();
                componentRigidbody.velocity = Vector3.zero;
            }
            else
            {
                Health -= value;
                PointsText.SetText(Health.ToString());
                Destroy(collision.gameObject);

                for (int i = 0; i < value; i++)
                {
                    Length--;
                    componentSnakeTail.RemoveCircle();
                }
            }
        }
        else if (collision.gameObject.tag == "Finish")
        {
            Game.OnPlayerWon();
        }
    }
}

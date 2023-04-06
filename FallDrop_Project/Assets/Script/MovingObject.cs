using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovingObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;

    public float speed = 5f;

    void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }

    public void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}

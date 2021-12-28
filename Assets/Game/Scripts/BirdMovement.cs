using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float height;
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        //Application.targetFrameRate = 30;
    }
    void Update()
    {
        MoveUpAndDown();
    }


    void MoveUpAndDown()
    {
        //float y = Mathf.PingPong(Time.time*coefficient, height);
        float y = Mathf.Sin(Time.time*speed)*height;
        var tempPos = rb.position;
        tempPos.y = y;
        rb.position = tempPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Observer.updateScore?.Invoke(1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Pipes"))
        {
            Observer.gameOver?.Invoke();
        }
    }


}

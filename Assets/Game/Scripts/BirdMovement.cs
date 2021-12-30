using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float height;
    void Update()
    {
       MoveUpAndDown();
    }


    void MoveUpAndDown()
    {
        //float y = Mathf.PingPong(Time.time*coefficient, height);
        float y = Mathf.Sin(Time.time*speed)*height;
        var tempPos = transform.position;
        tempPos.y = y;
        transform.position = tempPos;
    }
    private void OnTriggerExit2D(Collider2D collision)
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

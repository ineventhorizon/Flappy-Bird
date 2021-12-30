using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] public float pipeSpeed = 0.1f;
    void Update()
    {
        HandleLifeTime();
        MoveLeft();
    }
    void MoveLeft()
    {
        transform.position += (Vector3)Vector2.left * Time.deltaTime *pipeSpeed;
    }

    void HandleLifeTime()
    {
        if (transform.position.x <= -1.2f) Destroy(gameObject);
    }
}

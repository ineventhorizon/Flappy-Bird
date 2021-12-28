using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeRootControl : MonoBehaviour
{
    [SerializeField] private float sensitivity = 0.0001f;
    private Vector2 mouseInput;
    private Vector2 prevMousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        UpAndDownMovement();
    }

    void UpAndDownMovement()
    {
        var pos = this.transform.position;
        pos += (Vector3)(Vector2.up * mouseInput*sensitivity);
        pos.y = Mathf.Clamp(pos.y, -0.5f, 1);
        transform.position = pos;
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clicked");
            prevMousePos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Swirling");
            mouseInput = Input.mousePosition;
            var newPos = mouseInput - prevMousePos;
            mouseInput = newPos;
        }
        if(Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Released");
            prevMousePos = Input.mousePosition;
            mouseInput = Vector2.zero;
        }
    }
}

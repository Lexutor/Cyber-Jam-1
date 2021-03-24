using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBehaviour : MonoBehaviour
{
    bool Preseed = false;

    void OnMouseDown()
    {
        Preseed = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseUp()
    {
        Preseed = false;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void Update()
    {
        if (Preseed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
    }
}

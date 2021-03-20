using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    int vertical, horizontal;
    
    void Start()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = (int)(vertical * Camera.main.aspect);

        horizontal *= 2;

        gameObject.transform.localPosition = new Vector3(0, -vertical - 0.5f, 0);
        gameObject.transform.localScale = new Vector3(horizontal + 2, 1, 1);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
        Grid grid;
        int value;

    void Start()
    {
        grid = new Grid(25, 14, 5f, new Vector3(-61.4f, -35));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition), 10);
        }
 
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }

    //IEnumerable RandomPixelDrop()
    //{
    //    int x = Random.Range(0, 25);
    //    int y = Random.Range(0, 14);
    //
    //    yield return WaitForSeconds;
    //}
}

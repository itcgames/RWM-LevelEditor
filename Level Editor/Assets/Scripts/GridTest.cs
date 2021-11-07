﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTest : MonoBehaviour
{
    GridLayout tile;
    Vector3 mousePos;
    Camera mainCamera;

    private void Start()
    {
        tile = new GridLayout(10, 8, 10.0f, new Vector3(-50, -40));
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            tile.SetValue(mousePos, 1);
        }

        if (Input.GetMouseButtonDown(1))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            tile.SetValue(mousePos, 0);
        }

        if (Input.GetMouseButtonDown(2))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Debug.Log(tile.GetValue(mousePos));
        }
    }
}
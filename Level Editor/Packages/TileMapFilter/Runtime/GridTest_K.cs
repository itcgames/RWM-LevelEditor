using UnityEngine;

public class GridTest_K : MonoBehaviour
{
    GridLayout_K tile;
    Vector3 mousePos;
    Camera mainCamera;

    Vector2 gridSize = new Vector2(16, 8);
    float tileSize = 8;

    private void Start()
    {
        tile = new GridLayout_K((int)gridSize.x, (int)gridSize.y, tileSize, new Vector3(((int)-gridSize.x * tileSize) / 2, ((int)-gridSize.y * tileSize) / 2));
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
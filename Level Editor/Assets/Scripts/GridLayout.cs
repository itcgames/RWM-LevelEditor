using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLayout
{
    private int width, height;
    private float tileSize;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;
    private Vector3 origin;

    public GridLayout(int t_width, int t_height, float t_tileSize, Vector3 t_origin)
    {
        width = t_width;
        height = t_height;
        tileSize = t_tileSize;
        origin = t_origin;
        

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for(int x = 0; x  < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x, y] = CreateWorldText(null, gridArray[x, y].ToString(), GetWorldPosition(x, y) + new Vector3(tileSize, tileSize) * 0.5f, 20, Color.green, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.green, 100.0f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.green, 100.0f);
            }                  
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.green, 100.0f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.green, 100.0f);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x, y;

        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public int GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else // Return "Missing texture" texture
        {
            return -1;
        }
    }

    public int GetValue(Vector3 worldPosition)
    {
        int x, y;

        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

    /// <summary>
    /// Convert X and Y to world position
    /// </summary>
    /// <param X Position="x"></param>
    /// <param Y Position="y"></param>
    /// <returns></returns>
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * tileSize + origin;
    }

    /// <summary>
    /// Convert world position to X and Y
    /// </summary>
    /// <param Position in Game="worldPosition"></param>
    /// <param X Position="x"></param>
    /// <param Y Position="y"></param>
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - origin).x / tileSize);
        y = Mathf.FloorToInt((worldPosition - origin).y / tileSize);
    }

    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.localPosition = localPosition;
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        return textMesh;
    }
}
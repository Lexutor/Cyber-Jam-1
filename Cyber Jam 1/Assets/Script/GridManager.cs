using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Sprite sprite;
    public GameObject pixelObj;

    public float[,] grid;
    int vertical, horizontal, columns, rows;

    public bool isGameRunning = true;

    private void Awake()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = (int)(vertical * Camera.main.aspect);
        columns = horizontal * 2;
        rows = vertical * 2;
        grid = new float[columns, rows];

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                grid[i, j] = Random.Range(0.0f, 1.0f);
                SpawnTile(i, j, grid[i, j]);
            }
        }
    }
    
    private void Start()
    {
        StartCoroutine(RandomPixelDrop());
    }

    private void SpawnTile(int x, int y, float value)
    {
        GameObject gameObject = new GameObject($"X: {x}  -  Y: {y}");

        gameObject.transform.position = new Vector3(x - (horizontal - 0.5f), y - (vertical - 0.5f));
        var pixelSprite = gameObject.AddComponent<SpriteRenderer>();
        pixelSprite.sprite = sprite;
        pixelSprite.color = new Color(1, 1, 1, 0);
    }

    IEnumerator RandomPixelDrop()
    {
        int time = Random.Range(3, 16);
        int x = Random.Range(0, columns);
        int y = Random.Range(0, rows);

        //Debug.Log($"Random max range for X: {columns}");
        //Debug.Log($"Random max range for Y: {rows}");
        Debug.Log($"Time: {time}  -  X: {x}  -  Y: {y}");
        
        yield return new WaitForSeconds(time);

        GameObject pixel = GameObject.Find($"X: {x}  -  Y: {y}");
        
        if (pixel.GetComponent<SpriteRenderer>().color != Color.black)
        {
            pixel.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            Instantiate(pixelObj, new Vector3(pixel.transform.position.x, pixel.transform.position.y, -2), Quaternion.identity);
        }

        if (isGameRunning)
        {
            StartCoroutine(RandomPixelDrop());
        }
    }
}

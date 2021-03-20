using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Sprite sprite;
    public float[,] grid;
    int vertical, horizontal, columns, rows;

    public bool deadPixel = true;

    private void Awake()
    {
        vertical = (int)Camera.main.orthographicSize;
        horizontal = vertical * (Screen.width / Screen.height);
        columns = horizontal * 3 + 1;
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

        gameObject.transform.position = new Vector3(x - (horizontal + 2.5f), y - (vertical - 0.5f));
        var pixelSprite = gameObject.AddComponent<SpriteRenderer>();
        pixelSprite.sprite = sprite;
        pixelSprite.color = new Color(1, 1, 1);
    }

    IEnumerator RandomPixelDrop()
    {
        int time = Random.Range(4, 15);
        int x = Random.Range(0, 15);
        int y = Random.Range(0, 9);

        Debug.Log($"Time: {time}  -  X: {x}  -  Y: {y}");
        
        yield return new WaitForSeconds(time);

        GameObject pixel = GameObject.Find($"X: {x}  -  Y: {y}");
        pixel.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
    }
}

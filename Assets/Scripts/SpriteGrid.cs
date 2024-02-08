using UnityEngine;

public class SpriteGrid : MonoBehaviour
{
    public GameObject spritePrefab;
    public int numRows = 5; 
    public int numColumns = 5; 
    public float rowSpacing = 0.2f;
    public float colSpacing = 0.2f;

    void Start()
    {
        InstantiateGrid();
    }

    void InstantiateGrid()
    {
        float spriteWidth = spritePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float spriteHeight = spritePrefab.GetComponent<SpriteRenderer>().bounds.size.y;

        float screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize * 2;

        float totalWidth = numColumns * spriteWidth + (numColumns - 1) * colSpacing;
        float totalHeight = numRows * spriteHeight + (numRows - 1) * rowSpacing;

        float offsetX = (screenWidth - totalWidth) / 2;
        float offsetY = (screenHeight - totalHeight) / 2;

        Vector2 initialPosition = new Vector2(-totalWidth / 2 + offsetX, totalHeight / 2 - offsetY);

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numColumns; col++)
            {
                float x = initialPosition.x + col * (spriteWidth + colSpacing);
                float y = initialPosition.y - row * (spriteHeight + rowSpacing);

                Vector2 spawnPosition = new Vector2(x, y);
                Instantiate(spritePrefab, spawnPosition, Quaternion.identity, transform);
            }
        }
    }
}

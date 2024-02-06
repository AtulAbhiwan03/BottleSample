using UnityEngine;

public class BoundryManager : MonoBehaviour
{
    public Transform leftWall;
    public Transform rightWall;
    private bool isInstantiated = false;
    public GameObject prefab;
    void Start()
    {
        float screenWidth = Camera.main.orthographicSize * 2 * Camera.main.aspect;

        leftWall.position = new Vector2(-screenWidth / 2f, leftWall.position.y);
        rightWall.position = new Vector2(screenWidth / 2f, rightWall.position.y);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isInstantiated)
        {
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f)); // The z-coordinate is set to 10f, adjust as needed
            GameObject bb =  Instantiate(prefab);
            bb.transform.position = worldMousePosition;
            isInstantiated = true;

        }
    }
}

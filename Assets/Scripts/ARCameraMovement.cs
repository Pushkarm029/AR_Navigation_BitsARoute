using UnityEngine;

public class ARCameraMovement : MonoBehaviour
{
    private GameObject player; // cached reference to player object

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player != null) // check if player reference is valid
        {
            Transform playerTransform = player.transform;
            // get player position
            Vector3 position = playerTransform.position;
            transform.position = position;
        }
    }
}

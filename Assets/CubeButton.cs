using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeButton : MonoBehaviour
{
    // Variables for sphere customization
    public float radius = 1f;
    public Color color = Color.white;
    public float speed = 5.0f;
    public GameObject player;

    void Start()
    {
     player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            HandleLeftClick();
        }
        else if (Input.GetMouseButtonDown(1)) // Right-click
        {
            HandleRightClick();
        }
    }

    // Method called when a left-click occurs
    public void HandleLeftClick()
    {
         Debug.Log("Left-click detected");

         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            // Get the GameObject that was hit
            GameObject hitObject = hit.collider.gameObject;

            // Assuming hitObject contains TileInfo
            TileInfo tileInfo = hitObject.GetComponent<TileInfo>();

            // Check if tileInfo is not null to prevent errors
            if (tileInfo != null)
            {
                 player.transform.position = new Vector3(tileInfo.x, 1f, tileInfo.z);
            }
       
    
  
    }
        }
    

    // Method called when a right-click occurs
    public void HandleRightClick()
    {
        Debug.Log("Right-click detected");

        // Perform a raycast from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            // Get the GameObject that was hit
            GameObject hitObject = hit.collider.gameObject;

            // Assuming hitObject contains TileInfo
            TileInfo tileInfo = hitObject.GetComponent<TileInfo>();

            // Check if tileInfo is not null to prevent errors
            if (tileInfo != null)
            {
                // Create a new GameObject for the sphere
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.name = "Sphere";

                // Set the material color
                sphere.GetComponent<Renderer>().material.color = color;

                // Set the sphere's position using TileInfo
                Vector3 position = new Vector3(tileInfo.x, 1f, tileInfo.z);
                sphere.transform.position = position;

                Debug.Log("Sphere created at position: " + position);
            }
            else
            {
                Debug.LogError("TileInfo not found on hitObject.");
            }
        }
        else
        {
            Debug.LogError("Raycast did not hit any objects.");
        }
        
    }
}

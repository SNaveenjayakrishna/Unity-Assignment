using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileRaycaster : MonoBehaviour
{
    public TextMeshProUGUI tileInfoText; // Reference to a TextMeshProUGUI element to display tile info

    private GameObject lastHoveredTile;


    void Update()
    {
 //RectTransform rectTransform = tileInfoText.rectTransform;
      
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            TileInfo tileInfo = hitObject.GetComponent<TileInfo>();

            if (tileInfo != null)
            {
                // Display the tile's position information on the UI
               // rectTransform.tileInfoText = new Vector3(tileInfo.x, 0, tileInfo.z);
                tileInfoText.text = $"Tile Position: ({tileInfo.x}, {tileInfo.z})";

                // Change color of the hovered tile
                if (lastHoveredTile != hitObject)
                {
                    if (lastHoveredTile != null)
                    {
                        lastHoveredTile.GetComponent<Renderer>().material.color = Color.white;
                    }
                    lastHoveredTile = hitObject;
                    lastHoveredTile.GetComponent<Renderer>().material.color = Color.yellow;
                }
            }
        }
        else
        {
            if (lastHoveredTile != null)
            {
                lastHoveredTile.GetComponent<Renderer>().material.color = Color.white;
                lastHoveredTile = null;
            }

            tileInfoText.text = "";
        }
    }
}

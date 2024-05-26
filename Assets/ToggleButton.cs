using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour
{
//  private bool isToggled = false;
public UnityEvent unityEvent = new UnityEvent();
public GameObject button;
    //public Material cubeRenderer; 
    void Start()
    {
        //cubeRenderer = GetComponent<Renderer>().material;
        button = this.gameObject;
    }

void Update(){
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    if(Input.GetMouseButtonDown(0)){
        if(Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject){
            unityEvent.Invoke();
        }
    }
}
  
}

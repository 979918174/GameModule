using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cursorMovement : MonoBehaviour
{

    RaycastHit hit;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray,out hit)&&hit.collider.tag == "gridElement")
        {
            this.transform.position = hit.collider.transform.position;
            Debug.Log(hit.collider.name);
        }
    }
}

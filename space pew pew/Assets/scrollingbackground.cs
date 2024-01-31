using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingbackground : MonoBehaviour
{
    float scrollSpeed = 0.5f;
    float offset;
    Renderer rend; //reference to the mesh's renderer component
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using System.Collections.Generic;

public class CreateObjects : MonoBehaviour {
   

    void Awake()
    {
        Screen.lockCursor = true;
    }


    // Use this for initialization
    void Start() {
        
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P))
            if (Screen.lockCursor)
                Screen.lockCursor = false;
            else {
                Screen.lockCursor = true;
            }
    }
}



using UnityEngine;
using System.Collections;

public class ColoringForAlgorithm : MonoBehaviour {

    private GameObject[] receivers;
    private bool receiversWellFilled;
    void Awake()
    {
        receivers = GameObject.FindGameObjectsWithTag("receiver");

        
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject go in receivers)
        {
            if (go.GetComponent<ReceiverScript>().validObject == null)
            {
                receiversWellFilled = false;
                break;
            }
            receiversWellFilled = true;
        }

        if (receiversWellFilled)
        {
            Debug.Log("size of the contener : " + receivers.Length);
            foreach (GameObject go in receivers)
            {
                GameObject lockedObject = go.GetComponent<ReceiverScript>().lockedObject;
                if(lockedObject != null)
                    Debug.Log(go.GetComponent<ReceiverScript>().lockedObject.name);
            }
        }

	}
}

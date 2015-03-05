using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {
    public GameObject hitBackObject = null;
    public GameObject hitDownObject = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 bwd = transform.TransformDirection(Vector3.back);
        Vector3 down = transform.TransformDirection(Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, bwd, out hit))
        {
            hitBackObject = hit.transform.gameObject;
        }
        else
            hitBackObject = null;
        if (Physics.Raycast(transform.position, down, out hit))
        {
            hitDownObject = hit.transform.gameObject;
        }
	}
}

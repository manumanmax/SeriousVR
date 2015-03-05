using UnityEngine;
using System.Collections.Generic;

public class DropOn : MonoBehaviour {

	public List<GameObject> objectStored;

	// Use this for initialization
	void Start () {
		objectStored = new List<GameObject> ();
		print (objectStored);
	}

	void OnMouseDown(){

	}

	// Update is called once per frame
	void Update () {
	
	}

	public bool isValid(Vector3 pos){
		return false;
	}
}

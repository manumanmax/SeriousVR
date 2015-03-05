using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Rigidbody))]
public class Dragable : MonoBehaviour
{

	public Camera cam  ;
	public GameObject otherGameObject;
	private Rigidbody myRigidbody ;
	private Transform myTransform  ;
	private bool canMove = false;
	private DropOn workArea;
	private Transform camTransform ;
	private Vector3 initialPosition;

	void Start () 
	{
		//workArea = otherGameObject.GetComponent<DropOn> ();
		myRigidbody = rigidbody;
		myTransform = transform;
		if (!cam) 
		{
			cam = Camera.main;
		}
		if (!cam) 
		{
			Debug.LogError("Can't find camera tagged MainCamera");
			return;
		}
		camTransform = cam.transform;
		//sqrMoveLimit = moveLimit * moveLimit;   // Since we're using sqrMagnitude, which is faster than magnitude
	}
	
	void OnMouseDown () 
	{
		canMove = true;
		initialPosition = myTransform.position;
	}
	
	void OnMouseUp () 
	{
		canMove = false;
		/*if (workArea.isValid (myTransform.position)) {

		} else {
			myTransform.position = initialPosition;
		}*/
	}
	
	void FixedUpdate () 
	{
		if (!canMove)
		{
			return;
		}

		Vector3 mousePos = Input.mousePosition;
		//Vector3 move = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.nearClipPlane)) - myTransform.position;
		//move.z = 0;
		//print (move);
		//transform.position = (myTransform.position + move);		

		//myRigidbody.MovePosition(myRigidbody.position + move);
	}
}

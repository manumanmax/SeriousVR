using UnityEngine;
using System.Collections;

public class ReceiverScript : MonoBehaviour {

   // private GameObject[] grabbableCubes;
    public GameObject lockedObject = null;
    /*private CameraGrabber camScript;
    public int haloDistance = 3;

    private bool buttonDown;
    private bool buttonUp;

    private bool lockInside;*/


    // Use this for initialization
    void Awake() {
       /* grabbableCubes = GameObject.FindGameObjectsWithTag("grabbable");
        camScript = Camera.main.GetComponent<CameraGrabber>();
        Debug.Log(camScript);
        buttonDown = false;
        buttonUp = false;
        lockInside = false;*/
    }

    void Update() {


        if (lockedObject != null)
        {
            lockedObject.transform.position = new Vector3(transform.position.x, transform.position.y,lockedObject.transform.position.z);
            Debug.Log(lockedObject.transform.position);
        }
        /*

        if (Input.GetMouseButtonDown(0)) {
            buttonUp = false;
            buttonDown = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            buttonUp = true;
            buttonDown = false;
        }

        if (lockedObject == null) {
            foreach (GameObject go in grabbableCubes) {
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance <= 2) {
                    lockedObject = go;
                    // we take the position of the locker but not in z
                    lockedObject.transform.position = new Vector3(transform.position.x, transform.position.y, lockedObject.transform.position.z);
                    Camera.main.transform.LookAt(lockedObject.transform.position);
                    camScript.stopDrag = true;
                    //objectLost = false;
                }
            }
        }

        else {
            float camDistance = Vector3.Distance(camScript.transform.position, lockedObject.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(camScript.cursorPos.x, camScript.cursorPos.y, camDistance));
            Vector3 shootPoint = ray.origin + ray.direction * camDistance;
            float distanceToCursor = Vector3.Distance(transform.position, shootPoint);


            if (buttonDown && distanceToCursor < haloDistance)
            {
                lockInside = true;
            }

            if (buttonDown && distanceToCursor > haloDistance)
            {
                if (camScript.dragOk)
                {
                    //Debug.DrawLine(shootPoint, lockedObject.transform.position);
                    lockedObject.transform.position = new Vector3(shootPoint.x, shootPoint.y, lockedObject.transform.position.z);
                    lockedObject = null;
                    camScript.stopDrag = false;
                    //camera already look at the shootpoint position
                    Debug.DrawRay(ray.origin, ray.direction * camDistance * 0.90f, Color.red);
                    Debug.Log(distanceToCursor);
                    lockInside = false;
                }
                else
                {
                    lockInside = true;
                }
                
                
            }
            if (buttonUp && distanceToCursor < haloDistance)
            {
                Debug.Log("button down inside");
                lockInside = true;
                lockedObject.transform.position = new Vector3(transform.position.x, transform.position.y, lockedObject.transform.position.z);
            }
           if (buttonUp && distanceToCursor > haloDistance)
            {
                lockInside = true;
            }


            if (lockInside)
            {
                lockedObject.transform.position = new Vector3(transform.position.x, transform.position.y, lockedObject.transform.position.z);
            }
        }*/

    }
}

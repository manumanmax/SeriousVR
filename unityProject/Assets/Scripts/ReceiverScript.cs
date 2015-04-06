using UnityEngine;
using System.Collections;

public class ReceiverScript : MonoBehaviour {

    public GameObject lockedObject = null;
    public string receiverType = "";
    public bool validObject = false;

    void Update() {


        if (lockedObject != null)
        {
            lockedObject.transform.position = new Vector3(transform.position.x, transform.position.y,lockedObject.transform.position.z);
            if (!receiverType.Equals(""))
            {
                // be careful, you get to configure manually cause it's a prefab
                if (receiverType.Equals(lockedObject.GetComponent<Proprety>().name))
                {
                    validObject = true;
                }
                
            }
        
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponentInParent<Rigidbody>().useGravity = false;
        GetComponentInParent<Rigidbody>().isKinematic = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Ball")
        {
            Invoke("FallDown", 0.5f);
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true ;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);
    }
}

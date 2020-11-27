using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject door;
    void OnTriggerEnter2D (Collider2D other) {
    	if (other.gameObject.tag == "Object") {
    		door.SetActive(false);
    		this.transform.localScale = new Vector3(1,3,3);
    	}
    }

    void OnTriggerExit2D (Collider2D other) {
    	//door.SetActive(true);
    	//this.transform.localScale = new Vector3(3,3,3);
    }
}

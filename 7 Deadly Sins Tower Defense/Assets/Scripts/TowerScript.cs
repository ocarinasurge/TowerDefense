using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
    public Transform myTarget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (myTarget)
        {


        }
	}
    void OnTriggerEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            myTarget = other.gameObject.transform;

        }
    }
    void OnTriggerExit(Collider2D other)
    {
        if (other.gameObject.transform == myTarget)
        {
            myTarget = null;

        }
    }
}

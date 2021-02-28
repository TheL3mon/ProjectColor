using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    void OnTriggerEnter(Collider coll){
        coll.gameObject.GetComponent<Rigidbody>().drag = 1.1f;
    }

    void OnTriggerExit(Collider coll){
        coll.gameObject.GetComponent<Rigidbody>().drag = 0f;
    }
}

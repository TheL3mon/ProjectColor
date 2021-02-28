using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropController : MonoBehaviour
{
    Rigidbody rb;
    string currentMat;

    // water buoyancy
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        currentMat = gameObject.GetComponent<Renderer>().material.name.Replace(" (Instance)","");
        UpdateMatProperties();
    }

    void Update()
    {        
    }

    void FixedUpdate()
    {
        // water buoyancy
        if (transform.position.y < 0f)
        {
            float displacementMultiplier = Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;
            rb.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
        }
    }

    public void UpdateMatProperties(){
        currentMat = gameObject.GetComponent<Renderer>().material.name.Replace(" (Instance)","");
        switch (currentMat)
        {
            // Divide the real world densities (kg/m3) by 1.000!

            case "mtr_wood":
                rb.SetDensity(0.750f); // oak (600-900)
                rb.drag = 0f;
                rb.useGravity = true;
                break;

            case "mtr_metal":
                rb.SetDensity(7.870f); // iron (7870)
                rb.drag = 0f;
                rb.useGravity = true;
                break;

            default:
                break;
        }
    }
}

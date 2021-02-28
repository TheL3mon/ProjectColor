using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float range = 6;
    public RaycastHit target_hit;
    public GameObject object_lookingat;
    public string material_lookingat;
    public string active_material;
    
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButton(0)){
            ShootPaint();
        }
        else if (Input.GetMouseButton(1)){
            ExtractPaint();
        }
    }

    void FixedUpdate(){
        if (Physics.Raycast(Camera.main.transform.position, transform.forward, out target_hit, range)){
            object_lookingat = target_hit.collider.gameObject;
            material_lookingat = object_lookingat.GetComponent<Renderer>().material.name.Replace(" (Instance)","");
        }
        else{
            object_lookingat = null;
            material_lookingat = "unknown";
        }
    }

    void OnGUI(){
        GUI.Box(new Rect(Screen.width/2, Screen.height/2, 10, 10), "");
    }

    void ShootPaint(){
        if (object_lookingat.tag != "ground"){
            object_lookingat.GetComponent<Renderer>().material = Resources.Load("Materials/test/" + active_material) as Material;
            object_lookingat.GetComponent<PropController>().UpdateMatProperties();
        }
    }

    void ExtractPaint(){
        switch (material_lookingat){
            case "mtr_wood":
                active_material = "mtr_wood";
                break;

            case "mtr_metal":
                active_material = "mtr_metal";
                break;

            default:
                break;
        }
    }
}

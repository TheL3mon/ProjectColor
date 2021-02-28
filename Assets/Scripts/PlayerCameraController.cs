using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public float look_sensitivity = 5.0f;
    public float look_smoothing = 2.0f;
    public GameObject character;
    private Vector2 mouseLook;
    private Vector2 smoothV;

	void Start () {
        character = this.transform.parent.gameObject;
	}
	
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(look_sensitivity * look_smoothing, look_sensitivity * look_smoothing));
        
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / look_smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / look_smoothing);
        
        mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
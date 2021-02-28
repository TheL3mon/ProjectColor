using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpforce = 0.5f;
    public float current_jumpcount = 0;
    public float max_jumpcount = 2; // double jump
    public Rigidbody rb;
    private float translation;
    private float straffe;

    void Start (){
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
	}
	
	void Update (){
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape")) {
            Cursor.lockState = CursorLockMode.None;
        }

        // falling into the void reloads the scene
        // (should place you back to spawn without reloading in the final)
        if (rb.position.y <= -4.0f){
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void FixedUpdate(){
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (current_jumpcount < max_jumpcount){
                rb.AddForce(new Vector3(0, jumpforce, 0));//, ForceMode.Impulse);
                current_jumpcount += 1;
            }
        }
    }

    void OnCollisionEnter(Collision col){
        //if (col.gameObject.CompareTag("ground")){
            current_jumpcount = 0;
        //}
    }
}

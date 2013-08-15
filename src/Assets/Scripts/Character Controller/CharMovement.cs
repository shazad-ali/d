using UnityEngine;
using System.Collections;


//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class CharMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
		
	public float speed = 3.0F;
    public float rotateSpeed = 3.0F;
	public Transform bullitPrefab;
	
	// Update is called once per frame
	void Update () {
		var controller = GetComponent<CharacterController>();
	
		//rotate around y - axis
		transform.Rotate(0,Input.GetAxis("Horizontal") * rotateSpeed, 0);
		
		var forward = transform.TransformDirection(Vector3.forward);
		var curSpeed = speed * Input.GetAxis("Vertical");
		controller.SimpleMove(forward * curSpeed);
	
	    if(Input.GetButtonDown("Jump"))
		{
			
		   var bullit = Instantiate(bullitPrefab,
				GameObject.Find("spawnpoint").transform.position,
				Quaternion.identity) as Transform;
		
			bullit.rigidbody.AddForce(transform.forward * 2000);
		}
	}
}

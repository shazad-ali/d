using UnityEngine;
using System.Collections;

public class boxcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	
	public Transform BulletPrefab;
	public Transform LookAtTarget;
	public float damp = 6.0F;
	public int savedTime = 0;
	
	// Update is called once per frame
	void Update () {
		
		if(LookAtTarget) //ensures target is set
		{
			var rotate = Quaternion.LookRotation(LookAtTarget.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation,rotate,Time.deltaTime * damp);
			int seconds = (int)Time.time;
			var oddeven = (seconds % 2) == 0;
			
			if(oddeven)
			{
			   Shoot(seconds);
			}
		}
		
		//transform.LookAt(LookAtTarget);
	}
	
	void Shoot(int seconds)
	{
		if(seconds != savedTime)
		{
		
			var bullet = Instantiate(BulletPrefab,transform.Find("enemyspawn").transform.position,
				Quaternion.identity) as Transform;
			
			bullet.rigidbody.AddForce(transform.forward * 1000);
			
			savedTime = seconds;
		 }
	}
}

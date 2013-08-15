using UnityEngine;
using System.Collections;

public class objectlife : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float lifetime = 1.2F;
	
	void Awake () {
		Destroy(gameObject, lifetime);
	}
}

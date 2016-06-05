using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(-1,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

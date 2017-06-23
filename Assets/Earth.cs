using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {


	public Rigidbody earthBody;
	void Start () {
		earthBody = GetComponent<Rigidbody> ();
	}

}

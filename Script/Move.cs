using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public Transform t;

	// Update is called once per frame
	void Update () {
		t.position = Input.mousePosition;
	}
}

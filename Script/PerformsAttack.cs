using UnityEngine;
using System.Collections;

public class PerformsAttack : MonoBehaviour {
	
	public float cooldown = 5000f;
	public float range = 100.0f;
	
	float cooldownRemaining = 0;
	
	public AudioClip impact;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		cooldownRemaining -= Time.deltaTime;
		
		if (Input.GetMouseButton(0) && cooldownRemaining <= 0) {
			cooldownRemaining = 0.5f;
            audio.PlayOneShot(impact,0.1F);
           
			Ray	ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
			RaycastHit hitInfo;
			if (Physics.Raycast(ray, out hitInfo, range) ) {
				
				Vector3 hitPoint = hitInfo.point;
				GameObject go = hitInfo.collider.gameObject;
				if ( go.tag == "patient"){
					go.tag = "Untagged";
					Debug.Log("dead");
					
				
					
					Destroy(go);
				}
				
			}
		}
	}
}

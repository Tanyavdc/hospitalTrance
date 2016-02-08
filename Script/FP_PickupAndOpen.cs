using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FP_PickupAndOpen : MonoBehaviour {

	public float range = 2.0f;
	public bool hasKey = false;
	public Text pickeyText;
	
	public AudioClip key_sound;
	AudioSource audiokey;

	public AudioClip door_sound;
	AudioSource doorsound;

	private float current_time=0.0f, executed_time=0.0f, timeToWait = 5.0f;
	private bool showText=true;

	float cooldownRemaining = 0;

	// Use this for initialization
	void Start () {
		//audio = GetComponent<AudioSource>();
		Cursor.visible = true;
		pickeyText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

		cooldownRemaining -= Time.deltaTime;

		if (this.hasKey == true && cooldownRemaining <= 0) {
			pickeyText.text = "";
			showText = false;
		}
		
		if (Input.GetMouseButton(0)) {
    

			Ray	ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			if (Physics.Raycast(ray, out hitInfo, range) ) {
				
				Vector3 hitPoint = hitInfo.point;
				GameObject go = hitInfo.collider.gameObject;
				if ( go.tag == "Key"){
					GetComponent<AudioSource>().PlayOneShot(key_sound, 0.1F);
					go.tag = "Untagged";
					this.hasKey = true;
					Debug.Log("got key!");
					Destroy(go);
				}
				if(this.hasKey == true)
				{
					
					showText = true;
					pickeyText.text = "Picked Up Key!";
					cooldownRemaining = 4.0f;
				

				}



				if ( go.tag == "door"){
					if (hasKey){
						Debug.Log("door open!");
						go.tag = "Untagged";
						Destroy(go);
						GetComponent<AudioSource>().PlayOneShot(door_sound, 0.1F);
					}
					else{
						Debug.Log("need key");
					}
				}
				if (go.tag == "first_door") {
					Destroy (go);
					GetComponent<AudioSource> ().PlayOneShot (door_sound, 0.1F);
				}


			}
		}
	}
}
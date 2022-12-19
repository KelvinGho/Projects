using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	

	//How long the light flash is visible
	public float lightDuration = 0.02f;
	[Header("Light")]
	public Light lightFlash;

	[Header("Audio")]
	public AudioClip[] explosionSounds;
	public AudioSource audioSource;

	private void Start () {
		
		StartCoroutine (LightFlash ());

		//Get a random impact sound from the array
		audioSource.clip = explosionSounds
			[Random.Range(0, explosionSounds.Length)];
		//Play the random explosion sound
		audioSource.Play();
	}

	private IEnumerator LightFlash () {
		//Show the light
		lightFlash.GetComponent<Light>().enabled = true;
		//Wait for set amount of time
		yield return new WaitForSeconds (lightDuration);
		//Hide the light
		lightFlash.GetComponent<Light>().enabled = false;
	}

	
}

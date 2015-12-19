using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerNetworkSetup : NetworkBehaviour {
	
	void Start () {
		if(isLocalPlayer){
                        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
			GetComponentInChildren<Camera>().enabled = true;
			GetComponentInChildren<AudioListener>().enabled = true;
			GetComponent<CharacterController>().enabled = true;
		}
	}
}

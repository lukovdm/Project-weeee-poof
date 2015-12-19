using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncRotation : NetworkBehaviour {

	[SyncVar] Quaternion syncPlayerRotation;
	[SyncVar] Quaternion syncCamRotation;

	[SerializeField] Transform playerTransform;
	[SerializeField] Transform camTransform;
	[SerializeField] float lerpRate;

	Quaternion lastPlayerRot;
	Quaternion lastCamRot;
	[SerializeField] float threshold = 15;

	void Update () {
		TransmitRotations();
		LerpRotations();
	}

	private void LerpRotations () {
		if (!isLocalPlayer){
			playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, syncPlayerRotation, lerpRate * Time.deltaTime);
			camTransform.rotation = Quaternion.Lerp(camTransform.rotation, syncCamRotation, lerpRate * Time.deltaTime);
		}
	}

	[Command]
	void CmdProvideRotationServer(Quaternion playerRot, Quaternion camRot) {
		syncCamRotation = camRot;
		syncPlayerRotation = playerRot;
	}

	[ClientCallback]
	void TransmitRotations () {
		if(isLocalPlayer && (Quaternion.Angle(playerTransform.rotation, lastPlayerRot) > threshold || Quaternion.Angle(camTransform.rotation, lastCamRot) > threshold)) {
			CmdProvideRotationServer(playerTransform.rotation, camTransform.rotation);
		}
	}
}

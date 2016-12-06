using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour {

    public GameObject target;
    private Vector3 defaultPosition;

    public float rotationCameraVelocity;
    public float maxCameraRotation;
    public float maxCameraDodge;
    private bool isStarted;

	/// <summary>
	/// Start this instance.
	/// </summary>
    void Start() {
        defaultPosition = transform.position;
    }

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
        if( transform.position.x > maxCameraDodge)
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        if (isStarted) {
            Effect();
        }
	}

	/// <summary>
	/// Effect this instance.
	/// </summary>
    private void Effect() {
        if (transform.eulerAngles.y < maxCameraRotation) {
            transform.eulerAngles += new Vector3(0, rotationCameraVelocity, 0);
        }
    }

	/// <summary>
	/// Starts the effect.
	/// </summary>
    public void StartEffect() {
        this.isStarted = true;
    }

	/// <summary>
	/// Restart this instance.
	/// </summary>
    public void restart()
    {
        transform.rotation = Quaternion.identity;
        transform.position = defaultPosition;
        this.isStarted = false;
    }
}

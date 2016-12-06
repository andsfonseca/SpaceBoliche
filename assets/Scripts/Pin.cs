using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    private Transform point;
    private bool isFalled;
	public float falledLimiter;
    public float tamMax;
    private Vector3 originalPosition;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
        point = transform.GetChild(0);
        this.originalPosition = transform.position;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		point.transform.rotation = Quaternion.identity;
        if (!isFalled)
        {
			if (point.position.y < falledLimiter) {
                isFalled = true;
                GameLogic.Instance.placar.AddPoint(1);
            }
        }

        if (transform.position.y < tamMax)
        {
            gameObject.SetActive(false);
        }


    }

	/// <summary>
	/// Restart this instance.
	/// </summary>
    public void Restart() {
        transform.rotation = Quaternion.identity;
        transform.position = originalPosition;
        isFalled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}

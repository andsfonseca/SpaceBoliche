using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball : MonoBehaviour {

    private Rigidbody rb;
    private bool isLaunched;
    public float leftAndRightVelocity;
    public float letfLimit;
    public float rightLimit;
    public float tamMax;
    public float torqueVariation;
    private Vector3 originalPosition;

	/// <summary>
	/// Gets a value indicating whether this instance is launched.
	/// </summary>
	/// <value><c>true</c> if this instance is launched; otherwise, <c>false</c>.</value>
    public bool IsLaunched {
        get {
            return isLaunched;
        }
    }

    // Use this for initialization
	/// <summary>
	/// Start this instance.
	/// </summary>
    void Start()
    {
         
        this.originalPosition = transform.position;
        isLaunched = false;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
	/// <summary>
	/// Update this instance.
	/// </summary>
    void Update()
    {
        if (!isLaunched)
        {
			/* maintain the ball on the track and make horizontal movimentation */
            if (letfLimit < transform.position.z &&
                transform.position.z < rightLimit)
                transform.Translate(0f, 0f, leftAndRightVelocity * Input.GetAxis("Horizontal"));
            else if (!(letfLimit < transform.position.z))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, rightLimit - leftAndRightVelocity);
            }
            else if (!(transform.position.z < rightLimit))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, letfLimit + leftAndRightVelocity);
            }

        }

		/* set game over and disable ball - to prevent infinite falling ball */
        if (transform.position.y < tamMax)
        {
            GameLogic.Instance.gameOver.SetActive(true);
            gameObject.SetActive(false);
        }

    }
		
	/// <summary>
	/// Applies the force.
	/// </summary>
	/// <param name="force">Force count</param>
    public void ApplyForce(float force) {
        GetComponent<Rigidbody>().AddForce(-force, 0, 0);
        isLaunched = true;
        GetComponent<Rigidbody>().AddTorque(Input.GetAxis("Horizontal") * torqueVariation, 0, 0);
    }
		
	/// <summary>
	/// Restart this instance.
	/// </summary>
    public void Restart() {
        isLaunched = false;
        transform.position = originalPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }

  
}

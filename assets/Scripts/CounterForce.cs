using UnityEngine;
using System.Collections;

public class CounterForce : MonoBehaviour {


	private bool isKeyDown;
    private float force;
    private float deltaForce;
    private int Increment;

    private RectTransform rTransform;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
        this.force = 0;
        this.deltaForce = 0;
        this.Increment = 1;
        this.rTransform = GetComponent<RectTransform>();
        rTransform.localScale = new Vector3(1, 0, 1);
    }
	
	// Update is called once per frame
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
        if (!GameLogic.Instance.ball.IsLaunched)
        {
            if (Input.GetButtonDown(GameLogic.Instance.powerButtonName)) {
                isKeyDown = true;
            }

            if (Input.GetButtonUp(GameLogic.Instance.powerButtonName)) {
                GameLogic.Instance.ball.ApplyForce(force);
                GameLogic.Instance.cameraEffects.StartEffect();
                GameLogic.Instance.menu.SetActive(false);
                GameLogic.Instance.placar.gameObject.SetActive(true);
                isKeyDown = false;
                Start();
            }
        }


        if (isKeyDown) {
            if (deltaForce > 1) {
                Increment = -1;
            }
            if (deltaForce <= 0) {
                Increment = 1;
            }

            deltaForce += Time.fixedDeltaTime * Increment;
            
            force = deltaForce * GameLogic.Instance.maxBallForce;
			rTransform.localScale = new Vector3 ( 1, deltaForce, 1);
        }
	}

}

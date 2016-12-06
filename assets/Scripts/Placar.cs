using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar : MonoBehaviour
{

    private int points;
    private string defaultText;

	/// <summary>
	/// Start this instance.
	/// </summary>
    void Start()
    {
        this.points = 0;
        this.defaultText = GetComponent<Text>().text;
        atualizaPlacar();
    }

	/// <summary>
	/// Atualizas the placar.
	/// </summary>
    private void atualizaPlacar()
    {
        GetComponent<Text>().text = defaultText + points;
    }

	/// <summary>
	/// Adds the point.
	/// </summary>
	/// <param name="points">Points.</param>
    public void AddPoint(int points)
    {
        this.points += points;
        atualizaPlacar();
    }

	/// <summary>
	/// Restarts the placar.
	/// </summary>
    public void RestartPlacar() {
        this.points = 0;
        atualizaPlacar();
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar : MonoBehaviour
{

    private int points;
    private string defaultText;
    void Start()
    {
        this.points = 0;
        this.defaultText = GetComponent<Text>().text;
        atualizaPlacar();
    }

    private void atualizaPlacar()
    {
        GetComponent<Text>().text = defaultText + points;
    }

    public void AddPoint(int points)
    {
        this.points += points;
        atualizaPlacar();
    }

    public void RestartPlacar() {
        this.points = 0;
        atualizaPlacar();
        gameObject.SetActive(false);
    }
}

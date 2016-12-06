using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static GameLogic Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = GameObject.FindObjectOfType<GameLogic>();
                DontDestroyOnLoad(m_instance.gameObject);
            }

            return m_instance;
        }
    }

	/// <summary>
	/// The m instance.
	/// </summary>
    private static GameLogic m_instance;
    void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != m_instance)
            {
                Destroy(this.gameObject);
            }
        }
    }

    [Header("Game Elements")]
    [Tooltip("Camera")]
    public CameraEffects cameraEffects;
    [Tooltip("Bola do Jogo")]
    public Ball ball;
    [Tooltip("Pins")]
    public Pin[] pins;
    [Tooltip("Placar")]
    public Placar placar;
    [Tooltip("Menu")]
    public GameObject menu;
    [Tooltip("GameOver")]
    public GameObject gameOver;

    [Space]
    [Header("Game Variables")]
    [Tooltip("MAX Força de Lançamento")]
    public float maxBallForce;

    [Space]
    [Header("Controls Settings")]
    [Tooltip("Nome do Botão")]
    public string powerButtonName;

	/// <summary>
	/// Restarts the level.
	/// </summary>
    public void restartLevel()
    {
        gameOver.SetActive(false);
        menu.SetActive(true);
        ball.gameObject.SetActive(true);
        ball.Restart();
        placar.RestartPlacar();
        cameraEffects.restart();
        foreach (Pin p in pins) {
            p.gameObject.SetActive(true);
            p.Restart();
        }
    }


}

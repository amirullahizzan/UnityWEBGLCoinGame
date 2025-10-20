using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerTxt;
    Game game;
    [SerializeField] private GameObject playerPad;
    [SerializeField] private float speed = 2.0f;
    private Rigidbody playerPadRb;
    Vector3 force;

    [Header("Game Timer")]
    [SerializeField] private float totalTime = 60f;  // Total time in seconds
    private float timeLeft;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        game = GetComponent<Game>();
        playerPadRb = playerPad.GetComponent<Rigidbody>();
        timeLeft = totalTime;
    }
    void Start()
    {
        Time.timeScale = 0.8f;
        timerTxt.text = timeLeft.ToString("F3");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            force += -playerPad.transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            force += playerPad.transform.right * speed * Time.deltaTime;
        }

        // Update timer
        if (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime;

            // Optional: log the time left
            Debug.Log("Time Left: " + Mathf.CeilToInt(timeLeft));
        timerTxt.text = timeLeft.ToString("F3");
        }
        else
        {
            timeLeft = 0f;
            timerTxt.text = "Time's up!";
            Debug.Log("Time's up!");
            SceneManager.LoadScene(0);
        }
    }

    void FixedUpdate()
    {
        playerPad.transform.position += force;
        force = Vector3.zero;
    }


}

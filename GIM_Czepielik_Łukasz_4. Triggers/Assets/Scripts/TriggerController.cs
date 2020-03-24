using UnityEngine;
using UnityEngine.UI;

public class TriggerController : MonoBehaviour
{
    public const int TRIGGER_AMOUNT_OF_POINTS = 1;
    public const int GAME_FINISHED_AMOUNT_OF_POINTS = 10;

    public const string PLAYER_TAG = "ThirdPersonControllerPlayer";
    public const string TRIGGER_TAG = "Trigger";

    private int _score;

    public Text scoreText;
    public Text gameFinishedText;

    public AudioClip soundToPlay;
    public float volume;
    AudioSource soundSource;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        soundSource = GetComponent<AudioSource>();

        UpdateScoreText();
        InitializeGameFinishedText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TRIGGER_TAG))
        {
            soundSource.loop = true;
            soundSource.clip = soundToPlay;
            soundSource.volume = volume;
            soundSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(TRIGGER_TAG))
        {
            soundSource.Stop();
            other.gameObject.SetActive(false);

            SetScore(TRIGGER_AMOUNT_OF_POINTS);
            CheckIfPlayerWon();
        }
    }

    void SetScore(int gainedPoints)
    {
        _score = _score + gainedPoints;
        UpdateScoreText();
        CheckIfPlayerWon();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + _score.ToString();
    }

    void CheckIfPlayerWon()
    {
        if (_score >= GAME_FINISHED_AMOUNT_OF_POINTS)
        {
            gameFinishedText.text = "You have finished the game!";
        }
    }

    void InitializeGameFinishedText()
    {
        gameFinishedText.text = "";
    }
}

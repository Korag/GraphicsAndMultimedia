using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public const int PICKUP_CUBE_AMOUNT_OF_POINTS = 1;
    public const int PICKUP_SPHERE_AMOUNT_OF_POINTS = 2;
    public const int GAME_FINISHED_AMOUNT_OF_POINTS = 10;

    public const string PICKUP_CUBE_TAG = "Pick Up Cube";
    public const string PICKUP_SPHERE_TAG = "Pick Up Sphere";

    public float speed;

    private int _score;

    public Text scoreText;
    public Text gameFinishedText;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        UpdateScoreText();
        InitializeGameFinishedText();
    }

    // Update is called once per frame
    void Update()
    {
        // Record input from our player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Use the input we get to move the rigid body
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Make a smooth movement by multiplying by Time.deltaTime
        // Adjust our "movement" vector by "speed" to make game playable
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if our object collides with a pickup object
        CheckIfGameObjectIsPickUp(other);
    }

    void CheckIfGameObjectIsPickUp(Collider other)
    {
        CheckIfGameObjectIsPickUpCube(other);
        CheckIfGameObjectIsPickUpSphere(other);
    }

    void CheckIfGameObjectIsPickUpCube(Collider other)
    {
        if (CheckGameObjectByTagAndDiactivate(other, PICKUP_CUBE_TAG))
        {
            SetScore(PICKUP_CUBE_AMOUNT_OF_POINTS);
        }
    }

    void CheckIfGameObjectIsPickUpSphere(Collider other)
    {
        if (CheckGameObjectByTagAndDiactivate(other, PICKUP_SPHERE_TAG))
        {
            SetScore(PICKUP_SPHERE_AMOUNT_OF_POINTS);
        }
    }

    bool CheckGameObjectByTagAndDiactivate(Collider other, string tag)
    {
        if (other.gameObject.CompareTag(tag))
        {
            other.gameObject.SetActive(false);
            return true;
        }
        return false;
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
            gameFinishedText.text = "You win!";
        }
    }

    void InitializeGameFinishedText()
    {
        gameFinishedText.text = "";
    }
}

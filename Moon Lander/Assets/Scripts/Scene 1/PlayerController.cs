using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 17.5f;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI objective;
    public TextMeshProUGUI followArrow;
    public Button restartBtn;
    public PlayerInventory inventory;

    public GameObject arrow;
    public GameObject sceneTrigger;

    public AudioClip forwardSoundClip;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        inventory = inventory.GetComponent<PlayerInventory>();
        objective.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");


        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (forwardInput > 0 || forwardInput < -1)
        {
            // check if the audio is not playing already and play audio
            if (!audioSource.isPlaying)
            {
                // Play the forward sound
                audioSource.clip = forwardSoundClip;
                audioSource.Play();
            }
        }
            // when the number of crystals collected reaches the inputed number enable the win game method
            if (inventory.numberOfCrystals == 10)
        {
            WinGame();
        }

    }

    // Game Over
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Bad")
        {
            audioSource.Stop();
            gameOverText.gameObject.SetActive(true);
            restartBtn.gameObject.SetActive(true);
            Time.timeScale = 0f;
            
        }
    }

    // Restart Game
    public void RestartGame()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    // Game Over But you move on to the next phase!
    public void WinGame()
    {   
        objective.gameObject.SetActive(false);
        followArrow.gameObject.SetActive(true);
        sceneTrigger.SetActive(true);
        arrow.SetActive(true);
    }


}



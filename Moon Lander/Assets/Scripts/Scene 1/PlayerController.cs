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
    
    public TextMeshProUGUI winText;
    public Button restartBtn;

    public PlayerInventory inventory;

    int newCrystalCount;

    public GameObject objectToActivate;
    public Collider boxColliderToActivate;

    // Start is called before the first frame update
    void Start()
    {

        inventory = inventory.GetComponent<PlayerInventory>();

        objectToActivate =.CompareTag("");


    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        // when the number of crystals collected reaches the inputed number enable the win game method
        if (inventory.numberOfCrystals == 1)
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
            objectToActivate.gameObject.SetActive(true);
            boxColliderToActivate.enabled = true;
    }


}



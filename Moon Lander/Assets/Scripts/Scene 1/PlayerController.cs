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
    public Button restartBtn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }

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

    public void RestartGame()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}



using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
    GameObject[] pauseObjects;
    public Image Pause;
    public Text RetryText;
    public Text MainMenuText;
    public Button RetryButton;
    public Button MainMenuButton;
    // Reference to the AudioSource component.
    UnityStandardAssets.Characters.FirstPerson.FirstPersonController playerMovement;   // Reference to the player's movement.
    Shoot playerShooting;                              // Reference to the PlayerShooting script.
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Shoot>();
        pauseObjects = GameObject.FindGameObjectsWithTag("Player");
        pauseObjects = GameObject.FindGameObjectsWithTag("Monster");
        hidePaused();
        RetryButton.enabled = false;
        MainMenuButton.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //uses the p Text to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                RetryButton.enabled = true;
                MainMenuButton.enabled = true;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                RetryButton.enabled = false;    
                MainMenuButton.enabled = false;
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }


    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
        playerShooting.enabled = false; 
        playerMovement.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        RetryText.color = new Color(1f, 1f, 1f, 1f);
        MainMenuText.color = new Color(1f, 1f, 1f, 1f);
        Pause.color = new Color(0.5f, 0.5f, 1f, 0.4f);
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
        playerShooting.enabled = true;
        playerMovement.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RetryText.color = new Color(1f, 1f, 1f, 0f);
        MainMenuText.color = new Color(1f, 1f, 1f, 0f);
        Pause.color = new Color(1f, 0f, 0f, 0f);
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}

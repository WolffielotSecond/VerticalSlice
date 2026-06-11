using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class UI : MonoBehaviour
{
    
    [Header("UI Assets")]
    public Sprite hasHatchet;
    public Sprite hasPistol;
    public Sprite NoHatchet;
    public Sprite NoPistol;
    [Space]
    [Header("Main UI Elements")]
    public GameObject HatchetIndicator;
    public GameObject PistolIndicator;
    public TMP_Text Loaded_Ammo;
    public TMP_Text Carried_Ammo;
    public TMP_Text Meds;
    public GameObject MainUI;
    public TMP_Text ParryText;
    public TMP_Text AimShootText;
    [Space]
    [Header("Inventory")]
    public GameObject InventoryPanel;
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    public TMP_Text key1text;
    public TMP_Text key2text;
    public TMP_Text key3text;
    public GameObject key1icon;
    public GameObject key2icon;
    public GameObject key3icon;
    [Space]
    [Header("Pick Up UI")]
    public GameObject PickUpPanel;
    public RawImage BlurBackground;
    public Image pickupIcon;
    public TMP_Text pickupItemName;
    private Texture2D screenshot;
    [Space]
    [Header("Win and Death")]
    public GameObject WinScreen;
    public GameObject DeathScreen;
    [Space]
    [Header("General Prompt")]
    public GameObject prompt;
    public TMP_Text promptText;
    [Space]
    [Header("No Editing")]
    public GameObject Key;
    public WhichDoor doorType;
    public InteractableUnlockedDoorScript _doorScript;
    [Space]
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip pick_up_sfx;
    public AudioClip Heal_sfx;
    public AudioClip Parry_sfx;
    public AudioClip Shoot_sfx;
    public AudioClip Kick_sfx;
    public AudioClip footStep_sfx;
    public AudioClip Death_sfx;
    public AudioClip Win_sfx;

    private float timer = 0f;
    private Vector3 originalPos;
    //Menus Opened Bools
    private bool PickupMenuOpened = false;
    private bool InteractionMenuOpened = false;
    IEnumerator CaptureScreen()
    {
        audioSource.clip = pick_up_sfx;
        audioSource.pitch = 1f;
        audioSource.Play();
        yield return new WaitForEndOfFrame();

        screenshot = ScreenCapture.CaptureScreenshotAsTexture();

        BlurBackground.texture = screenshot;
        BlurBackground.gameObject.SetActive(true);
        PickUpPanel.SetActive(true);
        PickupMenuOpened = true;
        Time.timeScale = 0f;
    }
    public void OpenMenu()
    {
        StartCoroutine(CaptureScreen());
        originalPos = new Vector3(0, 90, 0);//pickupIcon.gameObject.transform.position;
    }
    public void CloseMenu()
    {
        Time.timeScale = 1f;

        PickUpPanel.SetActive(false);
        BlurBackground.gameObject.SetActive(false);
        PickupMenuOpened = false;
        timer = 0f;
        Destroy(Key);
    }

    private void SetStats()
    {
        PistolIndicator.GetComponent<Image>().sprite = Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasPistol ? hasPistol : NoPistol;
        //       GameInstanceHolder.instance.gameInstance.hasGun ? hasPistol : NoPistol;
        ParryText.enabled = Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasHatchet;
        AimShootText.enabled = Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasPistol;
        HatchetIndicator.GetComponent<Image>().sprite = Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasHatchet ? hasHatchet : NoHatchet;
        //    GameInstanceHolder.instance.gameInstance.hasHatchet ? hasHatchet : NoHatchet;
        Loaded_Ammo.text = Singleton.Instance._player.GetComponent<Player_Stats_Handler>().ammoLoaded.ToString(); //GameInstanceHolder.instance.gameInstance.ammoLoaded.ToString();
        Carried_Ammo.text = Singleton.Instance._player.GetComponent<Player_Stats_Handler>().ammo.ToString();//GameInstanceHolder.instance.gameInstance.ammoCarried.ToString();
        Meds.text = Singleton.Instance._player.GetComponent<Player_Stats_Handler>().medkits.ToString();
    }
    private void Start()
    {
        SetStats();
    }

    //Interaction UI

    public void OpenInteractionMenu()
    {
        InteractionMenuOpened = true;
        MainUI.SetActive(false);
        InventoryPanel.SetActive(true);
        Singleton.Instance._player.GetComponent<NewPlayer>().playerObj.SetActive(false);
        switch (doorType)
        {
            case WhichDoor.A:
                Debug.Log("Door A");
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyA)
                {
                    Key1.SetActive(true);
                }
                else
                {
                    Key1.SetActive(false);
                }
                
                Key2.SetActive(false);
                Key3.SetActive(false);
                break;
            case WhichDoor.B:
                Debug.Log("Door B");
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyA)
                {
                    Key1.SetActive(true);
                }
                else
                {
                    Key1.SetActive(false);
                }
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyB)
                {
                    Key2.SetActive(true);
                }
                else
                {
                    Key2.SetActive(false);
                }
                Key3.SetActive(false);
                break;
            case WhichDoor.C:
                Debug.Log("Door C");
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyA)
                {
                    Key1.SetActive(true);
                }
                else
                {
                    Key1.SetActive(false);
                }
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyB)
                {
                    Key2.SetActive(true);
                }
                else
                {
                    Key2.SetActive(false);
                }
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyC)
                {
                    Key3.SetActive(true);
                }
                else
                {
                    Key3.SetActive(false);
                }
                break;
        }
    }

    public void CloseInteractionMenu()
    {
        MainUI.SetActive(true);
        InventoryPanel.SetActive(false);
        Singleton.Instance._player.GetComponent<NewPlayer>().playerObj.SetActive(true);
        _doorScript.CameraReturnLocation();
        Singleton.Instance._player.GetComponent<NewPlayer>().enabled = true;
        InteractionMenuOpened = false;
    }

    public void keyOne()
    {
        switch (doorType)
        {
            case WhichDoor.A:
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyA)
                {
                    InventoryPanel.SetActive(false);
                    Singleton.Instance._player.GetComponent<Player_Stats_Handler>().RoomAUnlocked = true;
                    _doorScript.play_Unlock_Animation();
                    
                }
                else
                {
                    Debug.Log("Key Not Obtained");
                }
                break;
            case WhichDoor.B:
                PlayPrompt("Wrong Key");
                break;
            case WhichDoor.C:
                PlayPrompt("Wrong Key");
                break;
        }
    }

    public void keyTwo()
    {
        switch (doorType)
        {
            case WhichDoor.B:
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyB)
                {
                    InventoryPanel.SetActive(false);
                    Singleton.Instance._player.GetComponent<Player_Stats_Handler>().RoomBUnlocked = true;
                    _doorScript.play_Unlock_Animation();
                    
                }
                else
                {
                    Debug.Log("Key Not Obtained");
                }
                break;
            case WhichDoor.C:
                PlayPrompt("Wrong Key");
                break;
        }
    }
    public void keyThree()
    {
        if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyC)
        {
            InventoryPanel.SetActive(false);
            Singleton.Instance._player.GetComponent<Player_Stats_Handler>().RoomCUnlocked = true;
            _doorScript.play_Unlock_Animation();
            
        }
        else
        {
            Debug.Log("Key Not Obtained");
        }
    }
    public void SetInteractionMenuClosed()
    {
           InteractionMenuOpened = false;
    }

    //play prompt

    private float promptTimer = 2f;
    private bool promptActive = false;
    public void PlayPrompt(string text)
    {
        promptText.text = text;
        prompt.SetActive(true);
        promptTimer = 2f;
        promptActive = true;
    }

    public void ReloadPrompt(string text)
    {
        promptText.text = text;
        prompt.SetActive(true);
        promptTimer = 1f;
        promptActive = true;
    }
    public void instantPrompt(string text)
    {
        promptText.text = text;
        prompt.SetActive(true);
        promptTimer = 0.1f;
        promptActive = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("House Outside", LoadSceneMode.Single);
    }

    
    private void Update()
    {
        audioSource.transform.position = Singleton.Instance._player.transform.position;
        if (promptActive)
        {
            promptTimer -= Time.deltaTime;
            if (promptTimer <= 0f)
            {
                prompt.SetActive(false);
                promptActive = false;
            }
        }
        SetStats();
        if (PickupMenuOpened && Input.GetKeyDown(KeyCode.Mouse0))
        {
            CloseMenu();
        }
        if (InteractionMenuOpened && Input.GetKeyDown(KeyCode.Mouse1))
        {
            CloseInteractionMenu();
        }
        //debug
        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            OpenMenu();
        }
        */
        if (PickupMenuOpened)
        {
            timer += Time.unscaledDeltaTime;
            if (timer > 0.25f)
            {
                timer = 0.25f;
            }
            pickupIcon.gameObject.transform.position = new Vector3(originalPos.x, (originalPos.y - 400f) + (1600f * timer), originalPos.z);
        }
    }
}


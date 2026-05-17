using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum WhichDoor
{
    A,
    B,
    C
}

public class InteractableUnlockedDoorScript : InteractableBase
{
    
    //[SerializeField] private GameObject key;
    public Animator _animator;

    public GameObject _key;
    public Transform CameraLocation;

    private float timer = 0;
    private bool playAnimation = false;
   
    [Space]
    [Header("Properties")]
    public WhichDoor _doortype;
    //private Transform temptransformCamera;
    private Vector3 tempPositionCamera;
    private Quaternion tempRotCamera;
    private void Start()
    {
        _key.SetActive(false);
        switch (_doortype)
        {
            case WhichDoor.A:
                if (GameInstanceHolder.instance.gameInstance.Room_A_Unlocked)
                {
                    interactionText.SetText("Enter");
                }
                else
                {
                    interactionText.SetText("Interact");
                }
                break;
            case WhichDoor.B:
                if (GameInstanceHolder.instance.gameInstance.Room_B_Unlocked)
                {
                    interactionText.SetText("Enter");
                }
                else
                {
                    interactionText.SetText("Interact");
                }
                break;
            case WhichDoor.C:
                if (GameInstanceHolder.instance.gameInstance.Room_C_Unlocked)
                {
                    interactionText.SetText("Enter");
                }
                else
                {
                    interactionText.SetText("Interact");
                }
                break;
        }
        //interactionText.SetText("Interact");
    }
    public override void interact()
    {

        switch (_doortype)
        {
            case WhichDoor.A:
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().RoomAUnlocked)
                {
                    Singleton.Instance._player.GetComponent<Player_Stats_Handler>().loadStats();
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Room A", LoadSceneMode.Single);
                    break;
                }
                else
                {
                    Debug.Log("Interacted with Door A");

                    tempPositionCamera = Singleton.Instance._mainCamera.transform.position;
                    tempRotCamera = Singleton.Instance._mainCamera.transform.rotation;
                    Singleton.Instance._mainCamera.GetComponent<MainCamera>().Health.SetActive(false);
                    Singleton.Instance._mainCamera.transform.position = CameraLocation.position;
                    Singleton.Instance._mainCamera.transform.rotation = CameraLocation.rotation;
                    Singleton.Instance._player.GetComponent<NewPlayer>().enabled = false;
                    Singleton.Instance._UI.GetComponent<UI>().doorType = WhichDoor.A;
                    Singleton.Instance._UI.GetComponent<UI>()._doorScript = this;
                    Singleton.Instance._UI.GetComponent<UI>().OpenInteractionMenu();
                    break;
                }
            case WhichDoor.B:
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().RoomBUnlocked)
                {
                    Singleton.Instance._player.GetComponent<Player_Stats_Handler>().loadStats();
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Room B", LoadSceneMode.Single);
                    break;
                }
                else
                {
                    Debug.Log("Interacted with Door B");
                    tempPositionCamera = Singleton.Instance._mainCamera.transform.position;
                    tempRotCamera = Singleton.Instance._mainCamera.transform.rotation;
                    Singleton.Instance._mainCamera.GetComponent<MainCamera>().Health.SetActive(false);
                    Singleton.Instance._mainCamera.transform.position = CameraLocation.position;
                    Singleton.Instance._mainCamera.transform.rotation = CameraLocation.rotation;
                    Singleton.Instance._player.GetComponent<NewPlayer>().enabled = false;
                    Singleton.Instance._UI.GetComponent<UI>().doorType = WhichDoor.B;
                    Singleton.Instance._UI.GetComponent<UI>()._doorScript = this;
                    Singleton.Instance._UI.GetComponent<UI>().OpenInteractionMenu();
                    break;
                }
            case WhichDoor.C:
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().RoomCUnlocked)
                {
                    Singleton.Instance._player.GetComponent<Player_Stats_Handler>().loadStats();
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Room C", LoadSceneMode.Single);
                    break;
                }
                else
                {
                    Debug.Log("Interacted with Door C");
                    tempPositionCamera = Singleton.Instance._mainCamera.transform.position;
                    tempRotCamera = Singleton.Instance._mainCamera.transform.rotation;
                    Singleton.Instance._mainCamera.GetComponent<MainCamera>().Health.SetActive(false);
                    Singleton.Instance._mainCamera.transform.position = CameraLocation.position;
                    Singleton.Instance._mainCamera.transform.rotation = CameraLocation.rotation;
                    Singleton.Instance._player.GetComponent<NewPlayer>().enabled = false;
                    Singleton.Instance._UI.GetComponent<UI>().doorType = WhichDoor.C;
                    Singleton.Instance._UI.GetComponent<UI>()._doorScript = this;
                    Singleton.Instance._UI.GetComponent<UI>().OpenInteractionMenu();
                    break;
                }

        }
        //play_Unlock_Animation();
    }
    public void CameraReturnLocation()
    {
        Singleton.Instance._mainCamera.transform.position = tempPositionCamera;
        Singleton.Instance._mainCamera.transform.rotation = tempRotCamera;
        Singleton.Instance._mainCamera.GetComponent<MainCamera>().Health.SetActive(true);
    }

    

    public void play_Unlock_Animation()
    {
        interactionText.SetText("Enter");
        _key.SetActive(true);
        _animator.SetTrigger("Unlock");
        playAnimation = true;
        Debug.Log("Door Unlocked");
        Singleton.Instance._UI.GetComponent<UI>().SetInteractionMenuClosed();
    }

    private void Update()
    {
        
        if (playAnimation)
        {
            
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                _key.SetActive(false);
                playAnimation = false;
                Singleton.Instance._UI.GetComponent<UI>().CloseInteractionMenu();
                timer = 0f;
            }
        }
    }
}





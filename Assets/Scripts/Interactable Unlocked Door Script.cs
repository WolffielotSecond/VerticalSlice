using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public MeshRenderer _key;
    public Transform CameraLocation;

    private float timer = 0;
    private bool playAnimation = false;
   
    [Space]
    [Header("Properties")]
    public WhichDoor _doortype;
    //private Transform temptransformCamera;
    private Vector3 tempPositionCamera;
    private Quaternion tempRotCamera;
    public override void interact()
    {
        switch (_doortype)
        {
            case WhichDoor.A:
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().RoomAUnlocked)
                {
                    break;
                }
                else
                {
                    Debug.Log("Interacted with Door A");

                    tempPositionCamera = Singleton.Instance._mainCamera.transform.position;
                    tempRotCamera = Singleton.Instance._mainCamera.transform.rotation;
                    Singleton.Instance._mainCamera.transform.position = CameraLocation.position;
                    Singleton.Instance._mainCamera.transform.rotation = CameraLocation.rotation;
                    Singleton.Instance._player.GetComponent<NewPlayer>().enabled = false;
                    Singleton.Instance._UI.GetComponent<UI>().OpenInteractionMenu();
                    Singleton.Instance._UI.GetComponent<UI>().doorType = WhichDoor.A;
                    Singleton.Instance._UI.GetComponent<UI>()._doorScript = this;
                    break;
                }
            case WhichDoor.B:
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().RoomBUnlocked)
                {
                    Debug.Log("Entered Room B");
                    break;
                }
                else
                {
                    Debug.Log("Interacted with Door B");
                    tempPositionCamera = Singleton.Instance._mainCamera.transform.position;
                    tempRotCamera = Singleton.Instance._mainCamera.transform.rotation;
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
                    
                    break;
                }
                else
                {
                    Debug.Log("Interacted with Door C");
                    tempPositionCamera = Singleton.Instance._mainCamera.transform.position;
                    tempRotCamera = Singleton.Instance._mainCamera.transform.rotation;
                    Singleton.Instance._mainCamera.transform.position = CameraLocation.position;
                    Singleton.Instance._mainCamera.transform.rotation = CameraLocation.rotation;
                    Singleton.Instance._player.GetComponent<NewPlayer>().enabled = false;
                    Singleton.Instance._UI.GetComponent<UI>().OpenInteractionMenu();
                    Singleton.Instance._UI.GetComponent<UI>().doorType = WhichDoor.C;
                    Singleton.Instance._UI.GetComponent<UI>()._doorScript = this;
                    break;
                }

        }
        //play_Unlock_Animation();
    }
    public void CameraReturnLocation()
    {
        Singleton.Instance._mainCamera.transform.position = tempPositionCamera;
        Singleton.Instance._mainCamera.transform.rotation = tempRotCamera;
    }

    public void Start()
    {
        _key.enabled = false;
    }

    public void play_Unlock_Animation()
    {
        _key.enabled = true;
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
                _key.enabled = false;
                playAnimation = false;
                Singleton.Instance._UI.GetComponent<UI>().CloseInteractionMenu();
                timer = 0f;
            }
        }
    }
}





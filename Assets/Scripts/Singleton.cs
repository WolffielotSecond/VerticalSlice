using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
    [Header("通用")]
    public GameObject _player;
    public GameObject _mainCamera;
    public Transform _DefaultCameraLocation;
    [Space]
    [Header("枢纽")]
    public Transform _CenturalRoomExit;
    public Transform _RoomA;
    public Transform _RoomB;
    public Transform _RoomC;
    public Transform _CenturalRoomExit_Cam_Location;
    public Transform _RoomA_Cam_Location;
    public Transform _RoomB_Cam_Location;
    public Transform _RoomC_Cam_Location;
    public bool isCenturalRoom = false;
    private void Start()
    {
        // 如果是枢纽房间，尝试根据 GameInstance 的当前出口位置设置摄像机
        if (isCenturalRoom)
        {
            // 先做空检查，避免 NullReferenceException
            if (GameInstanceHolder.instance != null && GameInstanceHolder.instance.gameInstance != null)
            {
                switch (GameInstanceHolder.instance.gameInstance.CurrentExitRoom)
                {
                    case ExitRoom.Room_A:
                        _mainCamera.transform.position = _RoomA_Cam_Location.position;
                        _mainCamera.transform.rotation = _RoomA_Cam_Location.rotation;
                        _player.transform.position = _RoomA.position;
                        _player.transform.rotation = _RoomA.rotation;
                        break;

                    case ExitRoom.Room_B:
                        _mainCamera.transform.position = _RoomB_Cam_Location.position;
                        _mainCamera.transform.rotation = _RoomB_Cam_Location.rotation;
                        _player.transform.position = _RoomB.position;
                        _player.transform.rotation = _RoomB.rotation;
                        break;

                    case ExitRoom.Room_C:
                        _mainCamera.transform.position = _RoomC_Cam_Location.position;
                        _mainCamera.transform.rotation = _RoomC_Cam_Location.rotation;
                        _player.transform.position = _RoomC.position;
                        _player.transform.rotation = _RoomC.rotation;
                        break;

                    case ExitRoom.Outside:
                    default:
                        _mainCamera.transform.position = _CenturalRoomExit_Cam_Location.position;
                        _mainCamera.transform.rotation = _CenturalRoomExit_Cam_Location.rotation;
                        _player.transform.position = _CenturalRoomExit.position;
                        _player.transform.rotation = _CenturalRoomExit.rotation;
                        break;
                }
            }
            else
            {
                // 回退到默认位置以保证安全
                if (_DefaultCameraLocation != null)
                {
                    _mainCamera.transform.position = _DefaultCameraLocation.position;
                    _mainCamera.transform.rotation = _DefaultCameraLocation.rotation;
                }
            }
        }
        else
        {
            if (_DefaultCameraLocation != null)
            {
                _mainCamera.transform.position = _DefaultCameraLocation.position;
                _mainCamera.transform.rotation = _DefaultCameraLocation.rotation;
            }
        }

    }

}

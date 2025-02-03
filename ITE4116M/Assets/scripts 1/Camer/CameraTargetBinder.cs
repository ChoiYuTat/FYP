using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTargetBinder : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private string playerTag = "Player";

    private void Start()
    {
        
    }

    public void BindCameraToPlayer(GameObject PlayerPrefab)
    {
        GameObject player = PlayerPrefab;
        if (player != null && virtualCamera != null)
        {
            virtualCamera.Follow = player.transform;
            virtualCamera.LookAt = player.transform;
        }
    }
}

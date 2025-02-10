using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CameraTargetBinder cameraBinder;

    public void SpawnPlayer(Vector3 position)
    {
        GameObject player = Instantiate(playerPrefab, position, Quaternion.identity);
        cameraBinder.BindCameraToPlayer(player);
    }
}

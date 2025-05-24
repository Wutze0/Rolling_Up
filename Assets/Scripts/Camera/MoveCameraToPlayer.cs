using UnityEngine;

public class MoveCameraToPlayer : MonoBehaviour
{

    public GameObject _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _playerPos = _player.transform.position;
        _playerPos.z = -10;


        transform.position = _playerPos;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollowing : MonoBehaviour
{

    [SerializeField]
    private Transform _player;
    [SerializeField]
    private float _cameraSpeed = 1f;
    [SerializeField]
    private float _offsetY = 100f;
    [SerializeField]
    private float _maxDistanceDelta = 20f;

    private Transform _camera;
    private Vector3 nextStep;


    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Transform>();
    }
    private void Update()
    {

        nextStep = Vector3.Lerp(_camera.position, _player.position, _cameraSpeed);
        nextStep.y = _player.position.y + _offsetY;
        _camera.position = Vector3.MoveTowards(_camera.position, nextStep, _cameraSpeed * Time.deltaTime);
    }
}

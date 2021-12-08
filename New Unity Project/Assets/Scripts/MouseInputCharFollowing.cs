using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputCharFollowing : MonoBehaviour
{
    [SerializeField]
    private Transform _playerPosition;
    
    private void FixedUpdate()
    {
        this.transform.position = _playerPosition.position;
    }

}

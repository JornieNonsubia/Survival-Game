using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharController : MonoBehaviour
{

    [SerializeField]
    [InspectorName("Speed")]
    private float _speed = 10f;

    private LayerMask _mask;
    private Vector3 _cursorPosition;
    private Rigidbody _RB;
    private Vector3 _movement;

    // Start is called before the first frame update
    void Start()
    {
        _mask = 1 << LayerMask.NameToLayer("MousePosition");
        
        _RB = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        _cursorPosition = Input.mousePosition;

        _movement = new Vector3 (Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        //Player movement
        _RB.velocity = _movement * _speed *Time.fixedDeltaTime;

        //Player rotation to the cursor
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(_cursorPosition), out hit, 100,_mask.value))
        {
            Vector3 direction = hit.point - _RB.position;
            _RB.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movementScript : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Vector3 movement;
    private Vector3 tempMove;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        playerControl();
    }

    private void FixedUpdate()
    {
        Vector3 direction = movement.normalized;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
    private void playerControl()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            movement.x = moveHorizontal;
            movement.z = moveVertical;
        }
    }
}

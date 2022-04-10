using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
  [SerializeField] private float speed = 1.0f;
  private CharacterController _charController;
  [SerializeField] private float gravity = -9.8f;

  private void Start()
  {
    _charController = GetComponent<CharacterController>();
  }
  private void Update()
  {
    float deltaX = Input.GetAxis("Horizontal") * speed;
    float deltaZ = Input.GetAxis("Vertical") * speed;
    Vector3 movement = new Vector3(deltaX, 0, deltaZ);
    movement = Vector3.ClampMagnitude(movement, speed);
    movement.y = gravity;
    movement *= Time.deltaTime;
    movement = transform.TransformDirection(movement);
    _charController.Move(movement);


  }
}

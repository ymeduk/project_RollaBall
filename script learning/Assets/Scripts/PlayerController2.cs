using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class PlayerController2 : MonoBehaviour
{
   InputActions controls;
   Vector2 move;
   public float speed = 10;
 
   void Awake()
   {
       controls = new InputActions();
       controls.Player.Move.performed += ctx => 
                                      SendMessage(ctx.ReadValue<Vector2>());
       controls.Player.Move.performed += ctx => move = 
                                      ctx.ReadValue<Vector2>();
       controls.Player.Move.canceled += ctx => move = Vector2.zero;
   }
 
   private void OnEnable()
   {
       controls.Player.Enable();
   }
   private void OnDisable()
   {
       controls.Player.Disable();
   }
 
   void SendMessage(Vector2 coordinates)
   {
       Debug.Log("Thumb-stick coordinates = " + coordinates);
   }
 
   void FixedUpdate()
   {
       Vector3 movement = new Vector3(move.x, 0.0f, move.y) * speed 
                                                            * Time.deltaTime;
       transform.Translate(movement, Space.World);
   }
}
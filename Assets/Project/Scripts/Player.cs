using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float jumpDistance = 0.32f; // to be tested
   private bool jumped;
   private Vector3 startingPosition;

   // Start is called before the first frame update
   void Start()
   {
      /*Debug.Log(Screen.width);
       Debug.Log(Screen.height);*/

      startingPosition = transform.position;
   }

   // Update is called once per frame
   void Update()
   {
      // movement logic
      float horizontalMovement = Input.GetAxis("Horizontal");
      float verticalMovement = Input.GetAxis("Vertical");

      /*Debug.Log(horizontalMovement + " " + verticalMovement);*/

      if (!jumped)
      {
         // frog didn't move
         if (horizontalMovement != 0)
         {
            transform.position = new Vector2(
               transform.position.x + (horizontalMovement > 0 ? jumpDistance : -jumpDistance),
               transform.position.y);

            jumped = true;
         }
         /*else if would not allow diagonal movement*/
         if (verticalMovement != 0)
         {
            transform.position = new Vector2(
              transform.position.x ,
              transform.position.y + (verticalMovement > 0 ? jumpDistance : -jumpDistance));

            jumped = true;
         }
      }
      else
      {
         // frog moved
         if(horizontalMovement == 0 && verticalMovement == 0)
         {
            jumped = false;
         }
      }

      // keep the frog inside bounds
      if (transform.position.y < (-Screen.height / 100f) / 2f)
      {
         /*Debug.Log(((-Screen.height / 100) / 2).ToString());*/
         transform.position = new Vector3(
            transform.position.x,
            transform.position.y + jumpDistance
            );
      }

      if (transform.position.y > (-Screen.height / 100f) / 2f)
      {
         /*Debug.Log(((-Screen.height / 100) / 2).ToString());*/
         transform.position = startingPosition;
      }

      if (transform.position.y < (-Screen.width / 100f) / 2f)
      {
         transform.position = new Vector3(
            transform.position.x ,
            transform.position.y - jumpDistance
            );
      }

      if (transform.position.x < (Screen.width / 100f) / 2f)
      {
         transform.position = new Vector3(
            transform.position.x+ jumpDistance,
            transform.position.y
            );
      }

      if (transform.position.x < (Screen.width / 100f) / 2f)
      {
         transform.position = new Vector3(
            transform.position.x- jumpDistance,
            transform.position.y
            );
      }
   }
}

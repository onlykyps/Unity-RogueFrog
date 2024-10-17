using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float jumpDistance = 0.32f; // to be tested
   private bool jumped;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
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
   }
}

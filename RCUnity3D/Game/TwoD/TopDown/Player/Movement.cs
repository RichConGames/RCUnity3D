using UnityEngine;

// Copyright © Connor Richards & RichCon Games 2018. All rights reserved.

namespace RCUnity3D.Game.TwoD.TopDown.Player // Unity3D class library for player interaction and control in a top-down/isometric 2D context.
{
    public class Movement // An 'RC' setup for basic top-down 2d movement.
    {
        public class MovementComponent // A movement component used to deliver physics based movement in a top-down, 2D context.
        {
            #region Movement Component Attributes

            // Stores the player's movement speed.
            public float MovementSpeed { get; set; }

            // References the RigidBody2D component for 2D physics & collision.
            public Rigidbody2D RigidBody2D { get; set; }

            // Movement Parameters
            public float MoveHorizontal{ get; set; }
            public float MoveVertical { get; set; }
            Vector2 Direction { get; set; }

            #endregion

            #region Movement Component Constructors

            // Constructs a new movement component with optional defaults.
            public MovementComponent(ref Rigidbody2D rigidBody2D, float movementSpeed = 5f)
            {
                RigidBody2D = rigidBody2D;
                MovementSpeed = movementSpeed;
            }

            #endregion

            #region Top-Down Movement Methods

            // Updates the movement component based on "horizontal" and "vertical" inputs per tick.
            public void UpdateMovement()
            {
                // Set both input axis to 2 float values.
                MoveHorizontal = Input.GetAxis("Horizontal");
                MoveVertical = Input.GetAxis("Vertical");

                // Create new 2D movement vector from move inputs.
                Direction.Set(MoveHorizontal,MoveVertical);

                // Move the player by applying force multiplied by the movement speed. Also validates.
                if (RigidBody2D != null)
                {
                    RigidBody2D.AddForce(Direction * MovementSpeed);
                }
            }

            #endregion
        }
    }
}

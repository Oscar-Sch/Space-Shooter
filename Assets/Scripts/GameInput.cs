using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter
{
    public class GameInput : MonoBehaviour {
        private PlayerInputActions playerInputActions;

        private void Awake ( ) {
            playerInputActions = new PlayerInputActions();

            playerInputActions.Player.Enable();
        }

        public Vector2 GetMovementVectorNormalized ( ) {
            Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
            return inputVector.normalized;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class NewBehaviourScript : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameInput gameInput;
        [SerializeField] private CameraController cameraController;

        [Header("Properties")]
        [SerializeField] private float speed;

        #region Variable declaration

        private float moveDistance;
        private Vector2 inputVector;
        private Vector3 moveDirection;

        #endregion



        private void Update ( ) {
            HandleMovement();
        }

        private void HandleMovement ( ) {
            moveDistance = speed * Time.deltaTime;
            inputVector = gameInput.GetMovementVectorNormalized();
            moveDirection = new Vector3( inputVector.x, inputVector.y, transform.position.z );
            if (inputVector.y >= 0) {
                transform.position += transform.up * cameraController.GetCameraSpeed() * Time.deltaTime;
            }
            
            transform.position += moveDirection * moveDistance;
        }
    }
}

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
        [SerializeField] private float lerpSmoothness = 1f;
        [SerializeField] private float maxDisplacementX;
        [SerializeField] private float minDisplacementX;
        [SerializeField] private float maxDisplacementY;
        [SerializeField] private float minDisplacementY;

        #region Variable declaration

        private float moveDistance;
        private Vector2 inputVector;
        private Vector3 targetPosition;
        private Vector3 currentVelocity;
        private float maxPlayerPosX;
        private float minPlayerPosX;
        private float maxPlayerPosY;
        private float minPlayerPosY;

        #endregion



        private void Update ( ) {
            HandleMovement();
        }

        private void HandleMovement ( ) {
            moveDistance = speed * Time.deltaTime;
            inputVector = gameInput.GetMovementVectorNormalized();
            targetPosition = new Vector3( inputVector.x, inputVector.y, transform.position.z ) * moveDistance;
            
            

            maxPlayerPosX = cameraController.transform.position.x + maxDisplacementX;
            minPlayerPosX = cameraController.transform.position.x + minDisplacementX;
            maxPlayerPosY = cameraController.transform.position.y + maxDisplacementY;
            minPlayerPosY = cameraController.transform.position.y + minDisplacementY;

            //targetPosition.x = Math.Clamp(targetPosition.x, minPlayerPosX, maxPlayerPosX);
            //targetPosition.y = Math.Clamp(targetPosition.y, minPlayerPosY, maxPlayerPosY);

            var mockupPosition = transform.position + targetPosition;
            //if (mockupPosition.x > maxPlayerPosX) {
            //    mockupPosition.x=transform.position.x;
            //}
            //if (mockupPosition.x < minPlayerPosX) {
            //    mockupPosition.x = transform.position.x;
            //}
            //if (mockupPosition.y > maxPlayerPosY) {
            //    mockupPosition.y = transform.position.y;
            //}
            //if (mockupPosition.y < minPlayerPosY) {
            //    mockupPosition.y = transform.position.y;
            //}
                if (inputVector.y >= 0) {
                mockupPosition += transform.up * cameraController.GetCameraSpeed() * Time.deltaTime;
            }
            mockupPosition.x = Math.Clamp(mockupPosition.x, minPlayerPosX, maxPlayerPosX);
            mockupPosition.y = Math.Clamp(mockupPosition.y, minPlayerPosY, maxPlayerPosY);
            //transform.position = Vector3.SmoothDamp(transform.position,mockupPosition,ref currentVelocity, lerpSmoothness);
            transform.position = mockupPosition;
            //transform.position = Vector3.Lerp(transform.position, mockupPosition, lerpSmoothness);

        }

    }
}

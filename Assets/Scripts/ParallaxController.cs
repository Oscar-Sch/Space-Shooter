using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceShooter
{
    public class ParallaxController : MonoBehaviour
    {
        [Header("Background Elements")]
        [Tooltip("This array contains all the elements on the background that will be affected by the parallax effect")]
        [SerializeField] private Transform[] backgroundsArray;

        [Header("Parallax Properties")]
        [Tooltip("The overall speed of the scrolling")]
        [SerializeField] private float smoothValue;

        [Tooltip("How much the speed will be incremented per layer")]
        [SerializeField] private float multiplierValue;

        private Transform cam;
        private Vector3 previousCamPos;

        private void Awake ( ) {
            cam = Camera.main.transform;
        }
        private void Start () {
            previousCamPos = cam.position;
        }

        private void Update ( ) {

            HandleParallax();
            previousCamPos = cam.position;
        }

        private void HandleParallax ( ) {
            for ( int i = 0; i < backgroundsArray.Length; i++ ) {
                Vector3 actualPosition = backgroundsArray [i].position;
                float parallax = (previousCamPos.y - cam.position.y) * (i* multiplierValue);
                float targetY = backgroundsArray [i].position.y + parallax;

                Vector3 targetPosition = new Vector3(actualPosition.x , targetY , actualPosition.z);

                actualPosition = Vector3.Lerp(actualPosition , targetPosition , smoothValue * Time.deltaTime);
            }
        }
    }
}

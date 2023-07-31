using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class CameraController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform player;

        [Header("Properties")]
        [SerializeField] private float speed;

        private void Start ( ) {
            transform.position = new Vector3 (player.position.x,player.position.y,transform.position.z );
        }
        private void LateUpdate ( ) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
    }
}

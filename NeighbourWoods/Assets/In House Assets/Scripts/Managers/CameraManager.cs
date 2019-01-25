using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Manager.Player
{
    public class CameraManager : MonoBehaviour
    {
        public PlayerManager PM;
        [Tooltip("The variable that references the PlayerCamera script on the ColourBlind camera object")]
        public GameObject playerCamera;
        [Tooltip("The sensitivity of the Mouse for the camera movements")]
        public float mouseSensitivity = 10;
        private Vector3 currentRotation;
        private Vector3 rotationSmoothVelocity;
        [Tooltip("")]
        public Vector2 pitchMinMax = new Vector2(-40, 85);
        [Tooltip("")]
        public float cameraRotation;
        [Tooltip("")]
        public Transform target;
        private float yaw = 0;
        private float pitch = 0;
        public float dstFromTarget = 2;
        void Start() // Use this for initialization
        {
            playerCamera = GameObject.FindWithTag("MainCamera");
        }
        void Update() // Update is called once per frame
        {
            switch (GameManager.instance.gameState)
            {
                case GameState.FREE_ROAM: // if the GameState enum is in FreeRoam then all of the movement and button controls updates
                    CameraController();
                    break;
                case GameState.DIALOGUE: // if the GameState enum is in Dialogue then the DialogueController() updates 
                    break;
                case GameState.TITLE_SCREEN:
                    break;
                case GameState.PAUSE_SCREEN:
                    break;
                case GameState.CREDIT_SCREEN:
                    break;
                default:
                    break;
            }
        }
        #region CameraController()
        void CameraController() // Controls the third person camera
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);
            Vector3 targetRotation = new Vector3(pitch, yaw);
            float rotationSmoothTime = 0.12f;
            currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            playerCamera.transform.eulerAngles = targetRotation;
            transform.position = target.position - transform.forward * dstFromTarget;
        }
        #endregion
    }
}

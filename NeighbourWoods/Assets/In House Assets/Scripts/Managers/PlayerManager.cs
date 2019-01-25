using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.Animations;
using Manager.UI;
using Manager.Inventory;
using TMPro;
using DG.Tweening;
using Manager.Level;
using Manager.Audio;
namespace Manager.Player
{
    #region Vision Enum
    public enum Vision //The Enum that controls which vision state you are in  
    {
        NORMAL,
        SMELL,
    }
    #endregion
    #region PlayerManager Class
    public class PlayerManager : Singleton<PlayerManager> // An script that will not be destroyed when going new levels (if we need to load new levels)
    {
        #region Variables
        // Enums
        [Tooltip("The public Vision enum variable on the player object")]
        public Vision vision;
        #region Object Variables
        // All of the Variables that link to objects or components
        [Header("Object Variables")]
        [Tooltip("The GameObject variable that is the player object in the scene")]
        public GameObject player;
        public AudioSource dogAudioSource;
        [Tooltip("The variable that references the UIManager script on the canvas")]
        public UIManager gameManagerUI;
        [Tooltip("The variable that references the AudioManager Script on the GameManager object")]
        public AudioManager audioManager;
        [Tooltip("The variable that references the LevelManager Script on the GameManager object")]
        public LevelManager levelManager;
        [Tooltip("The variable that references the GameManager Script on the GameManager object")]
        public GameManager gameManager;
        [Tooltip("The PostProcessing Profile of smellOVision variable")]
        public PostProcessingBehaviour smellOVision;
        [Tooltip("The variable that references the Character Controller component on the player object")]
        public CharacterController characterController;
        [Tooltip("The array variable that holds smellObject")]
        public GameObject[] smellObjects = new GameObject[0];
        // All of the Variables for audio stuff
        [Header("Audio Variables")]
        public AudioClip Bark1;
        public AudioClip Bark2;
        public AudioClip Bark3;
        public AudioClip Digging;
        #endregion
        #region Control Variables
        //All of the controls variables used in the movement functions
        [Header("Control Variables")]
        [Tooltip("The speed of the walk of the character")]
        public float walkSpeed = 2;
        [Tooltip("The spped of the run of the character")]
        public float runSpeed = 6;
        [Tooltip("The gravity of the character when in air")]
        public float gravity = -12;
        [Tooltip("The jump height of the character")]
        public float jumpHeight = 1;
        [Tooltip("The percent of the player control in the air")]
        [Range(0, 1)]
        public float airControlPercent;
        private float velocityY;
        [Tooltip("")]
        public float turnSmoothTime = 0.2f;
        [Tooltip("")]
        public float speedSmoothTime = 0.1f;
        private float turnSmoothVelocity;
        private float speedSmoothVelocity;
        public float currentSpeed;
        public bool isStill;
        [Tooltip("")]
        public bool lockCursor;
        [Tooltip("The variable that references the transform of the playerCamera")]
        public Transform playerCameraTransform;
        private Vector3 currentRotation;
        private Vector3 rotationSmoothVelocity;
        [Tooltip("The variable that references animator on the player object")]
        public Animator playerAnimator;
        #endregion
        #region Vision Variables
        [Header("Vision Variables")]
        [Tooltip("The max intensity of the Vign")]
        [SerializeField]
        public float maxVignIntensity = 0.3f;
        [Tooltip("The duration of the animation")]
        [SerializeField]
        public float vignDuration = 0.5f;
        [Tooltip("Used for the intensity for the vignTween")]
        private float vignIntensity = 0;
        [Tooltip("Used for the vignmethods")]
        private Tween vignTween;
        public float focusMaxDis = 60;
        public float focusDuration = 1;
        private Tween focusTween;
        #endregion
        #endregion
        #region Start and Update Methods
        void Start() // Use this for initialization
        {
            player = GameObject.FindWithTag("Player");
            playerCameraTransform = Camera.main.transform;
            smellOVision = GetComponentInChildren<PostProcessingBehaviour>();
            vision = Vision.NORMAL;
            characterController = GetComponent<CharacterController>();
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        public void Update() // Update is called once per frame
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 inputDir = input.normalized;
            bool running = Input.GetButton("Sprint"); // Sprinting in Game
            if (running == true)
            {
                playerAnimator.SetBool("IsRunning", true);
                playerAnimator.SetBool("IsWalking", false);
            }
            else if (running == false && isStill == false)
            {
                playerAnimator.SetBool("IsRunning", false);
                playerAnimator.SetBool("IsWalking", true);
            }
            else if (running == false && isStill == true)
            {
                playerAnimator.SetBool("IsRunning", false);
                playerAnimator.SetBool("IsWalking", false);
            }
            else if (running == true && isStill == true)
            {
                playerAnimator.SetBool("IsRunning", false);
                playerAnimator.SetBool("IsWalking", false);
            }
            else
            {
                playerAnimator.SetBool("IsRunning", false);
                playerAnimator.SetBool("IsWalking", false);
            }
            switch (GameManager.instance.gameState)
            {
                case GameState.FREE_ROAM: // if the GameState enum is in FreeRoam then all of the movement and button controls updates
                    MovementController(inputDir, running);
                    InventoryController();
                    VisionController();
                    BarkController();
                    DigController();
                    JumpController();
                    DebugController();
                    MenuController();
                    break;
                case GameState.DIALOGUE: // if the GameState enum is in Dialogue then the DialogueController() updates 
                    InventoryController();
                    isStill = true;
                    break;
                case GameState.TITLE_SCREEN:
                    isStill = true;
                    break;
                case GameState.PAUSE_SCREEN:
                    isStill = true;
                    break;
                case GameState.CREDIT_SCREEN:
                    isStill = true;
                    break;
                default: break;
            }
        }
        #endregion
        #region Control Methods
        #region MovementController()
        void MovementController(Vector2 inputDir, bool running) // The Function that moves the Player 
        {
            if (inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + playerCameraTransform.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
            }
            float targetSpeed = (running ? runSpeed : walkSpeed) * inputDir.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));
            if (currentSpeed == 0 || currentSpeed <= 1)
            {
                isStill = true;
            }
            else
            {
                isStill = false;
            }
            velocityY += Time.deltaTime * gravity;
            Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
            characterController.Move(velocity * Time.deltaTime);
            if (characterController.isGrounded)
            {
                velocityY = 0;
            }
            #region Animator?
            // Animator?
            //float animationSpeedPercent = ((running) ? currentSpeed/runSpeed : currentSpeed/walkSpeed* .5f);
            //animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
            //currentSpeed = new Vector2(characterController.velocity.x, characterContoller.velocity.z).magnitude;
            #endregion
        }
        float GetModifiedSmoothTime(float smoothTime) // The Function that allows me to control the amount of movement that the player has when in the air
        {
            if (characterController.isGrounded)
            {
                return smoothTime;
            }
            if (airControlPercent == 0)
            {
                return float.MaxValue;
            }
            return smoothTime / airControlPercent;
        }
        #endregion
        #region VisionController() and Associated Methods()
        void VisionController() // The Function that switches the Vision enum event to smell or normal so that the colour blind camera comes on and the smell objects are turn on or off
        {
            if (Input.GetButtonDown("Smell-O-Vision"))
            {
                if (vision == Vision.NORMAL)
                {
                    vision = Vision.SMELL;
                }
                else
                {
                    vision = Vision.NORMAL;
                }
                GameEvents.ReportVisionChange(vision);
            }
        }
        public void AnimateVignette(bool value) // Calucating the animation for the vignette for Smell-O-Vision
        {
            vignTween = DOTween.To(() => vignIntensity, x => vignIntensity = x, value ? maxVignIntensity : 0, vignDuration).OnUpdate(UpdateVignetteAnimation);
            vignTween.OnComplete(OnVignetteAnimationEnd);
        }
        void UpdateVignetteAnimation() // Updating the animation for the vignette
        {
            VignetteModel.Settings vign = smellOVision.profile.vignette.settings;
            vign.intensity = vignIntensity;
            smellOVision.profile.vignette.settings = vign;
        }
        void OnVignetteAnimationEnd() // At the end of the animation
        {
            vignTween = null;
        }
        #endregion
        #region JumpController()
        void JumpController() // Controls the jump functions 
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (characterController.isGrounded)
                {
                    float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
                    velocityY = jumpVelocity;
                }
            }
        }
        #endregion
        #region DigController()
        void DigController()
        {
            if (Input.GetButtonDown("Dig"))
            {
                dogAudioSource.clip = Digging;
                dogAudioSource.Play();
                playerAnimator.SetBool("IsDigging", true);
            }
            if (Input.GetButtonUp("Dig"))
            {
                playerAnimator.SetBool("IsDigging", false);
            }
        }
        #endregion
        #region BarkController()
        void BarkController()
        {
            if (Input.GetButtonDown("Bark"))
            {
                int number = Random.Range(1, 4);
                if (number == 1)
                {
                    dogAudioSource.clip = Bark1;
                    dogAudioSource.Play();
                    //audioManager.FindsSoundSource(dogAudioSource);
                    //audioManager.PlayAudio("Bark 1");
                }
                if (number == 2)
                {
                    dogAudioSource.clip = Bark2;
                    dogAudioSource.Play();
                    //audioManager.FindsSoundSource(dogAudioSource);
                    //audioManager.PlayAudio("Bark 2");
                }
                if (number == 3)
                {
                    dogAudioSource.clip = Bark3;
                    dogAudioSource.Play();
                    //audioManager.FindsSoundSource(dogAudioSource);
                    //audioManager.PlayAudio("Bark 3");
                }
                //Debug.Log("Bark");
                playerAnimator.SetBool("IsBarking", true);
            }
            if (Input.GetButtonUp("Bark"))
            {
                playerAnimator.SetBool("IsBarking", false);
            }
        }
        #endregion
        #region InventoryController()
        void InventoryController() // Contols the inventory functions 
        {
            if (Input.GetButtonDown("Inventory"))
            {
                Debug.Log("Working");
                InventoryManager.instance.inventoryShowing = !InventoryManager.instance.inventoryShowing;
                GameEvents.ReportOnInventoryChange(InventoryManager.instance.inventoryShowing);
            }
        }
        #endregion
        #region MapController()
        void MapController()
        {
            if (Input.GetButtonDown("Map"))
            {
                Debug.Log("Map");
                //testTMP.text = ("Map to be coded");
            }
        }
        #endregion
        #region DebugController()
        public void DebugController()
        {
            if (gameManager.Debug)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    levelManager.UpdateTimeToMorningDay1();
                    StartCoroutine(levelManager.TeleportPlayer());
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    levelManager.UpdateTimeToMiddayDay1();
                    StartCoroutine(levelManager.TeleportPlayer());
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    levelManager.UpdateTimeToAfternoonDay1();
                    StartCoroutine(levelManager.TeleportPlayer());
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    levelManager.UpdateTimeToEveningDay1();
                    StartCoroutine(levelManager.TeleportPlayer());
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    levelManager.UpdateTimeToMorningDay2();
                    StartCoroutine(levelManager.TeleportPlayer());
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    levelManager.UpdateTimeToMiddayDay2();
                    StartCoroutine(levelManager.TeleportPlayer());
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    levelManager.UpdateTimeToAfternoonDay2();
                    StartCoroutine(levelManager.TeleportPlayer());
                }
                if (Input.GetKeyDown(KeyCode.Alpha8))
                {
                    levelManager.UpdateTimeToEveningDay2();
                    StartCoroutine(levelManager.TeleportPlayer());
                }
            }
        }
        #endregion
        #region MenuController
        public void MenuController()
        {
            if (Input.GetButtonDown("Escape"))
            {
                gameManagerUI.GoToMenu();
            }
        }
        #endregion
        #endregion
        #region Vision Event Methods
        void OnEnable() //Subscribes to our game events
        {
            GameEvents.OnVisionChange += OnVisionChange;
        }
        void OnDisable() //Unsubscribes to our game events
        {
            GameEvents.OnVisionChange -= OnVisionChange;
        }
        void OnVisionChange(Vision vision) // OnVisionChange function that run if statements if the vision state is in normal or smell
        {
            //Debug.Log("vision mode");
            if (vision == Vision.NORMAL)
            {
                Camera.main.GetComponent<GenericImageEffect>().enabled = false;
                //DOTween.To(() => smellOVision.profile.vignette.settings.color, x => smellOVision.profile.vignette.settings.color = x, 5, 1);
                AnimateVignette(false);
                foreach (GameObject smellObject in smellObjects)
                {
                    smellObject.SetActive(false);
                }
            }
            else
            {
                Camera.main.GetComponent<GenericImageEffect>().enabled = true;
                AnimateVignette(true);
                foreach (GameObject smellObject in smellObjects)
                {
                    smellObject.SetActive(true);
                }
            }
        }
        #endregion
        #region Menu Animation Methods
        public void AnimateFocus(bool value) // Calucating the animation for the vignette for Smell-O-Vision
        {
            focusTween = DOTween.To(() => focusMaxDis, x => focusMaxDis = x, value ? 60 : 0, focusDuration).OnUpdate(UpdateFocusAnimation);
            focusTween.OnComplete(OnFocusAnimationEnd);
        }
        void UpdateFocusAnimation() // Updating the animation for the vignette
        {
            DepthOfFieldModel.Settings focus = smellOVision.profile.depthOfField.settings;
            focus.focalLength = focusMaxDis;
            smellOVision.profile.depthOfField.settings = focus;
        }
        void OnFocusAnimationEnd() // At the end of the animation
        {
             focusTween = null;
        }
        #endregion
    }
    #endregion
}
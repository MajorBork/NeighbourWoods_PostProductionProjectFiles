using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using Manager.Level;
using Manager.Audio;
namespace Manager.Environment
{
    public class EnvironmentManager : Singleton<EnvironmentManager>
    {
        #region Variables
        [Header("Script Object References")]
        public Day day;
        public TimeSlot timeSlot;
        public Level.LevelManager levelManager;
        public AudioManager audioManager;
        public GameManager gameManager;
        public AudioSource managerAudioSource;
        [Header("Day Light Colour Setting")]
        public Light sceneLight;
        public Color morningLightColour;
        public Color middayLightColour;
        public Color afternoonLightColour;
        public Color eveningLightColour;
        [Header("TimeSlot Sky box Setting")]
        public Material morningSkyBox;
        public Material middaySkyBox;
        public Material afternoonSkyBox;
        public Material eveningSkyBox;
        [Header("Audio")]
        public AudioClip menuMusic;
        public AudioClip musicDay;
        public AudioClip musicNight;
        public AudioClip lastMusicPlaying;
        #endregion
        void Start()// Use this for initialization
        {

        }
        void Update()// Update is called once per frame
        {
            
        }
        #region OnTimeChange Event Listerers To be used later?
        void OnEnable()
        {
            GameEvents.OnTimeChange += OnTimeChange;
            GameEvents.OnGameStateChange += OnGameStateChange;
        }
        void OnDisable()
        {
            GameEvents.OnTimeChange -= OnTimeChange;
            GameEvents.OnGameStateChange -= OnGameStateChange;
        }
        void OnGameStateChange(GameState gameState)
        {
            switch (gameManager.gameState)
            {
                case GameState.FREE_ROAM:
                    if (managerAudioSource.clip = lastMusicPlaying)
                    {
                        managerAudioSource.Play();
                    }
                    if (managerAudioSource.clip = menuMusic)
                    {
                        if (levelManager.timeSlot == TimeSlot.MORNING)
                        {
                            managerAudioSource.clip = musicDay;
                            managerAudioSource.Play();
                        }
                        if (levelManager.timeSlot == TimeSlot.MIDDAY)
                        {
                            managerAudioSource.clip = musicDay;
                            managerAudioSource.Play();
                        }
                        if (levelManager.timeSlot == TimeSlot.AFTERNOON)
                        {
                            managerAudioSource.clip = musicNight;
                            managerAudioSource.Play();
                        }
                        if (levelManager.timeSlot == TimeSlot.EVENING)
                        {
                            managerAudioSource.clip = musicNight;
                            managerAudioSource.Play();
                        }
                    }
                    //audioManager.FindsSoundSource(managerAudioSource);
                    //audioManager.PlayAudio(lastMusicPlaying);
                    break;
                case GameState.DIALOGUE:
                    managerAudioSource.Stop();
                    //audioManager.FindsSoundSource(managerAudioSource);
                    //audioManager.PlayAudio(lastMusicPlaying);
                    break;
                case GameState.TITLE_SCREEN:
                    lastMusicPlaying = managerAudioSource.clip;
                    managerAudioSource.clip = menuMusic;
                    managerAudioSource.Play();
                    //audioManager.FindsSoundSource(managerAudioSource);
                    //audioManager.PlayAudio("sonk");
                    break;
                case GameState.PAUSE_SCREEN:
                    lastMusicPlaying = managerAudioSource.clip;
                    managerAudioSource.clip = menuMusic;
                    managerAudioSource.Play();
                    //audioManager.FindsSoundSource(managerAudioSource);
                    //audioManager.PlayAudio("sonk");
                    break;
                case GameState.CREDIT_SCREEN:
                    lastMusicPlaying = managerAudioSource.clip;
                    managerAudioSource.clip = menuMusic;
                    managerAudioSource.Play();
                    //audioManager.FindsSoundSource(managerAudioSource);
                    //audioManager.PlayAudio("sonk");
                    break;
                default:
                    break;
            }
        }
        void OnTimeChange(TimeSlot timeSlot, Day day)
        {
            StartCoroutine(ChangeTime());
        }
        IEnumerator ChangeTime ()
        {
            yield return new WaitForSeconds (2);
            switch (levelManager.timeSlot)
            {
                case TimeSlot.MORNING: // if the GameState enum is in FreeRoam then all of the movement and button controls updates
                    sceneLight.color = morningLightColour;
                    RenderSettings.skybox = morningSkyBox;
                    managerAudioSource.clip = musicDay;
                    managerAudioSource.Play();
                    //managerAudioSource.clip = lastMusicPlaying;
                    //audioManager.PlayAudio("Town - Day");
                    //lastMusicPlaying = "Town - Day";
                    break;
                case TimeSlot.MIDDAY:
                    sceneLight.color = middayLightColour;
                    RenderSettings.skybox = middaySkyBox;
                    managerAudioSource.clip = musicDay;
                    managerAudioSource.Play();
                    //managerAudioSource.clip = lastMusicPlaying;
                    //audioManager.PlayAudio("Town - Day");
                    //lastMusicPlaying = "Town - Day";
                    break;
                case TimeSlot.AFTERNOON:
                    sceneLight.color = afternoonLightColour;
                    RenderSettings.skybox = afternoonSkyBox;
                    managerAudioSource.clip = musicNight;
                    managerAudioSource.Play();
                    //managerAudioSource.clip = lastMusicPlaying;
                    //audioManager.PlayAudio("Town - Night");
                    //lastMusicPlaying = "Town - Night";
                    break;
                case TimeSlot.EVENING:
                    sceneLight.color = eveningLightColour;
                    RenderSettings.skybox = eveningSkyBox;
                    managerAudioSource.clip = musicNight;
                    managerAudioSource.Play();
                    //managerAudioSource.clip = lastMusicPlaying;
                    //audioManager.PlayAudio("Town - Night");
                    //lastMusicPlaying = "Town - Night";
                    break;
                default: break;
            }
        }
        #endregion
    }
}

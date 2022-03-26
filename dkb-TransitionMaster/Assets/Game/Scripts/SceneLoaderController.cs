// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Game.Scripts
{ 
    public enum SceneName
    {
        Scene1,
        Scene2,
        Scene3,
    }
    
    public class SceneLoaderController : MonoBehaviour
    {
        public static readonly float TransitionDelayTime = 0.7f;
        public SceneName sceneName;

        #region Booleans to check is the stated scene is loaded

        public static bool Scene1Loaded { get; private set; }
        public static bool Scene2Loaded { get; private set; }
        public static bool Scene3Loaded { get; private set; }

        #endregion

        private static string _lastLoadedScene;

        private bool IsMainSceneLoaded { get; set; }

        private void OnEnable()
        {
            Scene1Loaded = false;
            Scene2Loaded = false;
            Scene3Loaded = false;

            IsMainSceneLoaded = false;
        }
    
        private void Update()
        {

            if (!IsMainSceneLoaded)
            {
                IsMainSceneLoaded = true;
                sceneName = SceneName.Scene1;
                LoadScene(sceneName.ToString(),Scene1Loaded);
                ShowSceneNumberBehaviour.TrasitionStickMove(sceneName.ToString());
                ShowSceneNumberBehaviour.ButtonsAreReady(true);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                SceneDecider(SceneName.Scene1.ToString());
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                SceneDecider(SceneName.Scene2.ToString());
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                SceneDecider(SceneName.Scene3.ToString());
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            
        }
        
        public void SceneDecider(string sceneCode)
        {
            if (!ShowSceneNumberBehaviour.ButtonsAreActive) return;
            
            if(_lastLoadedScene != sceneCode)
            {
                LastSceneFadeOutOperations(_lastLoadedScene);
                switch (sceneCode)
                {
                    case "Scene1":
                        sceneName = SceneName.Scene1;
                        LoadScene(sceneCode, Scene1Loaded);
                        break;
                    case "Scene2":
                        sceneName = SceneName.Scene2;
                        LoadScene(sceneCode,Scene2Loaded);
                        break;
                
                    case "Scene3":
                        sceneName = SceneName.Scene3;
                        LoadScene(sceneCode,Scene3Loaded);
                        break;
                }
                ShowSceneNumberBehaviour.TrasitionStickMove(sceneCode);
                ShowSceneNumberBehaviour.PreviousLevelButtonShrink(_lastLoadedScene);

            }
        }
        
        public static void LoadScene(string sceneName,bool sceneIsLoaded)
        {
            if (!sceneIsLoaded)
            {
                ShowSceneNumberBehaviour.ButtonsAreReady(false);
                var progress = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                progress.completed += (op) =>
                {
                    SceneLoaderSetter(sceneName,true);
                    _lastLoadedScene = sceneName;

                    Debug.Log(sceneName+" Loaded!");
                };
            }
        }
    
        #region Load level with coroutine
    
        private IEnumerator LoadSceneCoroutine(string scene)
        {
            
            var progress = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    
            while (!progress.isDone)
            {
                yield return null;
            }
            
            Debug.Log("Level loaded");
        }
    
    
        #endregion 
        
        public static void UnLoadScene(string sceneName,bool sceneIsLoaded)
        {
            if (sceneIsLoaded)
            {
                var progress = SceneManager.UnloadSceneAsync(sceneName);
                progress.completed += (op) =>
                {
                    ShowSceneNumberBehaviour.ButtonsAreReady(true);
                    SceneLoaderSetter(sceneName,false);
                    Debug.Log(sceneName +" Unloaded!");
                };
            }
            
        }

        private static void SceneLoaderSetter(string sceneName,bool status)
        {
            if (sceneName == SceneName.Scene1.ToString()) Scene1Loaded = status;

            if (sceneName == SceneName.Scene2.ToString()) Scene2Loaded = status;
            
            if (sceneName == SceneName.Scene3.ToString()) Scene3Loaded = status;
            
        }

        private static void LastSceneFadeOutOperations(string sceneToFadeOut)
        {
            switch (sceneToFadeOut)
            {
                case "Scene1":
                    //Debug.Log("Fade Out of Scene 1");
                    TitleBehaviour.FadeOut();
                    break;
                
                case "Scene2":
                    //Debug.Log("Fade Out of Scene 2");
                    RotatingSpheresBehaviour.NonSelectedFadeOut();
                    break;
                
                case "Scene3":
                    //Debug.Log("Fade Out of Scene 3");
                    LastSceneController.FadeOut();
                    break;

            }
        }

    }   
}
// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.Scripts
{
    public class RotatingSpheresBehaviour : MonoBehaviour
    {
        public static bool CanRotate { get; set; }

        private static Transform _galaxyTransform;
        [SerializeField] private List<GameObject> planets = new List<GameObject>();
        public static bool EndSceneTwo { get; set; }

        private void OnEnable()
        {
            AssignInitValues();
            FadeIn();
        }

        private void Update()
        {
            if (EndSceneTwo)
            {
                FadeOutUnselectedSpheres();
            }
        }

        private void AssignInitValues()
        {
            CanRotate = true;
            EndSceneTwo = false;
            transform.localScale = Vector3.zero;
            _galaxyTransform = GetComponent<Transform>();
        }
        
        private void FadeIn()
        {
            transform.DOScale(Vector3.one, SceneLoaderController.TransitionDelayTime);
        }

        private void FadeOutUnselectedSpheres()
        {
            EndSceneTwo = false;
            foreach (GameObject child in planets)
            {
                child.transform.parent = null;
                
                if (!child.CompareTag("SelectedPlanet"))
                {
                    child.transform.DOScale(Vector3.zero, SceneLoaderController.TransitionDelayTime).SetEase(Ease.Linear);
                }
            }
        }

        public static void ClickedSphereFocus(GameObject clickedSphere)
        {
            SceneLoaderController.LoadScene(SceneName.Scene3.ToString(),SceneLoaderController.Scene3Loaded);
            clickedSphere.transform.DOMove(Vector3.zero, SceneLoaderController.TransitionDelayTime).SetEase(Ease.Linear).OnComplete(() =>
            {
                SceneLoaderController.UnLoadScene(SceneName.Scene2.ToString(),SceneLoaderController.Scene2Loaded);
            });

        }
        
        public static void NonSelectedFadeOut()
        {
            LastSceneController.FocusSphereScale = new Vector3(4, 4, 4);
            _galaxyTransform.DOScale(Vector3.zero,SceneLoaderController.TransitionDelayTime).SetEase(Ease.Linear).OnComplete(() =>
            {
                SceneLoaderController.UnLoadScene(SceneName.Scene2.ToString(),SceneLoaderController.Scene2Loaded);    
            });
        }
        
    }
}


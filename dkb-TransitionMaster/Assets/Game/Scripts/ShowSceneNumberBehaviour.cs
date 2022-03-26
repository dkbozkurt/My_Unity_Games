// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class ShowSceneNumberBehaviour : MonoBehaviour
    {
        public static List<GameObject> Buttons { get; } = new List<GameObject>();
        private static GameObject TransitionStick { get ; set; }

        public static bool ButtonsAreActive { get; set; }

        private void OnEnable()
        {
            AssignInitValues();
        }

        private void AssignInitValues()
        {
            ButtonsAreReady(false);
            
            for (int i = 1; i <= 3; i++)
            {
                Buttons.Add(transform.GetChild(i).gameObject);
            }
            
            TransitionStick = transform.GetChild(0).gameObject;
            TransitionStick.transform.localPosition= Buttons[0].transform.localPosition;
        }

        public static void TrasitionStickMove(string sceneName)
        {
            TransitionStick.transform.DOMove(Buttons[GetSceneNumber(sceneName) - 1].transform.position, SceneLoaderController.TransitionDelayTime*0.71f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Buttons[GetSceneNumber(sceneName) - 1].transform.DOScale(Vector3.one * 0.7f, SceneLoaderController.TransitionDelayTime*0.29f).SetEase(Ease.Linear);
                });
        }

        public static void PreviousLevelButtonShrink(string sceneName)
        {
            Buttons[GetSceneNumber(sceneName) - 1].transform.DOScale(Vector3.one * 0.5f, SceneLoaderController.TransitionDelayTime*0.43f).SetEase(Ease.Linear);
        }

        private static int GetSceneNumber(string sceneName)
        {
            int sceneNum = int.Parse(sceneName.Substring(sceneName.Length - 1));
            return sceneNum;
        }

        public static void ButtonsAreReady(bool buttonSituation)
        {
            ButtonsAreActive = buttonSituation;
            foreach (GameObject child in Buttons)
            {
                child.GetComponent<Button>().enabled =buttonSituation;
            }
            
        }
        
        
        
    }
}

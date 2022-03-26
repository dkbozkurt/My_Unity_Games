// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Game.Scripts
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [RequireComponent(typeof(RectTransform))]
    public class TitleBehaviour : MonoBehaviour
    {
        private static RectTransform _titleRectTransform;
        private static TextMeshProUGUI _titleTMP;
        private static Camera _cam;

        private void OnEnable()
        {
            AssignInitValues();
            FadeIn();
        }
    
        private void AssignInitValues()
        {
            _titleRectTransform = GetComponent<RectTransform>();
            _titleRectTransform.localScale = Vector3.zero;
            _titleTMP = GetComponent<TextMeshProUGUI>();
            _cam = Camera.main;
        }
        private void FadeIn()
        {
            _cam.DOColor(Color.black, SceneLoaderController.TransitionDelayTime).SetEase(Ease.Linear);
            _titleRectTransform.DOScale(new Vector3(5, 5,0), SceneLoaderController.TransitionDelayTime).SetEase(Ease.Linear);
        }

        public static void FadeOut()
        {
            _cam.DOColor(Color.white, SceneLoaderController.TransitionDelayTime).SetEase(Ease.Linear);
            _titleTMP.DOFade(0, SceneLoaderController.TransitionDelayTime).SetEase(Ease.Linear);
            _titleRectTransform.DOScale(new Vector3(600, 600,0), SceneLoaderController.TransitionDelayTime).SetEase(Ease.Linear).OnComplete(() =>
            {
                if (Camera.main is { }) Camera.main.backgroundColor = Color.white;
                SceneLoaderController.UnLoadScene(SceneName.Scene1.ToString(),SceneLoaderController.Scene1Loaded);
            });
            
        }

    }
}
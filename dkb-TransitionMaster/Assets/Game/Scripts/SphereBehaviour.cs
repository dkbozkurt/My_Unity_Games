// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using UnityEngine;

namespace Game.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class SphereBehaviour : MonoBehaviour
    {
        [SerializeField] private float sphereRotationSpeed;
        private void Update()
        {
            if(RotatingSpheresBehaviour.CanRotate) RotateSphere();
        }

        private void RotateSphere()
        {
            transform.RotateAround(transform.parent.position,Vector3.forward, sphereRotationSpeed * Time.deltaTime);
        }

        private void OnMouseDown()
        {
            LastSceneController.FocusSphereScale = gameObject.transform.lossyScale;

            RotatingSpheresBehaviour.CanRotate = false;
            gameObject.tag = "SelectedPlanet";
            RotatingSpheresBehaviour.EndSceneTwo = true;

            ShowSceneNumberBehaviour.TrasitionStickMove("Scene3");
            ShowSceneNumberBehaviour.PreviousLevelButtonShrink("Scene2");

            RotatingSpheresBehaviour.ClickedSphereFocus(this.gameObject);
        }
        
    }
    
}




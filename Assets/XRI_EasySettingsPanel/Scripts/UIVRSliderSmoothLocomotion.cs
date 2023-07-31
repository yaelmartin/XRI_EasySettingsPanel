using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace XRI_EasySettingsPanel.Scripts
{
    public class UIVRSliderSmoothLocomotion : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private Slider slider;
        [SerializeField] private UIVRSettingsLocomotionInstance uiVrSettingsLocomotionInstance;

        public void OnPointerUp(PointerEventData data)
        {
            uiVrSettingsLocomotionInstance.UseValueSmoothLocomotion();
        }
    }
}
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XRI_EasySettingsPanel.Scripts
{
    public class UIVRSliderSnapTurn : MonoBehaviour, IPointerUpHandler
    {
        [SerializeField] private Slider slider;
        [SerializeField] private UIVRSettingsLocomotionInstance uiVrSettingsLocomotionInstance;

        public void OnPointerUp(PointerEventData data)
        {
            uiVrSettingsLocomotionInstance.UseValueSnapTurn();
        }
    }
}
using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

namespace XRI_EasySettingsPanel.Scripts
{
    public class UIVRSettingsManager : MonoBehaviour
    {

        [SerializeField] private UIVRSettingsLocomotionInstance[] uiVrSettingsLocomotionInstances;

        [SerializeField] private ActionBasedSnapTurnProvider actionBasedSnapTurnProvider;
        [SerializeField] private ActionBasedContinuousTurnProvider actionBasedContinuousTurnProvider;
        [SerializeField] private ActionBasedControllerManager leftActionBasedControllerManager;
        [SerializeField] private ActionBasedControllerManager rightActionBasedControllerManager;
        [SerializeField] private DynamicMoveProvider dynamicMoveProvider;

        void Awake()
        {
            SmoothLocomotion(false);
            SmoothTurn(false);
            FlyMode(false);
            SetValueSmoothTurn(160);
            const float defaultSpeed = 1;
            SetValueSmoothLocomotion((float)(Math.Pow((2500000*defaultSpeed),1f/4f)));
            SetValueSnapTurn(45/15);
        }
        

        //ENABLING AND DISABLING
        public void SmoothLocomotion(bool value)
        {
            leftActionBasedControllerManager.smoothMotionEnabled = value;
            foreach (UIVRSettingsLocomotionInstance uiVrSettingsLocomotionInstance in uiVrSettingsLocomotionInstances)
            {
                if (uiVrSettingsLocomotionInstance != null)
                {
                    uiVrSettingsLocomotionInstance.UISetStateSmoothLocomotion(value);
                }
                else
                {
                    MissingLocomotionInstance();
                }
            }
        }

        public void SmoothTurn(bool value)
        {
            rightActionBasedControllerManager.smoothTurnEnabled = value;
            foreach (UIVRSettingsLocomotionInstance uiVrSettingsLocomotionInstance in uiVrSettingsLocomotionInstances)
            {
                if (uiVrSettingsLocomotionInstance != null)
                {
                    uiVrSettingsLocomotionInstance.UISetSatesSlidersSmoothSnapTurn(value);
                }
                else
                {
                    MissingLocomotionInstance();
                }
            }
        }
        
        public void FlyMode(bool value)
        {
            dynamicMoveProvider.enableFly = value;
            foreach (UIVRSettingsLocomotionInstance uiVrSettingsLocomotionInstance in uiVrSettingsLocomotionInstances)
            {
                if (uiVrSettingsLocomotionInstance != null)
                {
                    uiVrSettingsLocomotionInstance.UISetStateFlyMode(value);
                }
                else
                {
                    MissingLocomotionInstance();
                }
            }
        }

        
        
        
        //VALUES
        public void SetValueSmoothLocomotion(float speedRaw)
        {
            float speed = ((float) Math.Pow(speedRaw,4f))/2500000;
            dynamicMoveProvider.moveSpeed = speed;
            foreach (UIVRSettingsLocomotionInstance uiVrSettingsLocomotionInstance in uiVrSettingsLocomotionInstances)
            {
                if (uiVrSettingsLocomotionInstance != null)
                {
                    uiVrSettingsLocomotionInstance.UISetValueSmoothLocomotion(speedRaw,FormatSpeed(speed));
                }
                else
                {
                    MissingLocomotionInstance();
                }
            }
        }

        public void SetValueSnapTurn(float amountRaw)
        {
            float amount = amountRaw * 15;
            actionBasedSnapTurnProvider.turnAmount = amount;
            foreach (UIVRSettingsLocomotionInstance uiVrSettingsLocomotionInstance in uiVrSettingsLocomotionInstances)
            {
                if (uiVrSettingsLocomotionInstance != null)
                {
                    uiVrSettingsLocomotionInstance.UISetValuesSliderSnapTurn(amountRaw,FormatAngle(amount));
                }
                else
                {
                    MissingLocomotionInstance();
                }
            }
        }
        
        public void SetValueSmoothTurn(float speed)
        {
            actionBasedContinuousTurnProvider.turnSpeed = speed;
            foreach (UIVRSettingsLocomotionInstance uiVrSettingsLocomotionInstance in uiVrSettingsLocomotionInstances)
            {
                if (uiVrSettingsLocomotionInstance != null)
                {
                    uiVrSettingsLocomotionInstance.UISetValueSliderSmoothTurn(speed,FormatAngularSpeed(speed));
                }
                else
                {
                    MissingLocomotionInstance();
                }
            }
        }
        
    
        //METHODS    
        public string FormatSpeed(float speed)
        {
            var formattedSpeed = speed.ToString("F2") + "m/s";
            return formattedSpeed;
        }
        public string FormatAngle(float angle)
        {
            var formattedAngle = angle.ToString("F0") + "°";
            return formattedAngle;
        }
        public static string FormatAngularSpeed(float speed)
        {
            var formattedSpeed = speed.ToString("F0") + "°/s";
            return formattedSpeed;
        }

        private static void MissingLocomotionInstance()
        {
            Debug.Log("XRI_EasySettingsPanel : a UIVRSettingsLocomotionInstance object isn't assigned in UIVRSettingsManager"); 
        }
    }
}
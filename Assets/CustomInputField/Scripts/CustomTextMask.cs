using UnityEngine;

namespace CustomInputField
{
    [CreateAssetMenu(fileName = "Custom Mask", menuName = "UI/InputField/Custom Mask")]
    public class CustomTextMask : ScriptableObject
    {
        public string mask;
    }
}
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace CustomInputField
{
    [RequireComponent(typeof(InputField))]
    public class InputFieldMask : MonoBehaviour
    {
        [Tooltip("Set the InputField Mask. Ex: \"(00) 00000-0000\". the current character to check user input is \"0\"")]
        public CustomTextMask customTextMask;
        public CharacterInputValidation characterInputValidation;

        private int maxCharacterEnterLimit;
        private char[] trim;
        private InputField inputField;
        private static char enterDataValidation = '0';
        private string lastInput;
        private void Awake()
        {
            if (customTextMask)
            {
                trim = GetTrimMask();
                maxCharacterEnterLimit = string.Join(string.Empty, customTextMask.mask.Split(trim)).Length;
            }

            inputField = GetComponent<InputField>();

            inputField.onValueChanged.AddListener(call =>
            {
                if (lastInput == inputField.text)
                    return;

                string unmaskedText = "";
                if (customTextMask)
                {
                    unmaskedText = string.Join(string.Empty, call.Split(trim));
                }
                else
                {
                    unmaskedText = call;
                }

                unmaskedText = CustomInputValidation.GetCharacterInputValidation(unmaskedText, characterInputValidation);
                if (unmaskedText.Length == 0)
                {
                    lastInput = unmaskedText;
                    inputField.text = unmaskedText;
                    return;
                }

                if (customTextMask && unmaskedText.Length > maxCharacterEnterLimit)
                {
                    string resizeText = unmaskedText.Substring(0, maxCharacterEnterLimit);
                    lastInput = SetCustomMask(resizeText);
                    inputField.text = SetCustomMask(resizeText);

                }
                else if (customTextMask)
                {
                    lastInput = SetCustomMask(unmaskedText);
                    inputField.text = SetCustomMask(unmaskedText);
                    inputField.MoveTextEnd(false);
                }
                else
                {
                    lastInput = unmaskedText;
                    inputField.text = unmaskedText;
                    inputField.MoveTextEnd(false);
                }

            });
            inputField.onEndEdit.AddListener(call =>
            {
                if (!customTextMask)
                    return;

                inputField.text = SetCustomMask(call);

            });

        }

        private char[] GetTrimMask()
        {
            List<char> trimCharacter = new List<char>();
            foreach (char character in customTextMask.mask)
            {
                if (!character.Equals(enterDataValidation) && !trimCharacter.Contains(character))
                {
                    trimCharacter.Add(character);
                }
            }
            return trimCharacter.ToArray();
        }

        public string SetCustomMask(string text)
        {
            if (text.Length == 0)
                return "";
            string unmaskedText = string.Join(string.Empty, text.Split(trim));
            int stringSize = unmaskedText.Length;
            int index = 0;
            string returnMasked = "";
            foreach (char character in customTextMask.mask)
            {
                if (index >= stringSize)
                    break;

                if (!character.Equals(enterDataValidation))
                {
                    returnMasked += character;
                }
                else
                {
                    returnMasked += unmaskedText[index];
                    index++;
                }
            }
            return returnMasked;
        }
    }

}
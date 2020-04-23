# Custom InputField Mask
## A solution to create custom InputField mask for unity

### Before you start using:
- For better use consider using the Input Field in Content Type Custom mode, it will allow you by default to no longer allow the user to type other characters that you do not want by changing Keyboard Type, however on some platforms such as the computer even changing the Keyboard Type for do not prevent you from typing other unwanted characters. If you need, Consider using the Character Input Validation of the Input Field Mask component 
- Do not use the Character Validation of the Input Field, it checks all the text of the InputField, thus not allowing the use of the pre-defined mask. Consider using some Character Input Validation, it checks only the user inputs.
- By default, the maximum size of the InputField is set by the mask, it is not necessary to use the Character Limit of the InputField

### How to Use:

#### 1: add the InputFieldMask component to the object:
- Select the GameObject that you can add, click Add component -> Scripts -> CustomInputField -> Input Field Mask, or simply click Add Component -> and type Input Field Mask -> Select the Input Field Mask Component.

#### 2: Add a Custom Text Mask:
1. In your project folder, right-click -> Create -> UI -> InputField -> Custom Mask
2. Design the mask the way you want, considering user input standard "0", which will be replaced. Ex: (00) 000-000
3. Drag the Custom Text Mask ScriptableObject to the Custom Text Mask in the Input Field Mask Field

#### 3: (Optional) Select a user Input Validation:
This will only check user inputs and will not affect the mask and can be used in conjunction with the validation of the InputField component itself. Keep in mind that InputField validation affects the mask, so add it only if necessary.

- None: It will not check any user input
- Alphanumeric: It is only allowed to type letters and numbers (a-zA-Z0-9 ) "space included"
- Numeric: It is only allowed to type number(0-9 ) "space included"
- Alphabetic: It is Only allowed to type only letters (a-zA-Z ) "space included"


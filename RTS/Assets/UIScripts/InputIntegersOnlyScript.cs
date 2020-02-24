using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputIntegersOnlyScript : MonoBehaviour
{
    public InputField field;
    // Start is called before the first frame update
    void Start()
    {
        field.characterValidation = InputField.CharacterValidation.Integer;
    }
}

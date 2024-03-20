using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EX_UI_InputField_Text : MonoBehaviour
{
    public TMP_Text InputText, OutputText;

    public void OnClick_SetText()
    {
        OutputText.text = InputText.text;
    }
}

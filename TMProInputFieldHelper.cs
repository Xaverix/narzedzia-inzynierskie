using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TMProInputFieldHelper : MonoBehaviour
{
    public void MoveToTextStart() {
        //GetComponent<TMP_InputField>().textComponent.rectTransform.anchoredPosition = Vector2.zero;
        //GetComponent<TMP_InputField>().stringPosition = 0;
        //GetComponent<TMP_InputField>().caretPosition = 0;
        //GetComponent<TMP_InputField>().ForceLabelUpdate();
        StartCoroutine(MoveToTextStartDelayed());
    }
    
    IEnumerator MoveToTextStartDelayed() {
        yield return new WaitForEndOfFrame();
        //GetComponent<TMP_InputField>().Select();
        GetComponent<TMP_InputField>().MoveToStartOfLine(false, false);
        //GetComponent<TMP_InputField>().ForceLabelUpdate();
    }

    public void MoveToTextEnd() {
        GetComponent<TMP_InputField>().MoveToEndOfLine(false, false);
        GetComponent<TMP_InputField>().ForceLabelUpdate();
    }
}

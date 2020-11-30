using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TMProInputFieldHelper : MonoBehaviour
{
    public void MoveToTextStart() {
        StartCoroutine(MoveToTextStartDelayed());
    }
    
    IEnumerator MoveToTextStartDelayed() {
        yield return new WaitForEndOfFrame();
        GetComponent<TMP_InputField>().MoveToStartOfLine(false, false);
    }

    public void MoveToTextEnd() {
        GetComponent<TMP_InputField>().MoveToEndOfLine(false, false);
        GetComponent<TMP_InputField>().ForceLabelUpdate();
    }
}

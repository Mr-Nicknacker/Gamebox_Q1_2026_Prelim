using System.Collections;
using TMPro;
using UnityEngine;

public class WarningDisplay : MonoBehaviour
{
    [SerializeField]private TMP_Text _warningTextField;
    
    private void DisplayWarning(string warningText)
    {
        Debug.Log(warningText);
        StartCoroutine(Display(warningText));
        _warningTextField.text = string.Empty;
        StopCoroutine(Display(warningText));
    }
    private IEnumerator Display(string text)
    {
        _warningTextField.text = text;
        yield return new WaitForSeconds(3f);
    }
    private void OnEnable()
    {
        Resource.OnInsufficientResource += DisplayWarning;
    }
    private void OnDisable()
    {
        Resource.OnInsufficientResource -= DisplayWarning;
    }
}

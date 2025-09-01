using UnityEngine;
using TMPro;
using System;
using System.Runtime.CompilerServices;
using System.Collections;
public class EmailDeepLink : MonoBehaviour
{
    public TMPro.TMP_InputField recipientInput;
    public TMPro.TMP_InputField subjectInput;
    public TMPro.TMP_InputField messageInput;

    [SerializeField] GameObject errorPanel;

    public void Start()
    {
        recipientInput.text = "nicolas.b.gomez@outlook.com";
        subjectInput.text = "Resultado del simulacro";
    }

    public void OpenEmailApp() { 
        string recipient = recipientInput.text.Trim();
        string subject = subjectInput.text.Trim();
        string message = messageInput.text.Trim();

        if (string.IsNullOrEmpty(recipient) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message)) {
            Debug.LogError("All fields must be filled!");
            StartCoroutine(emailError());
            return;
        }
        string mailtoUrl = $"mailto:{recipient}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(message)}";
        Application.OpenURL(mailtoUrl);

    }

    private IEnumerator emailError() {
        errorPanel.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        errorPanel.SetActive(false);
    }

}

using UnityEngine;
using TMPro;
using System;
using System.Runtime.CompilerServices;
public class EmailDeepLink : MonoBehaviour
{
    public TMPro.TMP_InputField recipientInput;
    public TMPro.TMP_InputField subjectInput;
    public TMPro.TMP_InputField messageInput;

    public void OpenEmailApp() { 
        string recipient = recipientInput.text.Trim();
        string subject = subjectInput.text.Trim();
        string message = messageInput.text.Trim();

        if (string.IsNullOrEmpty(recipient) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message)) {
            Debug.LogError("All fields must be filled!");
            return;
        }
        string mailtoUrl = $"mailto:{recipient}?subject={Uri.EscapeDataString(subject)}&body={Uri.EscapeDataString(message)}";
        Application.OpenURL(mailtoUrl);

    }

}

using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class WhatsAppDeepLink : MonoBehaviour
{
    public TMP_InputField phoneInput;
    public TMP_InputField messageInput;

    public void OpenWhatsApp() { 
        string phone = phoneInput.text;
        string message = messageInput.text;

        if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(message)) {
            Debug.LogError("Phone number and message cannot be empty!");
            return;
        }

        string url = "https://api.whatsapp.com/send?phone=" + phone + "&text=" + UnityWebRequest.EscapeURL(message);
        Application.OpenURL(url);
    }
}

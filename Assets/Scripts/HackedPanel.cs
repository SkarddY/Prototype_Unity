using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HackedPanel : MonoBehaviour {
        private void Update() {
            StartCoroutine(DisablePanel());
        }

        private IEnumerator DisablePanel() {
            yield return new WaitForSeconds(8.0f);
            gameObject.SetActive(false);
        }    
}
        
    

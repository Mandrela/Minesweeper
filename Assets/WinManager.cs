using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
   public void DOWIN()
   {    
        StartCoroutine(DKDKD());
   }

   IEnumerator DKDKD() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(6);
   }
}

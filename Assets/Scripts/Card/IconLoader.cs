using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Card
{
    [RequireComponent(typeof(CardManager))]
    public class IconLoader : MonoBehaviour
    {
        private CardManager card;
        
        private void Start()
        {
            card = GetComponent<CardManager>();
            StartCoroutine(GetIconFromWeb());
        }

        IEnumerator GetIconFromWeb()
        {
            UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://picsum.photos/256");
            yield return www.SendWebRequest();

            Texture2D icon = DownloadHandlerTexture.GetContent(www);
            
            card.InicIcon(icon);
        }
    }
}

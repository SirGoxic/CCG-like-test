using System.Collections;
using System.Collections.Generic;
using Card;
using UnityEngine;

namespace Hand
{
    public class HandManager : MonoBehaviour
    {
        public Object cardPrefab;

        public int cardCount = 5;

        public float arcAngle = 90f;//In degree

        public float handRadius = 10f;

        public List<CardManager> cards = new List<CardManager>();
        
        private void Start()
        {
            Quaternion angleStep = Quaternion.Euler(0f, 0f, -arcAngle / (cardCount % 2 != 0 ? cardCount - 1 : cardCount));

            Quaternion rotation = Quaternion.Euler(0f, 0f, arcAngle * 0.5f);

            Vector3 position = transform.position + rotation  * transform.up * handRadius - new Vector3(0f, handRadius, 0f);

            for (int i = 0; i < cardCount; i++)
            {
                GameObject tempGo = (GameObject) Instantiate(cardPrefab, position, rotation, transform);
                CardManager tempCard = tempGo.GetComponent<CardManager>();
                tempCard.InicValues();
                
                cards.Add(tempCard);

                rotation *= angleStep;
                position = transform.position + rotation  * transform.up * handRadius - new Vector3(0f, handRadius, 0f);
            }
        }
    }
}

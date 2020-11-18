using System.Collections;
using System.Collections.Generic;
using Card;
using UnityEngine;

namespace Hand
{
    [RequireComponent(typeof(HandManager))]
    public class ChangeRndValue : MonoBehaviour
    {
        private HandManager hand;
        private bool isChanging = false;
        public void Start()
        {
            hand = GetComponent<HandManager>();
        }
        
        public void ChangeValue()
        {
            if (!isChanging)
            {
                isChanging = true;
                StartCoroutine(ChangeValueInCycle());
            }
        }

        IEnumerator ChangeValueInCycle()
        {
            int i = 0;
            while (i < hand.cards.Count)
            {
                CardManager tempCard = hand.cards[i];

                tempCard.transform.SetParent(transform.parent);
                
                int rndValueIndex = Random.Range(0, 2);
                int rndValue = Random.Range(-2, 9);
                
                switch (rndValueIndex)
                {
                    case 0:
                        tempCard.IncreaseMana(rndValue);
                        tempCard.UpdateMana();
                        break;
                    case 1:
                        tempCard.IncreaseAttack(rndValue);
                        tempCard.UpdateAttack();
                        break;
                    case 2:
                        tempCard.IncreaseHp(rndValue);
                        tempCard.UpdateHp();
                        break;
                }

                yield return StartCoroutine(ChangingAnim(tempCard));

                tempCard.transform.SetParent(transform);
                
                i++;
                if (i == hand.cards.Count)
                {
                    i = 0;
                }
            }
        }
        
        IEnumerator ChangingAnim(CardManager card)
        {
            while (card.transform.localScale.x < 0.8f)
            {
                card.transform.localScale += new Vector3(0.11f, 0.11f, 0f);
                card.transform.position += new Vector3(0f, 20f, 0f);
                yield return  new WaitForSeconds(0.05f);
            }

            while (card.updating)
            {
                yield return  new WaitForSeconds(0.1f);
            }
            
            yield return  new WaitForSeconds(1f);
            
            while (card.transform.localScale.x > 0.5f)
            {
                card.transform.localScale -= new Vector3(0.11f, 0.11f, 0f);
                card.transform.position -= new Vector3(0f, 20f, 0f);
                yield return  new WaitForSeconds(0.05f);
            }
            
            card.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        }

        private void OnApplicationQuit()
        {
            StopAllCoroutines();
        }
    }
}

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Card{
    public class CardManager : MonoBehaviour
    {

        [SerializeField] private float changeValueSpeed = 0.2f;//Number per second 
        
        [Header("UI Elements!")]
        [SerializeField] private TMP_Text manaValueText = null;
        [SerializeField] private TMP_Text attackValueText = null;
        [SerializeField] private TMP_Text hpValueText = null;

        [SerializeField] private TMP_Text descriptionText = null;
        
        [SerializeField] private RawImage cardIconUI = null;

        private int mana = 0;
        private int attack = 0;
        private int hp = 0;

        private string description = "";
        
        private Texture2D icon = null;

        public bool updating = false;

        public void InicValues()
        {
            mana = Random.Range(1, 10);
            attack = Random.Range(1, 10);
            hp = Random.Range(1, 10);

            manaValueText.text = mana.ToString();
            attackValueText.text = attack.ToString();
            hpValueText.text = hp.ToString();

            description = "Some description";
            
            descriptionText.text = description;

        }
        
        public void IncreaseMana(int manaI)
        {
            mana += manaI;
            
            if (mana < 0)
            {
                mana = 0;
            }
        }
        
        public void IncreaseAttack(int attackI)
        {
            attack += attackI;
            
            if (attack < 0)
            {
                attack = 0;
            }
        }
        
        public void IncreaseHp(int hpI)
        {
            hp += hpI;
            
            if (hp < 0)
            {
                hp = 0;
            }
        }

        public void InicIcon(Texture2D newIcon)
        {
            icon = newIcon;
            
            cardIconUI.texture = icon;
        }
        
        public void UpdateMana()
        {
            StartCoroutine(UpdateManaAnim(int.Parse(manaValueText.text)));
        }

        public void UpdateAttack()
        {
            StartCoroutine(UpdateAttackAnim(int.Parse(attackValueText.text)));
        }

        public void UpdateHp()
        {
            StartCoroutine(UpdateHpAnim(int.Parse(hpValueText.text)));
        }

        public void UpdateAll()
        {
            UpdateMana();
            UpdateAttack();
            UpdateHp();
        }

        IEnumerator UpdateManaAnim(int oldMana)
        {
            updating = true;
            while (oldMana != mana)
            {
                if (oldMana > mana)
                {
                    oldMana--;
                }
                else if(oldMana < mana)
                {
                    oldMana++;
                }
                manaValueText.text = oldMana.ToString();
                yield return new WaitForSeconds(changeValueSpeed);
            }
            updating = false;
        }

        IEnumerator UpdateAttackAnim(int oldAttack)
        {
            updating = true;
            while (oldAttack != attack)
            {
                if (oldAttack > attack)
                {
                    oldAttack--;
                }
                else if (oldAttack < attack)
                {
                    oldAttack++;
                }
                
                attackValueText.text = oldAttack.ToString();
                yield return new WaitForSeconds(changeValueSpeed);
            }
            updating = false;
        }
        
        IEnumerator UpdateHpAnim(int oldHp)
        {
            updating = true;
            while (oldHp != hp)
            {
                if (oldHp > hp)
                {
                    oldHp--;
                }
                else if (oldHp < hp)
                {
                    oldHp++;
                }
                
                hpValueText.text = oldHp.ToString();
                yield return  new WaitForSeconds(changeValueSpeed);
            }
            updating = false;
        }
    }
}

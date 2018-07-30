using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TAAI
{
	public class Manager_UI : MonoBehaviour {

		public GameObject Pausa;
        public Image PlayerHP;
        public Image BossHP;
        public Text WinText;
        public Text LoseText;
        public Sprite[] hpBarSprites;
        public Sprite[] hpBossSprites;

        public void UpdatePlayerHP(int newHP)
        {
            switch (newHP)
            {
                case 100:
                    PlayerHP.sprite = hpBarSprites[4];
                    break;

                case 75:
                    PlayerHP.sprite = hpBarSprites[3];
                    break;

                case 50:
                    PlayerHP.sprite = hpBarSprites[2];
                    break;

                case 25:
                    PlayerHP.sprite = hpBarSprites[1];
                        break;

                case 0:
                    PlayerHP.sprite = hpBarSprites[0];
                    LoseText.gameObject.SetActive(true);
                    break;
            }
        }

        public void UpdateBossHP(int newHP)
        {
            switch (newHP)
            {
                case 100:
                    PlayerHP.sprite = hpBossSprites[4];
                    break;

                case 75:
                    PlayerHP.sprite = hpBossSprites[3];
                    break;

                case 50:
                    PlayerHP.sprite = hpBossSprites[2];
                    break;

                case 25:
                    PlayerHP.sprite = hpBossSprites[1];
                    break;

                case 0:
                    PlayerHP.sprite = hpBossSprites[0];
                    WinText.gameObject.SetActive(true);
                    break;
            }
        }

        public void BossFound()
        {
            Debug.Log("Entered BossFound Method");
            if (!BossHP.gameObject.activeSelf)
            {
                Debug.Log("Found Boss !");
                BossHP.gameObject.SetActive(true);
            }
        }

		void Awake()
		{
			Manager_Static.uiManager = this;
		}

		public void isInPause(bool _isIt)
		{
			Pausa.gameObject.SetActive (_isIt);
		}
	}
}
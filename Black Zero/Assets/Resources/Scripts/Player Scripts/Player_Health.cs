using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    [SerializeField] private Image PlayerHealthBar;
    [SerializeField] private Text RatioText;

    public float CurrentPlayerHealth = 100f; //hitpoint
    public float MaxPlayerHealth = 100; //maxhitpoint

    private float FadeTimer = 3f;
    public bool FadeTimerIsActive = false;

    private void Start()
    {
        UpdateHealthBar();
    }


    void Update()
    {
        //Debug.Log("Player Health = " + CurrentPlayerHealth);

        UpdateHealthBar();

        if (CurrentPlayerHealth < 0)
        {
            CurrentPlayerHealth = 0;
            UpdateHealthBar();
            Destroy(this.gameObject.transform.root.gameObject); //of misschien later doe ik dat de player naar een scene waar game over staat wordt geteleport of zo?
        }

        if (FadeTimer <= 0f)
        {
            FadeTimerIsActive = false;
            FadeTimer = 3f;
            Background.SetActive(false);
        }

        if (FadeTimerIsActive == true)
        {
            FadeTimer -= Time.deltaTime;
            Background.SetActive(true);
        }

    }

    private void UpdateHealthBar() //dit checkt hoeveel health de speler echt heeft
    {
        float ratio = CurrentPlayerHealth / MaxPlayerHealth;

        //PlayerHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);

        PlayerHealthBar.fillAmount = CurrentPlayerHealth / 100;
        RatioText.text = (ratio * 100).ToString("0");

     
    }



}

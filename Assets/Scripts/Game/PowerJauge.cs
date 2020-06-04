using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerJauge : MonoBehaviour
{
    public GameObject jauge;
    public GameObject PowerReadyText;

    public float NbEnergie;
   
    public bool JaugeIsMax;
    public bool PowerIsTrue;
    public bool PowerIsGoing;

    // Start is called before the first frame update
    void Start()
    {
        jauge.transform.localScale = new Vector3(0, gameObject.transform.localScale.y, 1);
        jauge.transform.position = new Vector3(-344, gameObject.transform.position.y, -1);
    }

    // Update is called once per frame
    void Update()
    {
        loadjauge();
        StartCoroutine(EnergieUntilPower());
    }

    void loadjauge()
    {
        if(NbEnergie < 11 && NbEnergie > 0)
        {
            jauge.transform.localScale = new Vector3((gameObject.transform.localScale.x / 10) * NbEnergie, gameObject.transform.localScale.y, 1);
            jauge.transform.position = new Vector3(-180 + jauge.transform.localScale.x /2, gameObject.transform.position.y, -1);
             
        }

        if (NbEnergie >= 10)
        {
            JaugeIsMax = true;
            PowerReadyText.SetActive(true);

            if (Input.GetKeyUp(KeyCode.Return))
            {
                PowerReadyText.SetActive(false);
                NbEnergie = 0;
                PowerIsTrue = true;
            }
        }
        
    }

    public IEnumerator EnergieUntilPower()
    {
        if (PowerIsTrue)
        {
            PowerIsGoing = true;
            yield return new WaitForSeconds(12f);
            PowerIsGoing = false;
        }
    }
}

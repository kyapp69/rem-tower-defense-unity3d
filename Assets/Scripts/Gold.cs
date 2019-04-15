using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gold : MonoBehaviour
{
    public Text goldText;
    public Text warning;
    private float initialGold = 60.0f;
    public float currentGold;

    // weapon specification
    private string gunTag = "GunTag";
    private string machineGunTag = "MachineGunTag";
    private string canonTag = "CanonTag";
    private float gunPrice = 20.0f;
    private float machineGunPrice = 40.0f;
    private float CanonPrice = 200.0f;

    // Use this for initialization
    void Start()
    {
        goldText.color = Color.yellow;
        goldText.fontSize = 20;

        warning.color = Color.yellow;
        warning.fontSize = 20;

        currentGold = initialGold;
        UpdateGold();
    }

    // add gold when you kill the enemy
    public void addMoney()
    {
        currentGold += 1;
        UpdateGold();
    }

    // reduce the golds when you spawn weapon
    public void reduceMoney(GameObject towerToBuild)
    {
        if (towerToBuild.tag == canonTag && currentGold >= CanonPrice)
        {
            currentGold -= CanonPrice;
        }
        else if (towerToBuild.tag == machineGunTag && currentGold >= machineGunPrice)
        {
            currentGold -= machineGunPrice;
        }
        else if (towerToBuild.tag == gunTag && currentGold >= gunPrice)
        {
            currentGold -= gunPrice;
        }
        else
        {
            writeWarning();
        }
        UpdateGold();
    }

    // updating the current gold into the game
    private void UpdateGold()
    {
        goldText.text = "gold : " + currentGold;
    }

    // check whether there is enough gold or not
    public bool checkGold(GameObject towerToBuild)
    {
        if (towerToBuild.tag == canonTag)
        {
            bool canonFlag = isCanon(towerToBuild);
            if (canonFlag)
            {
                return true;
            }
        }

        if (towerToBuild.tag == machineGunTag)
        {
            bool machineGunFlag = isMachineGun(towerToBuild);
            if (machineGunFlag)
            {
                return true;
            }
        }

        if (towerToBuild.tag == gunTag)
        {
            bool gunFlag = isGun(towerToBuild);
            if (gunFlag)
            {
                return true;
            }
        }

        return false;
    }

    // check the canon
    private bool isCanon(GameObject towerToBuild)
    {
        if (towerToBuild.tag == canonTag && currentGold >= CanonPrice)
        {
            return true;
        }
        return false;
    }

    // check machine gun
    private bool isMachineGun(GameObject towerToBuild)
    {
        if (towerToBuild.tag == machineGunTag && currentGold >= machineGunPrice)
        {
            return true;
        }
        return false;
    }

    // check gun
    private bool isGun(GameObject towerToBuild)
    {
        if (towerToBuild.tag == gunTag && currentGold >= gunPrice)
        {
            return true;
        }
        return false;
    }

    // write warning when the current money is not enough to build a weapon
    public IEnumerator writeWarning()
    {
        warning.gameObject.SetActive(true);
        warning.text = "Not Enough Gold !!";
        yield return new WaitForSeconds(2.0f);
        warning.gameObject.SetActive(false);
        UpdateGold();
    }
}
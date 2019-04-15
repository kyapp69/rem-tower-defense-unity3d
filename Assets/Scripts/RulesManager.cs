using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RulesManager : MonoBehaviour {

    public Text rulesText;

    // creating rules uopon starting the rules scene
    void Start()
    {
        rulesText.text = "Initial gold : 60 golds\n\nThere are 2 types of enemies:\n\t1. Bunny Zombie (2 HP)\n\t2. Elephant Zombie (12 HP)\n\nyou will get 1 gold for each enemy you kill.\n\nthere are 3 types of weapon that can be used to destroy the enemy:\n     1. Gun (20 golds)\n     2. Machine-Gun (40 golds)\n     3. Canon (200 golds)\n\nThe game is over when you finish 10 waves or one of the enemy reach the goal.\n";
    }
}

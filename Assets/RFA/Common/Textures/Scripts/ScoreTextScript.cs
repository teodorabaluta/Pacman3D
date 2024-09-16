using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text text;
    public static int coinAmount;

    void Start()
    {
        text = GetComponent<Text>();
        coinAmount = 0; // Reset coinAmount to 0 every time the game starts
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString();
    }
}

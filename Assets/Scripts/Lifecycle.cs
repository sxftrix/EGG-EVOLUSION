using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Lifecycle : MonoBehaviour
{
    public Counter counter; // Make sure to assign this in the Inspector

    private static bool firstChickMatured = false;
    private GameManager gameManager;

    private void Start()
    {
        if (counter == null)
        {
            counter = FindObjectOfType<Counter>();
        }

        gameManager = FindObjectOfType<GameManager>();

        switch (gameObject.tag)
        {
            case "Egg":
                StartCoroutine(HatchEgg());
                break;
            case "Chick":
                StartCoroutine(MatureChick());
                break;
            case "Hen":
                StartCoroutine(LayEggsAndDie());
                break;
            case "Kiroster":
                StartCoroutine(PerishKiroster());
                break;
        }
    }

    private IEnumerator HatchEgg()
    {
        float hatchTime = 10f;
        yield return new WaitForSeconds(hatchTime);

        counter.eggCount--;
        gameManager.SpawnChick(transform.position + Vector3.up * 0.5f);
        Debug.Log("GG! EGG leveled up to TWEET TWEET(CHICK).");
        Destroy(gameObject);
    }

    private IEnumerator MatureChick()
    {
        float matureTime = 10f;
        yield return new WaitForSeconds(matureTime);

        counter.chickCount--;

        if (!firstChickMatured)
        {
            firstChickMatured = true;
            gameManager.SpawnHen(transform.position + Vector3.up * 0.5f);
            Debug.Log("First TWEET TWEET(CHICK) has upgraded to PAKOK(HEN).");
        }
        else
        {
            if (Random.value > 0.5f)
            {
                gameManager.SpawnHen(transform.position + Vector3.up * 0.5f);
                Debug.Log("TWEET TWEET(CHICK) has upgraded to PAKOK(HEN).");
            }
            else
            {
                gameManager.SpawnKiroster(transform.position + Vector3.up * 0.5f);
                Debug.Log("TWEET TWEET(CHICK) has upgraded to KIROSTER.");
            }
        }
        Destroy(gameObject);
    }

    private IEnumerator LayEggsAndDie()
    {
        float layEggsTime = 30f;
        yield return new WaitForSeconds(layEggsTime);

        int numberOfEggs = Random.Range(2, 11);
        for (int i = 0; i < numberOfEggs; i++)
        {
            StartCoroutine(gameManager.SpawnEggWithDelay(i * 0.5f));
            Debug.Log("EGG has entered the world.");
        }

        float perishTime = 10f; // Remaining time to perish after laying eggs
        yield return new WaitForSeconds(perishTime);

        counter.henCount--;
        Debug.Log("PAKOK has QUIT.");
        Destroy(gameObject);
    }

    private IEnumerator PerishKiroster()
    {
        float perishTime = 40f;
        yield return new WaitForSeconds(perishTime);

        counter.kirosterCount--;
        Debug.Log("KIROSTER was slayed by air.");
        Destroy(gameObject);
    }
}

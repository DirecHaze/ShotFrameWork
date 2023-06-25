using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : Singleton<UiManager>
{
    // Start is called before the first frame update
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverScoreText;
    [SerializeField]
    private Text _BotCount;
    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private Text _badGameOverText;
    [SerializeField]
    private Text _goodGameOverText;
    [SerializeField]
    private Image _crossHire;
    
 
   
    public override void function()
    {
        base.function();
        
    }
  
    public void Score(int Points)
    {
        _scoreText.text = "Score: " + Points;
      

        _gameOverScoreText.text = "Score: " + Points;
        
    }
    public void BotCount(int Count)
    {
        _BotCount.text = "Enemy: " + Count;
    }
   
   
    public void BadGameOver()
    {
       
        _scoreText.transform.gameObject.SetActive(false);
        _crossHire.transform.gameObject.SetActive(false);
        _BotCount.transform.gameObject.SetActive(false);
        _gameOverScoreText.transform.gameObject.SetActive(true);
        StartCoroutine(BadGameOverText());
        
    }
    public void GoodGameOver()
    {
        
        _scoreText.transform.gameObject.SetActive(false);
        _crossHire.transform.gameObject.SetActive(false);
        _BotCount.transform.gameObject.SetActive(false);
        _gameOverScoreText.transform.gameObject.SetActive(true);
        StartCoroutine(GoodGameOverText());

    }
    public void timer(float Timer)
    {
       
        float minutes = Mathf.FloorToInt(Timer / 60);
        float secound = Mathf.FloorToInt(Timer % 60);
        _timerText.text = minutes + " : " + secound; 
    }
    IEnumerator GoodGameOverText()
    {
        while (true)
        {

            _goodGameOverText.transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _goodGameOverText.transform.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);

        }
    }
    IEnumerator BadGameOverText()
    {
        while (true)
        {

            _badGameOverText.transform.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _badGameOverText.transform.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}

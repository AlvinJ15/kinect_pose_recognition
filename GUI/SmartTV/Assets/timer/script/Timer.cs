using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public int timeLeft = 5;
	public Text countdownText;
	public Text timer;
	public Image fillImg;
	float timeAmt = 10;
	GameObject childimagen;

	// Use this for initialization
	void Start(){
		childimagen = transform.FindChild ("Ejercicio").gameObject;
		cargarImagen ("hombroIzquierdo");
		//fillImg = this.GetComponent<Image>();
		StartCoroutine("LoseTime");

	}

	// Update is called once per frame
	void Update()
	{
		countdownText.text = (timeLeft + " ");
		fillImg.fillAmount = timeLeft / timeAmt;
		if (timeLeft<= 0)
		{
			StopCoroutine("LoseTime");
			countdownText.text = "PLAY";
			Application.LoadLevel("tizen Setting");
		}
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}

	public void cargarImagen(string str){
		//Image UIImage = newObject.AddComponent<Image>();
		Image UIImage = childimagen.GetComponent<Image>();
		UIImage.sprite = Resources.Load<Sprite> ("Imagen/"+str) as Sprite;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatorController : MonoBehaviour {

	Animator anim;
	public int timeLeft = 10;
	public Text countdownText;
	public Text timer;
	public int  time = 5;
	private int temptime;
	private int temptimeLeft;
	private int i ;
	//string[] rutina = { "hombroIzquierdo", };
	string [] rutina = { "hombroIzquierdo", "hombroDerecho", "cuelloIzquierdo", "cuelloDerecho", "sentadilla", "rana" }; 


	void Start () {
		anim = GetComponent<Animator> ();
		anim.Play ("idle");
		//StartCoroutine (Wait());
		StartCoroutine("LoseTime");
		countdownText.enabled = false;
		temptime = time;
		temptimeLeft = timeLeft;
		i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		countdownText.text = (temptimeLeft + " ");
		timer.text = (temptime + " ");
		anim.Play (rutina [i]);
		if (temptime <= 0)
		{
			StopCoroutine("LoseTime");
			timer.text = "PLAY";
			StartCoroutine("LoseTime2");
			temptime = time;
			timer.enabled = false;
			countdownText.enabled = true;
		}
		if (temptimeLeft <= 0) {
			StopCoroutine ("LoseTime2");
			temptimeLeft = timeLeft;
			timer.enabled = true;
			countdownText.enabled = false;
			StartCoroutine ("LoseTime");
			i = i + 1;


		} 
		//else {
			
		//}
		if(i == rutina.Length){
			StopCoroutine("LoseTime");
			StopCoroutine("LoseTime2");
			timer.text = "FINAL";
			Application.LoadLevel("menu");
		}

	}
	IEnumerator verificar(){
		WWW getresult = new WWW ("localhost:54744/api/posture/validar/"+rutina[i]);
		yield return getresult;
	}
	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			temptime--;
		}
	}
	IEnumerator LoseTime2()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			temptimeLeft--;
		}
	}
}

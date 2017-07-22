using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AnimatorController : MonoBehaviour {

	Animator anim;
	GameObject  render;
	public int timeLeft = 10;
	public Text countdownText;
	public Text timer;
	public int  time = 5;
	private int temptime;
	private int temptimeLeft;
	private int i ;
	private bool flagCourtine;

	bool str= true;
	int t = 1;

	public Text servicio;
	//string[] rutina = { "hombroIzquierdo", };
	string [] rutina = { "hombroIzquierdo", "hombroDerecho", "cuelloIzquierdo", "cuelloDerecho", "sentadilla", "rana" }; 


	void Start () {
		anim = GetComponent<Animator> ();
		render = GameObject.Find("GenericHuman");
		anim.Play ("idle");
		StartCoroutine("LoseTime");
		countdownText.enabled = false;
		servicio.enabled = false;
		temptime = time;
		temptimeLeft = timeLeft;
		i = 0;
		flagCourtine = true;
	}
	
	// Update is called once per frame
	void Update () {
		countdownText.text = (temptimeLeft + " ");
		timer.text = (temptime + " ");
		anim.Play (rutina [i]);
		if (temptime <= 0){
			render.GetComponent<Renderer> ().material.color = Color.white;
			//StopCoroutine ("verificar");
			StopCoroutine("LoseTime");
			timer.text = "PLAY";
			StartCoroutine("LoseTime2");
			temptime = time;
			timer.enabled = false;
			countdownText.enabled = true;
		}
		if (temptimeLeft <= 0) {
			StopCoroutine ("LoseTime2");
			StopCoroutine ("verificar");
			render.GetComponent<Renderer> ().material.color = Color.white;
			temptimeLeft = timeLeft;
			timer.enabled = true;
			countdownText.enabled = false;
			servicio.enabled = false;
			i = i + 1;
			StartCoroutine ("LoseTime");
		} 
		if(i == rutina.Length){
			StopCoroutine("LoseTime");
			StopCoroutine("LoseTime2");
			StopCoroutine ("verificar");
			timer.text = "FINAL";
			Application.LoadLevel("menu");
		}

	}
	IEnumerator verificar(){
		servicio.enabled = true;
		//WWW getresult = new WWW ("http://localhost/smartTv/extraerImagen.php");;
			
		WWW getresult = new WWW ("http://localhost:54744/api/posture/validar/" + rutina [i]);
		yield return getresult;
		string data = getresult.text.Trim ();
		data = "Tru";
		servicio.text = data;
		render.GetComponent<Renderer> ().material.color = Color.green;

		if (data.Contains ("True")) {
			render.GetComponent<Renderer> ().material.color = Color.green;
		} else {
			render.GetComponent<Renderer> ().material.color = Color.red;
			StopCoroutine ("LoseTime2");
			StopCoroutine ("verificar");
			while(true){
				getresult = new WWW ("http://localhost:54744/api/posture/validar/" + rutina [i]);
				yield return getresult;
				data = getresult.text.Trim ();
				if (data.Contains ("True")) {
					StartCoroutine ("LoseTime2");
					break;
				}
			}

		}
	}

	IEnumerator LoseTime(){
		while (true){
			yield return new WaitForSeconds(1);
			temptime--;
		}
	}
	IEnumerator LoseTime2(){
		while (true){
			StartCoroutine ("verificar");
			yield return new WaitForSeconds(1);
			temptimeLeft--;
		}
	}
	IEnumerator tiempoVerificar(){
		WWW getresult = new WWW ("http://localhost:54744/api/posture/validar/" + rutina [i]);
		yield return getresult;
	}
}

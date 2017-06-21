using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class CargarImagenes : MonoBehaviour{
	//public Image UIImage;
	public Canvas menuSeleccionRuntina;
	//public float width = 200;
	//public float height = 200;
	Image UIImage;
	public Text data;
	GameObject newObject;
	public string URLgetData = "http://localhost/smartTv/extraerImagen.php";
	// Use this for initialization
	/*void Start ()
	{
		

		newObject = new GameObject("Imagen");
		RectTransform rectTransform = newObject.AddComponent<RectTransform>();
		rectTransform.sizeDelta = new Vector2(300, 300);
		newObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

		Image UIImage = newObject.AddComponent<Image>();

		UIImage.sprite = Resources.Load<Sprite> ("Imagen/EJER1") as Sprite;


		UIImage.transform.SetParent (menuSeleccionRuntina.transform);

	}
	
	// Update is called once per frame
	void Update ()
	{
		//Destroy (newObject);
	} */
	public void recibir(){
		StartCoroutine ("LoadImage");	
	}
	private IEnumerator LoadImage(){
		newObject = new GameObject("Imagen");
		//RectTransform rectTransform = newObject.AddComponent<RectTransform>();
		//rectTransform.sizeDelta = new Vector2(300, 300);
		//newObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

		Image UIImage = newObject.AddComponent<Image>();
		WWW getImagen = new WWW (URLgetData);
		yield return getImagen;
		Sprite imag = Base64ToImage(getImagen);
		UIImage.transform.SetParent (menuSeleccionRuntina.transform);
		/*newObject.AddComponent<SpriteRenderer>();
		SpriteRenderer sprRenderer = newObject.GetComponent<SpriteRenderer>();
		sprRenderer.sprite = imag;
		*/
		UIImage.sprite = imag;
		//data.text = getImagen.text;
		//Debug.Log(getImagen.text);
	}
	/*private IEnumerator LoadName(){
		string URLgetData = "http://localhost/smartTv/extraerImagen.php";
		Debug.Log ("OLAS");
		Debug.Log (URLgetData);
		WWW getImagen = new WWW (URLgetData);
		yield return getImagen;
		data.text = getImagen.text;
		Debug.Log (getImagen.text);
	}*/
	public Sprite Base64ToImage(WWW www){
		byte[] Bytes = www.bytes;
		Texture2D tex = new Texture2D (500, 700);
		tex.LoadImage (Bytes);
		Rect rect = new Rect(0, 0, tex.width, tex.height);
		Sprite sprite = Sprite.Create (www.texture, rect, new Vector2() , 100f);
		return sprite;
	}
}


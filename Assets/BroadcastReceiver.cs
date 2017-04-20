using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BroadcastReceiver : MonoBehaviour
{
	AndroidJavaClass jc;
	string javaMessage = "";
	Text text;
	public GameObject sphere;
	float scale;

	void Start()
	{
		scale = sphere.transform.localScale.x;
		text = GetComponent<Text> ();
		// Acces the android java receiver we made
		jc = new AndroidJavaClass("com.gordey.receiveplugin.MyReceiver");
		// We call our java class function to create our MyReceiver java object
		jc.CallStatic("createInstance");       
	}

	void Update()
	{      
		// We get the text property of our receiver
		javaMessage = jc.GetStatic<string>("text");
		text.text = "airflow data : " + javaMessage;

		float airflow = float.Parse(javaMessage);
		float newScale = airflow.Map (0, 600, scale, 50);

		sphere.transform.localScale = new Vector3 (newScale, newScale, newScale);

	}
}
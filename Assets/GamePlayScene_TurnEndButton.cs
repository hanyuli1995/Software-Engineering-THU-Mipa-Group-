using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlayScene_TurnEndButton :MonoBehaviour
{
	
	void OnMouseDown()
	{
		if(GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().ifsuspend)
			return;
		GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().TurnChange();
		StartCoroutine(ButtonInside());
	}

//ʹ��ť����1��
	private IEnumerator ButtonInside()
	{
		transform.Translate(0,0,-40);
		yield return new WaitForSeconds(1);
		transform.Translate(0,0,40);
	}
}
using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
	#region Singleton
	public static GameEvents instance;

	private void Awake()
	{
		instance = this;
	}
	#endregion

	//public event Action<Food> OnPickUpFood;
	//public void PickUpFoodEvent(Food food)
	//{
	//	if(OnPickUpFood != null)
	//	{
	//		Debug.Log("OnPickUpFood");
	//		OnPickUpFood.Invoke(food);
	//	}
	//}

	
}
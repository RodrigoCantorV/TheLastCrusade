using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
	protected float baseAtack;
	protected float speed;
	protected float life;

	public abstract void RightAtack();
	public abstract void LeftAtack();
	public abstract void SuperPower();
	public abstract void Dash();

	public float getSpeed()
	{
		return speed;
	}
}

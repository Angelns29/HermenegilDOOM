using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
	public interface IDamageable
	{
		void TakeDamage(float damage);
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TcGame
{
	public class Timer
	{
		public Action OnTime;
		public float Time = 5.0f;
		private float acumTime;

		public void Update(float dt)
		{
			acumTime += dt;
			if (acumTime >= Time)
			{
				OnTime.Invoke();
				acumTime = 0.0f;
			}
		}
	}
}

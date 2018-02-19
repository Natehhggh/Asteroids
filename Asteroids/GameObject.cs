using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Asteroids
{
	



	abstract class GameObject
	{
		private int xPos;	
		private int yPos;
		private int hitBoxRadius;
		private Vector velocity;


		virtual public void UpdatePostion()
		{

		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPTConsole.Model
{
	public partial class Sentient
	{
		public virtual string Describe()
		{
			return String.Format("This being's name is {0}.", Name);
		}
	}
}

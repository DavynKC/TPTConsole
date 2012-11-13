using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPTConsole.Model
{
	public partial class Droid
	{
		public override string Describe()
		{
			return String.Format("{0} It is a {1} droid.", base.Describe(), DroidType);
		}
	}
}

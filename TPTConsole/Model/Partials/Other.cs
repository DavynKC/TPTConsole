using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPTConsole.Model
{
	public partial class Other
	{
		public override string Describe()
		{
			return String.Format("{0} {1}'s a {2}.", base.Describe(), IsMale ?? true ? "He" : "She", Title);
		}
	}
}

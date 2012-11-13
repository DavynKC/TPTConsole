using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPTConsole.Model
{
	public partial class Jedi
	{
		public override string Describe()
		{
			return String.Format("{0} This jedi has a {1} lightsaber and a midichlorian count of {2}.{3}", base.Describe(), LightsaberColor, MidichlorianCount, MidichlorianCount > 9000 ? " It's over 9000!" : String.Empty);
		}
	}
}

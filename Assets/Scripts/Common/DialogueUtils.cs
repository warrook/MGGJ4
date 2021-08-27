using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Common
{
	public class DialogueUtils
	{
		public static class Colors
		{
			public static ColorPair FloraHeart => new ColorPair(new Color(0.376f, 0.007f, 0.047f), new Color(1f, 0.356f, 0.584f));
			public static ColorPair FloraMaypop => new ColorPair(new Color(0.894f, 0.968f, 0.427f), new Color(0.415f, 0.227f, 0.501f));
			public static ColorPair FloraParadise => new ColorPair(new Color(0.949f, 0.811f, 0.062f), new Color(0.301f, 0.266f, 0.8f));

			public static Dictionary<string, ColorPair> CharacterColors => new Dictionary<string, ColorPair>()
			{
				{ "flora-heart", FloraHeart },
				{ "flora-maypop", FloraMaypop },
				{ "flora-paradise", FloraParadise }
			};

			public class ColorPair : Tuple<Color, Color>
			{
				public ColorPair(Color primary, Color secondary) : base(primary, secondary) { }
				public Color Primary() => this.Item1;
				public Color Secondary() => this.Item2;
			}
		}
	}
}

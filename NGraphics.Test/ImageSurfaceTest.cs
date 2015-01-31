﻿using NUnit.Framework;
using System;
using NGraphics;
using System.Diagnostics;

namespace NGraphics.Test
{
	public class PlatformTest
	{
		public static class Platforms
		{
			public static IPlatform Current { get { return PlatformTest.Platform; } }
		}

		public static IPlatform Platform = new NullPlatform ();

		public static string ResultsDirectory = "";
		public static string GetPath (string filename)
		{
			var name = (filename.EndsWith (".png")) ?
				System.IO.Path.GetFileNameWithoutExtension (filename) :
				filename;
			var path = System.IO.Path.Combine (ResultsDirectory, name + "-" + Platform.Name + ".png");
			Debug.WriteLine (path);
			return path;
		}
	}

	[TestFixture]
	public class ImageSurfaceTest : PlatformTest
	{
		[Test]
		public void Ellipse ()
		{
			var p = Platform;
			var s = p.CreateImageCanvas (new Size (100));
			s.DrawEllipse (new Point (10, 20), new Size (30, 40), Pens.Red.WithWidth (10), Brushes.Yellow);
			var i = s.GetImage ();
			var path = GetPath ("Ellipse");
			i.SaveAsPng (path);
//			System.Diagnostics.Process.Start ("open", "\"" + path + "\"");
		}
	}
}


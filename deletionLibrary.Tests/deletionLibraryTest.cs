using NUnit.Framework;
using System;
using deletionLibrary;

namespace deletionLibrary.Tests
{
	[TestFixture ()]
	public class deletionLibraryTest
	{
		[Test ()]
		public void goHomeTest ()
		{
			// NAVIGATE TO THE CURRENT USER'S HOME FOLDER
			string homePath = Environment.GetEnvironmentVariable ("HOME");
			Environment.CurrentDirectory = homePath;

			// ENSURE THE CORRECT PATH TO WORK FROM HAS BEEN LOADED
			Assert.AreEqual (Environment.CurrentDirectory, homePath);
		}
	}
}

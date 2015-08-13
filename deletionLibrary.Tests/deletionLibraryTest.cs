using NUnit.Framework;
using System;
using System.IO;

namespace deletionLibrary.Tests
{
	[TestFixture ()]
	public class deletionLibraryTest
	{
		// #############################################################################
		// MAIN TEST VARIABLES
		// #############################################################################

		#region mainTestVariables

		const string TESTFILE = ".test_file";
		const string TESTSTRING = "Hello World!";

		#endregion

		// #############################################################################
		// MAIN UNIT TESTS
		// #############################################################################

		#region mainUnitTests

		[Test ()]
		public void goHomeTest ()
		{
			// NAVIGATE TO THE CURRENT USER'S HOME FOLDER
			string homePath = Environment.GetEnvironmentVariable ("HOME");
			Environment.CurrentDirectory = homePath;

			// ENSURE THE CORRECT PATH TO WORK FROM HAS BEEN LOADED
			Assert.AreEqual (Environment.CurrentDirectory, homePath);
		}

		[Test ()]
		public void manageFileTest ()
		{
			// NAVIGATE TO THE CURRENT USER'S HOME FOLDER
			goHomeTest ();

			// CREATE THE TESTFILE IF NOT EXISTS AND INPUT A STRING
			File.WriteAllText (TESTFILE, TESTSTRING);

			// MAKE SURE FILE HAS HAD TESTSTRING WRITTEN
			Assert.True (new FileInfo (TESTFILE).Length > 0);

			// CREATE THE TESTFILE IF NOT EXISTS AND CLEAR ALL TEXT
			File.WriteAllText (TESTFILE, string.Empty);

			// MAKE SURE FILE HAS BEEN CLEARED OF ALL TEXT
			Assert.True (new FileInfo (TESTFILE).Length == 0);

			// DELETE THE FILE
			File.Delete (TESTFILE);

			// ENSURE FILE HAS BEEN DELETED
			Assert.False (File.Exists (TESTFILE));
		}

		#endregion
	}
}

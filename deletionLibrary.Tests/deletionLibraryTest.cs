using NUnit.Framework;
using System;
using System.IO;

namespace deletionLibrary.Tests
{
	[TestFixture ()]
	public class deletionLibraryTest
	{
		// #####################################################################
		// MAIN TEST VARIABLES
		// #####################################################################

		#region mainTestVariables

		const string TEST_FILE = ".test_file";
		const string TEST_STRING = "Hello World!";

		#endregion

		// #####################################################################
		// MAIN UNIT TESTS
		// #####################################################################

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
		public void createFileTest ()
		{
			// NAVIGATE TO THE CURRENT USER'S HOME FOLDER
			string homePath = Environment.GetEnvironmentVariable ("HOME");
			Environment.CurrentDirectory = homePath;

			// CREATE THE TESTFILE IF NOT EXISTS AND CLEAR ALL TEXT
			File.WriteAllText (TEST_FILE, string.Empty);

			// MAKE SURE FILE HAS BEEN CLEARED OF ALL TEXT
			Assert.True (new FileInfo (TEST_FILE).Length == 0);

			// DELETE THE FILE
			File.Delete (TEST_FILE);
		}

		[Test ()]
		public void writeToFileTest ()
		{
			// NAVIGATE TO THE CURRENT USER'S HOME FOLDER
			string homePath = Environment.GetEnvironmentVariable ("HOME");
			Environment.CurrentDirectory = homePath;

			// CREATE THE TESTFILE IF NOT EXISTS AND INPUT A STRING
			File.WriteAllText (TEST_FILE, TEST_STRING);

			// MAKE SURE FILE HAS HAD TESTSTRING WRITTEN TO IT
			Assert.True (new FileInfo (TEST_FILE).Length > 0);

			// DELETE THE FILE
			File.Delete (TEST_FILE);
		}

		[Test ()]
		public void deleteFileContentTest ()
		{
			// NAVIGATE TO THE CURRENT USER'S HOME FOLDER
			string homePath = Environment.GetEnvironmentVariable ("HOME");
			Environment.CurrentDirectory = homePath;

			// CREATE THE TESTFILE IF NOT EXISTS AND INPUT A STRING
			File.WriteAllText (TEST_FILE, TEST_STRING);

			// DELETE ALL TEXT FROM THE 'TESTFILE'
			File.WriteAllText (TEST_FILE, string.Empty);

			// MAKE SURE FILE HAS HAD TESTSTRING ERASED FROM IT
			Assert.True (new FileInfo (TEST_FILE).Length == 0);

			// DELETE THE FILE
			File.Delete (TEST_FILE);
		}

		[Test ()]
		public void deleteFileTest ()
		{
			// NAVIGATE TO THE CURRENT USER'S HOME FOLDER
			string homePath = Environment.GetEnvironmentVariable ("HOME");
			Environment.CurrentDirectory = homePath;

			// CREATE AND THEN DELETE THE 'TESTFILE'
			File.WriteAllText (TEST_FILE, string.Empty);

			// DELETE THE FILE
			File.Delete (TEST_FILE);

			// ENSURE FILE HAS BEEN DELETED
			Assert.False (File.Exists (TEST_FILE));
		}

		#endregion

	}
}
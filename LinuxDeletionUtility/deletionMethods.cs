using System;
using System.Diagnostics;
using System.IO;

namespace LinuxDeletionUtility
{
	public class deletionMethods
	{
		// #############################################################################
		// MAIN DELETION FUNCTIONS
		// #############################################################################

		#region mainDeletionFunctions

		public static void changeToHome ()
		{
			string homePath = Environment.GetEnvironmentVariable ("HOME");
			Environment.CurrentDirectory = homePath;
		}

		public static void deleteFiles (string path)
		{
			DirectoryInfo deletionTarget = new DirectoryInfo (path);

			foreach (FileInfo file in deletionTarget.GetFiles()) {
				file.Delete (); 
			}

			foreach (DirectoryInfo directory in deletionTarget.GetDirectories()) {
				directory.Delete (true); 
			}
		}

		#endregion

		// #############################################################################
		// HOME FOLDER DELETION FUNCTIONS
		// #############################################################################

		#region homeFolderDeletionFunctions

		public static void cleanMostRecentlyUsed ()
		{
			// Insert Cleaner code here.
		}

		public static void cleanCommandLineHistory ()
		{
			// Insert Cleaner code here.
		}

		public static void cleanWastebasket ()
		{
			// Insert Cleaner code here.
		}

		public static void cleanImageThumbnails ()
		{
			changeToHome ();
			string imageThumbnailPath = @".cache/thumbnails";
			deleteFiles (imageThumbnailPath);
		}

		#endregion
	}
}

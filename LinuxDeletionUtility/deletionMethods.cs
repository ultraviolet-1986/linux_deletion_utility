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

		// WARNING: ALTERING THESE VALUES WILL DAMAGE YOUR SYSTEM
		const string RECENT = @".local/share/recently-used.xbel";
		const string TERM = ".bash_history";
		const string TRASH = @".local/share/Trash";
		const string THUMBS = @".cache/thumbnails";

		public static void goHome ()
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
			goHome ();
			File.Delete (RECENT);
		}

		public static void cleanCommandLineHistory ()
		{
			goHome ();
			File.Delete (TERM);
		}

		public static void cleanWastebasket ()
		{
			goHome ();
			deleteFiles (TRASH);
		}

		public static void cleanImageThumbnails ()
		{
			goHome ();
			deleteFiles (THUMBS);
		}

		#endregion
	}
}

using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace LinuxDeletionUtility
{
	public class deletionLibrary
	{
		// #############################################################################
		// MAIN DELETION VARIABLES
		// #############################################################################

		#region mainDeletionVariables

		// WARNING: ALTERING THESE VALUES WILL DAMAGE YOUR SYSTEM
		const string RECENT_GTK = @".local/share/recently-used.xbel";
		const string RECENT_QT = @".kde/share/apps/RecentDocuments";
		const string TERM = ".bash_history";
		const string TRASH = @".local/share/Trash";
		const string THUMBS_GTK = @".cache/thumbnails";
		const string THUMBS_QT = @".thumbnails";

		#endregion

		// #############################################################################
		// MAIN DELETION FUNCTIONS
		// #############################################################################

		#region mainDeletionFunctions

		public static void goHome ()
		{
			string homePath = Environment.GetEnvironmentVariable ("HOME");
			Environment.CurrentDirectory = homePath;
		}

		public static void deleteFiles (string path)
		{
			DirectoryInfo deletionTarget = new DirectoryInfo (path);

			foreach (FileInfo file in deletionTarget.GetFiles())
			{
				file.Delete (); 
			}

			foreach (DirectoryInfo directory in deletionTarget.GetDirectories())
			{
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

			// USING GNOME OR COMPATIBLE DESKTOP
			if (File.Exists(RECENT_GTK))
			{
				File.WriteAllText (RECENT_GTK, string.Empty);
			}

			// USING KDE OR COMPATIBLE DESKTOP
			if (Directory.Exists(RECENT_QT))
			{
				if (Directory.GetFiles(RECENT_QT).Length > 0)
				{
					deleteFiles(RECENT_QT);
				}
			}
		}

		public static void cleanCommandLineHistory ()
		{
			goHome ();
			File.WriteAllText (TERM, string.Empty);
		}

		public static void cleanWastebasket ()
		{
			goHome ();

			if (Directory.GetFiles (TRASH).Length > 0)
			{
				deleteFiles (TRASH);
			}
		}

		public static void cleanImageThumbnails ()
		{
			goHome ();

			// USING GNOME OR COMPATIBLE DESKTOP
			if (Directory.Exists (THUMBS_GTK))
			{
				if (Directory.GetFiles (THUMBS_GTK).Length > 0)
				{
					deleteFiles (THUMBS_GTK);
				}
			}

			// USING KDE OR COMPATIBLE DESKTOP
			if (Directory.Exists (THUMBS_QT))
			{
				if (Directory.GetDirectories(THUMBS_QT).Length > 0)
				{
					deleteFiles(THUMBS_QT);
				}
			}
		}

		#endregion
	}
}

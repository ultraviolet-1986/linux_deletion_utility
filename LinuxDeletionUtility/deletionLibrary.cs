using System;
using System.Diagnostics;
using System.IO;

namespace LinuxDeletionUtility
{
	public class deletionLibrary
	{
		/// <summary>
		///	This class is composed of several methods which are used to delete
		/// certain 'junk' items. It is written with several desktop paradigms
		/// in mind such as GNOME and KDE as well as their derivatives and
		/// compatible counterparts. Because some applications can generate
		/// GNOME/KDE files and folders, this application will not detect and
		/// operate according to one desktop paradigm only, it will delete what
		/// it finds regardless of system configuration.
		/// </summary>
		
		// #####################################################################
		// MAIN DELETION VARIABLES
		// #####################################################################

		#region mainDeletionVariables

		// WARNING: ALTERING THESE VALUES WILL DAMAGE YOUR SYSTEM
		const string RECENT_GTK = @".local/share/recently-used.xbel";
		const string RECENT_QT = @".kde/share/apps/RecentDocuments";
		const string TERM = ".bash_history";
		const string TRASH = @".local/share/Trash";
		const string THUMBS_GTK = @".cache/thumbnails";
		const string THUMBS_QT = @".thumbnails";

		#endregion

		// #####################################################################
		// MAIN DELETION FUNCTIONS
		// #####################################################################

		#region mainDeletionFunctions

		public static void goHome ()
		{
			/// <summary>
			/// This method is integral to all others within this class; without
			/// it, the following deletion methods will not function correctly,
			/// if at all. All of the directories/files to be deleted by this
			/// library exist within the user's 'Home' folder.
			/// </summary>

			string homePath = Environment.GetEnvironmentVariable ("HOME");
			Environment.CurrentDirectory = homePath;
		}

		public static void deleteFiles (string path)
		{
			/// <summary>
			/// This method takes a parameter called 'path' and will delete all
			/// files and directories within the passed 'path' parameter. This
			/// function is useful when deleting collections of files and
			/// directories - an example of this function at work lies in the
			/// 'cleanImageThumbnails' and 'cleanWastebasket' methods where many
			/// files can gather.
			/// </summary>

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

		// #####################################################################
		// HOME FOLDER DELETION FUNCTIONS
		// #####################################################################

		#region homeFolderDeletionFunctions

		public static void cleanMostRecentlyUsed ()
		{
			/// <summary>
			/// This method will not simply delete the file, as would seem
			/// logical; in practice, this does not perform the desired
			/// behaviour. To achieve the desired results, the contents of the
			/// file are to be deleted, leaving the original file intact. This
			/// approach is more efficient and far less disruptive to the system
			/// than the initial approach. This method also allows for alternate
			/// desktop configurations.
			/// </summary>

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
			/// <summary>
			/// This method will function in the same manner on every known
			/// desktop. Because all known Terminal emulators store their
			/// history in the same file, only the contents of the file need be
			/// erased. This is similar to the 'cleanMostRecentlyUsed' method.
			/// This will not test if the file is empty, it will erase the
			/// contents if the file exists.
			/// </summary>

			goHome ();

			if (File.Exists(TERM))
			{
				File.WriteAllText (TERM, string.Empty);
			}
		}

		public static void cleanWastebasket ()
		{
			/// <summary>
			/// This method will check for files and folders inside the user's
			/// Trash/Wastebasket and delete them all. If this method does not
			/// discover any files or directories in the Trash/Wastebasket, it
			/// will not delete them. This method will function on all desktop
			/// paradigms.
			/// </summary>

			goHome ();

			if (Directory.GetFiles (TRASH).Length > 0 ||
				Directory.GetDirectories(TRASH).Length > 0)
			{
				deleteFiles (TRASH);
			}
		}

		public static void cleanImageThumbnails ()
		{
			/// <summary>
			/// This method will delete any and all thumbnails found inside the
			/// image thumbnail cache. This will delete any thumbnails generated
			/// by either a GNOME or KDE application and so will operate on any
			/// desktop currently being ran by the user.
			/// </summary>

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
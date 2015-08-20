using Gdk;
using Gtk;
using LinuxDeletionUtility;
using System;

public partial class frmMain: Gtk.Window
{
	// #########################################################################
	// MAIN FORM VARIABLES
	// #########################################################################

	#region mainFormVariables

	// THIS VARIABLE WILL ALWAYS CONTAIN THE NAME OF THE USER'S DESKTOP PARADIGM
	readonly string desktopName = Environment.GetEnvironmentVariable ("DESKTOP_SESSION");

	#endregion

	// #########################################################################
	// MAIN FORM FUNCTIONS
	// #########################################################################

	#region mainFormFunctions

	public frmMain () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		resetApplication ();
		appendToFormTitle (desktopName);
	}

	public void appendToFormTitle (string d)
	{
		Title = Title + " (" + d.ToUpper() + " Desktop)";
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	#endregion

	// #########################################################################
	// ADDITIONAL FORM FUNCTIONS
	// #########################################################################

	#region additionalFormFunctions

	public void resetApplication ()
	{
		/// <summary>
		/// This method contains all of the defaults which should be loaded when
		/// the application is launched. These values should all be 'cleared',
		/// this means that the application can be configured from scratch each
		/// time it is started.
		/// </summary>

		noteMain.CurrentPage = 0;

		txtConsole.Buffer.Clear ();

		chkMostRecentlyUsed.Active = false;
		chkCommandLineHistory.Active = false;
		chkWastebasket.Active = false;
		chkImageThumbnails.Active = false;
	}

	public void checkboxEnabled (bool state)
	{
		/// <summary>
		/// This method contains the 'state' of the application's checkboxes, a
		/// parameter called 'state' can be passed to determine whether or not
		/// all of the checkboxes are active - this should be set to 'false'
		/// during the execution of tasks, they can be re-enabled once the tasks
		/// are complete by passing the parameter 'true'.
		/// </summary>

		chkMostRecentlyUsed.Sensitive = state;
		chkCommandLineHistory.Sensitive = state;
		chkWastebasket.Sensitive = state;
		chkImageThumbnails.Sensitive = state;
	}

	public void performTask ()
	{
		/// <summary>
		/// This method checks the state of all of the checkboxes and performs
		/// the 'clean' operation depending on boxes which are 'checked'.
		/// </summary>

		checkboxEnabled (false);

		txtConsole.Buffer.Clear ();

		if (chkMostRecentlyUsed.Active == true)
		{
			txtConsole.Buffer.InsertAtCursor ("Now cleaning Most Recently Used list...\n");
			deletionLibrary.cleanMostRecentlyUsed ();
			txtConsole.Buffer.InsertAtCursor ("Most Recently Used list is now clean.\n\n");
		}

		if (chkCommandLineHistory.Active == true)
		{
			txtConsole.Buffer.InsertAtCursor ("Now cleaning Command Line history...\n");
			deletionLibrary.cleanCommandLineHistory ();
			txtConsole.Buffer.InsertAtCursor ("Command Line history is now clean.\n\n");
		}

		if (chkWastebasket.Active == true)
		{
			txtConsole.Buffer.InsertAtCursor ("Now cleaning Wastebasket / Trash contents...\n");
			deletionLibrary.cleanWastebasket ();
			txtConsole.Buffer.InsertAtCursor ("Wastebasket / Trash is now clean.\n\n");
		}

		if (chkImageThumbnails.Active == true)
		{
			txtConsole.Buffer.InsertAtCursor ("Now cleaning Image Thumbnail cache...\n");
			deletionLibrary.cleanImageThumbnails ();
			txtConsole.Buffer.InsertAtCursor ("Image Thumbnail cache is now clean.\n\n");
		}

		checkboxEnabled (true);
	}

	#endregion

	// #########################################################################
	// CLICK EVENTS
	// #########################################################################

	#region clickEvents

	// MENU STRIP CLICK EVENTS -------------------------------------------------

	protected void menuExit_Click (object sender, EventArgs e)
	{
		Application.Quit ();
	}

	public void menuAbout_Click (object sender, EventArgs e)
	{
		/// <summary>
		/// This method contains the 'About' screen, it contains the details of
		/// the application's name, that of the author, version number, website,
		/// etc... At this time, this item does not have its own icon and the
		/// code related to this below has been commented out for the time
		/// being.
		/// </summary>

		AboutDialog about = new AboutDialog ();
		about.ProgramName = "Linux Deletion Utility";
		about.Version = "0.1";
		about.Copyright = "(c) William Willis Whinn";
		about.Comments = "This is a simple application to delete unnecessary files inside a user's Home folder.";
		about.Website = @"https://github.com/ultraviolet-1986/LinuxDeletionUtility";
		//about.Logo = new Gdk.Pixbuf ("gtk-execute.png");
		about.Run ();
		about.Destroy ();
	}

	// BUTTON CLICK EVENTS -----------------------------------------------------

	protected void btnClean_Click (object sender, EventArgs e)
	{
		/// <summary>
		/// This method contains the checks required to perform the cleaning
		/// task. Though cumbersome, the statement below is required to ensure
		/// that the user has chosen at least one option before the application
		/// will commence the cleaning operation.
		/// </summary>

		if (chkMostRecentlyUsed.Active == false &&
		    chkCommandLineHistory.Active == false &&
		    chkWastebasket.Active == false &&
		    chkImageThumbnails.Active == false)
		{
			txtConsole.Buffer.Clear ();
			txtConsole.Buffer.InsertAtCursor ("You have not selected any items to delete.");
		}
		else
		{
			performTask ();
		}
	}

	protected void btnReset_Click (object sender, EventArgs e)
	{
		resetApplication ();
	}

	#endregion

}
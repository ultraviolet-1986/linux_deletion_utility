using System;
using Gdk;
using Gtk;
using LinuxDeletionUtility;

public partial class frmMain: Gtk.Window
{
	// #############################################################################
	// MAIN FORM FUNCTIONS
	// #############################################################################

	#region mainFormFunctions

	public frmMain () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		resetApplication ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	#endregion

	// #############################################################################
	// ADDITIONAL FORM FUNCTIONS
	// #############################################################################

	#region additionalFormFunctions

	public void checkboxEnabled (bool state)
	{
		chkMostRecentlyUsed.Sensitive = state;
		chkCommandLineHistory.Sensitive = state;
		chkWastebasket.Sensitive = state;
		chkImageThumbnails.Sensitive = state;
	}

	public void resetApplication ()
	{
		noteMain.CurrentPage = 0;

		txtConsole.Buffer.Clear ();

		chkMostRecentlyUsed.Active = false;
		chkCommandLineHistory.Active = false;
		chkWastebasket.Active = false;
		chkImageThumbnails.Active = false;
	}

	public void performTask ()
	{
		checkboxEnabled (false);

		txtConsole.Buffer.Clear ();

		if (chkMostRecentlyUsed.Active == true) {
			txtConsole.Buffer.InsertAtCursor ("Now cleaning Most Recently Used list...\n");
			deletionLibrary.cleanMostRecentlyUsed ();
			txtConsole.Buffer.InsertAtCursor ("Most Recently Used list is now clean.\n\n");
		}

		if (chkCommandLineHistory.Active == true) {
			txtConsole.Buffer.InsertAtCursor ("Now cleaning Command Line history...\n");
			deletionLibrary.cleanCommandLineHistory ();
			txtConsole.Buffer.InsertAtCursor ("Command Line history is now clean.\n\n");
		}

		if (chkWastebasket.Active == true) {
			txtConsole.Buffer.InsertAtCursor ("Now cleaning Wastebasket / Trash contents...\n");
			deletionLibrary.cleanWastebasket ();
			txtConsole.Buffer.InsertAtCursor ("Wastebasket / Trash is now clean.\n\n");
		}

		if (chkImageThumbnails.Active == true) {
			txtConsole.Buffer.InsertAtCursor ("Now cleaning Image Thumbnail cache...\n");
			deletionLibrary.cleanImageThumbnails ();
			txtConsole.Buffer.InsertAtCursor ("Image Thumbnail cache is now clean.\n\n");
		}

		checkboxEnabled (true);
	}

	#endregion

	// #############################################################################
	// CLICK EVENTS
	// #############################################################################

	#region clickEvents

	// MENU ITEM CLICK EVENTS
	protected void menuExit_Click (object sender, EventArgs e)
	{
		Application.Quit ();
	}

	public void menuAbout_Click (object sender, EventArgs e)
	{
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

	// BUTTON CLICK EVENTS
	protected void btnClean_Click (object sender, EventArgs e)
	{
		if (chkMostRecentlyUsed.Active == false &&
		    chkCommandLineHistory.Active == false &&
		    chkWastebasket.Active == false &&
		    chkImageThumbnails.Active == false) {
			txtConsole.Buffer.Clear ();
			txtConsole.Buffer.InsertAtCursor ("You have not selected any items to delete.");
		} else {
			performTask ();
		}
	}

	protected void btnReset_Click (object sender, EventArgs e)
	{
		resetApplication ();
	}

	#endregion
}

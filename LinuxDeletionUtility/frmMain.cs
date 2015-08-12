using System;
using Gtk;

public partial class frmMain: Gtk.Window
{
	public frmMain () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		resetApplication ();
	}

	public void resetApplication()
	{
		// Clear application console.
		txtConsole.Buffer.Clear ();

		// Display the first page of the notebook.
		noteMain.CurrentPage = 0;

		// Clear all Home Folder checkboxes.
		chkMostRecentlyUsed.Active = false;
		chkCommandLineHistory.Active = false;
		chkWastebasket.Active = false;
		chkImageThumbnails.Active = false;
	}

	public void checkboxEnabled(bool state)
	{
		chkMostRecentlyUsed.Sensitive = state;
		chkCommandLineHistory.Sensitive = state;
		chkWastebasket.Sensitive = state;
		chkImageThumbnails.Sensitive = state;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void menuExit_Click (object sender, EventArgs e)
	{
		Application.Quit ();
	}

	protected void menuAbout_Click (object sender, EventArgs e)
	{
		AboutDialog about = new AboutDialog();
		about.ProgramName = "Linux Deletion Utility";
		about.Version = "0.1";
		about.Copyright = "(c) William Willis Whinn";
		about.Comments = "This is a simple application to delete unnecessary files inside a user's Home folder.";
		about.Website = @"https://github.com/ultraviolet-1986/LinuxDeletionUtility";
		about.Run();
		about.Destroy();
	}

	protected void btnClean_Click (object sender, EventArgs e)
	{
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
			checkboxEnabled (false);

			// Placeholder text to demonstrate how to write to the console.
			txtConsole.Buffer.Clear ();
			txtConsole.Buffer.InsertAtCursor ("Now beginning cleaning Procedure...\n");
			txtConsole.Buffer.InsertAtCursor ("Performing Cleanup...\n");
			txtConsole.Buffer.InsertAtCursor ("Cleanup Complete.");

			checkboxEnabled (true);
		}
	}

	protected void btnClear_Click (object sender, EventArgs e)
	{
		resetApplication ();
	}
}

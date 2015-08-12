using System;
using Gtk;

public partial class frmMain: Gtk.Window
{
	public frmMain () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		// Display the first page of the notebook.
		noteMain.CurrentPage = 0;
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
}

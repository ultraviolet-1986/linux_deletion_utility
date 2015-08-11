using System;
using Gtk;

public partial class frmMain: Gtk.Window
{
	public frmMain () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void menuAbout_Click (object sender, EventArgs e)
	{
		// About the Author.
		AboutDialog about = new AboutDialog();
		about.ProgramName = "Linux Deletion Utility";
		about.Version = "0.1";
		about.Copyright = "© William Willis Whinn";
		about.Comments = "This is a simple application to delete unnecessary files.";
		about.Website = @"https://github.com/ultraviolet-1986";
		about.Run();
		about.Destroy();
	}
}

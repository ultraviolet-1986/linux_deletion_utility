# LinuxDeletionUtility
A simple utility for deleting unnecessary files in a user's Home folder.

**Build Environment:** Linux Mint 17.2 Cinnamon amd64, MonoDevelop 5.9.5

**Notes:**
- This implementation will lack *secure* deletion, this will be added during the next phase of the project.

**To do:**
- Give the application an original name.
- Implement native (C#) file handling and bring in a secure deletion library.
- Add deletion options for Applications and Desktops and include sub-items so the user can better select what to delete and what to leave.
- Include a configuration file so a user can keep their selection saved.

**Change Log:**
- **11/08/2015**: Began the project with the aim of creating a user-friendly application which can help keep a user's Home folder tidy and clean.
- **12/08/2015**: Included some basic deletion functionality and organised the code into sections, or what I call 'blocks'.
- **13/08/2015**: Included NUnit and created some Unit tests for 'deletionLibrary' to ensure the current manner of handling files will remain valid. Have also separated tests so that only one aspect of the process is tested at a time.
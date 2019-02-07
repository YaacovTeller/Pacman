# Pacman
C# Pacman project - work in progress

The movement controls are in form1.cs, thats where the problem lies.
There are two alternate methods lurking at the foot of the file, commented out.
The last is the original simple control set, that doesn't allow for form buttons, as the arrow keys default to tabbing between elements on the form.
The penultimate is an override that i copied, but the author couldn't get the keyup to work. It looks like it should.
The un-commented set uses a funky IMessageFilter, which seems to work around whatever problem the other suffered from.
All i need it to do now is recognise which key was raised, to be able to switch the relevant movementflag to false.

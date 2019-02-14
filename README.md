# Pacman
C# Pacman project - work in progress

The green fruit pick-up allows ghosts to be eaten for extra points. Be aware that ghosts can escape off-screen.
Esc key pauses. 's' and 'l' for save and load are NOT working at present, see below.

PROBLEMS:
The movement controls, in pacman_new/form1.cs.
There are two alternate methods lurking in 'unused controls', commented out.
The last is the original simple control set, that doesn't allow for form buttons, as the arrow keys default to tabbing between elements on the form.
The penultimate is an override that i copied, but the author couldn't get the keyup to work. It looks like it should.
The un-commented set uses a funky IMessageFilter, which seems to work around whatever problem the other suffered from.
All i need it to do now is recognise which key was raised, to be able to switch the relevant movementflag to false.

The buttons themselves don't actually work properly as of yet, because pictureBoxs aren't serialisable?

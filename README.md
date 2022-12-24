# InputLockExampleProject
An example of an efficient Input lock service for Unity which follow SOLID principles.
- Has implimination of locking everything, specifc things or everything but somthing.
- Easly extendable
- Each lock can only be opened by a specific key. If something is locked with two locks and a key is used to unlock one of the locks then the other lock will remain.
- New lockable elements check on initialization if they need to be locked.
- Code which is responsible for locking input to also be responsible for unlocking it.
- Has the ability to define what the lock will be responsible for locking.
- Easy way to debug what locks are currently locked and what those locks are locking.
- Input lock service to be the only code responsible for locking and unlocking inputs.

# Description of example
In this example there are buttons and 3d models which change color when pressed. I supplied a number of buttons for locking diffrent things such as raycasters and event triggers.

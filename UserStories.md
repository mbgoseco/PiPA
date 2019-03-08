# User Stories

## Voice Activation
As a user I should be able to say "PiPA" to get the Raspberry Pi's attention so that I can give it commands.

Features:
- User can say "PiPA" to illicit a response from the device.
- PiPA will give an audio response (voice or chime) to indicate it heard the user's command.

Acceptance:
- Ensure that audio channels are open and operational to hear user.
- Ensure that device understands the command "PiPA" regardless of tone or accent.
- Ensure that device emits an audio response when the activation command is given.

## PiPA Web App Registration
As a user I should be able to register on the PiPA web application to start using the device.

Features:
- Web app has a registration page.
- User can fill out a registration form.
- User can enter personal information and save it to their profile.

Acceptance:
- Registration page has a form which a user can enter personal data to complete registration.
- Page will inform user if any required information in incorrect.
- Form has a confirmation button that saves information to user database and log user in.

## PiPA Web App Login
As a user I should be able to log in to the PiPA web app after previously registering.

Features:
- Web app has a login page.
- User can log into he web app with their username and password.
- User can access their profile and to-do list upon successful login.

Acceptance:
- User can enter their login information to a form.
- User will be informed if their username or password wrong with a generic error message.
- User will be taken to landing page upon successful login.

## Manage Tasks
As a user, I want to be able to access my todo list on the web app, and modify them as I please.

Features:
- User can view page displaying all the tasks on their to-do list.
- Usre can mark a task as complete.
- User can add a new task to their to-do list.
- User can select individual tasks to view details of them.
- User can edit existing tasks.
- User can delete a task from their to-do list.

Acceptance:
- Ensure that completed tasks are distinguishable from incomplete tasks.
- Ensure that the task the user selects links to the correct task in the database.
- Ensure that any new task is added to the database.
- Ensure any edited task is updated in the database.
- Ensure any deleted task is removed from the database.

## PiPA User Database
As a developer I should create a separate database for users so that I can take advantage of the Identity Framework.

Features:
- A separate SQL database will store user profiles.
- DB will use Identity Framework features to protect user's email, password.
- User profiles will be given claims and roles that control their access within the web app.

Acceptance:
- Ensure database is successfully connected to web app.
- Basic CRUD operations can be performed on users in the DB.
- Claims and roles are able to be added to new and existing users.

## PiPA To-Do List Database
As a developer I want to create a database store each user's to-do list and each list's collection of tasks.

Features:
- Usage of a database consisting of a To-Do List table with a one to many relationship with a Task table.
- Each registered user has To-Do list associated to them and added to the table.
- Each user can store a list of tasks to their to-do list in the table.

Acceptance:
- Ensure database is successfully connected to the web app.
- Ensure basic CRUD operations can be perfromed on the DB.
- Ensure users are properly linked to their To-Do list ID.
- Ensure tasks in the Tasks table are linked to the corrects To-Do lists.

## PiPA Device/Database Connection
As a developer I should create a way for the PiPA and the website to communicate together so that they can update the same database.

Features:
- A user can select a PiPA device to pair with.
- Users who use that device to add tasks will add them to the to-do list belonging to the paired user.

Acceptance:
- Ensure users have a setting in their profile to select a PiPA device to pair with.
- Ensure the device can only pair with one user at a time.
- Ensure that when the device is given a command to add a task, a new task in the DB is created with the proper user ID.

## Voice Commands
As a user, I should be able to give to give a verbal command, “add,” to add to my to-do list.

Features:
- User can say, “add,” to add to their to-do list.
- PiPA will give an audio response (voice or chime) to indicate that the task was added to the to-do list.

Acceptance:
- Ensure that audio channels are open and operational to hear user.
- Ensure that device understands the command "add" regardless of tone or accent.
- Ensure that device emits an audio response when the activation command is given.


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

## Voice Commands
As a user, I should be able to give to give a verbal command, “add,” to add to my to-do list.

Features:
- User can say, “add,” to add to their to-do list.
- PiPA will give an audio response (voice or chime) to indicate that the task was added to the to-do list.

Acceptance:
- Ensure that audio channels are open and operational to hear user.
- Ensure that device understands the command "add" regardless of tone or accent.
- Ensure that device emits an audio response when the activation command is given.

## PiPA Web App Registration
As a user I should be able to register on the PiPA web application so that I can start using the device.

Features:
- Web app has a registration page.
- User can fill out a registration form.
- User can enter personal information and save it to their profile.

Acceptance:
- Registration page has a form which a user can enter personal data to complete registration.
- Page will inform user if any required information in incorrect.
- Form has a confirmation button that saves information to user database and log user in.

## PiPA Web App Login
As a user I should be able to log in to the PiPA web app after previously registering so that I can access my to-do list and profile.

Features:
- Web app has a login page.
- User can log into he web app with their username and password.
- User can access their profile and to-do list upon successful login.

Acceptance:
- User can enter their login information to a form.
- User will be informed if their username or password wrong with a generic error message.
- User will be taken to landing page upon successful login.

## View and Add Tasks Through Web App
As a user, I want to be able to access my todo list on the web app so that I can add tasks to it.

Features:
- User can view page displaying all the tasks on their to-do list.
- User can mark a task as complete.
- User can add a new task to their to-do list.

Acceptance:
- Ensure that completed tasks are distinguishable from incomplete tasks.
- Ensure that any new task is added to the database.

## View Task Details
As a user, I want to be able to select individual tasks on my to-do list so that I can view their details.

Features:
- User can view details of a task.

Acceptance:
- Ensure the task pulled from the database matches the one selected by the user.
- Ensure the details of the task can be retrieved from the database.

## Update Task
As a user, I want to be able to update a selected task so that when details of my tasks change they can be reflected in my to-do list.

Features:
- User can select a specific task and update details of it.

Acceptance:
- Ensure the user is given a form with which to give new data to update the task.
- Ensure the data given to the form is passed into the database.
- Ensure the task being updated is the one the user selected.

## Delete Task
As a user, I want to be able to remove a task from my to-do list so that my list is not cluttered with tasks I don't have to do.

Features:
- User can select a task and remove it from their to-do list.

Acceptance:
- Ensure that task selected from the database matches the one the user chose for deletion.
- Ensure that after user confirms, the selected task no longer exists in the database.

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
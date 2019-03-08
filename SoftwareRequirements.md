<h1 align="center">Software Requirements</h1>

<strong>Project Team:</strong> Andrew Hinojosa, Charles Clemens, Mike Filicetti, Mike Goseco, Julie Ly</br>
<strong>Name of Project:</strong> PiPA (Pi Personal Assistant)

<h2>Vision</h2>

<strong>What is the vision of this product?</strong>
To create an at-home assistant that provides users the ability to create, update, read, and delete a to-do-list using voice commands and a web app.

<strong>What pain point does it solve?</strong>
Virtual assistants are everywhere now, making life easier than ever for us. Our project would serve as an assistant in a world that asks us to do so many things in so little time. By simply being able to say what you need, rather than taking the time to pull out your phone or planner and write it down, you’re offered a new level of freedom and increased daily efficiency. By providing users the ability to build to-do lists, write notes, and more, we have the ability to explore a new technology that we can actually put to good use.

<strong>Why should we care?</strong>
While there is a ton of documentation for building virtual assistants using Python and other languages, we have a unique opportunity to explore this space using C#. It will be a very engaging process to work to translate our needs from one language to another, and even adapt our own implementations. This will provide the unique opportunity to contribute to a community that has given so much to us. Additionally, it is really great knowing we are the first team to tackle this in the 6 ASP.NET Core cohorts to pass through Code Fellows.

<h2>Scope</h2>

<strong>IN</strong>
<ul>
<li>PiPA (Hardware)</li>
<ul>
<li>The device will accept verbal commands from the user</li>
<li>The device will respond with a “chime” when prompted to let the user know it is listening</li>
<li>Users will have the ability to add tasks to their to-do list</li>
</ul>
</ul>

<ul>
<li>Web App</li>
<ul>
<li>The web app will utilize Identity to allow users to sign-in to their account</li>
<li>The web app will serve as a dashboard for device users</li>
<li>Users will have the ability to perform full CRUD operations</li>
</ul>
</ul>

<strong>OUT</strong>
<ul>
<li>The device will not have functionality beyond the to-do-list application</li>
</ul>

<h2>Minimum MVP</h2>

Voice-activated virtual assistant running on the Nano Framework (C#) utilizing a Raspberry Pi, bluetooth speaker, and omni-directional microphone.

<strong>Features:</strong>
<ul>
<li>Raspberry Pi 3b running Ubuntu</li>
<li>To-Do List application built into hardware</li>
<li>Corresponding web application that provides users full CRUD operations</li>
<li>Bluetooth powered speaker driving audio control</li>
</ul>

<h2>Stretch Goals</h2>
<ul>
<li>Users can create multiple to-do-lists</li>
<li>Incorporate third-party APIs to enhance functionality</li>
</ul>

<h2>Functional Requirements</h2>
<ul>
<li>A user can interact with PiPA via voice command</li>
<li>A user can create a to-do-list task via voice command</li>
<li>A user can create an account in the web app</li>
<li>A user can sign-in and log out of their account in the web app</li>
<li>A user can create, update, view, and delete to-do-list tasks in the web app</li>
<li>PiPA utilizes either the Micro or Nano framework to implement the ASP.NET Core application device-side</li>
<li>Web app utilizes ASP.NET Identity</li>
<li>Web app utilizes XUnit testing to ensure properly tested code and appropriate code coverage</li>
</ul>

<h2>Non-Functional Requirements</h2>
<h3>Integrability</h3>
<ul>
<li>Achieving system integration by linking together the hardaware and software components of the project.</li>
</ul>

<h3>Documentation</h3>
<ul>
<li>Users will be presented a robust set of documentation regarding the full funtionality of the web app and PiPA.</li>
</ul>

<h3>Open Source</h3>
<ul>
<li>Repository will house code-base and provide users the ability to create their own PiPA given the appropriate components.</li>
</ul>

<h2>Data Flow</h2>
<ul>
<li>Users give verbal commands to PiPA to add task</li>
<li>PiPA persists the given information to our Azure database</li>
<li>Users can then log in to the web app to further edit, view, and delete tasks</li>
<li>All changes persist to the Azure database so that both the web app and PiPA have access to them</li>
</ul>

# TabL
The sample is ready to use.

When I created idL I struggled a lot in order to duplicate tabs for the IDE (idL). I eventually found a solution that uses XmlwWriters and XmlReaders. In order to avoid some other people this struggling I will try to develop this code as much as possible to make it easy to duplicate tabs in a WPF application.

TabL is an example of code in order to duplicate Tabs in a wpf application. The name of the tabcontrol and the duplicated tab is needed in order to do that.

# Instructions
You can copy paste the code, you will be able to add or remove tabs with the implemented shortcuts, Ctrl + T to add and Ctrl + W to delete.
The useful thing in this sample is that I implemented a dictionary system where the key is the ID of the tab, therefore each tab is differenciable.
You can associate data to tabs, it was useful for one of my other projects, you can for example store an object and then access it and modify it easily.
I have developped an IDE so it was very useful to keep information about each tab, for example if you want to save the code in a file from a certain file or more advanced stuff such as LSP protocol implementation and usage.

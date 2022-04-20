# TabL
The sample is ready to use.

When I created my own IDE I struggled a lot in order to create new tabs with the WPF framework. I eventually found a solution that uses XmlWriters and XmlReaders.

TabL is an example of code in order to create new Tabs in a WPF application.

# Instructions

With this sample it is possible to add or remove tabs with the implemented shortcuts, Ctrl + T to add and Ctrl + W to delete. These are modifiable it is also possible to add a button for example. I haven't found a way to put a button on the tab itself yet.
The useful thing in this sample is that every tab is stored in a dictionnary where the key is the ID of a tab, therefore each tab is differenciable object.
You can associate data to tabs, it was useful for one of my other projects, you can for example store an object and then access it and modify it easily.
I have developped an IDE so it was very useful to keep track of information in about each tab, for instance, the text in the tab.

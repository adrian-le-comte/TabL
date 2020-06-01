# TabL
The code is not finished yet.

When I created idL I struggled a lot in order to duplicate tabs for the IDE (idL). I eventually found a solution that uses XmlwWriters and XmlReaders. In order to avoid some other people this struggling I will try to develop this code as much as possible to make it easy to duplicate tabs in a WPF application.

TabL is an example of code in order to duplicate Tabs in a wpf application. The name of the tabcontrol and the duplicated tab is needed in order to do that.

# Instructions for the current version

I'm a beginner so my code may not be the best even though it works, however I will explain as clearly as possible how you can import this code. I will try to make it better for the next versions so that you don't need to change more than two fields.
You can copy all of the code your MainWindow code or at least the class which would represent it. Then, you need to modify the constants and give the name of your TabControl and the TabItem you would like to duplicate. In the constructor of MainWindow, add the two events after the InitializeComponent(), these will call the methods I implemented in order to duplicate a tab. If you want you can also modify the shortcuts directly in the functions.

Feel free to modify my code as much as you want, I have my own vision of the tabs usage which might not fit yours.

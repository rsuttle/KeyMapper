# KeyMapper
A C# program that allows you to remap your keyboard, run keystroke macros, and open programs.

## Setting up the config.txt file
The syntax for the configuration file is as follows: `[Comma separated list of keys]::[Action to perform],[Key to press or program to open]`

For example, `A,B,C::Single,F5` would tell the program to press the F5 key whenever the A, B, and C keys are pressed down at the same time.

Another example: `ALT::Open,chrome` will open the Chrome browser when the ALT key is pressed. To open a specific url, do this: `ALT::Open,https://google.com`. This will open google.com in your default web browser.

To open other programs, you will need to supply the full path to the program's executable file.

To set up a keyboard macro, format the message like this: `PGUP::Multi,n,a,m,e`. This will type the word "name" when the Page Up button is pressed.

Most of the keys on a standard keyboard are supported, but there are a couple limitations: The program currently cannot differentiate between the left alt key and
the right alt key, so if you use the alt key in a mapping, both alt keys will work. Also, some mappings involving the ctrl and alt keys will not yet work.

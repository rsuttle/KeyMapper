# KeyMapper
A C# program that allows you to remap your keyboard.

## Setting up the config.txt file
The syntax for the configuration file is as follows: `[Comma separated list of keys]::[Action to perform],[Key to press or program to open]`

For example, `A,B,C::Single,F5` would tell the program to press the F5 key whenever the A, B, and C keys are pressed down at the same time.

Another example: `ALT::Open,browser` will open the default browser when the ALT key is pressed.

Most of the keys on a standard keyboard are supported, but there are a couple limitations: The program currently cannot differentiate between the left alt key and
the right alt key, so if you use the alt key in a mapping, both alt keys will work. Also, some mappings involving the ctrl and alt keys will not work. 

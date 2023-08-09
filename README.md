# About
This was my final project in the Magshimim program. It is a remote computer controller, you can view computer screens and control the mouse/keyboard.
<br><br>
The project is split into a client and a server. The client connects to the server and authenticates, when the client is connected to another client then the connection is p2p.
<br><br>
The data transfer is working with TCP for a reliable connection and only in LAN.
To make it available in WAN as well, there is a need to add a [hole punching](https://en.wikipedia.org/wiki/TCP_hole_punching) feature.
<br><br>
There are image manipulation techniques (lowering the resolution and reducing color depth) that are being used before turning the image into a string and compressing it.
These steps are being conducted to reduce the amount of information that is being sent.

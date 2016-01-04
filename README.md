# IoTGateway

**IoTGateway** is a C# implementation of an IoT gateway. It is self contained, and includes all libraries and frameworks 
it needs to operate. Example applications also include binary downloads.

The solution is divided into different groups of projects:

* [Clients](#clients)
* [Events](#events)
* [Mocks](#mocks)
* [Networking](#networking)
* [Things](#things)

## License

The source code provided in this project is provided open for the following uses:

* For **Personal evaluation**. Personal evaluation means evaluating the code, its libraries and underlying technologies, including learning 
	about underlying technologies.

* For **Academic use**. If you want to use the following code for academic use, all you need to do is to inform the author of who you are, what academic
	institution you work for (or study for), and in what projects you intend to use the code.

* For **Security analyzis**. If you perform any security analyzis on the code, to see what security aspects the code might have,
	all I ask is that you inform me of any findings so that any vulnerabilities might be addressed. I am thankful for any such contributions,
	and will acknowledge them.

All rights to the source code are reserved. If you're interested in using the source code, as a whole, or partially, you need a license agreement
with the author. You can contact him through [LinkedIn](http://waher.se/).

## Clients

Projects starting with **Waher.Client.** denote client projects. Clients are front-end applications that can be run by users to perform different
types of interaction with things or the network.

### Waher.Client.WPF

| Screen Shot | Project description |
|-------------|---------------------|
|![Waher.Client.WPF](Images/Small/Waher.Client.WPF.1.png)| The [Waher.Client.WPF](Waher.Client.WPF) project is a simple IoT client that allows you to interact with things and users. If you connect to the network, you can chat with users and things. The client GUI is built using Windows Presentation Foundation (WPF). [Full Screen Shot.](Images/Waher.Client.WPF.1.png) [Executable.](Executables/Waher.Client.WPF.zip) |
|![Waher.Client.WPF](Images/Small/Waher.Client.WPF.2.png)| To allow developers to understand underlying network protocols, the IoT client provides sniffers that display detailed information about the underlying protocol. [Full Screen Shot.](Images/Waher.Client.WPF.2.png) |
|![Waher.Client.WPF](Images/Small/Waher.Client.WPF.3.png)| Apart from norlam Instant Messaging features, the IoT client also includes integrated support for M2M and IoT protocols. [Full Screen Shot.](Images/Waher.Client.WPF.3.png) |

## Events

This sections contains libraries that manage different aspects of event logging in networks.

| Project | Project description |
|-------------|---------------------|
| **Waher.Events** | The [Waher.Events](Waher.Events) project provides the basic architecture and framework for event logging in applications. It uses the static class **Log** as a hub for all type of event logging in applications. To this hub you can register any number of **Event Sinks** that receive events and distribute them according to implementation details in each one. By logging all events to **Log** you have a configurable environment where you can change logging according to specific needs of the project. |
| **Waher.Events.Console** | The [Waher.Events.Console](Waher.Events.Console) project provides a simple event sink, that outputs events to the console standard output. Useful, if creating simple console applications. |
| **Waher.Events.Documentation** | The [Waher.Events.Documentation](Waher.Events.Documentation) project contains documentation of specific imortant events. This documentation includes Event IDs and any parameters they are supposed to include. |
| **Waher.Events.XMPP** | The [Waher.Events.XMPP](Waher.Events.XMPP) project defines an event sink that distributes events over XMPP, according to [XEP-0337](http://xmpp.org/extensions/xep-0337.html). |

## Mocks

This sections contains projects that implement different mock devices. These can be used as development tools to test technologies, implementation, 
networks and tools.

| Project | Project description |
|-------------|---------------------|
| **Waher.Mock** | The [Waher.Mock](Waher.Mock) project is a class library that provides support for simple mock applications. This includes simple network configuration. |
| ![Waher.Client.WPF](Images/Small/Waher.Mock.Temperature.png)| The [Waher.Mock.Temperature](Waher.Mock.Temperature) project simulates a simple temperature sensor with an XMPP interface. The first time the application is run, it provides a simple console interface for the user to provide network credentials. It also outputs any events and network communication to the console, to facilitate implementation of IoT interfaces. [Full Screen Shot.](Images/Waher.Mock.Temperature.png) [Executable.](Executables/Waher.Mock.Temperature.zip) |

## Networking

This sections contains libraries that manage different aspects of network communication.

| Project | Project description |
|-------------|---------------------|
| **Waher.Networking** | The [Waher.Networking](Waher.Networking) project provides the basic architecture and tools for all networking libraries.  This includes sniffers, timing, data types and parsing, etc. |
| **Waher.Networking.MQTT** | The [Waher.Networking.MQTT](Waher.Networking.MQTT) project provides a simple MQTT client. |
| **Waher.Networking.PeerToPeer** | The [Waher.Networking.PeerToPeer](Waher.Networking.PeerToPeer) project provides tools for peer-to-peer communication. |
| **Waher.Networking.UPnP** | The [Waher.Networking.UPnP](Waher.Networking.UPnP) project provides a library for interacting with UPnP-enabled devices in the network. |
| **Waher.Networking.XMPP** | The [Waher.Networking.XMPP](Waher.Networking.XMPP) project provides a simple XMPP client. |
| **Waher.Networking.XMPP.Chat** | The [Waher.Networking.XMPP.Chat](Waher.Networking.XMPP.Chat) project provides a simple XMPP chat server bot for things, that is added to the XMPP client defined in [Waher.Networking.XMPP](Waher.Networking.XMPP). It follows the chat semantics outlined in this proto-XEP: [Chat Interface for Internet of Things Devices](http://htmlpreview.github.io/?https://github.com/joachimlindborg/XMPP-IoT/blob/master/xep-0000-IoT-Chat.html) |
| **Waher.Networking.XMPP.Interoperability** | The [Waher.Networking.XMPP.Interoperability](Waher.Networking.XMPP.Interoperability) project provides an add-on to the XMPP client defined in [Waher.Networking.XMPP](Waher.Networking.XMPP). This add-on provides client and server interoperability capabilities, as defined in this proto-XEP: [Internet of Things - Interoperability](http://htmlpreview.github.io/?https://github.com/joachimlindborg/XMPP-IoT/blob/master/xep-0000-IoT-Interoperability.html) |
| **Waher.Networking.XMPP.Sensor** | The [Waher.Networking.XMPP.Sensor](Waher.Networking.XMPP.Sensor) project provides an add-on to the XMPP client defined in [Waher.Networking.XMPP](Waher.Networking.XMPP). This add-on provides client and server sensor capabilities, as defined in [XEP-0323](http://xmpp.org/extensions/xep-0323.html) |
| **Waher.Networking.XMPP.Test** | The [Waher.Networking.XMPP.Test](Waher.Networking.XMPP.Test) project contains unit-tests for the [Waher.Networking.XMPP](Waher.Networking.XMPP) library and add-ons. |

## Things

This sections contains libraries that manage data abstraction for things.

| Project | Project description |
|-------------|---------------------|
| **Waher.Things** | The [Waher.Things](Waher.Things) project is a class library that provides basic abstraction of things, errors, sensor data and control operations. |

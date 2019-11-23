# WIP

## Solution Information

### NucuCar.Domain

Holds common classes and interfaces that are required by the other projects. 

It provides all the types that are generated via protocol buffers.

### NucuCar.Sensors

Manages all the car sensors. For more info see the readme file located in the project directory.

### NucuCar.TestClient

Command line utility to play around with the car functionality. You can use it to remotely read data from the sensors via gRPC methods and to publish and read telemetry data.

---

### Building and Running.

You can build the project then run them as you would run an executable file.

```$xslt
dotnet build --runtime linux-arm
```
---

# Milestones: 

- [X] Make a working BME680 module. ~~(Unit tests?)~~
  - [X] Add settings: ~~gRPC enabled~~, Telemetry Enabled, Sensor Enabled, Measurement Delay
- [X] Make a gRPC test project to test the modules.
- [ ] Add systemd config file.
- [ ] Add makefile for easy building & installing.
- [ ] ~~Make a .Net Core web api project. Add support for BME680.~~ Replaced by gRPC.
- [ ] Buy a toy car with H-Bridge.
- [ ] Make a H-Bridge Module to interface with it.
- [ ] Make a desktop application /w Xbox Controller support.
- [ ] Buy Raspbery Pi Camera & Pi Zero Camera adapter.
- [ ] Figure out how to integrate camera to stream to the dekstop.
- [ ] Buy mobile 4G router.
- [ ] Figure out how to make a reverse VPN connection on boot. (Hint: SSH tunneling)
- [ ] Add telemetry streaming to GCP's Iot Core
- [ ] Improve the desktop application.
- [ ] Add additional sensors
  - [ ] GPS
  - [ ] Collision
  
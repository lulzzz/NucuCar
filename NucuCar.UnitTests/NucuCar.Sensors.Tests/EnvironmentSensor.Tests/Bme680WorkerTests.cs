using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NucuCar.Sensors;
using NucuCar.Sensors.Environment;
using NucuCar.Sensors.Telemetry;
using NucuCarSensorsProto;
using Xunit;

namespace NucuCar.UnitTests.NucuCar.Sensors.Tests.EnvironmentSensor.Tests
{
    public class Bme680WorkerTest
    {
        private readonly Mock<ILogger<Bme680Worker>> _mockLogger;
        private readonly Mock<IOptions<Bme680Config>> _mockOptions;
        private readonly Mock<SensorTelemetry> _mockSensorTelemetry;
        private readonly Mock<TestBme680Sensor> _mockTestBme680Sensor;
        private readonly Mock<ISensor<Bme680Sensor>> _mockBme680ISensor;
        private readonly CancellationTokenSource _cts;

        public Bme680WorkerTest()
        {
            _cts = new CancellationTokenSource();
            _mockLogger = new Mock<ILogger<Bme680Worker>>();
            _mockOptions = new Mock<IOptions<Bme680Config>>();
            _mockSensorTelemetry = new Mock<SensorTelemetry>();
            _mockTestBme680Sensor = new Mock<TestBme680Sensor>();
            _mockBme680ISensor = new Mock<ISensor<Bme680Sensor>>();

            _mockBme680ISensor.Setup(o => o.Object).Returns(_mockTestBme680Sensor.Object);
        }

        [Fact]
        public async Task Test_Bme680Worker_SensorIsInitialized()
        {
            _mockOptions.Setup(o => o.Value).Returns(new Bme680Config()
            {
                Enabled = true,
            });
            var service = new Bme680Worker(_mockLogger.Object, _mockSensorTelemetry.Object, _mockBme680ISensor.Object);

            await service.StartAsync(_cts.Token);
            _mockTestBme680Sensor.Verify(s => s.Initialize(), Times.AtLeastOnce);
            await service.StopAsync(_cts.Token);
        }
        
        [Fact]
        public async Task Test_Bme680Worker_SensorIsBeingMeasured()
        {
            _mockOptions.Setup(o => o.Value).Returns(new Bme680Config()
            {
                Enabled = true,
            });
            _mockTestBme680Sensor.Setup(s => s.GetState()).Returns(SensorStateEnum.Initialized);
            
            var service = new Bme680Worker(_mockLogger.Object, _mockSensorTelemetry.Object, _mockBme680ISensor.Object);
            await service.StartAsync(_cts.Token);
            _mockTestBme680Sensor.Verify(s => s.Initialize(), Times.AtLeastOnce);
            _mockTestBme680Sensor.Verify(s => s.TakeMeasurementAsync(), Times.AtLeastOnce);
            await service.StopAsync(_cts.Token);
        }
    }
}
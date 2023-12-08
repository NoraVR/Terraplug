using System.Threading;
using System.Threading.Tasks;
using Buttplug.Client;
using Buttplug.Client.Connectors.WebsocketConnector;

namespace Terraplug
{
    public static class VibrationController
    {
        private static readonly ButtplugWebsocketConnector _connector = new(new("ws://localhost:12345"));
        private static readonly ButtplugClient _client = new("Terraplug! >_<");

        public static Task ConnectAsync(CancellationToken cancellationToken = default)
            => _client.ConnectAsync(_connector, cancellationToken);

        public static Task DisconnectAsync()
            => _client.DisconnectAsync();

        public static Task Vibrate(double speed, int delay)
             => Parallel.ForEachAsync(_client.Devices, async (device, token) =>
             {
                 await device.VibrateAsync(speed).ConfigureAwait(false);

                 await Task.Delay(delay, token).ConfigureAwait(false);

                 await device.VibrateAsync(0).ConfigureAwait(false);


             });

    }
}

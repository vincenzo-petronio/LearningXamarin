using System.Net.NetworkInformation;

namespace App.Core.Utils
{
    class NetworkHelper
    {
        /// <summary>
        /// Verifica se c'è connettività
        /// </summary>
        /// <returns>bool True/False</returns>
        public static bool CheckConnectivity()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}

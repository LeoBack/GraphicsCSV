/* libEthernet
 * 
 * Funciones Ethernet
 * ====================================================
 * -> String DisplayAddress(IPAddress address)
 * Formatea el numero IP al formato XXX.XXX.XXX.XXX .
 * 
 * -> String printEthernet()
 * Devuelve la configuracion Ethernet.
 * 
 */
 
String DisplayAddress(IPAddress address)
{
 return String(address[0]) + "." + 
        String(address[1]) + "." + 
        String(address[2]) + "." + 
        String(address[3]);
}

String printEthernet() {
  String eth = "IP:";
  eth.concat(DisplayAddress(Ethernet.localIP()));
  eth.concat("\nMask:");
  eth.concat(DisplayAddress(Ethernet.subnetMask()));
  eth.concat("\nGateway IP:");
  eth.concat(DisplayAddress(Ethernet.gatewayIP()));
  eth.concat("\nDNS:");
  eth.concat(DisplayAddress(Ethernet.dnsServerIP()));
  return eth;
}


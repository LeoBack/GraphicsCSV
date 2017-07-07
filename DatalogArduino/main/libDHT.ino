/* libDHT
 * 
 * Funciones DHT (temperatura y Humedad)
 * ====================================================
 * -> int ReadDHT()
 * Realiza el proceso de lectura del sensor.
 * 
 * -> String printDHT()
 * Devuelve los datos obtenidos.
 * 
 */

//float Humidity = 0;
//float Temperature = 0;

int ReadDHT(){
  // Wait a few seconds between measurements.
  delay(2000);
  
  // Reading temperature or humidity takes about 250 milliseconds!
  Humidity = oDht.readHumidity();
  Temperature = oDht.readTemperature();

  if (isnan(Humidity) || isnan(Temperature))
    return 1;
  else
    return 0;
}

String printDHT() {
  String tm = "H: ";
  tm.concat(String(Humidity));
  tm.concat(" %\t");
  tm.concat("T: ");
  tm.concat(String(Temperature));
  tm.concat(" *C");
  return tm;
}


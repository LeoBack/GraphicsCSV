/* libDatalog
 * 
 * Funciones DataLogs
 * ====================================================
 * -> void Datalogger(String Data)
 * 
 * 
 * -> String dataLine(String Val[])
 * 
 * 
 */
 
void Datalogger(String Data) {
  digitalWrite(LED_STATUS, HIGH);

  if (FileName != printDate())  
    FileName = printDate();
  
  File dataFile = SD.open(FileName, FILE_WRITE);
  if (dataFile) {
    dataFile.println(Data);
    dataFile.close();
  } else {
    Serial.println("Error opening: " + FileName);
  }
  digitalWrite(LED_STATUS, LOW);
}

String dataLine(String Val[]) {
  String R = "";
  for (int i = 0; i < sizeof(Val)+1; i++) {
    R.concat(Val[i]);
    
    if (sizeof(Val) != i)
      R.concat(";");
  }
  return R;
}


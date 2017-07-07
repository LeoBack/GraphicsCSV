/* libDateTime
 * 
 * Funciones RTC
 * ====================================================
 * -> String printDateNow()
 * Devuelve: Dia/Mes/Año-Hora:Min:Seg
 * 
 * -> String printDate()
 * Devuelve: Dia/Mes/Año
 * 
 * -> String printTime()
 * Devuelve: Hora:Min:Seg
 * 
 * -> String printResumeDate()
 * Devuelve: DiaMesAño-HoraMinSeg
 * 
 */
 
String printDateNow() {
  DateTime now = oRtc.now();
  String dt = String(now.day());
  dt.concat('/');
  dt.concat(String(now.month()));
  dt.concat('/');
  dt.concat(String(now.year()));
  dt.concat(' ');
  dt.concat(String(now.hour()));
  dt.concat(':');
  dt.concat(String(now.minute()));
  dt.concat(':');
  dt.concat(String(now.second()));
  return dt; 
}

String printDate(){
  DateTime now = oRtc.now();
  String dt = String(now.year());
  dt.concat(String(now.month()));
  dt.concat(String(now.day()));
  return dt; 
}

String printTime(){
  DateTime now = oRtc.now();
  String dt = String(now.hour());
  dt.concat(String(now.minute()));
  dt.concat(String(now.second()));
  return dt; 
}

String printResumeDate(){
  DateTime now = oRtc.now();
  String dt = String(now.year());
  dt.concat(",");
  dt.concat(String(now.month()));
  dt.concat(",");
  dt.concat(String(now.day()));
  dt.concat("-");
  dt.concat(String(now.hour()));
  dt.concat(",");
  dt.concat(String(now.minute()));
  dt.concat(",");
  dt.concat(String(now.second()));
  return dt; 
}


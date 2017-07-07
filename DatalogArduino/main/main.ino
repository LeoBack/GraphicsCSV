// Comunicacion
#include <SPI.h>
#include <Wire.h>
// Shield
#include <SD.h>
#include <Ethernet.h>
//#include <EthernetUdp.h>
#include "RTClib.h"
#include "DHT.h"
#include <MsTimer2.h>

/*
 The circuit:
 ** I2C - Shield DS1307
 ** SPI - Shield Ethernet + SD 
 *
 * (I2C)  SDA   pin A4
 * (I2C)  SCL   pin A5 
 * (SPI)  MOSI  pin 11
 * (SPI)  MISO  pin 12
 * (SPI)  CLK   pin 13
 * (IO)   CS    pin 10  ETHERNET_SS
 * (IO)   CS    pin 4   SDCARD_SS
 * (IO)   CS    pin 8   RFID_SS
 * (IO)   RESET pin 9   RFID_RESET
 * (IO)   DHT   pin 5   DHT_IO
 * (IO)   STA   pin 7   LED_STATUS
*/

#define ETHERNET_SS 10
#define SDCARD_SS   4
#define DHT_IO      5
#define DHTTYPE     DHT11
#define LED_STATUS  7
//---------------------------------------------------

// RTC
RTC_DS1307 oRtc;
// DHT
DHT oDht(DHT_IO, DHTTYPE);
// Ethernet
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
IPAddress ip(192,168,1, 177);

// SD Card
String FileName;
int SDerror = 0;
//
float Humidity = 0;
float Temperature = 0;
String Date = "";
String Value;
bool Record = false;
//---------------------------------------------------

void flash() {
//  // Test Interrupcion Timer
//  static boolean output = HIGH;
//  digitalWrite(LED_STATUS, output);
//  output = !output;

  String Values[] = { Date, String(Temperature), String(Humidity) };
  Value = dataLine(Values);
  Record = true;
}


void setup() {
  Serial.begin(9600);
  pinMode(LED_STATUS, OUTPUT);
  digitalWrite(LED_STATUS, HIGH);
  
  SPI.begin();      // Init SPI bus
  oDht.begin();     // Init Dht module

  // Init Rtc module
  Serial.print("RTC ");
  if (!oRtc.begin())
    Serial.println("Failed");
 else
    Serial.println("Initialized");
  // Ponemos en hora, solo la primera vez, luego comentar y volver a cargar.
  // Ponemos en hora con los valores de la fecha y la hora en que el sketch ha sido compilado.
  //rtc.adjust(DateTime(F(__DATE__), F(__TIME__)));

  // Init SD Card module
  Serial.print("SD card ");
  if (!SD.begin(SDCARD_SS)){
    Serial.println("Failed");
    SDerror = 1;
  } else
    Serial.println("Initialized");
//
//  // Init ethernet module
//  Serial.print("Ethernet ");
//  if (Ethernet.begin(mac) == 0) {
//    Serial.println("Failed to configure Ethernet using DHCP");
//    Ethernet.begin(mac, ip);
//  }
//  //Serial.println(printEthernet());

  MsTimer2::set(5000, flash); // 5000ms period
  MsTimer2::start();
  digitalWrite(LED_STATUS, LOW);  
}
//------------------------------------------------------------------

void loop() {
  ReadDHT();

  if(Record == true){
    Date = printResumeDate();
    MsTimer2::stop();
    if (SDerror == 0){
      Record = false;
      Serial.println(Value);
      Datalogger(Value);
    } else
      Serial.println("SD Error");
    MsTimer2::start();
  }
}


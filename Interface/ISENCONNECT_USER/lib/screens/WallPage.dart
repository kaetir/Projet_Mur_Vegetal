import 'package:ISENCONNECT/others/Thumbnails.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

bool alertHumidity = false;
bool alertLuminosity = false;
bool alertAirQuality = false;
bool alertBees = false;
bool alertPressure = false;
bool alertOutsideTemperature = false;


class Personal {
  Personal._();

  static const _kFontFam = 'Personal';

  static const IconData watering_can =
      const IconData(0xe800, fontFamily: _kFontFam);
  static const IconData temperature =
      const IconData(0xe801, fontFamily: _kFontFam);
  static const IconData bee = const IconData(0xe802, fontFamily: _kFontFam);
}

class WallPage extends StatelessWidget {
  @override
  Widget build(BuildContext ctxt) {

    List <InkWell> listInkWell = new List();

// humidity sensor : 

    
  ThumbNails thumbNails = new ThumbNails('Humidité du Mur',Icons.local_drink,Colors.blue[900],Colors.blue[200],alertHumidity);
  listInkWell.add(thumbNails.showThumbnails(ctxt));
  

// luminosity sensor: 
  

 
  thumbNails = new ThumbNails('Luminosité du Mur',Icons.brightness_6,Colors.amber[900],Colors.amber[200],alertLuminosity);
  listInkWell.add(thumbNails.showThumbnails(ctxt));
 

 // bees sensor : 
  
    
    
  thumbNails = new ThumbNails('Abeilles dans la ruche',Personal.bee,Colors.grey[700],Colors.yellow,alertBees);
  listInkWell.add(thumbNails.showThumbnails(ctxt));
    
    
// air quality sensor : 
  

  
  thumbNails = new ThumbNails('Qualité de l\'air',Icons.toys,Colors.lightGreen[900],Colors.lightGreen[300],alertAirQuality);
  listInkWell.add(thumbNails.showThumbnails(ctxt));
  

  // atmospheric pressure sensor :
  
 
  thumbNails = new ThumbNails('Pression atmosphérique sur le toit',Icons.cloud,Colors.brown,Colors.brown[200], alertPressure);
  listInkWell.add(thumbNails.showThumbnails(ctxt));
  

  // outside temperature sensor :

  
  thumbNails = new ThumbNails('Température sur le toit',Personal.temperature,Colors.red[400],Colors.red[100], alertOutsideTemperature);
  listInkWell.add(thumbNails.showThumbnails(ctxt));
  

    return Scaffold(
      body: Center(
        child: GridView.extent(
          maxCrossAxisExtent: 300,
          padding: const EdgeInsets.all(4),
          mainAxisSpacing: 4,
          crossAxisSpacing: 4,
          children: listInkWell,
        ),
      ),
    );
  }
}

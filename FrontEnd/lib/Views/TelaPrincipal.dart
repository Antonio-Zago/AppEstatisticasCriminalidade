import 'dart:async';
import 'package:appcrime/Controllers/LoginController.dart';
import 'package:appcrime/Controllers/ZonaController.dart';
import 'package:appcrime/Views/Comuns/NavBar.dart';
import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';
import 'package:provider/provider.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../Models/Zona.dart';

class TelaPrincipal extends StatefulWidget {

  TelaPrincipal();

  static const routeName = '/principal';

  @override
  State<TelaPrincipal> createState() => _TelaPrincipalState();
}

class _TelaPrincipalState extends State<TelaPrincipal> {

  Completer<GoogleMapController> _controller =
  Completer<GoogleMapController>();

  Set<Circle> _circulos = {};

  ZonaController zonaController = ZonaController();


  Color RetornarCorOpacidadeZonas(Zona zona){

    if(zona.IndiceFurto < zona.Media){
      return Colors.green.withOpacity(0.3);
    }else if(zona.IndiceFurto > zona.Media && zona.IndiceFurto < zona.MediaMaxima){
      return Colors.blue.withOpacity(0.3);
    }else{
      return Colors.red.withOpacity(0.3);
    }
  }


  @override
  Widget build(BuildContext context) {

    final loginController = Provider.of<LoginController>(context);

    return Scaffold(
      appBar: AppBar(
        title: Text("App"),
      ),
      drawer: NavBar(
        name:  loginController.nome,
        email: loginController.email,
      ),
      body: Container(
        child: FutureBuilder<List<Zona>>(
          future: zonaController.GetAllZonas(),
          builder: (context, snapshot){
            switch( snapshot.connectionState ){
              case ConnectionState.none :
              case ConnectionState.waiting :
                return Center(
                  child: CircularProgressIndicator(),
                );
              case ConnectionState.active :
              case ConnectionState.done :
                if( snapshot.hasError ){
                  print("Erro ao carregar ");
                }else {
                    for(var zona in snapshot.data!){
                      Circle circulo = Circle(
                        circleId: CircleId("id"),
                        center: LatLng(zona.LatitudeCentral, zona.LongitudeCentral),
                        radius: zona.Raio * 1000, //Convertendo Km para metros
                        fillColor: RetornarCorOpacidadeZonas(zona),
                        strokeWidth: 2,

                      );

                      _circulos.add(circulo);
                    }
                  return Container(
                    child: GoogleMap(
                      initialCameraPosition: CameraPosition(
                          target: LatLng(-23.2652163761331, -45.900088944777956),
                          zoom: 15
                      ),
                      onMapCreated: (GoogleMapController controller){
                        _controller.complete(controller);
                        },
                      circles: _circulos,
                      mapType: MapType.normal,
                    ),
                  );

                }
                break;
            }
          return Container();
          },
        ),
      ),
    );
  }
}

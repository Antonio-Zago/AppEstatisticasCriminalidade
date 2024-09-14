import 'dart:io';
import 'package:appcrime/Controllers/CadastroController.dart';
import 'package:appcrime/Controllers/LoginController.dart';
import 'package:appcrime/Controllers/RouboController.dart';
import 'package:appcrime/Views/TelaLogin.dart';
import 'package:appcrime/Views/TelaPrincipal.dart';
import 'package:appcrime/Views/TelaReporte.dart';
import 'package:appcrime/Views/TelaLogin.dart';
import 'package:appcrime/Views/TelaReporteAssalto.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'Comuns/MyHttpOverrides.dart';
import 'Controllers/AssaltoController.dart';


void main() {
  HttpOverrides.global = MyHttpOverrides();

  runApp(MultiProvider(
      providers: [
        Provider(
            create: (_) => LoginController()
        ),
        Provider(
            create: (_) => CadastroController()
        ),
        Provider(
            create: (_) => RouboController()
        ),
        Provider(
            create: (_) => AssaltoController()
        )
      ],
    child: MaterialApp(
      initialRoute: "/",
      routes: {
        TelaReporte.routeName : (context) => TelaReporte(),
        TelaPrincipal.routeName : (context) => TelaPrincipal(),
        Telalogin.routeName : (context) => Telalogin(),
        TelaReporteAssalto.routeName : (context) => TelaReporteAssalto(),
      },
      title: 'Navigation Basics',
      debugShowCheckedModeBanner: false,
      home: Telalogin(),
    )
  ),
  );

}

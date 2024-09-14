import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:mobx/mobx.dart';

import '../Models/Zona.dart';
import '../Comuns/Urls.dart';
import 'LoginController.dart';
part 'ZonaController.g.dart';

class ZonaController = ZonaControllerBase with _$ZonaController;

abstract class ZonaControllerBase with Store{


  @observable
  List<Zona> zonas = [];

  @action
  Future<List<Zona>> GetAllZonas() async{
    List<Zona> zonas = [];
    try {
      final token = await LoginController().getToken();

      http.Response response = await http.get(
        Uri.parse(Urls.UrlIndiceFurtos),
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': 'Bearer $token',
        }
      );
      var dadosJson = json.decode(response.body);

      for(var zona in dadosJson){
        Zona p = Zona(zona["id"],zona["latitudeCentral"],zona["longitudeCentral"],zona["raio"],zona["indiceFurto"], zona["media"],zona["mediaMaxima"]);

        zonas.add(p);
      }
    }catch(e){
      throw Exception(e);
    }
    return zonas;
  }


}
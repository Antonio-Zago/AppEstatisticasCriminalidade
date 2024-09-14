import 'dart:convert';
import 'package:appcrime/Views/Comuns/ItemMultiSelect.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:mobx/mobx.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:provider/provider.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../Comuns/Urls.dart';
import '../Models/Roubo.dart';
import 'LoginController.dart';
part 'RouboController.g.dart';

class RouboController = RouboControllerBase with _$RouboController;

abstract class RouboControllerBase with Store{

  @observable
  TextEditingController descricaoController = TextEditingController();

  @observable
  TextEditingController dataController = TextEditingController();

  @observable
  bool validacaoData = true;

  @observable
  List<ItemMultiSelect> itensSelecionados = [];

  @observable
  bool validacaoItens = true;

  @observable
  bool cadastrouBoletim = false;

  @observable
  String dataFormatada = "";

  @observable
  List<ItemMultiSelect> tipoBens = [];

  @action
  bool validarCampos(){
    validacaoData = dataController.text.isNotEmpty;
    validacaoItens = itensSelecionados.isNotEmpty;

    return validacaoData && validacaoItens;
  }

  @action
  void limparCampos(){
    descricaoController.text = "";
    dataController.text = "";
    itensSelecionados = [];
    cadastrouBoletim =false;
  }

  @action
  Future<void> BuscarItens(BuildContext context) async{
    List<ItemMultiSelect> tipoBens = [];
    try {
      final loginController = Provider.of<LoginController>(context);
      final token = await loginController.getToken();

      http.Response response = await http.get(
          Uri.parse(Urls.UrlTipoBens),
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'Bearer $token',
          }
      );
      var dadosJson = json.decode(response.body);

      for(var tipoBem in dadosJson){
        ItemMultiSelect p = ItemMultiSelect(tipoBem["id"],tipoBem["nome"]);

        tipoBens.add(p);
      }
      this.tipoBens = tipoBens;
    }catch(e){
      throw Exception(e);
    }
  }


  @action
  Future<int> ReportarRoubo(Roubo roubo, BuildContext context) async{
    try {
      final loginController = Provider.of<LoginController>(context,listen: false);
      final token = await loginController.getToken();

      http.Response response = await http.post(Uri.parse(Urls.UrlReportarRoubo),
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'Bearer $token',
          },
          body: json.encode({
            "TipoBens" : roubo.tipoBens,
            "descricao": roubo.descricao,
            "dataHora": DateTime.parse(roubo.dataHora).toIso8601String(),
            "cadastrouBoletimOcorrencia": roubo.cadastrouBoletimOcorrencia
          })
      );


      return response.statusCode;
    }catch(e){
      throw Exception(e);
    }
  }
}
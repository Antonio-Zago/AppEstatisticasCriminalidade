import 'dart:convert';

import 'package:flutter/cupertino.dart';
import 'package:http/http.dart' as http;
import 'package:mobx/mobx.dart';
import 'package:provider/provider.dart';

import '../Comuns/Urls.dart';
import '../Models/Assalto.dart';
import '../Models/Roubo.dart';
import '../Views/Comuns/ItemMultiSelect.dart';
import 'LoginController.dart';
part 'AssaltoController.g.dart';

class AssaltoController = AssaltoControllerBase with _$AssaltoController;

abstract class AssaltoControllerBase with Store{
  @observable
  TextEditingController descricaoController = TextEditingController();

  @observable
  TextEditingController quantidadeAssaltantes = TextEditingController();

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
  bool estavaArmado = false;

  @observable
  String dataFormatada = "";

  @observable
  List<ItemMultiSelect> tipoBens = [];

  @observable
  List<ItemMultiSelect> tipoArmas = [];

  @observable
  int tipoArma = 1;

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
  Future<void> BuscarTipoArmas(BuildContext context) async{
    try {
      final loginController = Provider.of<LoginController>(context);
      final token = await loginController.getToken();

      http.Response response = await http.get(
          Uri.parse(Urls.UrlTipoArmas),
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'Bearer $token',
          }
      );
      var dadosJson = json.decode(response.body);

      for(var tipoArma in dadosJson){
        ItemMultiSelect p = ItemMultiSelect(tipoArma["id"],tipoArma["descricao"]);

        this.tipoArmas.add(p);
      }
    }catch(e){
      throw Exception(e);
    }
  }


  @action
  Future<int> ReportarAssalto(Assalto assalto,BuildContext context) async{
    try {
      final loginController = Provider.of<LoginController>(context,listen: false);
      final token = await loginController.getToken();

      http.Response response = await http.post(Uri.parse(Urls.UrlReportarAssalto),
          headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Authorization': 'Bearer $token',
          },
          body: json.encode({
            "TipoBens" : assalto.tipoBens,
            "descricao": assalto.descricao,
            "dataHora": DateTime.parse(assalto.dataHora).toIso8601String(),
            "cadastrouBoletimOcorrencia": assalto.cadastrouBoletimOcorrencia,
            "quantidadeAgressores" : assalto.,
            "possuiArma": false,
            "TipoArmaId" : 1
          })
      );


      return response.statusCode;
    }catch(e){
      throw Exception(e);
    }
  }
}
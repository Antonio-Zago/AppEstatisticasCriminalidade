import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:mobx/mobx.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:shared_preferences/shared_preferences.dart';
import '../Comuns/Urls.dart';
part 'LoginController.g.dart';

class LoginController = LoginControllerBase with _$LoginController;

abstract class LoginControllerBase with Store{

  @observable
  FlutterSecureStorage storage = FlutterSecureStorage();

  @observable
  String email = "";

  @observable
  String nome = "";


  @action
  Future<int> FazerLogin(String email, String senha) async{
    try {
      http.Response response = await http.post(Uri.parse(Urls.UrlLogin),
                                                headers: {
                                                        'Content-type': 'application/json; charset=UTF-8'
                                                },
                                                body: json.encode( {
                                                    "email": email,
                                                    "senha": senha
                                                  })
                                                );
      if(response.statusCode == 200){
        var dadosJson = json.decode(response.body);
        await storage.write(key: "token", value: dadosJson["token"]);
        this.email = dadosJson["email"];
        this.nome = dadosJson["usuario"];
      }
      return response.statusCode;

    }catch(e){
      throw Exception(e);
    }
  }

  @action
  Future<String?> getToken() async {
    final token = await storage.read(key: "token");
    return token;
  }

}
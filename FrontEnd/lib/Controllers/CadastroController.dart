import 'dart:convert';

import 'package:appcrime/Models/Usuario.dart';
import 'package:flutter/material.dart';
import 'package:mobx/mobx.dart';
import 'package:http/http.dart' as http;
import '../Comuns/Urls.dart';
part 'CadastroController.g.dart';

class CadastroController = CadastroControllerBase with _$CadastroController;

abstract class CadastroControllerBase with Store{

  @action
  Future<int?> cadastrar(Usuario usuario, BuildContext context) async {
    final String apiUrl = Urls.UrlCadastrar; // URL da API

    // Corpo da requisição com os dados do formulário
    final Map<String, dynamic> requestBody = {
      'nome': usuario.nome,
      'email': usuario.email,
      'senha': usuario.senha,
      'cpf' : usuario.cpf
    };

    try {
      final response = await http.post(
        Uri.parse(apiUrl),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Accept': 'application/json'
        },
        body: jsonEncode(requestBody),
      );

      if (response.statusCode == 200) {
        final responseData = jsonDecode(response.body);
        if (context.mounted){
          await associarPermissaoUsuario(usuario.email, context);
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(content: Text('Cadastro feito com sucesso')),
          );
        }


      } else {
        // Lidar com erro, exibir mensagem para o usuário
        if (context.mounted){
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(content: Text('Falha ao cadastrar: ${response.body}')),
          );
        }
      }
      return response.statusCode;
    } catch (e) {
      // Lidar com exceções, exibir mensagem para o usuário
      if (context.mounted){
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Erro: $e')),
        );
      }
    }
  }

  @action
  Future<int?> associarPermissaoUsuario(String email, BuildContext context) async {
    const String role = "USER";

    final String apiUrl = "${Urls.UrlAssociarPermissao}/$email/$role";

    try {
      final response = await http.post(
        Uri.parse(apiUrl),
        headers: <String, String>{
          'Content-Type': 'application/json; charset=UTF-8',
          'Accept': 'application/json'
        },
      );
      return response.statusCode;
    } catch (e) {
      if (context.mounted){
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Erro: $e')),
        );
      }
    }
  }

}
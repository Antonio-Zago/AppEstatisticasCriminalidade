// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'LoginController.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$LoginController on LoginControllerBase, Store {
  late final _$storageAtom =
      Atom(name: 'LoginControllerBase.storage', context: context);

  @override
  FlutterSecureStorage get storage {
    _$storageAtom.reportRead();
    return super.storage;
  }

  @override
  set storage(FlutterSecureStorage value) {
    _$storageAtom.reportWrite(value, super.storage, () {
      super.storage = value;
    });
  }

  late final _$emailAtom =
      Atom(name: 'LoginControllerBase.email', context: context);

  @override
  String get email {
    _$emailAtom.reportRead();
    return super.email;
  }

  @override
  set email(String value) {
    _$emailAtom.reportWrite(value, super.email, () {
      super.email = value;
    });
  }

  late final _$nomeAtom =
      Atom(name: 'LoginControllerBase.nome', context: context);

  @override
  String get nome {
    _$nomeAtom.reportRead();
    return super.nome;
  }

  @override
  set nome(String value) {
    _$nomeAtom.reportWrite(value, super.nome, () {
      super.nome = value;
    });
  }

  late final _$FazerLoginAsyncAction =
      AsyncAction('LoginControllerBase.FazerLogin', context: context);

  @override
  Future<int> FazerLogin(String email, String senha) {
    return _$FazerLoginAsyncAction.run(() => super.FazerLogin(email, senha));
  }

  late final _$getTokenAsyncAction =
      AsyncAction('LoginControllerBase.getToken', context: context);

  @override
  Future<String?> getToken() {
    return _$getTokenAsyncAction.run(() => super.getToken());
  }

  @override
  String toString() {
    return '''
storage: ${storage},
email: ${email},
nome: ${nome}
    ''';
  }
}

// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'CadastroController.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$CadastroController on CadastroControllerBase, Store {
  late final _$cadastrarAsyncAction =
      AsyncAction('CadastroControllerBase.cadastrar', context: context);

  @override
  Future<int?> cadastrar(Usuario usuario, BuildContext context) {
    return _$cadastrarAsyncAction.run(() => super.cadastrar(usuario, context));
  }

  late final _$associarPermissaoUsuarioAsyncAction = AsyncAction(
      'CadastroControllerBase.associarPermissaoUsuario',
      context: context);

  @override
  Future<int?> associarPermissaoUsuario(String email, BuildContext context) {
    return _$associarPermissaoUsuarioAsyncAction
        .run(() => super.associarPermissaoUsuario(email, context));
  }

  @override
  String toString() {
    return '''

    ''';
  }
}

// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'RouboController.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$RouboController on RouboControllerBase, Store {
  late final _$descricaoControllerAtom =
      Atom(name: 'RouboControllerBase.descricaoController', context: context);

  @override
  TextEditingController get descricaoController {
    _$descricaoControllerAtom.reportRead();
    return super.descricaoController;
  }

  @override
  set descricaoController(TextEditingController value) {
    _$descricaoControllerAtom.reportWrite(value, super.descricaoController, () {
      super.descricaoController = value;
    });
  }

  late final _$dataControllerAtom =
      Atom(name: 'RouboControllerBase.dataController', context: context);

  @override
  TextEditingController get dataController {
    _$dataControllerAtom.reportRead();
    return super.dataController;
  }

  @override
  set dataController(TextEditingController value) {
    _$dataControllerAtom.reportWrite(value, super.dataController, () {
      super.dataController = value;
    });
  }

  late final _$validacaoDataAtom =
      Atom(name: 'RouboControllerBase.validacaoData', context: context);

  @override
  bool get validacaoData {
    _$validacaoDataAtom.reportRead();
    return super.validacaoData;
  }

  @override
  set validacaoData(bool value) {
    _$validacaoDataAtom.reportWrite(value, super.validacaoData, () {
      super.validacaoData = value;
    });
  }

  late final _$itensSelecionadosAtom =
      Atom(name: 'RouboControllerBase.itensSelecionados', context: context);

  @override
  List<ItemMultiSelect> get itensSelecionados {
    _$itensSelecionadosAtom.reportRead();
    return super.itensSelecionados;
  }

  @override
  set itensSelecionados(List<ItemMultiSelect> value) {
    _$itensSelecionadosAtom.reportWrite(value, super.itensSelecionados, () {
      super.itensSelecionados = value;
    });
  }

  late final _$validacaoItensAtom =
      Atom(name: 'RouboControllerBase.validacaoItens', context: context);

  @override
  bool get validacaoItens {
    _$validacaoItensAtom.reportRead();
    return super.validacaoItens;
  }

  @override
  set validacaoItens(bool value) {
    _$validacaoItensAtom.reportWrite(value, super.validacaoItens, () {
      super.validacaoItens = value;
    });
  }

  late final _$cadastrouBoletimAtom =
      Atom(name: 'RouboControllerBase.cadastrouBoletim', context: context);

  @override
  bool get cadastrouBoletim {
    _$cadastrouBoletimAtom.reportRead();
    return super.cadastrouBoletim;
  }

  @override
  set cadastrouBoletim(bool value) {
    _$cadastrouBoletimAtom.reportWrite(value, super.cadastrouBoletim, () {
      super.cadastrouBoletim = value;
    });
  }

  late final _$dataFormatadaAtom =
      Atom(name: 'RouboControllerBase.dataFormatada', context: context);

  @override
  String get dataFormatada {
    _$dataFormatadaAtom.reportRead();
    return super.dataFormatada;
  }

  @override
  set dataFormatada(String value) {
    _$dataFormatadaAtom.reportWrite(value, super.dataFormatada, () {
      super.dataFormatada = value;
    });
  }

  late final _$tipoBensAtom =
      Atom(name: 'RouboControllerBase.tipoBens', context: context);

  @override
  List<ItemMultiSelect> get tipoBens {
    _$tipoBensAtom.reportRead();
    return super.tipoBens;
  }

  @override
  set tipoBens(List<ItemMultiSelect> value) {
    _$tipoBensAtom.reportWrite(value, super.tipoBens, () {
      super.tipoBens = value;
    });
  }

  late final _$BuscarItensAsyncAction =
      AsyncAction('RouboControllerBase.BuscarItens', context: context);

  @override
  Future<void> BuscarItens(BuildContext context) {
    return _$BuscarItensAsyncAction.run(() => super.BuscarItens(context));
  }

  late final _$ReportarRouboAsyncAction =
      AsyncAction('RouboControllerBase.ReportarRoubo', context: context);

  @override
  Future<int> ReportarRoubo(Roubo roubo, BuildContext context) {
    return _$ReportarRouboAsyncAction
        .run(() => super.ReportarRoubo(roubo, context));
  }

  late final _$RouboControllerBaseActionController =
      ActionController(name: 'RouboControllerBase', context: context);

  @override
  bool validarCampos() {
    final _$actionInfo = _$RouboControllerBaseActionController.startAction(
        name: 'RouboControllerBase.validarCampos');
    try {
      return super.validarCampos();
    } finally {
      _$RouboControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  void limparCampos() {
    final _$actionInfo = _$RouboControllerBaseActionController.startAction(
        name: 'RouboControllerBase.limparCampos');
    try {
      return super.limparCampos();
    } finally {
      _$RouboControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
descricaoController: ${descricaoController},
dataController: ${dataController},
validacaoData: ${validacaoData},
itensSelecionados: ${itensSelecionados},
validacaoItens: ${validacaoItens},
cadastrouBoletim: ${cadastrouBoletim},
dataFormatada: ${dataFormatada},
tipoBens: ${tipoBens}
    ''';
  }
}

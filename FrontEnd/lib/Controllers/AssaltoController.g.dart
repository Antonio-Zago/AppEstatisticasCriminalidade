// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'AssaltoController.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$AssaltoController on AssaltoControllerBase, Store {
  late final _$descricaoControllerAtom =
      Atom(name: 'AssaltoControllerBase.descricaoController', context: context);

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

  late final _$quantidadeAssaltantesAtom = Atom(
      name: 'AssaltoControllerBase.quantidadeAssaltantes', context: context);

  @override
  TextEditingController get quantidadeAssaltantes {
    _$quantidadeAssaltantesAtom.reportRead();
    return super.quantidadeAssaltantes;
  }

  @override
  set quantidadeAssaltantes(TextEditingController value) {
    _$quantidadeAssaltantesAtom.reportWrite(value, super.quantidadeAssaltantes,
        () {
      super.quantidadeAssaltantes = value;
    });
  }

  late final _$dataControllerAtom =
      Atom(name: 'AssaltoControllerBase.dataController', context: context);

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
      Atom(name: 'AssaltoControllerBase.validacaoData', context: context);

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
      Atom(name: 'AssaltoControllerBase.itensSelecionados', context: context);

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
      Atom(name: 'AssaltoControllerBase.validacaoItens', context: context);

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
      Atom(name: 'AssaltoControllerBase.cadastrouBoletim', context: context);

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

  late final _$estavaArmadoAtom =
      Atom(name: 'AssaltoControllerBase.estavaArmado', context: context);

  @override
  bool get estavaArmado {
    _$estavaArmadoAtom.reportRead();
    return super.estavaArmado;
  }

  @override
  set estavaArmado(bool value) {
    _$estavaArmadoAtom.reportWrite(value, super.estavaArmado, () {
      super.estavaArmado = value;
    });
  }

  late final _$dataFormatadaAtom =
      Atom(name: 'AssaltoControllerBase.dataFormatada', context: context);

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
      Atom(name: 'AssaltoControllerBase.tipoBens', context: context);

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

  late final _$tipoArmasAtom =
      Atom(name: 'AssaltoControllerBase.tipoArmas', context: context);

  @override
  List<ItemMultiSelect> get tipoArmas {
    _$tipoArmasAtom.reportRead();
    return super.tipoArmas;
  }

  @override
  set tipoArmas(List<ItemMultiSelect> value) {
    _$tipoArmasAtom.reportWrite(value, super.tipoArmas, () {
      super.tipoArmas = value;
    });
  }

  late final _$tipoArmaAtom =
      Atom(name: 'AssaltoControllerBase.tipoArma', context: context);

  @override
  int get tipoArma {
    _$tipoArmaAtom.reportRead();
    return super.tipoArma;
  }

  @override
  set tipoArma(int value) {
    _$tipoArmaAtom.reportWrite(value, super.tipoArma, () {
      super.tipoArma = value;
    });
  }

  late final _$BuscarItensAsyncAction =
      AsyncAction('AssaltoControllerBase.BuscarItens', context: context);

  @override
  Future<void> BuscarItens(BuildContext context) {
    return _$BuscarItensAsyncAction.run(() => super.BuscarItens(context));
  }

  late final _$BuscarTipoArmasAsyncAction =
      AsyncAction('AssaltoControllerBase.BuscarTipoArmas', context: context);

  @override
  Future<void> BuscarTipoArmas(BuildContext context) {
    return _$BuscarTipoArmasAsyncAction
        .run(() => super.BuscarTipoArmas(context));
  }

  late final _$ReportarAssaltoAsyncAction =
      AsyncAction('AssaltoControllerBase.ReportarAssalto', context: context);

  @override
  Future<int> ReportarAssalto(Assalto assalto, BuildContext context) {
    return _$ReportarAssaltoAsyncAction
        .run(() => super.ReportarAssalto(assalto, context));
  }

  late final _$AssaltoControllerBaseActionController =
      ActionController(name: 'AssaltoControllerBase', context: context);

  @override
  bool validarCampos() {
    final _$actionInfo = _$AssaltoControllerBaseActionController.startAction(
        name: 'AssaltoControllerBase.validarCampos');
    try {
      return super.validarCampos();
    } finally {
      _$AssaltoControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  void limparCampos() {
    final _$actionInfo = _$AssaltoControllerBaseActionController.startAction(
        name: 'AssaltoControllerBase.limparCampos');
    try {
      return super.limparCampos();
    } finally {
      _$AssaltoControllerBaseActionController.endAction(_$actionInfo);
    }
  }

  @override
  String toString() {
    return '''
descricaoController: ${descricaoController},
quantidadeAssaltantes: ${quantidadeAssaltantes},
dataController: ${dataController},
validacaoData: ${validacaoData},
itensSelecionados: ${itensSelecionados},
validacaoItens: ${validacaoItens},
cadastrouBoletim: ${cadastrouBoletim},
estavaArmado: ${estavaArmado},
dataFormatada: ${dataFormatada},
tipoBens: ${tipoBens},
tipoArmas: ${tipoArmas},
tipoArma: ${tipoArma}
    ''';
  }
}
